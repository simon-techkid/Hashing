// HashingHandler by Simon Field

using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Base class for hashing algorithms.
/// </summary>
/// <typeparam name="T">The type of objects being hashed.</typeparam>
public abstract class HashingAlgorithmBase<T> : IHashingAlgorithmAsync<T>
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

    public string ComputeHash(T data, IHashingProvider<T> provider, IStringEncoding? encoding = null)
    {
        encoding ??= new StringExtensions();

        byte[] bytes = provider.ConvertToBytes(data);
        byte[] hashBytes = ComputeHash(bytes);
        return encoding.ConvertToString(hashBytes);
    }

    public Task<string> ComputeHashAsync(T data, IHashingProvider<T> provider, CancellationToken cancellationToken = default, IStringEncoding? encoding = null)
    {
        return Task.Run(() => AsyncHashComputation(data, provider, cancellationToken, encoding), cancellationToken);
    }

    private async Task<string> AsyncHashComputation(T data, IHashingProvider<T> provider, CancellationToken cancellationToken, IStringEncoding? encoding)
    {
        encoding ??= new StringExtensions();

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
        return encoding.ConvertToString(hashBytes);
    }
}
