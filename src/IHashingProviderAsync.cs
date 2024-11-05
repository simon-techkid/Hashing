// HashingHandler by Simon Field

using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Unifies classes supporting the asynchronous conversion of data of type <typeparamref name="T"/> to a <see cref="byte"/>[].
/// </summary>
/// <typeparam name="T">Data type to be converted to a <see cref="byte"/>[].</typeparam>
public interface IHashingProviderAsync<T> : IHashingProvider<T>
{
    /// <summary>
    /// Asynchronously convert an object, <paramref name="data"/>, of type <typeparamref name="T"/> to a <see cref="byte"/>[] to serve as the payload to be hashed.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be converted to <see cref="byte"/>[].</param>
    /// <param name="cancellationToken">A cancellation token allowing the canceling of asynchronous jobs.</param>
    /// <returns>A <see cref="Task"/> representing the conversion of this document of type <typeparamref name="T"/> in the form <see cref="byte"/>[].</returns>
    public Task<byte[]> ConvertToBytesAsync(T data, CancellationToken cancellationToken);
}
