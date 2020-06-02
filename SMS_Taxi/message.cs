using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS_Taxi
{
    public partial class message : UserControl
    {
        public message()
        {
            InitializeComponent();
        }
        public message(byte boja, string t, string n = "MessageBox")
        {
            InitializeComponent();
            colorChange(boja);
            this.naslov.Text = n;
            this.text.Text = t;
        }
        private void message_Load(object sender, EventArgs e)
        {
            this.timer.Enabled = true;
        }
        private void colorChange(byte z)
        {
            switch (z)
            {
                case 1:
                    // CRVENA
                    this.BackColor = System.Drawing.Color.FromArgb(255, 226, 226);
                    break;

                case 2:
                    // ZUTA
                    this.BackColor = System.Drawing.Color.FromArgb(255, 255, 226);
                    break;

                case 3:
                    // PLAVA
                    this.BackColor = System.Drawing.Color.FromArgb(226, 228, 255);
                    break;

                case 4:
                    // ZELENA
                    this.BackColor = System.Drawing.Color.FromArgb(226, 255, 231);
                    break;

                case 7:
                    //TRANSPARENT TEST
                    this.BackColor = Color.Transparent;
                    break;

                default:
                    this.BackColor = Color.White;
                    break;
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            this.Dispose();
        }
    }
}
