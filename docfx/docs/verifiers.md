# Verifiers

Verifiers in HashingHandler implement `IHashVerifier<T>` or `IHashVerifierAsync<T>`. Implementers of `IHashVerifierAsync<T>` also implement `IHashVerifier<T>`.

## Variants

### IHashVerifier

`IHashVerifier<T>` is used for accessing hash verifier classes. These classes allow for the verification of data against expected hashes.

### IHashVerifierAsync

`IHashVerifierAsync<T>` allows the asynchronous use of `IHashVerifier<T>`. It implements `IHashVerifier<T>`, so objects capable of asynchronous verification are also able to leverage synchronous methods.
 
### HashVerifierBase

`HashVerifierBase<T>` is the primary base class for implementations of both `IHashVerifierAsync<T>` and `IHashVerifier<T>`, providing methods for both. It provides support for both synchronous and asynchronous hash verification, using `public` methods `bool VerifyHash()` and `Task<bool> VerifyHashAsync()`.

### HashVerifierGeneric

`HashVerifierGeneric<T>` provides a generic implementation of `HashVerifierBase<T>`. It can be constructed with the required `IHashingProvider<T>` and optional `StringComparison` setting for the comparison of the hash strings.

## Examples

If you'd like to provide type-flexible hash verification, use an implementation of `HashVerifierBase<T>` or a `HashVerifierGeneric<T>` rather than making your own implementation of `IHashVerifier<T>` or `IHashVerifierAsync<T>`. Only make your own `IHashVerifier<T>` or `IHashVerifierAsync<T>` if you'd like to use a different string comparison method than [`string.Equals()`](https://learn.microsoft.com/dotnet/api/system.string.equals) for hash strings.

### Implementing `HashVerifierGeneric<T>`

`HashVerifierGeneric<T>` is a non-abstract class implementation of the abstract class `HashVerifierBase<T>`, meaning you can instantiate it and re-use it for verifications of the same data type, `T`.

```
public class MyClass
{
    public static bool VerifyHash(DateTime data, string expectedHash)
    {
        // Create an IHashingProvider<DateTime> called 'provider'.
        
        IHashVerifier<DateTime> verifier = CreateVerifier(provider);

        // Create an IHashingAlgorithm<DateTime> called 'algorithm'.

        // Optionally, create an IStringEncoding called 'encoding' to use for hash byte encoding.
        // Not doing this will interpret the hash calculation as Hexadecimal string by default.

        return verifier.VerifyHash(data, expectedHash, algorithm, encoding) // encoding is an optional parameter.
    }

    // could also return IHashVerifier<DateTime> because HashVerifierGeneric is IHashVerifierAsync.
    private static IHashVerifier<DateTime> CreateVerifier(IHashingProvider<DateTime> provider)
    {
        return new HashVerifierGeneric(provider); // StringComparison is an optional parameter for the constructor.
    }
}
```
