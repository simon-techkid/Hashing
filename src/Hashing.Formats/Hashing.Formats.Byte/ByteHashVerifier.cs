// Hashing by Simon Field

using Hashing.Provisioning;
using Hashing.Verification;

namespace Hashing.Formats.Byte;

public class ByteHashVerifier : HashVerifierBase<byte[]>
{
    protected override IHashingProvider<byte[]> HashProvider => new ByteHashProvider();
}
