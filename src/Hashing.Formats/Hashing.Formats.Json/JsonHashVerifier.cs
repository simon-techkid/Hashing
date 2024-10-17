// Hashing by Simon Field

using Hashing.Provisioning;
using Hashing.Verification;
using System.Collections.Generic;
using System.Text.Json;

namespace Hashing.Formats.Json;

public class JsonHashVerifier : HashVerifierBase<List<JsonDocument>>
{
    protected override IHashingProvider<List<JsonDocument>> HashProvider => new JsonHashProvider();
}
