﻿// Logging by Simon Field

using Logging;
using System;

namespace SpotifyGPX.Input;

/// <summary>
/// Interfaces with file import classes supporting verifying the included hashes with the subsequent data.
/// </summary>
public interface IHashVerifier : ILogger<string>
{
    /// <summary>
    /// Verifies whether checksum included in the document matches the document's contents.
    /// </summary>
    /// <returns>True, if the checksum matches. Otherwise, false.</returns>
    bool VerifyHash();

    /// <summary>
    /// Verifies the hash of the file, and prints the result to the console.
    /// </summary>
    void CheckHash()
    {
        // If the object has been disposed, throw an exception.
        ObjectDisposedException.ThrowIf(Disposed, this);

        bool hashVerified = VerifyHash();

        if (hashVerified)
        {
            BCaster.Broadcast($"Hash verification successful for {GetType().FullName}.");
        }
        else
        {
            BCaster.Broadcast($"Hash verification failed for {GetType().FullName}.");
        }
    }

    bool Disposed { get; }
}
