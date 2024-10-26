// HashingHandler by Simon Field

namespace HashingHandler.Formats.Byte;

public class ByteHashProvider : IHashingProvider<byte[]>
{
    public byte[] ConvertToBytes(byte[] data) => data;
}
