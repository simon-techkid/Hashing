// Hashing by Simon Field

using Hashing.Provisioning;
using Hashing.Provisioning.Xml;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Hashing.Verification.Xml;

public class XmlHashVerifier : HashVerifierBase<IEnumerable<XElement>>
{
    protected override IHashProvider<IEnumerable<XElement>> HashProvider => new XmlHashProvider();
}
