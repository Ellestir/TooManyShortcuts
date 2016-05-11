using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TooManyShortcuts
{
    [XmlRoot(ElementName = "ShortcutList")]
    public class XMLShortcutList
    {
        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = XmlSchema.InstanceNamespace)]
        public string SchemaLocation = "SCM_Schema.xsd";

        public List<Shortcut> Shortcuts = new List<Shortcut>();
    }


    
}
