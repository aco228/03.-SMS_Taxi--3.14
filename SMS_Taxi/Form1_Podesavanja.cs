using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMS_Taxi.Aco;
using System.IO;

namespace SMS_Taxi
{
    public partial class Form1_Podesavanja : Form
    {
        bool prozorOtvoren = false;
        bool resizeDone = true;
        Form1 Form1;
        bool t_startovan;

        public Form1_Podesavanja(Form1 form1, bool star)
        {
            InitializeComponent();
            Form1 = form1; t_startovan = star;
        }
        private void Form1_Podesavanja_Load(object sender, EventArgs e)
        {
            restartSize();
            provjeraBaze();
        }
        public void provjeraBaze()
        {
            if (!var.postojiBlackList) this.btn_lista.BackColor = Color.IndianRed;
            if (!var.postojiUserConfig)
            {
                this.btn_restart.BackColor = Color.IndianRed;
                this.btn_sound.BackColor = Color.IndianRed;
            }
        }
        private void restartSize(int x = 547, int y = 176)
        {
            this.Size = new System.Drawing.Size(x, y);
        }

        // MOUSE ENTER LEAVE
        private void btn_lista_MouseEnter(object sender, EventArgs e)
        {
            this.btn_lista.ForeColor = Color.Blue;
        }
        private void btn_lista_MouseLeave(object sender, EventArgs e)
        {
            this.btn_lista.ForeColor = Color.Black;
        }
        private void btn_sound_MouseEnter(object sender, EventArgs e)
        {
            this.btn_sound.ForeColor = Color.Blue;
        }
        private void btn_sound_MouseLeave(object sender, EventArgs e)
        {
            this.btn_sound.ForeColor = Color.Black;
        }
        private void btn_restart_MouseEnter(object sender, EventArgs e)
        {
            this.btn_restart.ForeColor = Color.Blue;
        }
        private void btn_restart_MouseLeave(object sender, EventArgs e)
        {
            this.btn_restart.ForeColor = Color.Black;
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.btn_baner.ForeColor = Color.Blue;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.btn_baner.ForeColor = Color.Black;
        }
        // MOUSE ENTER LEAVE

        private void btn_lista_Click(object sender, EventArgs e)
        {
            if (!prozorOtvoren)
            {
            if (var.postojiBlackList && !prozorOtvoren)
            {
                Form1_BL b = new Form1_BL();
                b.Show();
                this.Dispose();
                Form1.Visible = true;
                b.TopMost = true;
            }
            else MessageBox.Show("Greska pri konekciji sa bazom!");
            }
            else MessageBox.Show("Morate zatvoriti sadasnja podesavanja!");
        }
        private void btn_restart_Click(object sender, EventArgs e)
        {
            if (!prozorOtvoren)
            {
                if (var.postojiUserConfig)
                {
                    restartSize(547, 424);
                    prozorOtvoren = true;
                    this.panel_restart.Location = new System.Drawing.Point(12, 137);
                    this.panel_restart.Visible = true;
                    this.restart_time.Text = var.vrijemeRestarta.ToString();
                    if (var.vrijemeRestarta < 60) this.restart_trackBar.Value = var.vrijemeRestarta;
                }
                else MessageBox.Show("Greska u komunikaciji sa bazom!");
            }
            else MessageBox.Show("Morate zatvoriti sadasnja podesavanja!");
        }
        private void btn_sound_Click(object sender, EventArgs e)
        {
            if (!prozorOtvoren)
            {
                if (var.postojiUserConfig)
                {
                    restartSize(547, 424);
                    prozorOtvoren = true;
                    sound_getLista();
                    this.sound_izabrano.Text = "";
                    this.panel_sound.Location = new System.Drawing.Point(12, 137);
                    this.panel_sound.Visible = true;
                }
                else MessageBox.Show("Greska u komunikaciji sa bazom!");
            }
            else MessageBox.Show("Morate zatvoriti sadasnja podesavanja!");
        }
        private void btn_baner_Click(object sender, EventArgs e)
        {
            if (!prozorOtvoren)
            {
                prozorOtvoren = true;
                restartSize(547, 324);
                panel_baner.Location = new System.Drawing.Point(12,137);
                panel_baner.Visible = true;
                if (!File.Exists("baner.jpg")) baner_delete.Enabled = false;
            }
            else MessageBox.Show("Morate zatvoriti sadasnja podesavanja!");
        }

        private void restart_BTN_exit_Click(object sender, EventArgs e)
        {
            restartSize();
            prozorOtvoren = false;
            this.panel_restart.Visible = false;
        }

        private void restart_trackBar_Scroll(object sender, EventArgs e)
        {
            this.restart_time.Text = restart_trackBar.Value.ToString();
        }

        private void restart_time_TextChanged(object sender, EventArgs e)
        {
            this.restart_timeZero.Checked = false;
            int br = 0;
            if (int.TryParse(restart_time.Text, out br) && br < 60)
            {
                restart_trackBar.Value = br;
            }
        }

        private void restart_timeZero_CheckedChanged(object sender, EventArgs e)
        {
            this.restart_time.Text = "0";
            this.restart_trackBar.Value = 0;
            //this.restart_timeZero.Checked = true;
        }

        private void restart_BTN_save_Click(object sender, EventArgs e)
        {
            if (!restart_provjera(this.restart_time.Text))
            {
                TextWriter tw = File.CreateText(var.imeUserConfig);
                tw.WriteLine(restart_time.Text);
                tw.WriteLine(var.messageSound);
                tw.Close();
                MessageBox.Show("Promjena sacuvana!");
                provjera p = new provjera();
                Form1.aco_restartLoad();
            }
            else MessageBox.Show("Upisali ste ne dozvoljeni znak.");

        }
        private bool restart_provjera(string a)
        {
            int br = 0;
            bool greska = true;
            if(int.TryParse(a, out br)) 
            {
                greska = false;
            }
            return greska;
        }

        private void baner_exit_Click(object sender, EventArgs e)
        {
            this.panel_baner.Visible = false;
            prozorOtvoren = false;
            restartSize();
        }

        private void baner_save_Click(object sender, EventArgs e)
        {
            string folderAplikacije = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(folderAplikacije + @"\baner.jpg") && File.Exists(folderAplikacije + @"\baner1.jpg"))
            {
                this.baner_save.Enabled = false;
                MessageBox.Show("Morate u potpunosti restartovati program radi daljih izmjena!");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG FILES(*.jpg)|*.jpg";
            //MessageBox.Show("put : " + folderAplikacije);
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(folderAplikacije + @"\baner.jpg"))
                {
                    File.Copy(ofd.FileName, folderAplikacije + @"\baner1.jpg");
                    MessageBox.Show("Dodavanje izvrseno!\r\nPromjene ce u potpunosti biti sacuvane nakon potpunog restarta programa!");
                    Form1.aco_setBaner();
                    baner_delete.Enabled = true;
                }
                else
                {
                    File.Copy(ofd.FileName, folderAplikacije + @"\baner.jpg");
                    MessageBox.Show("Dodavanje izvrseno!");
                    Form1.aco_setBaner();
                    baner_delete.Enabled = true;
                }
            }
        }
        private void baner_delete_Click(object sender, EventArgs e)
        {
            if (File.Exists("baner.jpg") && MessageBox.Show("Koriscenjem ove opcije brisete baner koji ste postavili.\r\nDa li ste sigurni", "Upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TextWriter tw = File.CreateText("command.CONFIGX");
                tw.WriteLine(""); tw.Close();
                Form1.aco_setBaner(1);
                MessageBox.Show("Promjena ce biti sacuvana nakon potpunog restarta programa!");
            }
        }

        private void sound_exit_Click(object sender, EventArgs e)
        {
            restartSize();
            this.panel_sound.Visible = false;
            prozorOtvoren = false;
        }
        public void sound_getName(string a) 
        {
            sound_izabrano.Text = a;
        }
        private void sound_getLista()
        {
            string put = Path.GetDirectoryName(Application.ExecutablePath);
            string[] a = Directory.GetFiles(put + "\\sound", "*.wav");
            if (a.Length == 0) MessageBox.Show("Ne postoje zvukovi u bazi! Molimo vas da ubacite svoje zvukove koristeci opciju <<Ubaci svoj zvuk>>!");
            this.sound_list.Controls.Clear();
            for (int i = 0; i < a.Length; i++)
            {
                soundList l = new soundList(this, a[i]);
                sound_list.Controls.Add(l);
            }
        }
        private void sound_save_Click(object sender, EventArgs e)
        {
            if (sound_izabrano.Text != "")
            {
                TextWriter tw = File.CreateText(var.imeUserConfig);
                tw.WriteLine(var.vrijemeRestarta);
                tw.WriteLine(sound_izabrano.Text);
                tw.Close();
                MessageBox.Show("Promjena sacuvana!");
                provjera p = new provjera();
            }
            else
            {
                MessageBox.Show("Morate iz liste da izaberete zvuk!");
            }
        }

        private void sound_uppload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WAV FILES(*.wav)|*.wav";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = imeFajlaZaCuvanje(ofd.FileName);
                if (File.Exists("sound\\" + name) && MessageBox.Show("Zvuk sa takvim imenom vec postoji u bazi, da li zelite da presnimite?", "Presnimavanje!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete("sound\\" + name);
                    File.Copy(ofd.FileName, "sound\\" + name);
                    sound_list.Controls.Clear();
                    sound_getLista();
                    MessageBox.Show("Sacuvano!");
                }
                if (!File.Exists("sound\\" + name))
                {
                    File.Copy(ofd.FileName, "sound\\" + name);
                    sound_list.Controls.Clear();
                    sound_getLista();
                    MessageBox.Show("Sacuvano!");
                }
            }
        }
        private string imeFajlaZaCuvanje(string a)
        {
            string b = a.Replace(@"\", "#");
            string[] g = b.Split('#');
            return g[g.Length - 1];
        }

        private void Form1_Podesavanja_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.aco_podesavanjaUcitana = false;
            Form1.Visible = true;
            if (t_startovan) Form1.START();
        }



    }
}
