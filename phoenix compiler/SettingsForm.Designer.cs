namespace phoenix_compiler
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SelectionSetEnable = new System.Windows.Forms.CheckBox();
            this.StopSyntaxTreeAtFalse = new System.Windows.Forms.CheckBox();
            this.ThrowSyntaxError = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SyntaxErrorHints = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toggle settings true or false";
            // 
            // SelectionSetEnable
            // 
            this.SelectionSetEnable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectionSetEnable.AutoSize = true;
            this.SelectionSetEnable.Checked = true;
            this.SelectionSetEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectionSetEnable.ForeColor = System.Drawing.Color.SlateGray;
            this.SelectionSetEnable.Location = new System.Drawing.Point(20, 45);
            this.SelectionSetEnable.Name = "SelectionSetEnable";
            this.SelectionSetEnable.Size = new System.Drawing.Size(125, 17);
            this.SelectionSetEnable.TabIndex = 1;
            this.SelectionSetEnable.Text = "Selection Set Enable";
            this.SelectionSetEnable.UseVisualStyleBackColor = true;
            this.SelectionSetEnable.CheckedChanged += new System.EventHandler(this.SelectionSetEnable_CheckedChanged);
            // 
            // StopSyntaxTreeAtFalse
            // 
            this.StopSyntaxTreeAtFalse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StopSyntaxTreeAtFalse.AutoSize = true;
            this.StopSyntaxTreeAtFalse.Checked = true;
            this.StopSyntaxTreeAtFalse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StopSyntaxTreeAtFalse.ForeColor = System.Drawing.Color.SlateGray;
            this.StopSyntaxTreeAtFalse.Location = new System.Drawing.Point(20, 70);
            this.StopSyntaxTreeAtFalse.Name = "StopSyntaxTreeAtFalse";
            this.StopSyntaxTreeAtFalse.Size = new System.Drawing.Size(149, 17);
            this.StopSyntaxTreeAtFalse.TabIndex = 2;
            this.StopSyntaxTreeAtFalse.Text = "Stop Syntax Tree At False";
            this.StopSyntaxTreeAtFalse.UseVisualStyleBackColor = true;
            this.StopSyntaxTreeAtFalse.CheckedChanged += new System.EventHandler(this.StopSyntaxTreeAtFalse_CheckedChanged);
            // 
            // ThrowSyntaxError
            // 
            this.ThrowSyntaxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ThrowSyntaxError.AutoSize = true;
            this.ThrowSyntaxError.Checked = true;
            this.ThrowSyntaxError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThrowSyntaxError.ForeColor = System.Drawing.Color.SlateGray;
            this.ThrowSyntaxError.Location = new System.Drawing.Point(231, 70);
            this.ThrowSyntaxError.Name = "ThrowSyntaxError";
            this.ThrowSyntaxError.Size = new System.Drawing.Size(116, 17);
            this.ThrowSyntaxError.TabIndex = 3;
            this.ThrowSyntaxError.Text = "Throw Syntax Error";
            this.ThrowSyntaxError.UseVisualStyleBackColor = true;
            this.ThrowSyntaxError.CheckedChanged += new System.EventHandler(this.ThrowSyntaxError_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Enabled = false;
            this.checkBox4.ForeColor = System.Drawing.Color.SlateGray;
            this.checkBox4.Location = new System.Drawing.Point(231, 45);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(110, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Sementic analysis";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.ForeColor = System.Drawing.Color.SlateGray;
            this.checkBox1.Location = new System.Drawing.Point(19, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Enable Highlightings";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Location = new System.Drawing.Point(-26, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(760, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "_________________________________________________________________________________" +
    "_____________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Location = new System.Drawing.Point(16, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Shortcut Keys ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(22, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Run Code :        Ctrl + F5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(22, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Syntax Tree :     Ctrl + T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(22, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Token Set  :       Ctrl + F";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(23, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Settings  :          Ctrl + Q";
            // 
            // SyntaxErrorHints
            // 
            this.SyntaxErrorHints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SyntaxErrorHints.AutoSize = true;
            this.SyntaxErrorHints.Checked = true;
            this.SyntaxErrorHints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SyntaxErrorHints.ForeColor = System.Drawing.Color.SlateGray;
            this.SyntaxErrorHints.Location = new System.Drawing.Point(231, 95);
            this.SyntaxErrorHints.Name = "SyntaxErrorHints";
            this.SyntaxErrorHints.Size = new System.Drawing.Size(110, 17);
            this.SyntaxErrorHints.TabIndex = 12;
            this.SyntaxErrorHints.Text = "Syntax Error Hints";
            this.SyntaxErrorHints.UseVisualStyleBackColor = true;
            this.SyntaxErrorHints.CheckedChanged += new System.EventHandler(this.SyntaxErrorHints_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 259);
            this.Controls.Add(this.SyntaxErrorHints);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.ThrowSyntaxError);
            this.Controls.Add(this.StopSyntaxTreeAtFalse);
            this.Controls.Add(this.SelectionSetEnable);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(423, 298);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SelectionSetEnable;
        private System.Windows.Forms.CheckBox StopSyntaxTreeAtFalse;
        private System.Windows.Forms.CheckBox ThrowSyntaxError;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox SyntaxErrorHints;
    }
}