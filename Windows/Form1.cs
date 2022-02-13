using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Form1 : Form
    {
        BigInteger virus = 0;
        BigInteger stvirus = 0;
        BigInteger antivirus = 0;
        BigInteger antiviruspotent = 0;
        BigInteger comhealt = 0;
        BigInteger infected = 0;
        BigInteger timer = 0;
        int speed = 0;
        bool work = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            virust.Enabled = true;
            updatetick.Enabled = true;
            control.Enabled = true;
            virus = BigInteger.Parse(textBox1.Text);
            stvirus = BigInteger.Parse(textBox1.Text);
            antivirus = BigInteger.Parse(textBox2.Text);
            antiviruspotent = BigInteger.Parse(textBox3.Text);
            comhealt = BigInteger.Parse(textBox4.Text);
            speed = Convert.ToInt32(textBox5.Text);
            work = true;
            virust.Interval *= speed;
            antivirust.Interval *= speed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            virus *= 2;
        }

        private void antivirust_Tick(object sender, EventArgs e)
        {
            virus -= antivirus * antiviruspotent;
            antivirus *= (antivirus * antiviruspotent);
        }

        private void updatetick_Tick(object sender, EventArgs e)
        {
            if (virus > stvirus * 10)
            {
                antivirust.Enabled = true;
            }
            infected = (virus / antiviruspotent) / comhealt;
            label1.Text = "Status:\nVirus Count:" + virus + "\nAnti-Virus Count:" + antivirus + "\nComputer Status:\nInfected parts:" + infected + "\nComputer Healt:" + comhealt + "\nTime:" + timer + "s";
        }

        private void time_Tick(object sender, EventArgs e)
        {
            timer += 1;
        }

        private void control_Tick(object sender, EventArgs e)
        {
            if (virus < 1)
            {
                label1.Text = "Status: Computer Saved :) Time:" + timer + "s";
                virus = 0;
                antivirus = 0;
                antiviruspotent = 0;
                comhealt = 0;
                infected = 0;
                timer = 0;
                stvirus = 0;
                virust.Interval = 1;
                antivirust.Interval = 1;
                virust.Enabled = false;
                antivirust.Enabled = false;
                updatetick.Enabled = false;
                control.Enabled = false;
                control.Stop();
                virust.Stop();
                antivirust.Stop();
                updatetick.Stop();
                work = false;
                Thread.Sleep(10000);
            }
            if (infected > comhealt)
            {
                label1.Text = "Status: Computer Destroyed :( Time:" + timer + "s";
                virus = 0;
                antivirus = 0;
                antiviruspotent = 0;
                comhealt = 0;
                infected = 0;
                timer = 0;
                stvirus = 0;
                virust.Interval = 1;
                antivirust.Interval = 1;
                virust.Enabled = false;
                antivirust.Enabled = false;
                updatetick.Enabled = false;
                control.Enabled = false;
                control.Stop();
                virust.Stop();
                antivirust.Stop();
                updatetick.Stop();
                work = false;
                Thread.Sleep(10000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
