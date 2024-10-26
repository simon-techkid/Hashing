// Hashing by Simon Field

namespace Hashing.Formats.String;

public class StringHashVerifier : HashVerifierBase<string>
{
    protected override IHashingProvider<string> HashProvider => new StringHashProvider();
}
