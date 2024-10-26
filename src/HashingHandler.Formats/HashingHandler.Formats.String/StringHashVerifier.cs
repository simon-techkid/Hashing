// Hashing by Simon Field

using Hashing;

namespace HashingHandler.Formats.String;

public class StringHashVerifier : HashVerifierBase<string>
{
    protected override IHashingProvider<string> HashProvider => new StringHashProvider();
}
