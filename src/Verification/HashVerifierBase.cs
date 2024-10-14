// Hashing by Simon Field

using Hashing.Provisioning.Algorithms;
using Hashing.Provisioning.Providers;
using System;

namespace Hashing.Verification;

public abstract class HashVerifierBase<T> : IHashChecker<T>
{
    protected abstract IHashingProvider<T> HashProvider { get; }

    public bool VerifyHash(T data, string expectedHash, IHashingAlgorithm<T> algorithm)
    {
        string actualHash = algorithm.ComputeHash(data, HashProvider);
        return string.Equals(actualHash, expectedHash, StringComparison.OrdinalIgnoreCase);
    }
}
