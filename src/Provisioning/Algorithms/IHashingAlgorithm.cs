// Hashing by Simon Field

using Hashing.Provisioning.Providers;

namespace Hashing.Provisioning.Algorithms;

/// <summary>
/// Unifies all classes supporting returning a hash of an object (as a string).
/// </summary>
/// <typeparam name="T">The type of the object being hashed.</typeparam>
public interface IHashingAlgorithm<T>
{
    /// <summary>
    /// Compute a checksum (<see langword="string"/>) hash for the given <typeparamref name="T"/> data.
    /// </summary>
    /// <param name="data">An object of type <typeparamref name="T"/> to be hashed to a string.</param>
    /// <param name="provider">An <see cref="IHashingProvider{T}"/> that provides access to data of type <typeparamref name="T"/>.</param>
    /// <returns>A <see langword="string"/> representation of <paramref name="data"/>.</returns>
    public abstract string ComputeHash(T data, IHashingProvider<T> provider);
}
