// Hashing by Simon Field

using System.IO.Hashing;

namespace Hashing;

/// <summary>
/// An abstract class to handle hashing using derived classes of <see cref="NonCryptographicHashAlgorithm"/>.
/// </summary>
/// <typeparam name="T">The type of data to be hashed.</typeparam>
public abstract class HashingNonCrypto<T> : IHashingAlgorithm<T>
{
    /// <summary>
    /// Get the specific <see cref="NonCryptographicHashAlgorithm"/> (abstract) implementing class.
    /// </summary>
    /// <returns>An instance of a class derived from <see cref="NonCryptographicHashAlgorithm"/> that can be used for hashing.</returns>
    protected abstract NonCryptographicHashAlgorithm GetAlgorithm();

    public string ComputeHash(T data, IHashingProvider<T> provider)
    {
        byte[] bytes = provider.ConvertToBytes(data);

        NonCryptographicHashAlgorithm algorithm = GetAlgorithm();
        algorithm.Append(bytes);
        byte[] hashBytes = algorithm.GetHashAndReset();

        return StringExtensions.ByteToHex(hashBytes);
    }

}
