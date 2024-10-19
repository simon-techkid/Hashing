// Hashing by Simon Field

namespace Hashing.Formats.Byte;

public class ByteHashVerifier : HashVerifierBase<byte[]>
{
    protected override IHashingProvider<byte[]> HashProvider => new ByteHashProvider();
}
