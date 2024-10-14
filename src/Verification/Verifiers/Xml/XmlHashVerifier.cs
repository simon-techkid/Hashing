// Hashing by Simon Field

using Hashing.Provisioning.Providers;
using Hashing.Provisioning.Providers.Xml;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Hashing.Verification.Verifiers.Xml;

public class XmlHashVerifier : HashVerifierBase<IEnumerable<XElement>>
{
    protected override IHashingProvider<IEnumerable<XElement>> HashProvider => new XmlHashProvider();
}
