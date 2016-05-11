using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TooManyShortcuts
{
    public static class ListSerializer
    {
        //Schreibt Shortcut-Liste in XML
        public static void Serialize(XMLShortcutList list, string xmlpath)
        {
            // Erstellt eine neue Instanz der XmlSerializer-Klasse für den Typ unserer Listenklasse
            XmlSerializer serializerObj = new XmlSerializer(typeof(XMLShortcutList));

            StringWriter validationStream = new StringWriter();

            serializerObj.Serialize(validationStream, list);
            validationStream.Close();
            string validationData = validationStream.ToString();

            //validiert das bei der Serialisierung entstandene XML gegen das Schema bevor es gespeichert wird
            string validationResult = ValidateXML(validationData, list.SchemaLocation);

            if (validationResult == "ok")
            {
                // Erstellt eine neue StreamWriter-Instanz um die Daten in eine Datei zu schreiben
                TextWriter writeFileStream = new StreamWriter(xmlpath);

                // Alle Shortcuts werden als einzelne Child-Elemente("Shortcut") von "Shortcuts" geschrieben
                serializerObj.Serialize(writeFileStream, list);

                // Aufräumarbeiten
                writeFileStream.Close();
            }
            //Platzhalter um irgendetwas mit der Exception-Message zu tun
        }

        //Liest Shortcut-Liste aus XML aus
        public static void DeSerialize(XMLShortcutList list, string xmlpath)
        {
            if (File.Exists(xmlpath))
            {
                // Erstellt eine neue Instanz der XmlSerializer-Klasse für den Typ unserer Listenklasse
                XmlSerializer serializerObj = new XmlSerializer(typeof(XMLShortcutList));

                // Erstellt einen neuen FileStream um die Daten zu lesen

                FileStream readFileStream = new FileStream(xmlpath, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Deserialisiert das XML-File und erzeugt daraus ein XMLShortcutList-Objekt
                XMLShortcutList loadedObj = (XMLShortcutList)serializerObj.Deserialize(readFileStream);

                //Überträgt die Shortcut-Liste von dem deserialisierten Objekt in das übergebene XMLShortcutList-Objekt (aktualisiert also die Liste, die bereits verwendet wird)
                list.Shortcuts = loadedObj.Shortcuts;

                // Aufräumarbeiten
                readFileStream.Close();
            }
        }
        //Prüft, ob das gegebene XML dem gegebenen Schema entspricht
        public static string ValidateXML(string xml, string schema)
        {

            XDocument xdoc = XDocument.Parse(xml);
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, schema);

            try
            {
                xdoc.Validate(schemas, null);
                return "ok";
            }
            catch (XmlSchemaValidationException e)
            {
                return e.Message;
            }

        }
    }
}
