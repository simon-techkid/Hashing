// Hashing by Simon Field

namespace Hashing;

/// <summary>
/// Interface for classes supporting the verification of data using hashes.
/// </summary>
public interface IHashVerifier
{
    /// <summary>
    /// Verifies whether checksum included in the data matches the dats's contents.
    /// </summary>
    /// <returns>True, if the checksum matches. Otherwise, false.</returns>
    bool VerifyHash();
}
