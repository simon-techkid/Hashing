// HashingHandler by Simon Field

using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Interface for encoding <see cref="byte"/>[] to <see cref="string"/> asynchronously.
/// </summary>
public interface IStringEncodingAsync : IStringEncoding
{
    /// <summary>
    /// Converts a <see cref="byte"/>[] to a <see cref="string"/> asynchronously.
    /// </summary>
    /// <param name="bytes">The <see cref="byte"/>[] to convert to a <see cref="string"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation that returns a <see cref="string"/> converted from the <see cref="byte"/>[].</returns>
    public Task<string> ConvertToStringAsync(byte[] bytes);
}
