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
        }
        

        private void StopSyntaxTreeAtFalse_CheckedChanged(object sender, EventArgs e)
        {
            Utility.StopAtFalse = StopSyntaxTreeAtFalse.Checked;
        }
    }
}
