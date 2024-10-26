// Hashing by Simon Field

using Hashing;

namespace HashingHandler.Formats.Byte;

public class ByteHashVerifier : HashVerifierBase<byte[]>
{
    protected override IHashingProvider<byte[]> HashProvider => new ByteHashProvider();
}
