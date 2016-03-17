﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TooManyShortcuts
{
    [XmlRoot("Shortcutlist")]
    public class XMLShortcutList
    {
        public List<Shortcut> Shortcuts = new List<Shortcut>(); 
        // Settings könnten hier noch rein und in das gleiche XML geschrieben werden
    }

    public static class ListSerializer
    {
        //Schreibt Shortcut-Liste in XML
        public static void Serialize(XMLShortcutList list, string xmlpath)
        {
            // Erstellt eine neue Instanz der XmlSerializer-Klasse für den Typ unserer Listenklasse
            XmlSerializer SerializerObj = new XmlSerializer(typeof(XMLShortcutList));

            // Erstellt eine neue StreamWriter-Instanz um die Daten in eine Datei zu schreiben
            TextWriter WriteFileStream = new StreamWriter(xmlpath);
            
            // Alle Shortcuts werden als einzelne Child-Elemente("Shortcut") von "Shortcuts" geschrieben
            SerializerObj.Serialize(WriteFileStream, list);

            // Aufräumarbeiten
            WriteFileStream.Close();
        }

        //Liest Shortcut-Liste aus XML aus
        public static void DeSerialize(XMLShortcutList list, string xmlpath)
        {
            // Erstellt eine neue Instanz der XmlSerializer-Klasse für den Typ unserer Listenklasse
            XmlSerializer SerializerObj = new XmlSerializer(typeof(XMLShortcutList));
            
            // Erstellt einen neuen FileStream um die Daten zu lesen
            FileStream ReadFileStream = new FileStream(xmlpath, FileMode.Open, FileAccess.Read, FileShare.Read);

            // Deserialisiert das XML-File und erzeugt daraus ein XMLShortcutList-Objekt
            XMLShortcutList LoadedObj = (XMLShortcutList)SerializerObj.Deserialize(ReadFileStream);

            //Überträgt die Shortcut-Liste von dem deserialisierten Objekt in das übergebene XMLShortcutList-Objekt (aktualisiert also die Liste, die bereits verwendet wird)
            list.Shortcuts = LoadedObj.Shortcuts;

            // Aufräumarbeiten
            ReadFileStream.Close();
            
        }
    }
}
