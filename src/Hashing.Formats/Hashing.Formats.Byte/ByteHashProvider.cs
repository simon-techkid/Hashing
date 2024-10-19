// Hashing by Simon Field

namespace Hashing.Formats.Byte;

public class ByteHashProvider : IHashingProvider<byte[]>
{
    public byte[] ConvertToBytes(byte[] data) => data;
}
