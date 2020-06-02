using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMS_Taxi.Aco;

namespace SMS_Taxi
{
    public partial class Form1_BL : Form
    {
        public Form1_BL()
        {
            InitializeComponent();
        }
        public Form1_BL(string a)
        {
            InitializeComponent();
            add_panel.Visible = true;
            this.add_panel.Location = new System.Drawing.Point(11, 21);
            this.number.Text = a;
        }

        private void Form1_BL_Load(object sender, EventArgs e)
        {
            ubacivanjeUListu();
        }
        private void ubacivanjeUListu()
        {   
            lista.Items.Clear();
            for (int i = 0; i < var.listaBrojeva.Length; i++)
            {
                
                if (var.listaBrojeva[i].ime != "")
                {
                    lista.Items.Add(var.listaBrojeva[i].broj + " (" + var.listaBrojeva[i].ime + ") ");
                    //lista_DrawItem(this, 12);
                    //lista.Items.Add(item1);
                }
                else
                    lista.Items.Add(var.listaBrojeva[i].broj + " ");

                if (var.listaBrojeva[i].boja == 1)
                    lista.Items[i].ForeColor = Color.Blue;

            }
        }
        
        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] a = lista.SelectedItems[0].Text.Split(' ');
                //MessageBox.Show("Broj |" + a[0]+"|");
                var.blackList.dell(a[0]);
                ubacivanjeUListu();
            }
            catch (Exception)
            {
                MessageBox.Show("Kliknite na broj koji zelite da izbrisete!");
            }
            
            //MessageBox.Show("indeks: " + lista.SelectedIndex);
            /*
            if (lista.item > -1)
            {
                if (MessageBox.Show("Dali ste sigurni da zelite da izbrisete broj " + lista.SelectedItem.ToString() + " iz liste? ", "Brisanje broja!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string[] a = lista.SelectedItem.ToString().Split(' ');
                    //MessageBox.Show("Broj |" + a[0]+"|");
                    var.blackList.dell(a[0]);
                    ubacivanjeUListu();
                }
            }
            else
            {
                MessageBox.Show("Kliknite na broj koji zelite da izbrisete!");
            }*/
        }

        private void broj_TextChanged(object sender, EventArgs e)
        {
            add.Enabled = true;
        }

        private void add_Click(object sender, EventArgs e)
        {
            add_panel.Visible = true;
            this.add_panel.Location = new System.Drawing.Point(11, 21);
        }

        private void blue_CheckedChanged(object sender, EventArgs e)
        {
            if (blue.Checked) black.Checked = false;
            if (!blue.Checked) black.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_panel.Visible = false;
            add_panel.Location = new System.Drawing.Point(1000,1000);
            this.name.Text = "";
            this.number.Text = "";
            this.black.Checked = true;
            this.blue.Checked = false;
        }

        private void black_CheckedChanged(object sender, EventArgs e)
        {
            if (black.Checked) blue.Checked = false;
            if (!black.Checked) blue.Checked = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (number.Text != "")
            {
                if (number.Text.Length > 2 && number.Text.Length < 16)
                {
                    if (name.Text == "" || name.Text != "" && name.Text.Length > 2 && name.Text.Length < 16)
                    {
                        //odredjivanje boja
                        byte boja = 0;
                        if (black.Checked) boja = 0;
                        else if (blue.Checked) boja = 1;

                        //napokon cuvanje
                        var.blackList.add(boja, number.Text, name.Text);
                        ubacivanjeUListu();
                    }
                    else MessageBox.Show("Prekoracili ste ogranicenja za ime!\r\nOgranicenja su od 3 do 15 karaktera!");
                } 
                else MessageBox.Show("Prekoracili ste ogranicenja za broj!\r\nOgranicenja su od 3 do 15 karaktera!");
            }
            else MessageBox.Show("Polje za broj je prazno!");
        }

        string info = "";
        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        { /*
            if (lista.Items.Count >= 0)
            {
                info = lista.SelectedItems[0].Text;
                MessageBox.Show("info: " + info + "\r\ne: " + e.ToString());
            }
           * */
        }

    }
}
