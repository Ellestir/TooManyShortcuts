using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TooManyShortcuts
{
    [XmlRoot(ElementName ="ShortcutList")]
    public class XMLShortcutList
    {
        public List<Shortcut> Shortcuts = new List<Shortcut>();

        public bool LaunchOnSystemStartup;

        [XmlIgnore]
        public string Schema = "SCM_Schema.xsd";
    }

    
}
