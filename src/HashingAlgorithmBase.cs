// HashingHandler by Simon Field

using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Provides a base for algorithms that can calculate a hash of an object of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of object being hashed.</typeparam>
public abstract class HashingAlgorithmBase<T> : IHashingAlgorithm<T>
{
    /// <summary>
    /// Compute a hash of type <see cref="byte"/>[] given the data <paramref name="bytes"/> of type <see cref="byte"/>[].
    /// </summary>
    /// <param name="bytes">The given data to hash.</param>
    /// <returns>A <see cref="byte"/>[] representing the hash of the data <paramref name="bytes"/>.</returns>
    protected abstract byte[] ComputeHash(byte[] bytes);

    public string ComputeHash(T data, IHashingProvider<T> provider)
    {
        byte[] bytes = provider.ConvertToBytes(data);
        byte[] hashBytes = ComputeHash(bytes);
        return StringExtensions.ByteToHex(hashBytes);
    }
}
