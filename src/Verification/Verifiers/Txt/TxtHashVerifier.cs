// Hashing by Simon Field

using Hashing.Provisioning.Providers;
using Hashing.Provisioning.Providers.Txt;

namespace Hashing.Verification.Verifiers.Txt;

public class TxtHashVerifier : HashVerifierBase<string?[]>
{
    protected override IHashingProvider<string?[]> HashProvider => new TxtHashProvider();
}
