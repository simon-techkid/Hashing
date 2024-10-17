// Hashing by Simon Field

using Hashing.Provisioning;

namespace Hashing.Verification;

/// <summary>
/// Unifies all classes supporting verifying a hash of an object with another hash.
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public interface IHashChecker<T>
{
    /// <summary>
    /// Verify that the hash of the given <typeparamref name="T"/> data matches the expected hash.
    /// </summary>
    /// <param name="data">Data to be hashed, in format <typeparamref name="T"/>.</param>
    /// <param name="expectedHash">A <see langword="string"/> representing the expected hash for the given <typeparamref name="T"/> data.</param>
    /// <param name="algorithm">The algorithm used to hash the given data of type <typeparamref name="T"/>.</param>
    /// <returns>True, if the calculated hash of the <typeparamref name="T"/> data matches the given expected hash. Otherwise, false.</returns>
    public bool VerifyHash(T data, string expectedHash, IHashingAlgorithm<T> algorithm);
}
