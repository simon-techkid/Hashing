// Hashing by Simon Field

using Hashing.Provisioning;

namespace Hashing.Formats.Byte;

public class ByteHashProvider : IHashingProvider<byte[]>
{
    public byte[] ConvertToBytes(byte[] data) => data;
}
