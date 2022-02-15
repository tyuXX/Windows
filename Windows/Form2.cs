using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusSim
{
    public partial class Army : Form
    {
        string former1 = "VVVVVVVVVVVVVVVVVVV                                                                   AAAAAAAAAAAAAAAAAAA";
        public Army()
        {
            InitializeComponent();
        }

        private void Army_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            assemble();
            timer1.Enabled = false;
        }
        private void delone()
        {
            string[] text = richTextBox1.Lines;
            for (int i = 0; i < 24; i++)
            {
                for(int ii = 0; ii < text[i].Length + 1; ii++)
                {
                    if(text[i][ii] == ' ')
                    {

                        text[i].Remove(ii);
                    }
                }
            }
        }
        private void assemble()
        {
            for (int i = 24; i > 0; i--)
            {
                for (int ii = 0; ii < former1.Length; ii++)
                {
                    richTextBox1.Text += former1[ii];
                }
                richTextBox1.Text += "\n";
            }
            for (int ii = 0; ii < former1.Length; ii++)
            {
                richTextBox1.Text += former1[ii];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            delone();
        }
    }
}
