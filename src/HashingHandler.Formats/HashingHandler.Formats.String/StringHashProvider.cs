// Hashing by Simon Field

using System.Text;
using Hashing;

namespace HashingHandler.Formats.String;

public class StringHashProvider(Encoding? encoding = null) : StringHashProviderBase<string>(encoding)
{
    protected override string ConvertToString(string data) => data;
}
