using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Windows.rntm;

namespace Windows.sim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labels();
        }
        private void labels()
        {
            label1.Text += ".";
            label2.Text += ".";
            if (label1.Text == "Generating More Viruses......")
            {
                label1.Text = "Generating More Viruses";
            }
            if (label2.Text == "Killing Antivirusses......")
            {
                label2.Text = "Killing Antivirusses";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = "Virus Count:" + virus;
        }
    }
}
