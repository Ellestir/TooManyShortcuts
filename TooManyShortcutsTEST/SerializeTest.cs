using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TooManyShortcuts;

namespace TooManyShortcutsTEST
{
    [TestClass]
    public class SerializeTest
    {
        XMLShortcutList original = new XMLShortcutList(); //Liste mit den zu serialisierenden Objekten
        XMLShortcutList deserialized = new XMLShortcutList(); //Liste für das Ergebnis der Deserialisierung

        //füllt die Listen mit Objekten, die für die einzelnen Tests genutzt werden können
        [TestInitialize]
        public void init()
        {
            original.Shortcuts.Add(new Shortcut { Shorthand = "GGB", Keycombo = "strg+G", Path = "Test\\yolo.exe" });
            original.Shortcuts.Add(new Shortcut { Shorthand = "FFX", Keycombo = "strg+B", Path = "Test\\lmao.exe" });
            original.Shortcuts.Add(new Shortcut { Shorthand = "JKL", Keycombo = "strg+M", Path = "Test\\woopwoop.exe" });
            ListSerializer.Serialize(original, "test.xml");
            ListSerializer.DeSerialize(deserialized, "test.xml");
        }
        
        //Soll testen ob die Shortcuts korrekt serialisiert werden so dass die deserialisierten Objekte exakt die selben Eigenschaften haben
        [TestMethod]
        public void Compare_Obj_1()
        {

            Assert.IsTrue((deserialized.Shortcuts[0].Shorthand == original.Shortcuts[0].Shorthand)
                        && (deserialized.Shortcuts[0].Keycombo == original.Shortcuts[0].Keycombo)
                        && (deserialized.Shortcuts[0].Path == original.Shortcuts[0].Path)); 
            //Assert schlägt fehl sobald auch nur eines der Wertepaare nicht übereinstimmt (etwas unglücklich gelöst aber unter normalen Umständen sollten entweder alle Felder falsch geschrieben worden sein oder keins)
            
        }

        [TestMethod]
        public void Compare_Obj_2()
        {
            Assert.IsTrue((deserialized.Shortcuts[1].Shorthand == original.Shortcuts[1].Shorthand)
                        && (deserialized.Shortcuts[1].Keycombo == original.Shortcuts[1].Keycombo)
                        && (deserialized.Shortcuts[1].Path == original.Shortcuts[1].Path));
        }

        [TestMethod]
        public void Compare_Obj_3()
        {
            Assert.IsTrue((deserialized.Shortcuts[2].Shorthand == original.Shortcuts[2].Shorthand)
                        && (deserialized.Shortcuts[2].Keycombo == original.Shortcuts[2].Keycombo)
                        && (deserialized.Shortcuts[2].Path == original.Shortcuts[2].Path));
        }

    }
}
