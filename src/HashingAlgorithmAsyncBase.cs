// HashingHandler by Simon Field

using System.Threading.Tasks;
using System.Threading;

namespace HashingHandler;

/// <summary>
/// Provides a base for algorithms that can calculate a hash of an object of type <typeparamref name="T"/> asynchronously.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class HashingAlgorithmAsyncBase<T> : HashingAlgorithmBase<T>, IHashingAlgorithmAsync<T>
{
    /// <summary>
    /// Gets an asynchronous hash computation job that returns a hash of type <see cref="byte"/>[] given the data <paramref name="bytes"/> of type <see cref="byte"/>[].
    /// </summary>
    /// <param name="bytes">The given data to hash.</param>
    /// <param name="cancellationToken">A cancellation token allowing the canceling of asynchronous jobs.</param>
    /// <returns>A <see cref="Task"/> representing the hash computation that returns a hash of type <see cref="byte"/>[] given the data <paramref name="bytes"/>.</returns>
    protected virtual Task<byte[]> ComputeHashAsync(byte[] bytes, CancellationToken cancellationToken = default) => Task.Run(() => ComputeHash(bytes), cancellationToken);

    public Task<string> ComputeHashAsync(T data, IHashingProvider<T> provider, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => AsyncHashComputation(data, provider, cancellationToken), cancellationToken);
    }

    private async Task<string> AsyncHashComputation(T data, IHashingProvider<T> provider, CancellationToken cancellationToken)
    {
        byte[] bytes;

        if (provider is IHashingProviderAsync<T> asyncProvider)
        {
            bytes = await asyncProvider.ConvertToBytesAsync(data, cancellationToken);
        }
        else
        {
            bytes = provider.ConvertToBytes(data);
        }

        byte[] hashBytes = await ComputeHashAsync(bytes, cancellationToken);
        return StringExtensions.ByteToHex(hashBytes);
    }
}
