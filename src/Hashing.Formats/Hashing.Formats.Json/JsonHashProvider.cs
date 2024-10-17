// Hashing by Simon Field

using Hashing.Provisioning;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Hashing.Formats.Json;

public class JsonHashProvider(Encoding? encoding = null) : StringHashProviderBase<List<JsonDocument>>(encoding)
{
    protected override string ConvertToString(List<JsonDocument> data)
    {
        return string.Join("", data.Select(document => document.RootElement.ToString()));
    }
}
