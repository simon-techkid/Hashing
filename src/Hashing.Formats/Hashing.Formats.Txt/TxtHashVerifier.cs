// Hashing by Simon Field

using Hashing.Provisioning;
using Hashing.Verification;

namespace Hashing.Formats.Txt;

public class TxtHashVerifier : HashVerifierBase<string?[]>
{
    protected override IHashingProvider<string?[]> HashProvider => new TxtHashProvider();
}
