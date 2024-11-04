// HashingHandler by Simon Field

using System;

namespace HashingHandler;

/// <summary>
/// Base class for verifying hashes of objects of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of objects being hashed.</typeparam>
public abstract class HashVerifierBase<T> : IHashChecker<T>
{
    /// <summary>
    /// The hashing provider used to convert objects of type <typeparamref name="T"/> to <see cref="byte"/>[].
    /// </summary>
    protected abstract IHashingProvider<T> HashProvider { get; }

    public bool VerifyHash(T data, string expectedHash, IHashingAlgorithm<T> algorithm)
    {
        string actualHash = algorithm.ComputeHash(data, HashProvider);
        return string.Equals(actualHash, expectedHash, StringComparison.OrdinalIgnoreCase);
    }
}
