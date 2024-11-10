# Algorithms

Algorithms in HashingHandler implement IHashingAlgorithm or IHashingAlgorithmAsync. Implementers of IHashingAlgorithmAsync also implement IHashingAlgorithm. IHashingAlgorithm provides synchronous hashing algorithm computation, and IHashingAlgorithmAsync provides both synchronous and asynchronous computation support.

`HashingAlgorithmBase` is the primary base class for implementations of `IHashingAlgorithm` and `IHashingAlgorithmAsync`. It provides support for both synchronous and asynchronous hash computation, using `protected` methods `byte[] ComputeHash()` and `Task<byte[]> ComputeHashAsync()`, as well as synchronous and asynchronous checksum computation of those hashes, using `public` methods `string ComputeHash()` and `Task<string> ComputeHashAsync()`.

## Variants

### IHashingAlgorithm

`IHashingAlgorithm<T>` is used for accessing hash algorithm classes. These classes allow the hashing of byte arrays (`byte[]`), producing `string` checksums of the given data.

### IHashingAlgorithmAsync

`IHashingAlgorithmAsync<T>` allows the asynchronous use of `IHashingAlgorithm<T>`. It implements `IHashingAlgorithm<T>`, so objects capable of asynchronous computation are also able to leverage synchronous methods.

## HashingCrypto and HashingNonCrypto

HashingHandler contains base classes for creating hashes using its `HashingCrypto` and `HashingNonCrypto` classes, allowing hash creation using [HashAlgorithm](https://learn.microsoft.com/dotnet/api/system.security.cryptography.hashalgorithm) and [NonCryptographicHashAlgorithm](https://learn.microsoft.com/dotnet/api/system.io.hashing.noncryptographichashalgorithm), respectively.

Both of these classes implement `IHashingAlgorithm<string>` and `IHashingAlgorithmAsync<string>` because they inherit `HashingNonCrypto<string>` and `HashingAlgorithmBase<string>`. This allows you to create common functionality across your program by using the shared methods in different contexts.

### Getting Started

To get started using `HashingCrypto` and `HashingNonCrypto` abstract classes in your program, you must create a class that implements one of these. Below are samples that allow calculation of SHA256 and XXH3 hashes using both `HashAlgorithm` and `NonCryptographicHashAlgorithm` abstract classes.

In your class implementing `HashingCrypto` or `HashingNonCrypto`, you must provide a method, `GetAlgorithm()`, that returns an instance of a hashing class (ie. `SHA256` or `XxHash3`) derived from either `HashAlgorithm` or `NonCryptographicHashAlgorithm`, respectively. This instance will then be used by the base, implemented class to create hashes using those algorithms.

See the sample implementations below of each.

## Samples

After creating a class that inherits `IHashingAlgorithm<T>` (including the below samples), you are able to compute hashes for data of type `T`, using the `IHashingAlgorithm<T>.ComputeHash()` method. This method returns a `string` of the hash of the data.

#### HashingCrypto

```
class SHA256Hasher : HashingCrypto<string>
{
    protected override HashAlgorithm GetAlgorithm()
    {
        return SHA256.Create(); // Returns new SHA256 object
    }
}
```

To create a hash using the SHA256 algorithm, construct this `SHA256Hasher` class.

It can be cast to `IHashingAlgorithm`:
```
IHashingAlgorithm<string> sha256 = new SHA256Hasher();
```

It can also be cast to `IHashingAlgorithmAsync` for asynchronous use, because `HashingCrypto` implements it.
```
IHashingAlgorithmAsync<string> sha256Async = new SHA256Hasher();
```

#### HashingNonCrypto

```
class XXH3Hasher(long seed = 0) : HashingNonCrypto<string>
{
    private readonly long _seed = seed; // XxHash3 allows a seed, so we will add seed support to our class

    protected override NonCryptographicHashAlgorithm GetAlgorithm()
    {
        return new XxHash3(_seed);
    }
}
```

To create a hash using the XXH3 algorithm, construct this `XXH3Hasher` class.

It can be cast to `IHashingAlgorithm`:
```
IHashingAlgorithm<string> xxh3 = new XXH3Hasher();
```

It can also be cast to `IHashingAlgorithmAsync` for asynchronous use, because `HashingNonCrypto` implements it.
```
IHashingAlgorithmAsync<string> xxh3Async = new XXH3Hasher();
```

#### Create Your Own

To create your own hashing algorithm, create a class implementing `IHashingAlgorithm` or `IHashingAlgorithmAsync`. Remember, `IHashingAlgorithmAsync` implements `IHashingAlgorithm`, so you must provide a synchronous implementation for it!

I've chosen to inherit `HashingAlgorithmBase<T>`, because it provides both asynchronous and synchronous support in the base class. The below example provides a synchronous implementation.

By inheriting `HashingAlgorithmBase`, you make this `XORHash` class an `IHashingAlgorithm<T>` and `IHashingAlgorithmAsync<T>`. 

The below example is a simple XOR hash algorithm:

```
class XORHash : HashingAlgorithmBase<object>
{
    protected override byte[] ComputeHash(byte[] bytes)
    {
        // Specify the length of the payload to be hashed.
        int payloadLength = bytes.Length; // Let's hash the entire payload.

        // Specify the length of the returned hash.
        int hashLength = 8; // 8 bytes, 16 characters

        // Initialize result array to hold the hash of specified length
        byte[] result = new byte[hashLength];

        // Perform XOR on the bytes, distributing across each position in result
        for (int i = 0; i < payloadLength; i++)
        {
            result[i % hashLength] ^= bytes[i];
        }

        return result;
    }    
}
```

To create a hash using this sample algorithm, construct this `XORHash` class.

It can be cast to `IHashingAlgorithm`:
```
IHashingAlgorithm<object> xor = new XORHash();
```

It can also be cast to `IHashingAlgorithmAsync` for asynchronous use, because `HashingAlgorithmBase` implements it.
```
IHashingAlgorithmAsync<object> xor = new XORHash();
```

Because we didn't override `HashingAlgorithmBase.ComputeHashAsync()` in the above sample implementation, any calls to `xor.ComputeHashAsync()` will use the default implementation, a `Task.Run()` of the synchronous implementation, `ComputeHash()`. If you'd like to create a specific asynchronous implementation, override `ComputeHashAsync()`.

### Conclusion

After creating the `IHashingAlgorithm<T>` or `IHashingAlgorithmAsync<T>` implementing object, you can perform hashing using the methods of `IHashingAlgorithm<T>` or `IHashingAlgorithmAsync<T>`, respectively.

```
// Create an IHashingProvider<T>, where T matches the type of your IHashingAlgorithm<T>.
// Assume we have instantiated an IHashingProvider<string> called 'provider'
// See the above samples on how to create an IHashingAlgorithm.
// Assume we have instantiated an IHashingAlgorithm<string> called 'algorithm'

string textPayload = "Hello World!";
return algorithm.ComputeHash(textPayload, provider);
```

We can also do it asynchronously, if our `algorithm` instance is `IHashingAlgorithmAsync<string>`

```
// Simulated asynchronous method below by using GetAwaiter().GetResult()
return algorithm.ComputeHashAsync(textPayload, provider).GetAwaiter().GetResult();
```

Remember, `IHashingAlgorithmAsync<T>` implements `IHashingAlgorithm<T>`, so you can perform synchronous hashing using an asynchronous hashing capable object using the methods of `IHashingAlgorithm<T>` on an `IHashingAlgorithmAsync<T>`.