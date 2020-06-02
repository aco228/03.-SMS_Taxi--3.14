using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace SMS_Taxi
{
    public partial class soundList : UserControl
    {
        string soundName = "";
        string soundPath = "";
        SoundPlayer sp;
        Form1_Podesavanja pd;
        bool damaged = false;
        bool clicked = false;

        public soundList()
        {
            InitializeComponent();
        }
        public soundList(Form1_Podesavanja p, string a)
        {
            InitializeComponent();
            pd = p;
            soundPath = a;
            getPath();
            this.name.Text = soundName;
        }
        private void getPath()
        {
            string a = soundPath.Replace(@"\", "#");
            string[] b = a.Split('#');
            soundName = b[b.Length-1];
        }
        private void play_Click(object sender, EventArgs e)
        {
            try
            {
                sp = new SoundPlayer(soundPath);
                sp.Play();
                stop.Visible = true;
                if(!clicked) up.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fajl je ostecen!");
                damaged = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            potvrda();
            if (!clicked) up.Enabled = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            sp.Stop();
            stop.Visible = false;
        }

        int r = 238;
        int b = 244;
        int g = 196;

        private void up_Tick(object sender, EventArgs e)
        {
            clicked = true;
            if (r == 214 && b == 242 && g == 27)
            {
                up.Enabled = false;
                down.Enabled = true;
                return;
            }
            if (r != 214) r--;
            if (b != 242) b--;
            if (g != 27) g--;
            this.BackColor = System.Drawing.Color.FromArgb(r, b, g);
            this.Update();
        }

        private void down_Tick(object sender, EventArgs e)
        {
            if (r == 238 && b == 244 && g == 196)
            {
                clicked = false;
                down.Enabled = false;
                return;
            }
            if (r != 238) r++;
            if (b != 244) b++;
            if (g != 196) g++;
            this.BackColor = System.Drawing.Color.FromArgb(r, b, g);
            this.Update();
        }

        private void soundList_Load(object sender, EventArgs e)
        {

        }
        private void potvrda()
        {
            if (!damaged)
            {
                up.Enabled = true;
                pd.sound_getName(soundName);
            }
        }

        private void soundList_Click(object sender, EventArgs e)
        {
            potvrda();
        }
    }
}
