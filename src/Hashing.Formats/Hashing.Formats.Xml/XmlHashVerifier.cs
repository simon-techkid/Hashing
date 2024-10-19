// Hashing by Simon Field

using System.Collections.Generic;
using System.Xml.Linq;

namespace Hashing.Formats.Xml;

public class XmlHashVerifier : HashVerifierBase<IEnumerable<XElement>>
{
    protected override IHashingProvider<IEnumerable<XElement>> HashProvider => new XmlHashProvider();
}
