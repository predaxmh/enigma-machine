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
    public partial class CrtPlugBoardKey : UserControl
    {
        public delegate void CrtPlugBoardKeyEventHandler(object sender , char letter);
        public event CrtPlugBoardKeyEventHandler SendLetter;

        private Color _PlugBackColor;
        public bool IsPlugActive { get; set; }
        public Color PlugBackColor
        { 
            get { return _PlugBackColor; } 
            
            set 
            {               
                lbLetter.BackColor = value;
            }
        }

        public byte LetterIndex { get; set; }
        private char _Letter;
        public char Letter
        {
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

        public bool isPlugKeyPressed = false;

        public CrtPlugBoardKey()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("C:\\Users\\islam\\source\\repos\\ProjectEnigma\\ProjectEnigma\\Properties\\PlugBoardKey.png");

            // if you want to add an event to a user control you must add the event to all of its children (controls), i geuss !!
            this.Controls.OfType<Control>().ToList().ForEach(control =>
            {
                control.Click += CrtPlugBoardKey_Click;
                control.MouseEnter += CrtPlugBoardKey_MouseEnter;
            });

        }

        private void CrtPlugBoardKey_Click(object sender, EventArgs e)
        {
            SendLetter?.Invoke(this, _Letter);            
        }

        private void CrtPlugBoardKey_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
