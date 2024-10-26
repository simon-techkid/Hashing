// HashingHandler by Simon Field

namespace HashingHandler.Formats.String;

public class StringHashVerifier : HashVerifierBase<string>
{
    protected override IHashingProvider<string> HashProvider => new StringHashProvider();
}
