// Hashing by Simon Field

using Hashing;

namespace HashingHandler.Formats.Byte;

public class ByteHashProvider : IHashingProvider<byte[]>
{
    public byte[] ConvertToBytes(byte[] data) => data;
}
