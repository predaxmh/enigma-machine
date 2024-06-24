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
using BusinessLayer;


using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEnigma
{
    public partial class Form1 : Form
    {

        private StartPage _StartPage;
        private int _CryptedMessageLetterLength = 0;
        private Dictionary<CrtPlugBoardKey, CrtPlugBoardKey> SwitchedLetterPairsInPlugBoard = new Dictionary<CrtPlugBoardKey, CrtPlugBoardKey>();
        
        private int ColorIndex = 0;
        
        private CrtPlugBoardKey _FirstControlSelected;

        private Color[] PlugBoardMatchColors ={
            
            Color.Navy,
            Color.DarkRed,
            Color.Green,
            Color.Purple,
            Color.Teal,
            Color.Olive,
            Color.Maroon,
            Color.DarkBlue,
            Color.DarkGreen,
            Color.Brown,
            Color.Indigo,
            Color.DarkSlateGray,
            Color.Firebrick
        };

        private Encryption EncryptionKey;
        public Form1(StartPage startPage, int r1Posiition, int r2Posiition, int r3Posiition)
        {
            InitializeComponent();

            SubscribeToEventEveryCrtPlugBoard();
            SubscribeToEventEveryCrtKeyBoard();

            EncryptionKey = new Encryption();

            EncryptionKey.PositionRotor1 = (byte) numericUpDown1.Value;
            EncryptionKey.PositionRotor2 = (byte) numericUpDown2.Value;
            EncryptionKey.PositionRotor3 = (byte) numericUpDown3.Value;

            _StartPage = startPage;

            cbR1.SelectedIndex = r1Posiition;
            cbR2.SelectedIndex = r2Posiition;
            cbR3.SelectedIndex = r3Posiition;

            lbCryptedMsg.Text = "";
            lbDeCryptedMsg.Text = "";

        }

        // add a white space after 4 letter in crypted screen
        private string AddWhiteSpaceToCryptedMessageLayout(string text, int length) 
        {
            if (_CryptedMessageLetterLength == length) 
            {
                _CryptedMessageLetterLength = 0;
                return text + "  ";
            }  
            return text;
        }

        // plugBoard change colors EncryptionKey object logic
        private void crtPlugBoard_Click(object sender, char e)
        {
            
            CrtPlugBoardKey letterControl = (CrtPlugBoardKey)sender;
          
                if (!letterControl.IsPlugActive) 
                {
                    if (_FirstControlSelected == null)
                    {
                        letterControl.BackColor = PlugBoardMatchColors[ColorIndex];
                        SwitchedLetterPairsInPlugBoard.Add(letterControl, null);
                        
                        _FirstControlSelected = letterControl;
                    }
                    else
                    {
                        letterControl.BackColor = PlugBoardMatchColors[ColorIndex];
                        SwitchedLetterPairsInPlugBoard[_FirstControlSelected] = letterControl;
                        EncryptionKey.SwitchedLetterPairsInPlugBoard.Add(_FirstControlSelected.LetterIndex, letterControl.LetterIndex);
                        _FirstControlSelected = null;
                        ColorIndex++;
                    }

                    letterControl.IsPlugActive = true;
                    
                }
                else
                {
                    if (SwitchedLetterPairsInPlugBoard.ContainsKey(letterControl))
                    {
                        if (SwitchedLetterPairsInPlugBoard[letterControl] == null) 
                        {
                            SwitchedLetterPairsInPlugBoard.Remove(letterControl);
                            EncryptionKey.SwitchedLetterPairsInPlugBoard.Remove(letterControl.LetterIndex);
                            _FirstControlSelected = null;
                            letterControl.BackColor = Color.Black;
                            
                    }
                        else
                        {
                                                          
                            SwitchedLetterPairsInPlugBoard[letterControl].BackColor = Color.Black;
                            letterControl.BackColor = Color.Black;
                            SwitchedLetterPairsInPlugBoard.Remove(letterControl);
                            EncryptionKey.SwitchedLetterPairsInPlugBoard.Remove(letterControl.LetterIndex);
                            ColorIndex--;
                    }
                        
                    } 
                    else
                    {
                        foreach (var plugBoardControl in SwitchedLetterPairsInPlugBoard)
                        {
                            if (plugBoardControl.Value == letterControl)
                            {
                                plugBoardControl.Key.BackColor = Color.Black;
                                letterControl.BackColor = Color.Black;
                                SwitchedLetterPairsInPlugBoard.Remove(plugBoardControl.Key);
                                EncryptionKey.SwitchedLetterPairsInPlugBoard.Remove(plugBoardControl.Key.LetterIndex);
                                ColorIndex--;
                                break;
                            }
                        }
                    }

                    letterControl.IsPlugActive = false;
                }
            
            
        }


        // 
        private void crtKeyBoard_Click(object sender, CrtKeyBoard.KeyBoardEventArgs e)
        {
          
            char encryptedChar = EncryptionKey.EncryptCharacter(e.LetterIndex);
            LightUpKeyLamp(encryptedChar);
            lbCryptedMsg.Text = lbCryptedMsg.Text + " " + encryptedChar.ToString();
            lbDeCryptedMsg.Text = lbDeCryptedMsg.Text + " " + e.Letter.ToString() ;

            _CryptedMessageLetterLength++;
            lbCryptedMsg.Text = AddWhiteSpaceToCryptedMessageLayout(lbCryptedMsg.Text, 4); 
            
            numericUpDown1.UpButton();

        }

        // search for the corresponded crypted letter and change background
        private void LightUpKeyLamp(char keyChar) 
        {
            gbKeyLamp.Controls.OfType<CrtCryptedKeyLamp>().ToList().ForEach(lampControl => {
                if (lampControl != null && lampControl.Letter == keyChar) 
                {
                    lampControl.LightTheLampKey();                  
                }
            });
        }

        private void SubscribeToEventEveryCrtPlugBoard() 
        {
            gbPlugBoard.Controls.OfType<CrtPlugBoardKey>().ToList().ForEach(control =>
            {
                control.SendLetter += crtPlugBoard_Click;               
            }
            );        
        }

        private void SubscribeToEventEveryCrtKeyBoard()
        {
            gbKeyBoard.Controls.OfType<CrtKeyBoard>().ToList().ForEach(control =>
            {
                control.CrtKeyBoardEventHandler += crtKeyBoard_Click;
                
            }
            );
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
            InfiniteLoopToNumericUpDown((NumericUpDown)sender);
            EncryptionKey.PositionRotor3 = (byte)numericUpDown3.Value;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            UpValueNextNumericUpDown((NumericUpDown)sender, numericUpDown3);
            InfiniteLoopToNumericUpDown((NumericUpDown)sender);
            EncryptionKey.PositionRotor2 = (byte)numericUpDown2.Value;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpValueNextNumericUpDown((NumericUpDown)sender, numericUpDown2);
            InfiniteLoopToNumericUpDown((NumericUpDown)sender);
            EncryptionKey.PositionRotor1 = (byte)numericUpDown1.Value;
        }

        // if it reach 27 make it 1 and if it reach 0 make it 26 
        private void InfiniteLoopToNumericUpDown(NumericUpDown upDown) 
        {
            if (upDown.Value > 26) upDown.Value = 1;
            else if (upDown.Value == 0) upDown.Value = 26;
        }
        //this will incress a NumericUpDown by 1 if the other NumericUpDown value is more than 26
        private void UpValueNextNumericUpDown(NumericUpDown upDown, NumericUpDown numericUp )
        {
            if (upDown.Value > 26) numericUp.Value++;
            
        }


        // change the rotor inside the EncryptionKey object 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncryptionKey.PlaceMainRotorInMachine((byte)(cbR1.SelectedIndex + 1), 1);
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncryptionKey.PlaceMainRotorInMachine((byte)(cbR2.SelectedIndex + 1), 2);
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncryptionKey.PlaceMainRotorInMachine((byte)(cbR3.SelectedIndex + 1), 3);
            
        }

        // activate keyboard
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyPressed = char.ToLower(e.KeyChar); // Convert to lowercase for case-insensitive matching

            if (char.IsLetter(keyPressed))
            {
                switch (keyPressed)
                {
                    case 'a':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('a');
                        break;
                    case 'b':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('b');
                        break;
                    case 'c':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('c');
                        break;
                    case 'd':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('d');
                        break;
                    case 'e':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('e');
                        break;
                    case 'f':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('f');
                        break;
                    case 'g':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('g');
                        break;
                    case 'h':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('h');
                        break;
                    case 'i':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('i');
                        break;
                    case 'j':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('j');
                        break;
                    case 'k':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('k');
                        break;
                    case 'l':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('l');
                        break;
                    case 'm':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('m');
                        break;
                    case 'n':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('n');
                        break;
                    case 'o':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('o');
                        break;
                    case 'p':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('p');
                        break;
                    case 'q':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('q');
                        break;
                    case 'r':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('r');
                        break;
                    case 's':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('s');
                        break;
                    case 't':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('t');
                        break;
                    case 'u':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('u');
                        break;
                    case 'v':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('v');
                        break;
                    case 'w':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('w');
                        break;
                    case 'x':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('x');
                        break;
                    case 'y':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('y');
                        break;
                    case 'z':
                        GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent('z');
                        break;
                    default:
                        
                        break;
                }
            }
        }

        // invoke the click when a key pressed
        private void GetCrtKeyBoardThatMatchLetterAndInvokeClickEvent(char letter)
        {
            gbKeyBoard.Controls.OfType<CrtKeyBoard>().ToList().ForEach(control =>
            {
                if (char.ToLower(control.Letter) == letter)
                    control.InvokeEvent();
                
            }
            );

        }

        // show and hide decrypted msg
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (flpDecryptedMessage.Enabled)
            {
                flpDecryptedMessage.Enabled = false;
                flpDecryptedMessage.Visible = false;
            }
            else
            {
                flpDecryptedMessage.Enabled = true;
                flpDecryptedMessage.Visible = true;
            }

        }

        // clear Both screen
        private void btnClear_Click(object sender, EventArgs e)
        {
            lbCryptedMsg.Text = "";
            lbDeCryptedMsg.Text = "";
            _CryptedMessageLetterLength = 0;
    }

        private void btnLogOut_Click(object sender, EventArgs e)
        {           
            _StartPage.Show();
            this.Close();
        }
    }
}
