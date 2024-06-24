namespace ProjectEnigma
{
    partial class CrtCryptedKeyLamp
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
            this.pbKeyLamp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbKeyLamp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLetter
            // 
            this.lbLetter.AutoSize = true;
            this.lbLetter.BackColor = System.Drawing.Color.Gray;
            this.lbLetter.Font = new System.Drawing.Font("Arial Narrow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLetter.ForeColor = System.Drawing.Color.White;
            this.lbLetter.Location = new System.Drawing.Point(10, 9);
            this.lbLetter.Name = "lbLetter";
            this.lbLetter.Size = new System.Drawing.Size(20, 23);
            this.lbLetter.TabIndex = 2;
            this.lbLetter.Text = "?";
            // 
            // pbKeyLamp
            // 
            this.pbKeyLamp.BackColor = System.Drawing.Color.Transparent;
            this.pbKeyLamp.Location = new System.Drawing.Point(0, 0);
            this.pbKeyLamp.Name = "pbKeyLamp";
            this.pbKeyLamp.Size = new System.Drawing.Size(40, 40);
            this.pbKeyLamp.TabIndex = 1;
            this.pbKeyLamp.TabStop = false;
            // 
            // CrtCryptedKeyLamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLetter);
            this.Controls.Add(this.pbKeyLamp);
            this.Name = "CrtCryptedKeyLamp";
            this.Size = new System.Drawing.Size(41, 39);
            ((System.ComponentModel.ISupportInitialize)(this.pbKeyLamp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbKeyLamp;
        private System.Windows.Forms.Label lbLetter;
    }
}
