// HashingHandler by Simon Field

using System;

namespace HashingHandler;

/// <summary>
/// A class containing methods for manipulating <see cref="string"/> objects.
/// </summary>
internal class StringExtensions : IStringEncoding
{
    public string ConvertToString(byte[] data)
    {
        return BitConverter.ToString(data).Replace("-", "");
    }
}
