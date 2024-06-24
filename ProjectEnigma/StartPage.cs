using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEnigma
{
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetError();
            if (cbR1.SelectedIndex == -1 || cbR2.SelectedIndex == -1 || cbR3.SelectedIndex == -1) 
            {
                MessageBox.Show("Please fix Error", "erro", MessageBoxButtons.OK);

            }
            else
            {
                Form1 form1 = new Form1(this, cbR1.SelectedIndex, cbR2.SelectedIndex, cbR3.SelectedIndex);
                this.Hide();
                form1.ShowDialog();
            }
                       
        }

        private void SetError() 
        {
            epMustChooseRotor.Clear();
            if (cbR1.SelectedIndex == -1)
            {
                epMustChooseRotor.SetError(cbR1, "You must Choose Rotor 1");
            }

            if (cbR2.SelectedIndex == -1) 
            {
                epMustChooseRotor.SetError(cbR2, "You must Choose Rotor 2");
            }

            if (cbR3.SelectedIndex == -1)
            {
                epMustChooseRotor.SetError(cbR3, "You must Choose Rotor 3");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
