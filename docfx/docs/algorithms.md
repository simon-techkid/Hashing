---
title: algorithms
created: '2024-11-11T00:29:49.195Z'
modified: '2024-11-30T04:44:53.790Z'
---

# Algorithms

## Interfaces and Base Classes

### IHashingAlgorithm

`IHashingAlgorithm<T>` is used for accessing hash algorithm classes. These classes allow the hashing of byte arrays (`byte[]`), producing `string` checksums of the given data.

### IHashingAlgorithmAsync

`IHashingAlgorithmAsync<T>` allows the asynchronous use of `IHashingAlgorithm<T>`. It implements `IHashingAlgorithm<T>`, so objects capable of asynchronous computation are also able to leverage synchronous methods.

### HashingAlgorithmBase

`HashingAlgorithmBase` is the primary base class for implementations of `IHashingAlgorithm` and `IHashingAlgorithmAsync`. It provides support for both synchronous and asynchronous hash computation, using `protected` methods `byte[] ComputeHash()` and `Task<byte[]> ComputeHashAsync()`, as well as synchronous and asynchronous checksum computation of those hashes, using `public` methods `string ComputeHash()` and `Task<string> ComputeHashAsync()`.

### HashingCrypto and HashingNonCrypto

HashingHandler contains base classes for creating hashes using its `HashingCrypto` and `HashingNonCrypto` classes, allowing hash creation using [HashAlgorithm](https://learn.microsoft.com/dotnet/api/system.security.cryptography.hashalgorithm) and [NonCryptographicHashAlgorithm](https://learn.microsoft.com/dotnet/api/system.io.hashing.noncryptographichashalgorithm), respectively.

Both of these classes implement `IHashingAlgorithm<string>` and `IHashingAlgorithmAsync<string>` because they inherit `HashingNonCrypto<string>` and `HashingAlgorithmBase<string>`. This allows you to create common functionality across your program by using the shared methods in different contexts.

#### Getting Started

To get started using `HashingCrypto` and `HashingNonCrypto` abstract classes in your program, you must create a class that implements one of these.

In your class implementing `HashingCrypto` or `HashingNonCrypto`, you must provide a method, `GetAlgorithm()`, that returns an instance of a hashing class (ie. `SHA256` or `XxHash3`) derived from either `HashAlgorithm` or `NonCryptographicHashAlgorithm`, respectively. This instance will then be used by the base, implemented class to create hashes using those algorithms.

See the sample implementations below of each.

## Samples

After creating a class that inherits `IHashingAlgorithm<T>` (including the below samples), you are able to compute hashes for data of type `T`, using the `IHashingAlgorithm<T>.ComputeHash()` method. This method returns a `string` of the hash of the data.

### Implementing `IHashingAlgorithm<T>` and `IHashingAlgorithmAsync<T>`

Below are some examples of classes that implement either `IHashingAlgorithm<T>` or `IHashingAlgorithmAsync<T>`.


#### HashingCrypto Implementing Class Example

```
class SHA256Hasher : HashingCrypto<string> // Implements IHashingAlgorithmAsync, and IHashingAlgorithm as a result.
{
    protected override HashAlgorithm GetAlgorithm()
    {
        return SHA256.Create(); // Returns new SHA256 object
    }
}
```

#### HashingNonCrypto Implementing Class Example

```
class XXH3Hasher(long seed = 0) : HashingNonCrypto<string> // Implements IHashingAlgorithmAsync, and IHashingAlgorithm as a result.
{
    private readonly long _seed = seed; // XxHash3 allows a seed, so we will add seed support to our class

    protected override NonCryptographicHashAlgorithm GetAlgorithm()
    {
        return new XxHash3(_seed);
    }
}
```

#### Create Your Own `IHashingAlgorithm<T>`

To create your own hashing algorithm without asynchronous support, create a class implementing only `IHashingAlgorithm<T>`.

This object does not comply with `IHashingAlgorithmAsync<T>` because it does not have an asynchronous required method `ComputeHashAsync()`.

The below example is a simple XOR hash algorithm:

```
class XORHash : IHashingAlgorithm<string>
{
    // Required function
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

#### Create Your Own `IHashingAlgorithmAsync<T>`

To create your own asynchronous hashing algorithm, create a class implementing `IHashingAlgorithmAsync<T>`. Remember, `IHashingAlgorithmAsync` implements `IHashingAlgorithm`, so you must provide a synchronous implementation for your implementation!

Any class implementing `IHashingAlgorithmAsync<T>` can inherit `HashingAlgorithmBase<T>`. By inheriting `HashingAlgorithmBase<T>`, you make the class an `IHashingAlgorithm<T>` and `IHashingAlgorithmAsync<T>`. 

The below example is an example generic asynchronous hasher.

```
class GenericAsyncHasher : IHashingAlgorithmAsync<string> // can inherit HashingAlgorithmBase<string>, too
{
    private IHashingAlgorithm<string> Hasher { get; }

    public GenericAsyncHasher(IHashingAlgorithm<string> existingHasher)
    {
        Hasher = existingHasher;
    }

    // Required function of IHashingAlgorithmAsync, because it implements IHashingAlgorithm which requires ComputeHash.
    protected override byte[] ComputeHash(byte[] bytes)
    {
        return Hasher.ComputeHash(bytes);
    }

    // Required function when only implementing IHashingAlgorithmAsync
    // Optional function when also inheriting HashingAlgorithmBase
    protected override Task<byte[]> ComputeHashAsync(byte[] bytes, CancellationToken cancellationToken = default)
    {
        //your implementation here...
        throw new NotImplementedException();
    }
}
```

### Working with implementers of `IHashingAlgorithm<T>`

The following types are `IHashingAlgorithm<T>`:

- `HashingAlgorithmBase<T>` - `SHA256Hasher` and `XXH3Hasher` in our example (and optionally, `GenericAsyncHasher`)
- `HashingCrypto<T>` - `SHA256Hasher` in our example
- `HashingNonCrypto<T>` - `XXH3Hasher` in our example
- `IHashingAlgorithmAsync<T>` - `GenericAsyncHasher` in our example
- `IHashingAlgorithm<T>` - `XORHash` in our example

```
IHashingAlgorithm<string> algorithm = new SHA256Hasher();
// do some work...
algorithm = new XXH3Hasher(); // change the algorithm
// do some more work...
algorithm = new XORHash(); // change
// do some more work...
algorithm = new GenericAsyncHasher(algorithm); // change
```

### Working with `IHashingAlgorithmAsync<T>` instances

The following types are `IHashingAlgorithmAsync<T>`:

- `HashingAlgorithmBase<T>` - `SHA256Hasher` and `XXH3Hasher` in our example (and optionally, `GenericAsyncHasher`)
- `HashingCrypto<T>` - `SHA256Hasher` in our example
- `HashingNonCrypto<T>` - `XXH3Hasher` in our example
- `IHashingAlgorithmAsync<T>` - `GenericAsyncHasher` in our example

```
IHashingAlgorithmAsync<string> asyncAlgorithm = new SHA256Hasher();
// do some work...
asyncAlgorithm = new XXH3Hasher(); // change the algorithm
// do some more work...
IHashingAlgorithm<string> xor = new XORHash();
asyncAlgorithm = new GenericAsyncHasher(xor); // change
```

### Creating hashes using `IHashingAlgorithm<T>` instances

After creating the `IHashingAlgorithm<T>` implementing object, you can perform hashing using the methods of `IHashingAlgorithm<T>`.

```
// Create an IHashingProvider<T>, where T matches the type of your IHashingAlgorithm<T>.
// Assume we have instantiated an IHashingProvider<string> called 'provider'
// See the above samples on how to create an IHashingAlgorithm.
// Assume we have instantiated an IHashingAlgorithm<string> called 'algorithm'

string textPayload = "Hello World!";
string hash = algorithm.ComputeHash(textPayload, provider);
```

### Creating hashes using `IHashingAlgorithmAsync<T>` instances

After creating the `IHashingAlgorithmAsync<T>` implementing object, you can perform asynchronous or synchronous hashing using the methods of `IHashingAlgorithmAsync<T>` or `IHashingAlgorithm<T>`, respectively.

```
// Simulated asynchronous method below by using GetAwaiter().GetResult()
string hash = await algorithm.ComputeHashAsync(textPayload, provider);
```

Remember, `IHashingAlgorithmAsync<T>` implements `IHashingAlgorithm<T>`, so you can perform synchronous hashing using an asynchronous hashing capable object using the methods of `IHashingAlgorithm<T>` on an `IHashingAlgorithmAsync<T>`.
