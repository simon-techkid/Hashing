// Hashing by Simon Field

using System.Security.Cryptography;
using System.Text;

namespace Hashing.Provisioning;

/// <summary>
/// An abstract class to handle hashing using derived classes of <see cref="HashAlgorithm"/>.
/// </summary>
/// <typeparam name="T">The type of data to be hashed.</typeparam>
public abstract class HashingCrypto<T> : IHashingAlgorithm<T>
{
    /// <summary>
    /// Get the specific <see cref="HashAlgorithm"/> (abstract) implementing class.
    /// </summary>
    /// <returns>An instance of a class derived from <see cref="HashAlgorithm"/> that can be used for hashing.</returns>
    protected abstract HashAlgorithm GetAlgorithm();

    public string ComputeHash(T data, IHashingProvider<T> provider)
    {
        byte[] bytes = provider.ConvertToBytes(data);
        byte[] hashBytes = GetHash(bytes);

        StringBuilder builder = new();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

    private byte[] GetHash(byte[] inputBytes)
    {
        using HashAlgorithm algorithm = GetAlgorithm();
        return algorithm.ComputeHash(inputBytes);
    }

}
