namespace ProjectEnigma
{
    partial class CrtKeyBoard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLetter = new System.Windows.Forms.Label();
            this.pbKey = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLetter
            // 
            this.lbLetter.AutoSize = true;
            this.lbLetter.BackColor = System.Drawing.Color.Black;
            this.lbLetter.Font = new System.Drawing.Font("Arial Narrow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLetter.ForeColor = System.Drawing.Color.White;
            this.lbLetter.Location = new System.Drawing.Point(12, 8);
            this.lbLetter.Name = "lbLetter";
            this.lbLetter.Size = new System.Drawing.Size(20, 23);
            this.lbLetter.TabIndex = 1;
            this.lbLetter.Text = "?";
            // 
            // pbKey
            // 
            this.pbKey.BackColor = System.Drawing.Color.Transparent;
            this.pbKey.ImageLocation = "";
            this.pbKey.Location = new System.Drawing.Point(1, 0);
            this.pbKey.Name = "pbKey";
            this.pbKey.Size = new System.Drawing.Size(43, 42);
            this.pbKey.TabIndex = 0;
            this.pbKey.TabStop = false;
            // 
            // CrtKeyBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLetter);
            this.Controls.Add(this.pbKey);
            this.Name = "CrtKeyBoard";
            this.Size = new System.Drawing.Size(43, 41);
            this.Click += new System.EventHandler(this.CrtKeyBoard_Click);
            this.MouseEnter += new System.EventHandler(this.CrtKeyBoard_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CrtKeyBoard_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbKey;
        private System.Windows.Forms.Label lbLetter;
    }
}
