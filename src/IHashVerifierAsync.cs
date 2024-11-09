// HashingHandler by Simon Field

using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Unifies classes supporting the asynchronous verification of a hash of an object of type <typeparamref name="T"/> with another hash.
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public interface IHashVerifierAsync<T> : IHashVerifier<T>
{
    /// <summary>
    /// Asynchronously verify that the hash of the given <paramref name="data"/> of type <typeparamref name="T"/> matches the <paramref name="expectedHash"/>.
    /// </summary>
    /// <param name="data">Data to be hashed, in format <typeparamref name="T"/>.</param>
    /// <param name="expectedHash">A <see cref="string"/> representing the expected hash for the given <paramref name="data"/> of type <typeparamref name="T"/>.</param>
    /// <param name="algorithm">The algorithm used to hash the given data of type <typeparamref name="T"/>.</param>
    /// <param name="cancellationToken">A cancellation token allowing the canceling of asynchronous jobs.</param>
    /// <returns></returns>
    public Task<bool> VerifyHashAsync(T data, string expectedHash, IHashingAlgorithm<T> algorithm, CancellationToken cancellationToken = default);
}
