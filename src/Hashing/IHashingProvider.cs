// Hashing by Simon Field

namespace Hashing;

/// <summary>
/// Unifies all classes supporting the conversion of custom data of type <typeparamref name="T"/> to a byte array for hashing.
/// </summary>
/// <typeparam name="T">Custom data type to be converted.</typeparam>
public interface IHashingProvider<T>
{
    /// <summary>
    /// Convert an object of type <typeparamref name="T"/> to a <see langword="byte"/>[] so that the byte array can serve as the hashed payload.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be converted to <see langword="byte"/>[].</param>
    /// <returns>This document of type <typeparamref name="T"/> as a <see langword="byte"/>[].</returns>
    public byte[] ConvertToBytes(T data);
}
