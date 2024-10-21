// Hashing by Simon Field

namespace Hashing;

/// <summary>
/// Unifies classes supporting the verifying of a hash of an object of type <typeparamref name="T"/> with another hash.
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public interface IHashChecker<T>
{
    /// <summary>
    /// Verify that the hash of the given <paramref name="data"/> of type <typeparamref name="T"/> matches the <paramref name="expectedHash"/>.
    /// </summary>
    /// <param name="data">Data to be hashed, in format <typeparamref name="T"/>.</param>
    /// <param name="expectedHash">A <see cref="string"/> representing the expected hash for the given <paramref name="data"/> of type <typeparamref name="T"/>.</param>
    /// <param name="algorithm">The algorithm used to hash the given data of type <typeparamref name="T"/>.</param>
    /// <returns>True, if the calculated hash of the data of type <typeparamref name="T"/> matches the <paramref name="expectedHash"/>. Otherwise, false.</returns>
    public bool VerifyHash(T data, string expectedHash, IHashingAlgorithm<T> algorithm);
}
