// HashingHandler by Simon Field

using System;
using System.Threading;
using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Base class for verifying hashes of objects of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of objects being hashed.</typeparam>
public abstract class HashVerifierBase<T> : IHashVerifierAsync<T>
{
    /// <summary>
    /// The hashing provider used to convert objects of type <typeparamref name="T"/> to <see cref="byte"/>[].
    /// </summary>
    protected abstract IHashingProvider<T> HashProvider { get; }

    /// <summary>
    /// The method used for comparing the actual hash with the expected hash.
    /// The default is <see cref="DefaultComparisonMethod"/>.
    /// </summary>
    protected virtual StringComparison ComparisonMethod => DefaultComparisonMethod;

    /// <summary>
    /// The default string comparison method used for comparing the actual hash with the expected hash.
    /// </summary>
    public const StringComparison DefaultComparisonMethod = StringComparison.OrdinalIgnoreCase;

    public bool VerifyHash(T data, string expectedHash, IHashingAlgorithm<T> algorithm, IStringEncoding? encoding = null)
    {
        string actualHash = algorithm.ComputeHash(data, HashProvider, encoding);
        return string.Equals(actualHash, expectedHash, ComparisonMethod);
    }

    public Task<bool> VerifyHashAsync(T data, string expectedHash, IHashingAlgorithm<T> algorithm, CancellationToken cancellationToken = default, IStringEncoding? encoding = null)
    {
        return Task.Run(() => AsyncHashVerification(data, expectedHash, algorithm, cancellationToken, encoding), cancellationToken);
    }

    private async Task<bool> AsyncHashVerification(T data, string expectedHash, IHashingAlgorithm<T> algorithm, CancellationToken cancellationToken, IStringEncoding? encoding)
    {
        string actualHash;
        bool result;

        if (algorithm is IHashingAlgorithmAsync<T> asyncAlgorithm)
        {
            actualHash = await asyncAlgorithm.ComputeHashAsync(data, HashProvider, cancellationToken, encoding);
        }
        else
        {
            actualHash = algorithm.ComputeHash(data, HashProvider);
        }

        result = string.Equals(actualHash, expectedHash, ComparisonMethod);

        return result;
    }
}
