---
title: providers
created: '2024-11-11T00:29:49.196Z'
modified: '2024-11-30T05:13:51.343Z'
---

# Providers

Providers in HashingHandler implement `IHashingProvider<T>` or `IHashingProviderAsync<T>`. Implementers of `IHashingProviderAsync<T>` also implement `IHashingProvider<T>`.

## Variants

### IHashingProvider

`IHashingProvider<T>` is used when an object can convert the data to be hashed of type `T` to a byte array (`byte[]`), so that the byte array can serve as a common type in all hash operations.

### IHashingProviderAsync

`IHashingProviderAsync<T>` is offered when an object of type `T` can be converted to a byte array asynchronously. `IHashingProviderAsync<T>` implements `IHashingProvider<T>`, so objects that are capable of handling asynchronous conversions are also able to leverage the synchronous methods of `IHashingProvider<T>`.

## Examples

### Implementing `IHashingProvider<T>` and `IHashingProviderAsync<T>`

Below are some examples of classes that implement either `IHashingProvider<T>` or `IHashingProviderAsync<T>`.

#### String - `IHashingProvider<string>`

HashingHandler contains a built-in base class to serve as an `IHashingProvider<T>` for `string` types, `StringHashProviderBase<T>`. Implementers of `StringHashProviderBase<T>` must define how to convert the data of type `T` to a `string`. The base class, `StringHashProviderBase` handles conversion of this string (using the method `ConvertToString`) to bytes, using a byte encoding.

Adding the below class to your program, which implements `StringHashProviderBase`, will provide a structure for hashing `string` instances.

```
class StringProvider : StringHashProviderBase<string>
{
    // constructing StringHashProviderBase with an Encoding instance will decode any given strings using that encoding.
    // Doing this is equivalent to setting the below field, HashedDataEncoding.
    public StringProvider(Encoding? encoding) : base(encoding)
    {

    }

    protected override string ConvertToString(string data)
    {
        return data; // Already string, no conversion necessary
    }
    
    // Below is not a required field, but overriding it in your class will allow you to use other byte encodings than the default, UTF8.
    protected override Encoding HashedDataEncoding => Encoding.UTF16
}
```

Because this `StringProvider` class inherits `StringHashProviderBase`, it also implements `IHashingProvider`.

#### DateTime - `IHashingProvider<DateTime>`

`DateTime` is a different data type, so we must create an `IHashingProvider<DateTime>` for converting instances of it to `byte[]`.

```
class DateTimeProvider : IHashingProvider<DateTime>
{
    public byte[] ConvertToBytes(DateTime data)
    {
        // Convert DateTime to byte[] using BitConverter
        return BitConverter.GetBytes(dateTime.Ticks);
    }
}
```

#### Stream - `IHashingProviderAsync<Stream>`

In some cases, you may want to convert hashable data types to `byte[]` asynchronously. This can be done with implementers of `IHashingProviderAsync<T>`.

```
class StreamProvider : IHashingProviderAsync<Stream> // also IHashingProvider<Stream>
{
    public Task<byte[]> ConvertToBytesAsync(Stream data, CancellationToken cancellationToken = default)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            await data.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }

    // We must provide a ConvertToBytes() implementation for IHashingProvider<Stream>.
    public byte[] ConvertToBytes(Stream data)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            data.CopyTo(memoryStream); // use CopyTo instead of CopyToAsync
            return memoryStream.ToArray();
        }
    }
}
```

### Working with `IHashingProvider<T>` instances

To create a provider for converting the `T` data type to `byte[]` for hashing later, construct one of the example `IHashingProvider<T>` classes.

```
IHashingProvider<string> providerString = new StringProvider(null); // Encoding can be provided to StringHashProviderBase inheritors.
IHashingProvider<DateTime> providerDate = new DateTimeProvider();
IHashingProvider<Stream> providerStream = new StreamProvider();
```

You now have a few `IHashingProvider<T>` instances that can be passed to the corresponding `IHashingAlgorithm<T>` to create a hash.

```
// Assume we have initialized relevant IHashingProvider and IHashingAlgorithm instances above.
// IHashingAlgorithm<string> stringAlgo
// IHashingAlgorithm<DateTime> dateAlgo
// IHashingAlgorithm<Stream> streamAlgo

string testString = "Hello World!";
string testHash = stringAlgo.ComputeHash(testPayload, providerString);
Console.WriteLine(testHash);

DateTime testDate = DateTime.Now;
testHash = dateAlgo.ComputeHash(testDate, providerDate);
Console.WriteLine(testHash);

Stream testStream = GetStream(); // filler
testHash = streamAlgo.ComputeHash(testStream, providerStream);
Console.WriteLine(testHash);
```

### Working with `IHashingAlgorithmAsync<T>` instances

You can compute the hash of types `T` on another thread, if you've got an `IHashingAlgorithmAsync<T>` in an `async` method.

```
// testStream payload as above
IHashingProviderAsync<Stream> providerStreamAsync = new StreamProvider();
testHash = await streamAlgo.ComputeHashAsync(testStream, providerStreamAsync);
```
