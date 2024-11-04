// HashingHandler by Simon Field

using System.Security.Cryptography;

namespace HashingHandler;

/// <summary>
/// An abstract class to handle hashing using derived classes of <see cref="HashAlgorithm"/>.
/// </summary>
/// <typeparam name="T">The type of data to be hashed.</typeparam>
public abstract class HashingCrypto<T> : HashingAlgorithmBase<T>
{
    /// <summary>
    /// Get the specific <see cref="HashAlgorithm"/> (abstract) implementing class.
    /// </summary>
    /// <returns>An instance of a class derived from <see cref="HashAlgorithm"/> that can be used for hashing.</returns>
    protected abstract HashAlgorithm GetAlgorithm();

    protected override byte[] ComputeHash(byte[] bytes)
    {
        using HashAlgorithm hasher = GetAlgorithm();
        byte[] hashBytes = hasher.ComputeHash(bytes);

        return hashBytes;
    }
}
