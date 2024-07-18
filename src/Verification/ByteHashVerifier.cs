// Hashing by Simon Field

using Hashing.Provisioning;

namespace Hashing.Verification;

public class ByteHashVerifier : HashVerifierBase<byte[]>
{
    protected override IHashProvider<byte[]> HashProvider => new ByteHashProvider();
}
