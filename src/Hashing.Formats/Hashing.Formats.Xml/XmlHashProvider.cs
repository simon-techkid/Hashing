// Hashing by Simon Field

using Hashing.Provisioning;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hashing.Formats.Xml;

public class XmlHashProvider(Encoding? encoding = null) : StringHashProviderBase<IEnumerable<XElement>>(encoding)
{
    protected override string ConvertToString(IEnumerable<XElement> data)
    {
        return string.Join("", data.Select(data => data.ToString()));
    }
}
