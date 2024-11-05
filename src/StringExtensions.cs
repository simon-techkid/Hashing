// HashingHandler by Simon Field

using System;

namespace HashingHandler;

/// <summary>
/// A class containing methods for manipulating <see cref="string"/> objects.
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Convert a <see cref="byte"/>[] to a <see cref="string"/> of hexadecimal characters.
    /// </summary>
    /// <param name="data">The data to be converted.</param>
    /// <returns>A <see cref="string"/> of hexadecimals representing the given <paramref name="data"/>.</returns>
    internal static string ByteToHex(byte[] data)
    {
        return BitConverter.ToString(data).Replace("-", "");
    }
}
