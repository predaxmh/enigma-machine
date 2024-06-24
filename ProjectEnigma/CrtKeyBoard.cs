using ProjectEnigma.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEnigma
{
    public partial class CrtKeyBoard : UserControl
    {
        public class KeyBoardEventArgs : EventArgs
        {
            public byte LetterIndex { get; }
            public char Letter { get; }

            public KeyBoardEventArgs(byte letterIndex, char letter) 
            { 
                this.LetterIndex = letterIndex;
                this.Letter = letter;
            }
        }

        public event EventHandler<KeyBoardEventArgs> CrtKeyBoardEventHandler;

        public event Action<byte, char, char> CrtKeyBoardEventPressKeyHandler;
        
        

        public byte LetterIndex { get; set; }
        private char _Letter;
        public char Letter { 
            get 
            {
                return _Letter;
            }
            set
            {
                _Letter = value;
                lbLetter.Text = _Letter.ToString();
            }
        }
        public CrtKeyBoard()
        {
            InitializeComponent();
            // if you want to add an event to a user control you must add the event to all of its children (controls), i geuss !!
            this.Controls.OfType<Control>().ToList().ForEach(control =>
            {
                control.Click += CrtKeyBoard_Click;
                control.MouseEnter += CrtKeyBoard_MouseEnter;
                control.MouseLeave += CrtKeyBoard_MouseLeave;
                
            });

            DefaultSettings();
        }

        private void DefaultSettings() 
        { 
            pbKey.Image = Resources.btn_Image;
        }


        private void CrtKeyBoard_Click(object sender, EventArgs e)
        {           
            CrtKeyBoardEventHandler?.Invoke(this, new KeyBoardEventArgs(LetterIndex, _Letter));
        }

        private void CrtKeyBoard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            this.Cursor = Cursors.Hand;
        }

        private void CrtKeyBoard_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            this.Cursor = Cursors.Default;
        }

        public void InvokeEvent()
        {

            CrtKeyBoardEventHandler?.Invoke(this, new KeyBoardEventArgs(LetterIndex, _Letter));

        }
    }
}
