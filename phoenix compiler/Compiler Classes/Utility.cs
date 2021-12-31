using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Pheonix
{
    static public class Utility
    {
        
        static public readonly string serialFilePath = Directory.GetCurrentDirectory() + @"\serialFile.txt";
        static public readonly string logFilePath = Directory.GetCurrentDirectory() + @"\LogFile.txt";
        static public readonly string dataFilePath = Directory.GetCurrentDirectory() + @"\Lib\data.js";
        static public readonly string HTMLFilePath = Directory.GetCurrentDirectory() + @"\Lib\index.html";
        static public readonly string LibDirPath = Directory.GetCurrentDirectory() + @"\Lib";
        static public readonly string ResoucesFolder = @"D:\C# Projects\phoenix compiler\phoenix compiler\TextGen\Resources";   // Static path implementatio required

        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
