// Hashing by Simon Field

namespace Hashing.Formats.Stream;

public class StreamHashVerifier : HashVerifierBase<System.IO.Stream>
{
    protected override IHashingProvider<System.IO.Stream> HashProvider => new StreamHashProvider();
}
