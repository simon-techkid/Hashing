// HashingHandler by Simon Field

namespace HashingHandler;

public interface IStringEncoding
{
    /// <summary>
    /// Converts a <see cref="byte"/>[] to a <see cref="string"/>.
    /// </summary>
    /// <param name="bytes">The <see cref="byte"/>[] to convert.</param>
    /// <returns>A <see cref="string"/> representing the <see cref="byte"/>[] <paramref name="bytes"/>.</returns>
    public string ConvertToString(byte[] bytes);
}
