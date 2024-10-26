// HashingHandler by Simon Field

namespace HashingHandler.Formats.Byte;

public class ByteHashVerifier : HashVerifierBase<byte[]>
{
    protected override IHashingProvider<byte[]> HashProvider => new ByteHashProvider();
}
