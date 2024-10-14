// Hashing by Simon Field

namespace Hashing.Provisioning.Providers;

public class ByteHashProvider : IHashingProvider<byte[]>
{
    public byte[] ConvertToBytes(byte[] data) => data;
}
