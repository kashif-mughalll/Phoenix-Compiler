namespace Compiler_Pheonix
{
    partial class TokenSetForm
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
            this.tokenSetArea = new System.Windows.Forms.RichTextBox();
            this.FormLabel = new System.Windows.Forms.Label();
            this.SelectFormate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tokenSetArea
            // 
            this.tokenSetArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenSetArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokenSetArea.Location = new System.Drawing.Point(6, 40);
            this.tokenSetArea.Name = "tokenSetArea";
            this.tokenSetArea.ReadOnly = true;
            this.tokenSetArea.Size = new System.Drawing.Size(755, 428);
            this.tokenSetArea.TabIndex = 0;
            this.tokenSetArea.Text = "";
            // 
            // FormLabel
            // 
            this.FormLabel.AutoSize = true;
            this.FormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormLabel.Location = new System.Drawing.Point(5, 17);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(73, 17);
            this.FormLabel.TabIndex = 1;
            this.FormLabel.Text = "Token Set";
            // 
            // SelectFormate
            // 
            this.SelectFormate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFormate.FormattingEnabled = true;
            this.SelectFormate.Location = new System.Drawing.Point(613, 13);
            this.SelectFormate.Name = "SelectFormate";
            this.SelectFormate.Size = new System.Drawing.Size(147, 21);
            this.SelectFormate.TabIndex = 2;
            this.SelectFormate.TextChanged += new System.EventHandler(this.SelectFormate_TextChanged);
            // 
            // TokenSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 475);
            this.Controls.Add(this.SelectFormate);
            this.Controls.Add(this.FormLabel);
            this.Controls.Add(this.tokenSetArea);
            this.Name = "TokenSetForm";
            this.Text = "TokenSetForm";
            this.Load += new System.EventHandler(this.TokenSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tokenSetArea;
        private System.Windows.Forms.Label FormLabel;
        private System.Windows.Forms.ComboBox SelectFormate;
    }
}