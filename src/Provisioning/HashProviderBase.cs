// Hashing by Simon Field

using System.Security.Cryptography;

namespace Hashing.Provisioning;

/// <summary>
/// Central class supporting creating and verifying hashes for documents of type <typeparamref name="T"/>.
/// The document is converted to a <see langword="byte"/>[] before hashing.
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public abstract class HashProviderBase<T> : IHashProvider<T>
{
    /// <summary>
    /// Convert an object of type <typeparamref name="T"/> to a <see langword="byte"/>[] so that the byte array can serve as the hashed payload.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be converted to <see langword="byte"/>[].</param>
    /// <returns>This document of type <typeparamref name="T"/> as a <see langword="byte"/>[].</returns>
    protected abstract byte[] ConvertToBytes(T data);

    public virtual string ComputeHash(T data)
    {
        byte[] bytes = ConvertToBytes(data);
        byte[] hashBytes = SHA256.HashData(bytes);

        System.Text.StringBuilder builder = new();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
