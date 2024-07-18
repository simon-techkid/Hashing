// Hashing by Simon Field

namespace Hashing.Provisioning;

/// <summary>
/// Unifies all classes supporting returning a hash of an object (as a string).
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public interface IHashProvider<T>
{
    /// <summary>
    /// Compute a checksum hash for the given <typeparamref name="T"/> data.
    /// </summary>
    /// <param name="data">Data to be hashed, in format <typeparamref name="T"/>.</param>
    /// <returns>A <see langword="string"/> representing a checksum for the given <typeparamref name="T"/> data.</returns>
    string ComputeHash(T data);
}
