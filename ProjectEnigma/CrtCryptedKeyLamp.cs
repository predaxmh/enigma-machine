using ProjectEnigma.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ProjectEnigma
{
    public partial class CrtCryptedKeyLamp : UserControl
    {

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

        public CrtCryptedKeyLamp()
        {
            InitializeComponent();

            DefaultSettings();
        }

        private void DefaultSettings()
        {
           
            pbKeyLamp.Image = Resources.btn_KeyLamp;
            
        }
       
        public void LightTheLampKey() 
        {
     
            var timer = new System.Timers.Timer(1500);

            // Define an event handler for the timer elapsed event
            timer.Elapsed += OnTimerElapsed;

            // Start the timer
            timer.Start();
            pbKeyLamp.BackColor = Color.LightYellow;
            
            
            // Code continues executing

            void OnTimerElapsed(object sender, ElapsedEventArgs e)
            {
                // Your code to be executed after the pause
                
                pbKeyLamp.BackColor = Color.Transparent;
                
                // You can stop the timer if needed
                //timer.Stop();
            }
            
        }
    }
}
