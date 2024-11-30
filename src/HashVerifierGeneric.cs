// HashingHandler by Simon Field

using System;

namespace HashingHandler;

/// <summary>
/// Verifies hashes of objects of type <typeparamref name="T"/> using a given hashing provider.
/// </summary>
/// <typeparam name="T">The type of objects to verify the hashes of.</typeparam>
public class HashVerifierGeneric<T> : HashVerifierBase<T>
{
    private StringComparison UserComparisonMethod { get; }

    /// <summary>
    /// Creates a new instance of <see cref="HashVerifierGeneric{T}"/> with the given hashing provider.
    /// The default string comparison method will be used, <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="provider">The provider for converting this data type to byte array.</param>
    public HashVerifierGeneric(IHashingProvider<T> provider, StringComparison method = DefaultComparisonMethod)
    {
        HashProvider = provider;
        UserComparisonMethod = method;
    }

    protected override IHashingProvider<T> HashProvider { get; }

    protected override StringComparison ComparisonMethod => UserComparisonMethod;
}
