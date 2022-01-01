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
            this.EnableHighlighting = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
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
            this.SelectionSetEnable.Enabled = false;
            this.SelectionSetEnable.Location = new System.Drawing.Point(20, 45);
            this.SelectionSetEnable.Name = "SelectionSetEnable";
            this.SelectionSetEnable.Size = new System.Drawing.Size(125, 17);
            this.SelectionSetEnable.TabIndex = 1;
            this.SelectionSetEnable.Text = "Selection Set Enable";
            this.SelectionSetEnable.UseVisualStyleBackColor = true;
            // 
            // StopSyntaxTreeAtFalse
            // 
            this.StopSyntaxTreeAtFalse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StopSyntaxTreeAtFalse.AutoSize = true;
            this.StopSyntaxTreeAtFalse.Checked = true;
            this.StopSyntaxTreeAtFalse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StopSyntaxTreeAtFalse.Location = new System.Drawing.Point(20, 70);
            this.StopSyntaxTreeAtFalse.Name = "StopSyntaxTreeAtFalse";
            this.StopSyntaxTreeAtFalse.Size = new System.Drawing.Size(149, 17);
            this.StopSyntaxTreeAtFalse.TabIndex = 2;
            this.StopSyntaxTreeAtFalse.Text = "Stop Syntax Tree At False";
            this.StopSyntaxTreeAtFalse.UseVisualStyleBackColor = true;
            this.StopSyntaxTreeAtFalse.CheckedChanged += new System.EventHandler(this.StopSyntaxTreeAtFalse_CheckedChanged);
            // 
            // EnableHighlighting
            // 
            this.EnableHighlighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EnableHighlighting.AutoSize = true;
            this.EnableHighlighting.Checked = true;
            this.EnableHighlighting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableHighlighting.Enabled = false;
            this.EnableHighlighting.Location = new System.Drawing.Point(21, 96);
            this.EnableHighlighting.Name = "EnableHighlighting";
            this.EnableHighlighting.Size = new System.Drawing.Size(117, 17);
            this.EnableHighlighting.TabIndex = 3;
            this.EnableHighlighting.Text = "Enable Highlighting";
            this.EnableHighlighting.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(20, 120);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(110, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Sementic analysis";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 162);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.EnableHighlighting);
            this.Controls.Add(this.StopSyntaxTreeAtFalse);
            this.Controls.Add(this.SelectionSetEnable);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SelectionSetEnable;
        private System.Windows.Forms.CheckBox StopSyntaxTreeAtFalse;
        private System.Windows.Forms.CheckBox EnableHighlighting;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}