// Hashing by Simon Field

using Hashing.Provisioning.Providers;
using Hashing.Provisioning.Providers.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace Hashing.Verification.Verifiers.Json;

public class JsonHashVerifier : HashVerifierBase<List<JsonDocument>>
{
    protected override IHashingProvider<List<JsonDocument>> HashProvider => new JsonHashProvider();
}
