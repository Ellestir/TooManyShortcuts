using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TooManyShortcuts
{
    class ShortcutSerializer
    {
        XmlSerializer SerializerObj = new XmlSerializer(typeof(Shortcut));
        
        public void SerializeList (ShortcutList list)
        {
            var xmlSerializer = new XmlSerializer(typeof(ShortcutList));
            var stringBuilder = new StringBuilder();
            var xmlTextWriter = XmlTextWriter.Create(stringBuilder,
                new XmlWriterSettings { NewLineChars = "\r\n", Indent = true });
            xmlSerializer.Serialize(xmlTextWriter, list);
            var finalXml = stringBuilder.ToString();
        }

        public void DeSerializeList (ShortcutList list)
        {
            var xmlSerializer = new XmlSerializer(typeof(ShortcutList));
            var xmlReader = XmlReader.Create(new StringReader("Shortcuts.xml"));
            var deserializedOrder = (ShortcutList)xmlSerializer.Deserialize(xmlReader);

           
        }
    }
}
