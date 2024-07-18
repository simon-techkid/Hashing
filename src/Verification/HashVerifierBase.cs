// Hashing by Simon Field

using Hashing.Provisioning;
using System;

namespace Hashing.Verification;

public abstract class HashVerifierBase<T> : IHashChecker<T>
{
    protected abstract IHashProvider<T> HashProvider { get; }

    public virtual bool VerifyHash(T data, string expectedHash)
    {
        string actualHash = HashProvider.ComputeHash(data);
        return string.Equals(actualHash, expectedHash, StringComparison.OrdinalIgnoreCase);
    }
}
