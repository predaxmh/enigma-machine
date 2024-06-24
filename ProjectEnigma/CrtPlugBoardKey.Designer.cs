namespace ProjectEnigma
{
    partial class CrtPlugBoardKey
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLetter
            // 
            this.lbLetter.AutoSize = true;
            this.lbLetter.BackColor = System.Drawing.Color.Black;
            this.lbLetter.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLetter.ForeColor = System.Drawing.Color.White;
            this.lbLetter.Location = new System.Drawing.Point(-1, 0);
            this.lbLetter.Name = "lbLetter";
            this.lbLetter.Size = new System.Drawing.Size(20, 23);
            this.lbLetter.TabIndex = 1;
            this.lbLetter.Text = "?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CrtPlugBoardKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLetter);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CrtPlugBoardKey";
            this.Size = new System.Drawing.Size(22, 46);
            this.Click += new System.EventHandler(this.CrtPlugBoardKey_Click);
            this.MouseEnter += new System.EventHandler(this.CrtPlugBoardKey_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbLetter;
    }
}
