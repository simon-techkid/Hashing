// Hashing by Simon Field

using System.IO;

namespace Hashing.Formats.File;

public class FileHashVerifier : HashVerifierBase<FileStream>
{
    protected override IHashingProvider<FileStream> HashProvider => new FileHashProvider();
}
