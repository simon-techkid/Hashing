// Hashing by Simon Field

using Hashing.Provisioning;
using Hashing.Provisioning.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace Hashing.Verification.Json;

public class JsonHashVerifier : HashVerifierBase<List<JsonDocument>>
{
    protected override IHashProvider<List<JsonDocument>> HashProvider => new JsonHashProvider();
}
