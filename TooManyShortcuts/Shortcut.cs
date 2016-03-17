using System;

namespace TooManyShortcuts
{
    //Grundgerüst, Verweis auf die Icons fehlt noch, evtl. noch Name oder ID
    [Serializable()]
    public class Shortcut
    {
        private string shorthand;

        public string Shorthand
        {
            get { return shorthand; }
            set { shorthand = value; }
        }

        private string keycombo;

        public string Keycombo
        {
            get { return keycombo; }
            set { keycombo = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

    }
}
