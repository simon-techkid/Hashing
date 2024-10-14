// Hashing by Simon Field

using Hashing.Provisioning.Providers;
using System.Security.Cryptography;
using System.Text;

namespace Hashing.Provisioning.Algorithms;

public class HashAlgorithmSha256<T> : IHashingAlgorithm<T>
{
    public string ComputeHash(T data, IHashingProvider<T> provider)
    {
        byte[] bytes = provider.ConvertToBytes(data);
        byte[] hashBytes = SHA256.HashData(bytes);

        StringBuilder builder = new();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
