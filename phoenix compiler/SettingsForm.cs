using Compiler_Pheonix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phoenix_compiler
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            StopSyntaxTreeAtFalse.Checked = Utility.StopAtFalse;
            ThrowSyntaxError.Checked = Utility.ThrowSyntaxError;
            SelectionSetEnable.Checked = Utility.EnableSS;
            SyntaxErrorHints.Checked = Utility.SyntaxHints;
            checkBox4.Checked = Utility.EnableSemanticAnalysis;
        }
        

        private void StopSyntaxTreeAtFalse_CheckedChanged(object sender, EventArgs e)
        {
            Utility.StopAtFalse = StopSyntaxTreeAtFalse.Checked;
        }


        private void ThrowSyntaxError_CheckedChanged(object sender, EventArgs e)
        {
            Utility.ThrowSyntaxError = ThrowSyntaxError.Checked;
        }

        private void SelectionSetEnable_CheckedChanged(object sender, EventArgs e)
        {
            Utility.EnableSS = SelectionSetEnable.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Utility.EnableSemanticAnalysis = checkBox4.Checked;
        }

        private void SyntaxErrorHints_CheckedChanged(object sender, EventArgs e)
        {
            Utility.SyntaxHints = SyntaxErrorHints.Checked;
        }
    }
}
