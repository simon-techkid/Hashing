// Hashing by Simon Field

using Hashing.Provisioning;
using Hashing.Provisioning.Txt;

namespace Hashing.Verification.Txt;

public class TxtHashVerifier : HashVerifierBase<string?[]>
{
    protected override IHashProvider<string?[]> HashProvider => new TxtHashProvider();
}
