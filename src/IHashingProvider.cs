// HashingHandler by Simon Field

namespace HashingHandler;

/// <summary>
/// Unifies classes supporting the conversion of data of type <typeparamref name="T"/> to a <see cref="byte"/>[].
/// </summary>
/// <typeparam name="T">Data type to be converted to a <see cref="byte"/>[].</typeparam>
public interface IHashingProvider<T>
{
    /// <summary>
    /// Convert an object, <paramref name="data"/>, of type <typeparamref name="T"/> to a <see cref="byte"/>[] to serve as the payload to be hashed.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be converted to <see cref="byte"/>[].</param>
    /// <returns>This document of type <typeparamref name="T"/> in the form <see cref="byte"/>[].</returns>
    public byte[] ConvertToBytes(T data);
}
