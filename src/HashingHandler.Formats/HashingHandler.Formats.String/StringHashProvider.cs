// Hashing by Simon Field

using System.Text;

namespace Hashing.Formats.String;

public class StringHashProvider(Encoding? encoding = null) : StringHashProviderBase<string>(encoding)
{
    protected override string ConvertToString(string data) => data;
}
