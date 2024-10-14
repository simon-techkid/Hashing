using Hashing.Provisioning.Providers;
using System.IO;

namespace Hashing.Verification.Verifiers;

public class FileHashVerifier : HashVerifierBase<FileStream>
{
    protected override IHashingProvider<FileStream> HashProvider => new FileHashProvider();
}
