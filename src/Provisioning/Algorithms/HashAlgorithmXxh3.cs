// Hashing by Simon Field

using Hashing.Provisioning.Providers;
using System;
using System.IO.Hashing;

namespace Hashing.Provisioning.Algorithms;

public class HashAlgorithmXxh3<T> : IHashingAlgorithm<T>
{
    public string ComputeHash(T data, IHashingProvider<T> provider)
    {
        byte[] bytes = provider.ConvertToBytes(data);

        XxHash3 xxh3 = new();
        xxh3.Append(bytes);
        byte[] hashBytes = xxh3.GetHashAndReset();

        return Convert.ToHexString(hashBytes).ToLower();
    }
}
