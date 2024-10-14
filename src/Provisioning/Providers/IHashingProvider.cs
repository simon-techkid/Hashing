// Hashing by Simon Field

namespace Hashing.Provisioning.Providers;

public interface IHashingProvider<T>
{
    /// <summary>
    /// Convert an object of type <typeparamref name="T"/> to a <see langword="byte"/>[] so that the byte array can serve as the hashed payload.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be converted to <see langword="byte"/>[].</param>
    /// <returns>This document of type <typeparamref name="T"/> as a <see langword="byte"/>[].</returns>
    public byte[] ConvertToBytes(T data);
}
