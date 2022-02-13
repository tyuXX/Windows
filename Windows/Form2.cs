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
            for(int i = 25; i > 0; i++)
            {
                for(int ii = 0; i < former1.Length; i++)
                {
                    richTextBox1.Text += former1[ii];
                    Thread.Sleep(100);
                }
                richTextBox1.Text += "\n";
                Thread.Sleep(100);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
