using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TooManyShortcuts
{
    [XmlRoot]
    class ShortcutList
    {
        public List<Shortcut> Shortcuts { get; set; }
    }
}
