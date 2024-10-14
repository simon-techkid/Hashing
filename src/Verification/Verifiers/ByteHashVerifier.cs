// Hashing by Simon Field

using Hashing.Provisioning.Providers;

namespace Hashing.Verification.Verifiers;

public class ByteHashVerifier : HashVerifierBase<byte[]>
{
    protected override IHashingProvider<byte[]> HashProvider => new ByteHashProvider();
}
