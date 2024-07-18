// Hashing by Simon Field

namespace Hashing.Provisioning;

public class ByteHashProvider : HashProviderBase<byte[]>
{
    protected override byte[] ConvertToBytes(byte[] data)
    {
        return data;
    }
}
