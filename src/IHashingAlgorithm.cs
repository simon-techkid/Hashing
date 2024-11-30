// HashingHandler by Simon Field

namespace HashingHandler;

/// <summary>
/// Unifies classes supporting returning a hash of an object of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the object to be hashed.</typeparam>
public interface IHashingAlgorithm<T>
{
    /// <summary>
    /// Compute a checksum (<see cref="string"/>) hash for the given data of type <typeparamref name="T"/>.
    /// If the provided <paramref name="encoding"/> is null, the hash will be given in hexadecimal format.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be hashed.</param>
    /// <param name="provider">An <see cref="IHashingProvider{T}"/> that provides access to data of type <typeparamref name="T"/> as a <see cref="byte"/>[].</param>
    /// <param name="encoding">An <see cref="IStringEncoding"/> representing the conversion method of the hash from <see cref="byte"/>[] to <see cref="string"/>. Default: Hexadecimal string.</param>
    /// <returns>A <see cref="string"/> representation of <paramref name="data"/>.</returns>
    public string ComputeHash(T data, IHashingProvider<T> provider, IStringEncoding? encoding = null);
}
