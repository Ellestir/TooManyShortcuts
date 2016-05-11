using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TooManyShortcuts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TooManyShortcutsTEST
{
    [TestClass]
    public class SerializeValidationTest
    {
        [TestMethod]
        public void uniqueName()
        {
            XMLShortcutList list = new XMLShortcutList();
            list.Shortcuts.Add(new Shortcut { Name = "Dingens1", Shorthand = "GGB", Keycombo = "strg+F", Path = "yolo.exe", Parameters = "-yeah" });
            list.Shortcuts.Add(new Shortcut { Name = "Dingens1", Shorthand = "GGF", Keycombo = "strg+G", Path = "wuff.exe"});
            XmlSerializer serializerObj = new XmlSerializer(typeof(XMLShortcutList));
            StringWriter validationStream = new StringWriter();
            serializerObj.Serialize(validationStream, list);
            validationStream.Close();
            string validationData = validationStream.ToString();
            string validationResult = ListSerializer.ValidateXML(validationData, list.SchemaLocation);
            Assert.IsFalse(validationResult == "ok");
        }

        [TestMethod]
        public void uniqueShorthand()
        {
            XMLShortcutList list = new XMLShortcutList();
            list.Shortcuts.Add(new Shortcut { Name = "Dingens1", Shorthand = "GGB", Keycombo = "strg+F", Path = "yolo.exe", Parameters = "-yeah" });
            list.Shortcuts.Add(new Shortcut { Name = "Dingens2", Shorthand = "GGB", Keycombo = "strg+G", Path = "wuff.exe" });
            XmlSerializer serializerObj = new XmlSerializer(typeof(XMLShortcutList));
            StringWriter validationStream = new StringWriter();
            serializerObj.Serialize(validationStream, list);
            validationStream.Close();
            string validationData = validationStream.ToString();
            string validationResult = ListSerializer.ValidateXML(validationData, list.SchemaLocation);
            Assert.IsFalse(validationResult == "ok");
        }

        [TestMethod]
        public void uniqueKeycombo()
        {
            XMLShortcutList list = new XMLShortcutList();
            list.Shortcuts.Add(new Shortcut { Name = "Dingens1", Shorthand = "GGB", Keycombo = "strg+F", Path = "yolo.exe", Parameters = "-yeah" });
            list.Shortcuts.Add(new Shortcut { Name = "Dingens2", Shorthand = "GGF", Keycombo = "strg+F", Path = "wuff.exe" });
            XmlSerializer serializerObj = new XmlSerializer(typeof(XMLShortcutList));
            StringWriter validationStream = new StringWriter();
            serializerObj.Serialize(validationStream, list);
            validationStream.Close();
            string validationData = validationStream.ToString();
            string validationResult = ListSerializer.ValidateXML(validationData, list.SchemaLocation);
            Assert.IsFalse(validationResult == "ok");
        }
    }
}
