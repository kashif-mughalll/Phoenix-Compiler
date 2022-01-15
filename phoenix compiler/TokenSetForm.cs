using phoenix_compiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Pheonix
{
    public partial class TokenSetForm : Form
    {
        private List<Token> tokenList;

        public TokenSetForm()
        {
            InitializeComponent();
        }

        private void TokenSetForm_Load(object sender, EventArgs e)
        {
            SelectFormate.Items.Add("Token Set Data");
            SelectFormate.Items.Add("Serial File Data");
            SelectFormate.Items.Add("Log File Data");
            SelectFormate.SelectedItem = "Token Set Data";
        }

        public void ShowTokenSet(List<Token> tokenList)
        {
            this.tokenList = tokenList;
            this.Show();
        }

        public void generateData()
        {
            string append = "";
            foreach (Token T in this.tokenList)
                append += T.ToString() + "\n";
            tokenSetArea.Text = append;
        }

        public void generateDataLogFile()
        {
            tokenSetArea.Text = File.ReadAllText(Utility.logFilePath);
        }

        public void generateDataSerialFile()
        {
            string DATA = File.ReadAllText(Utility.serialFilePath);
            tokenSetArea.Text = "";
            foreach (string line in DATA.Split('\n'))
            {
                if ( line.Length < 2 ) continue;
                string[] tokens = line.Split(':');
                if (tokens.Length > 2)
                {
                    string append = tokens[0] + "\t : \t  " + tokens[1];
                    string[] furtherTokens = tokens[2].Split('%');
                    if (furtherTokens.Length >= 3)
                    {
                        append += "     \t\t\t " + furtherTokens[0] + "   " + furtherTokens[1] + "   " + furtherTokens[2] + "\n";
                        tokenSetArea.Text += append;
                    }
                }
            }
        }

        private void SelectFormate_TextChanged(object sender, EventArgs e)
        {
            FormLabel.Text = SelectFormate.SelectedItem.ToString();
            switch (SelectFormate.SelectedIndex)
            {
                case 0:
                    generateData();
                    break;

                case 1:
                    generateDataSerialFile();
                    break;

                case 2:
                    generateDataLogFile();
                    break;
            }
        }
    }
}
