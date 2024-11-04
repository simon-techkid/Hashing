// HashingHandler by Simon Field

using System.Text;

namespace HashingHandler;

/// <summary>
/// Central class supporting stringifying objects of type <typeparamref name="T"/> prior to being hashed.
/// The document is converted to a <see cref="string"/> before it is converted to a <see cref="byte"/>[] and hashed.
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public abstract class StringHashProviderBase<T>(Encoding? encoding = null) : IHashingProvider<T>
{
    /// <summary>
    /// Convert an object of type <typeparamref name="T"/> to a <see cref="string"/> so that the string can serve as the hashed payload.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be hashed.</param>
    /// <returns>The object as a string.</returns>
    protected abstract string ConvertToString(T data);

    /// <summary>
    /// The encoding of the document of type <typeparamref name="T"/> as a string to be hashed.
    /// Default value: <see cref="Encoding.UTF8"/>, override to change.
    /// </summary>
    protected virtual Encoding HashedDataEncoding { get; } = encoding ?? Encoding.UTF8;

    public byte[] ConvertToBytes(T data)
    {
        string serializedData = ConvertToString(data);
        return HashedDataEncoding.GetBytes(serializedData);
    }
}
