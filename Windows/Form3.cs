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

namespace Windows
{
    public partial class Form3 : Form
    {
        int genform = 5;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for(int i = genform; i > 0; i--)
            {
                sim.Form1 f = new sim.Form1();
                f.MdiParent = this;
                f.Show();
            }
            for (int i = genform; i > 0; i--)
            {
                sim.Form2 f = new sim.Form2();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (work)
            {

            }
            else
            {
                this.Close();
            }
        }
    }
}
