// HashingHandler by Simon Field

using System.IO;
using System.IO.Hashing;
using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// An abstract class to handle hashing using derived classes of <see cref="NonCryptographicHashAlgorithm"/>.
/// </summary>
/// <typeparam name="T">The type of data to be hashed.</typeparam>
public abstract class HashingNonCrypto<T> : HashingAlgorithmBase<T>
{
    /// <summary>
    /// Get the specific <see cref="NonCryptographicHashAlgorithm"/> (abstract) implementing class.
    /// </summary>
    /// <returns>An instance of a class derived from <see cref="NonCryptographicHashAlgorithm"/> that can be used for hashing.</returns>
    protected abstract NonCryptographicHashAlgorithm GetAlgorithm();

    protected override byte[] ComputeHash(byte[] bytes)
    {
        NonCryptographicHashAlgorithm algorithm = GetAlgorithm();
        algorithm.Append(bytes);
        byte[] hashBytes = algorithm.GetHashAndReset();

        return hashBytes;
    }

    protected override Task<byte[]> ComputeHashAsync(byte[] bytes, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            NonCryptographicHashAlgorithm algorithm = GetAlgorithm();
            using MemoryStream stream = new(bytes);

            await algorithm.AppendAsync(stream, cancellationToken);
            return algorithm.GetHashAndReset();
        });
    }
}
