// Logging by Simon Field

namespace Hashing.Verification;

/// <summary>
/// Interfaces with file import classes supporting verifying the included hashes with the subsequent data.
/// </summary>
public interface IHashVerifier
{
    /// <summary>
    /// Verifies whether checksum included in the document matches the document's contents.
    /// </summary>
    /// <returns>True, if the checksum matches. Otherwise, false.</returns>
    bool VerifyHash();

    bool Disposed { get; }
}
