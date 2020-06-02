using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace SMS_Taxi
{
    public partial class Form4_lista : Form
    {
        Form3 form3;
        private MySqlConnection conn;

        public Form4_lista(Form3 fr)
        {
            InitializeComponent();
            form3 = fr;

        }
        private void Form4_lista_Load(object sender, EventArgs e)
        {
            openConn();
            updateDG();
        }
        private void openConn()
        {
            if (conn != null)
                conn.Close();
            Helper hl = new Helper();
            string connStr = String.Format("server={0};user id={1}; password={2}; database=sms_taxi; pooling=false", "localhost", "root", hl.base64Decode("bWFoYXJhZGph"));
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error connecting to the server: " + ex.Message);
            }
        }
        public void updateDG()
        {
            DataTable data = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM " + "usluga;", conn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            da.Fill(data);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = data;

            grid.DataSource = bSource;
            //dataGrid.DataSource = data;
        }

        //Zatvaranje
        private void Form4_lista_FormClosing(object sender, FormClosingEventArgs e)
        {
            form3.form4_open = false;
            form3.load();
        }
        public void close()
        {
            this.Dispose();
        }

        private void zatvori_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        //brisanje
        public void noSQL(string s)
        {
            string strConnection = s;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = strConnection;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());
            }
        }
        public void eraseToday()
        {
            string s = "delete from poruke where datum=CURDATE();";
            string s1 = "delete from usluga where datum=CURDATE();";
            noSQL(s);
            noSQL(s1);
            MessageBox.Show("Sve današnje poruke su izbrisane");
        }
        public void eraseWeek()
        {
            string s = "delete from poruke where datum>=DATE_SUB(CURDATE(),INTERVAL 7 DAY);";
            string s1 = "delete from usluga where datum>=DATE_SUB(CURDATE(),INTERVAL 7 DAY);";
            noSQL(s);
            noSQL(s1);
            MessageBox.Show("Sve poruke iz zadnjih nedelju dana su izbrisane!");
        }
        public void eraseMonth()
        {
            string s = "delete from poruke where datum>=DATE_SUB(CURDATE(),INTERVAL 30 DAY);";
            noSQL(s);
            string s1 = "delete from usluga where datum>=DATE_SUB(CURDATE(),INTERVAL 30 DAY);";
            noSQL(s1);
            MessageBox.Show("Sve poruke iz zadnjih mjesec dana su izbrisane!");
        }
        public void eraseAll()
        {
            string s = "drop table poruke;";
            noSQL(s);
            s = "CREATE TABLE poruke(sms_id int primary key auto_increment,sms_br text,vrijeme time,datum date,status int);";
            noSQL(s);
            string s1 = "drop table usluga;";
            noSQL(s1);
            s1 = "CREATE TABLE usluga(usl_id int primary key auto_increment,sms_id int,txt_odgovor text,br_vozila int,vrijeme time,datum date);";
            noSQL(s1);
            MessageBox.Show("Sve poruke su izbrisane!");
        }

        private void danas_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete sve poruke za danasnji dan?", "Brisanje danasnjih poruka!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseToday();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void mjesec_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete sve poruke za ovaj mjesec?", "Brisanje poruka za zadnji mjesec!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseMonth();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void nedelja_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete sve poruke za ovu nedelju?", "Brisanje poruka za zadnju nedelju!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseWeek();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void sve_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da izbrisete sve poruke?", "Brisanje svih poruka!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseAll();
                    TextWriter t = File.CreateText("data.CONFIGX"); t.Close();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }
    }
}
