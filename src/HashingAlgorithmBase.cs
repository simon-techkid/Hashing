// HashingHandler by Simon Field

using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

public abstract class HashingAlgorithmBase<T> : IHashingAlgorithm<T>, IHashingAlgorithmAsync<T>
{
    /// <summary>
    /// Compute a hash of type <see cref="byte"/>[] given the data <paramref name="bytes"/> of type <see cref="byte"/>[].
    /// </summary>
    /// <param name="bytes">The given data to hash.</param>
    /// <returns>A <see cref="byte"/>[] representing the hash of the data <paramref name="bytes"/>.</returns>
    protected abstract byte[] ComputeHash(byte[] bytes);

    /// <summary>
    /// Gets an asynchronous hash computation job that returns a hash of type <see cref="byte"/>[] given the data <paramref name="bytes"/> of type <see cref="byte"/>[].
    /// </summary>
    /// <param name="bytes">The given data to hash.</param>
    /// <param name="cancellationToken">A cancellation token allowing the canceling of asynchronous jobs.</param>
    /// <returns>A <see cref="Task"/> representing the hash computation that returns a hash of type <see cref="byte"/>[] given the data <paramref name="bytes"/>.</returns>
    protected virtual Task<byte[]> ComputeHashAsync(byte[] bytes, CancellationToken cancellationToken = default) => Task.Run(() => ComputeHash(bytes), cancellationToken);

    public string ComputeHash(T data, IHashingProvider<T> provider)
    {
        byte[] bytes = provider.ConvertToBytes(data);
        byte[] hashBytes = ComputeHash(bytes);
        return StringExtensions.ByteToHex(hashBytes);
    }

    public async Task<string> ComputeHashAsync(T data, IHashingProvider<T> provider, CancellationToken cancellationToken = default)
    {
        byte[] bytes;

        if (provider is IHashingProviderAsync<T> asyncProvider)
        {
            bytes = await asyncProvider.ConvertToBytes(data, cancellationToken);
        }
        else
        {
            bytes = provider.ConvertToBytes(data);
        }

        byte[] hashBytes = await ComputeHashAsync(bytes, cancellationToken);
        return StringExtensions.ByteToHex(hashBytes);
    }
}
