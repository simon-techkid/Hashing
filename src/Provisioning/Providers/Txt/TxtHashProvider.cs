// Hashing by Simon Field

using System.Text;

namespace Hashing.Provisioning.Providers.Txt;

public class TxtHashProvider(Encoding? encoding = null) : StringHashProviderBase<string?[]>(encoding)
{
    protected override string ConvertToString(string?[] data)
    {
        return string.Join("", data);
    }
}