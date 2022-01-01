using System.Windows.Forms;

namespace Compiler_Pheonix
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RunBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.viewTokenSet = new System.Windows.Forms.Button();
            this.viewSyntaxTreeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CodeArea = new ICSharpCode.TextEditor.TextEditorControl();
            this.debugWindow = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.settingsBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunBtn
            // 
            this.RunBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunBtn.Location = new System.Drawing.Point(649, 8);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(55, 28);
            this.RunBtn.TabIndex = 1;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(710, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 28);
            this.button2.TabIndex = 0;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // viewTokenSet
            // 
            this.viewTokenSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewTokenSet.Enabled = false;
            this.viewTokenSet.Location = new System.Drawing.Point(9, 551);
            this.viewTokenSet.Name = "viewTokenSet";
            this.viewTokenSet.Size = new System.Drawing.Size(112, 23);
            this.viewTokenSet.TabIndex = 0;
            this.viewTokenSet.Text = "View Token Set";
            this.viewTokenSet.UseVisualStyleBackColor = true;
            this.viewTokenSet.Click += new System.EventHandler(this.viewTokenSet_Click);
            // 
            // viewSyntaxTreeBtn
            // 
            this.viewSyntaxTreeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewSyntaxTreeBtn.Enabled = false;
            this.viewSyntaxTreeBtn.Location = new System.Drawing.Point(129, 551);
            this.viewSyntaxTreeBtn.Name = "viewSyntaxTreeBtn";
            this.viewSyntaxTreeBtn.Size = new System.Drawing.Size(118, 23);
            this.viewSyntaxTreeBtn.TabIndex = 0;
            this.viewSyntaxTreeBtn.Text = "View Syntax Tree";
            this.viewSyntaxTreeBtn.UseVisualStyleBackColor = true;
            this.viewSyntaxTreeBtn.Click += new System.EventHandler(this.viewSyntaxTreeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code Area\r\n";
            // 
            // CodeArea
            // 
            this.CodeArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeArea.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CodeArea.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Auto;
            this.CodeArea.IsReadOnly = false;
            this.CodeArea.Location = new System.Drawing.Point(12, 52);
            this.CodeArea.Name = "CodeArea";
            this.CodeArea.Size = new System.Drawing.Size(758, 399);
            this.CodeArea.TabIndex = 2;
            this.CodeArea.TextChanged += new System.EventHandler(this.CodeArea_TextChanged_1);
            // 
            // debugWindow
            // 
            this.debugWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugWindow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.debugWindow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugWindow.Location = new System.Drawing.Point(-2, 435);
            this.debugWindow.Name = "debugWindow";
            this.debugWindow.ReadOnly = true;
            this.debugWindow.Size = new System.Drawing.Size(814, 110);
            this.debugWindow.TabIndex = 0;
            this.debugWindow.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Location = new System.Drawing.Point(-4, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1879, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // settingsBTN
            // 
            this.settingsBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsBTN.Location = new System.Drawing.Point(683, 551);
            this.settingsBTN.Name = "settingsBTN";
            this.settingsBTN.Size = new System.Drawing.Size(87, 23);
            this.settingsBTN.TabIndex = 11;
            this.settingsBTN.Text = "Settings";
            this.settingsBTN.UseVisualStyleBackColor = true;
            this.settingsBTN.Click += new System.EventHandler(this.settingsBTN_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(779, 578);
            this.Controls.Add(this.settingsBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.debugWindow);
            this.Controls.Add(this.CodeArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewSyntaxTreeBtn);
            this.Controls.Add(this.viewTokenSet);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.RunBtn);
            this.MinimumSize = new System.Drawing.Size(691, 539);
            this.Name = "MainForm";
            this.Text = "Pheonix Compiler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button viewTokenSet;
        public System.Windows.Forms.Button viewSyntaxTreeBtn;
        private System.Windows.Forms.Label label1;
        private ICSharpCode.TextEditor.TextEditorControl CodeArea;
        private System.Windows.Forms.RichTextBox debugWindow;
        private System.Windows.Forms.Label label2;
        public Button settingsBTN;
    }
}

