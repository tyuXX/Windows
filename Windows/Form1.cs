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
using static Windows.rntm;

namespace Windows
{
    public struct Virus
    {
        public int id;
        public int type;
        public int life;
        public bool veteran;
    }
    public struct Antivirus
    {
        public int id;
        public int knowntypes;
        public int life;
        public bool veteran;
    }
    public partial class Form1 : Form
    {
        Random rng = new Random();
        Virus[] evirus;
        Antivirus[] eantivirus;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private Virus genvir(int i)
        {
            Virus vir = new Virus();
            vir.id = i;
            vir.type = rng.Next(1, virustypes);
            vir.life = 1;
            return vir;
        }
        private Antivirus genantivir(int i)
        {
            Antivirus antivir = new Antivirus();
            antivir.id = i;
            antivir.knowntypes = rng.Next(1, virustypes);
            antivir.life = 1;
            return antivir;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                virustypes = 1;
                if (checkBox1.Checked)
                {
                    virustypes = Convert.ToInt16(rng.Next(1, 5));
                }
                virus = BigInteger.Parse(textBox1.Text);
                stvirus = BigInteger.Parse(textBox1.Text);
                antivirus = BigInteger.Parse(textBox2.Text);
                antiviruspotent = BigInteger.Parse(textBox3.Text);
                comhealt = BigInteger.Parse(textBox4.Text);
                speed = Convert.ToInt32(textBox5.Text);
                if (checkBox2.Checked)
                {
                    int i = 0;
                    while (i < virus)
                    {
                        Virus vir = new Virus();
                        vir.id = i;
                        vir.type = rng.Next(1, virustypes);
                        vir.life = 1;
                        evirus[i] = vir;
                        i++;
                    }
                    i = 0;
                    while (i < antivirus)
                    {
                        Antivirus antivir = new Antivirus();
                        antivir.id = i;
                        antivir.knowntypes = rng.Next(1, virustypes);
                        antivir.life = 1;
                        eantivirus[i] = antivir;
                        i++;
                    }
                }
                virust.Enabled = true;
                updatetick.Enabled = true;
                control.Enabled = true;
                work = true;
                virust.Interval *= speed;
                antivirust.Interval *= speed;
                if (checkBox4.Checked)
                {
                    Form3 f3 = new Form3();
                    f3.Show();
                }
            }
            catch (Exception ex)
            {
                label1.Text = "There Has Been an error.\n Please Check all the textboxes\nSystem error:" + ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked)
                {
                    int ii = evirus.Length;
                    while (ii > -1)
                    {
                        virus += evirus[ii].type + evirus[ii].life;
                        evirus[ii].life += 1;
                        ii--;
                    }
                    int i = ((int)virus) - evirus.Length;
                    while (i < virus)
                    {
                        Virus vir = new Virus();
                        vir.id = i;
                        vir.type = rng.Next(1, virustypes);
                        vir.life = 1;
                        evirus[i] = vir;
                        i++;
                    }
                }
                else
                {
                    virus *= 2 * virustypes;
                    antivirus -= ((virus / antivirus) / antiviruspotent) / comhealt;
                }
            }
            catch (Exception ex)
            {
                label1.Text = "There Has Been an error.\nSystem error:" + ex;
            }
        }

        private void antivirust_Tick(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked)
                {
                    int ii = eantivirus.Length;
                    while (ii > -1)
                    {
                        antivirus += eantivirus[ii].life * antiviruspotent;
                        evirus[ii].life += 1;
                        ii--;
                    }
                    int i = ((int)virus) - evirus.Length;
                    while (i < virus)
                    {
                        Antivirus vir = new Antivirus();
                        vir.id = i;
                        vir.life = 1;
                        eantivirus[i] = vir;
                        i++;
                    }
                }
                else
                {
                    virus -= antivirus * antiviruspotent;
                    antivirus += (antivirus * antiviruspotent);
                }
            }
            catch (Exception ex)
            {
                label1.Text = "There Has Been an error.\nSystem error:" + ex;
            }
        }

        private void updatetick_Tick(object sender, EventArgs e)
        {
            if (virus > stvirus * 10)
            {
                antivirust.Enabled = true;
            }
            infected = (virus / antiviruspotent) / comhealt;
            label1.Text = "Status:\nVirus Count:" + virus + "\nAnti-Virus Count:" + antivirus + "\nComputer Status:\nInfected parts:" + infected + "\nComputer Healt:" + comhealt + "\nVirus Types:" + virustypes + "\nTime:" + timer + "s";
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
            menuStrip1.Visible = false;
        }

        private void autoDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1000";
            textBox2.Text = "2";
            textBox3.Text = "2";
            textBox4.Text = "100";
            textBox5.Text = "1000";
        }
    }
}
