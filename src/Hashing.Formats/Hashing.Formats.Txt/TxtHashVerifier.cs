// Hashing by Simon Field

namespace Hashing.Formats.Txt;

public class TxtHashVerifier : HashVerifierBase<string?[]>
{
    protected override IHashingProvider<string?[]> HashProvider => new TxtHashProvider();
}
