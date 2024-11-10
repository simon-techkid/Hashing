# Providers

Providers in HashingHandler implement `IHashingProvider<T>` or `IHashingProviderAsync<T>`. Implementers of `IHashingProviderAsync<T>` also implement `IHashingProvider<T>`.

## Variants

### IHashingProvider

`IHashingProvider<T>` is used when an object can convert the data to be hashed of type `T` to a byte array (`byte[]`), so that the byte array can serve as a common type in all hash operations.

### IHashingProviderAsync

`IHashingProviderAsync<T>` is offered when an object of type `T` can be converted to a byte array asynchronously. `IHashingProviderAsync<T>` implements `IHashingProvider<T>`, so objects that are capable of handling asynchronous conversions are also able to leverage the synchronous methods of `IHashingProvider<T>`.

## Examples

You can find several examples of data types that you may want to create hashes for.

### Strings

HashingHandler contains a built-in base class to serve as an `IHashingProvider<T>` for `string` types, `StringHashProviderBase<T>`. Implementers of `StringHashProviderBase<T>` must define how to convert the data of type `T` to a `string`. The base class, `StringHashProviderBase` handles conversion of this string (using the method `ConvertToString`) to bytes, using a byte encoding.

Adding the below class to your program, which implements `StringHashProviderBase`, will provide a structure for hashing `string` instances.

```
class StringProvider : StringHashProviderBase<string>
{
    protected override string ConvertToString(string data)
    {
        return data; // Already string, no conversion necessary
    }
    
    // Below is not a required field, but overriding it in your class will allow you to use other byte encodings than the default, UTF8.
    protected override Encoding HashedDataEncoding => Encoding.UTF16
}
```

Because this `StringProvider` class inherits `StringHashProviderBase`, it also implements `IHashingProvider`.

To create a provider for converting the `string` data type to `byte[]` for hashing later, construct the example `StringProvider` class.

```
IHashingProvider<string> provider = new StringProvider();
```

You now have an `IHashingProvider<string>` that can be passed to an `IHashingAlgorithm<string>` to create a hash.

```
// Assume we have initialized the provider as well as an IHashingAlgorithm<string> above.
// The IHashingProvider<string> instance is called 'provider'
// The IHashingAlgorithm<string> instance is called 'algorithm'

string testPayload = "Hello World!";
string testHash = algorithm.ComputeHash(testPayload, provider);
Console.WriteLine(testHash);
```

We can compute the hash on another thread, if you've got an `IHashingAlgorithmAsync<string>`. Let's call the instance of the algorithm `algorithm`.

```
string testHash = algorithm.ComputeHashAsync(testPayload, provider).GetAwaiter().GetResult();
```