using Compiler_Pheonix;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phoenix_compiler.TextGen
{
    static class TextGen
    {
        private static TextEditorControl CodeArea;

        public static void Init(TextEditorControl _CodeArea)
        {
            string Data = "import { * } from \"./Package\";\n\n";
            Data += "void myFunc(){";
            Data += "\n   int A = 78;";
            Data += "\n   str D = \"This is a String\";";
            Data += "\n}\n\n";
            Data += "##  $$$$$$$$$$$ This is a comment $$$$$$$$$$$$$$";

            CodeArea = _CodeArea;
            CodeArea.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                       
            CodeArea.Text = Data;
            setHighLightnings();
        }

        private static void setHighLightnings()
        {
            FileSyntaxModeProvider fsmProvider; 
            if (Directory.Exists(Utility.ResoucesFolder))
            {
                fsmProvider = new FileSyntaxModeProvider(Utility.ResoucesFolder); // Create new provider with the highlighting directory.
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider); // Attach to the text editor.
                CodeArea.SetHighlighting("Java"); // Activate the highlighting, use the name from the SyntaxDefinition node.
            }
            else
            {
                MessageBox.Show("Text Gen Error Directory not found!");
            }            
        }

    }
}
