// HashingHandler by Simon Field

using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Unifies classes supporting returning a <see cref="Task"/> to hash of an object of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of object being hashed.</typeparam>
public interface IHashingAlgorithmAsync<T> : IHashingAlgorithm<T>
{
    /// <summary>
    /// Get a <see cref="Task"/> representing the hash computation of data <paramref name="data"/> of type <typeparamref name="T"/>.
    /// If the provided <paramref name="encoding"/> is null, the hash will be given in hexadecimal format.
    /// </summary>
    /// <param name="data">The data to hash.</param>
    /// <param name="provider">The data interpreter.</param>
    /// <param name="cancellationToken">A cancellation token allowing the canceling of asynchronous jobs.</param>
    /// <param name="encoding">An <see cref="IStringEncoding"/> representing the conversion method of the hash from <see cref="byte"/>[] to <see cref="string"/>. Default: Hexadecimal string.</param>
    /// <returns>A <see cref="Task"/> including the hash computation job.</returns>
    public Task<string> ComputeHashAsync(T data, IHashingProvider<T> provider, CancellationToken cancellationToken = default, IStringEncoding? encoding = null);
}
