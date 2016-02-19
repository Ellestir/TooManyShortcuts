using System;

using System.Drawing;



namespace TooManyShortcuts
{
   public  class ImportIcon
    {
        public Icon ExtractAssociatedIconEx(string path) {
          Icon ico = Icon.ExtractAssociatedIcon(path);
           return ico; 
        }
  
    }
}
