﻿using phoenix_compiler;
using phoenix_compiler.TextGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Pheonix
{
    public partial class MainForm : Form
    {
        
        private TokenSetForm tokenSetForm;
        List<Token> tokenList = new List<Token>();
        private SettingsForm settings;

        public MainForm()
        {
            InitializeComponent();
        }
        

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextGen.Init(CodeArea);            
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            debugWindow.Text = "";
            Thread.Sleep(300);
            AppendText(debugWindow, "Generating token list ....\n", Color.Black);
            try { tokenList = GenerateTokens.Generate(CodeArea.Text.Trim()); }
            catch(LexicalError E)
            {
                AppendText(debugWindow, "[Lexical Error] token doesn't meet language specification at \nline number : "+E.line+"\ntoken : \""+E.token+"\"\n", Color.Red);
                viewTokenSet.Enabled = true;
                return;
            }
            AppendText(debugWindow, "[Lexical Error] No Lexical error found. \n", Color.Green);
            viewTokenSet.Enabled = true;
            viewSyntaxTreeBtn.Enabled = true;
            RunBtn.Enabled = false;

            // Syntax Error Checking //

            try
            {
                bool result = SyntaxAnalyzer.Start(tokenList);
                if (result) AppendText(debugWindow, "[Syntax Error] No syntax error found. \n", Color.Green);
                else
                {
                    AppendText(debugWindow, "[Syntax Error] syntax error at un specified line number \n", Color.Red);
                    return;
                }
            }
            catch (ArgumentOutOfRangeException E)
            {
                AppendText(debugWindow, "[Internal Error] Argument out of bound internal error.\n"+E.ToString()+"\n", Color.Red);
                return;
            }

            AppendText(debugWindow, "\n        [Successful] Build Successful. \n\n", Color.DarkGreen,false);
        }

        private void viewTokenSet_Click(object sender, EventArgs e)
        {
            tokenSetForm = new TokenSetForm();
            tokenSetForm.ShowTokenSet(tokenList);
        }
                

        private void viewSyntaxTreeBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Utility.LibDirPath))
            {
                MessageBox.Show("Syntax lib not available");
                return;
            }

            string Data = File.ReadAllText(Utility.serialFilePath);
            string text = "var Data = `"+Data+"`;";
            File.WriteAllText(Utility.dataFilePath, text);
            Thread.Sleep(500);
            System.Diagnostics.Process.Start(Utility.HTMLFilePath);
        } 
                    


        public void AppendText(RichTextBox box, string text, Color color,bool flag = true)
        {
            if (flag)
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = Color.Navy;
                box.AppendText("  >>  ");
                box.SelectionColor = box.ForeColor;
            }

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CodeArea.Text = "";
        }


        private void CodeArea_TextChanged_1(object sender, EventArgs e)
        {
            RunBtn.Enabled = true;
            viewSyntaxTreeBtn.Enabled = false;
            viewTokenSet.Enabled = false;
        }

        private void settingsBTN_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }
    }
}
