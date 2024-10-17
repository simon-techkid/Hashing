// Hashing by Simon Field

using Hashing.Provisioning;
using System.Text;

namespace Hashing.Formats.Txt;

public class TxtHashProvider(Encoding? encoding = null) : StringHashProviderBase<string?[]>(encoding)
{
    protected override string ConvertToString(string?[] data)
    {
        return string.Join("", data);
    }
}
