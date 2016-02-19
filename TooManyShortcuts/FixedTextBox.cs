/*
 * Created by SharpDevelop.
 * User: r401-fobi1
 * Date: 03.12.2015
 * Time: 09:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;



// Problematik: Eine Textbox die auch die Shortcuts STRG + R etc aufnehmen kann da diese sonst bei einer normalen Textbox nicht möglich war
class FixedTextBox : TextBox {
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
        if (keyData == (Keys.Control | Keys.R) ||
            keyData == (Keys.Control | Keys.L) ||
            keyData == (Keys.Control | Keys.E) ||
            keyData == (Keys.Control | Keys.J)) return false;
        return base.ProcessCmdKey(ref msg, keyData);
    }
}
