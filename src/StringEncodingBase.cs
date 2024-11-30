// HashingHandler by Simon Field

using System.Threading.Tasks;

namespace HashingHandler;

/// <summary>
/// Base class for encoding <see cref="byte"/>[] to <see cref="string"/>.
/// </summary>
public abstract class StringEncodingBase : IStringEncodingAsync
{
    public abstract string ConvertToString(byte[] bytes);

    public virtual Task<string> ConvertToStringAsync(byte[] bytes) => Task.Run(() => ConvertToString(bytes));
}
