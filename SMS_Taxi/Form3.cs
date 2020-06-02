using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
namespace SMS_Taxi
{
    public partial class Form3 : Form
    {
        private MySqlConnection conn;
        Form mn;
        Form fm;
        private DataTable data;
        private MySqlDataAdapter da;

        public bool form4_open = false; // aco
        private Form4_lista form4;
 
        private MySqlCommandBuilder cb;
        public Form3(Form main,Form fm2)
        {
            mn = main;
            fm = fm2;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string f = "insert into vozac values('','{0}');";
                f = string.Format(f, textBox1.Text);
                noSQL(f);
                ucitajVozace();
                updateStats();
            }
            else
                MessageBox.Show("Unesi broj vozila u polje iznad!");
        }
        void loadOdgovore()
        {
            MySqlDataReader rdr = null;
            listBox1.Items.Clear();
            try
            {

                string stm = "SELECT imav,nemav FROM config where c_id>0";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    textBox3.Text = rdr.GetString(0);
                    textBox4.Text = rdr.GetString(1);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Greška: {0}", ex.ToString());
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

            }
        }
        private void ucitajVozace()
        {
            MySqlDataReader rdr = null;
            listBox1.Items.Clear();
            try
            {

                string stm = "SELECT * FROM vozac";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   listBox1.Items.Add( rdr.GetString(1));
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: {0}", ex.ToString());
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

            }
        }
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
        public int getStat(string s)
        {
            string strConnection = s;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd = new MySqlCommand(s, conn);
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                return i<0?0:i;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());

            }
            return 0;
        }
        public void updateStats()
        {
            DateTime MyDateTime;
            MyDateTime = new DateTime();
            
            label3.Text = "Broj vozila: "+ getStat("select count(*) from vozac;").ToString();
            label4.Text = "Ukupan broj poruka: " + getStat("select count(*) from poruke;").ToString();
            label5.Text = "Broj odgovorenih poruka: " + getStat("select count(*) from poruke where status='1';").ToString();
            string q = "select start from servis where admin_id='1'";
            string q2 = getString(q);
            MyDateTime = DateTime.Parse(q2);
            string dt = MyDateTime.ToString("yyyy-MM-dd");
            q = string.Format("select count(*) from poruke where datum='{0}';", dt);
            label6.Text = "Br. poruka od pokretanja programa: "+getStat(q).ToString();

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            fm.Visible = false;
            load();
        }
        public void load()
        {
            fm.Visible = false;
            openConn();
            ucitajVozace();
            updateDG();
            updateStats();
            loadOdgovore();
        }
        private void openConn()
        {
            if (conn != null)
                conn.Close();
            Helper hl = new Helper();
            string connStr = String.Format("server={0};user id={1}; password={2}; database=sms_taxi; pooling=false",
                "localhost", "root", hl.base64Decode("bWFoYXJhZGph"));

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                // GetDatabases();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error connecting to the server: " + ex.Message);

            }
        }
        public void updateDG()
        {
            data = new DataTable();

            da = new MySqlDataAdapter("SELECT * FROM " + "usluga;", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(data);

            dataGrid.DataSource = data;
        }
        public DataTable updateDG2()
        {
            data = new DataTable();

            da = new MySqlDataAdapter("SELECT * FROM " + "usluga;", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(data);
            return data;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                string del = "delete from vozac where br_vozila='{0}';";
                del = string.Format(del, listBox1.SelectedItem.ToString());
                noSQL(del);
                ucitajVozace();
                updateStats();
            }
            else
                MessageBox.Show("Izaberi broj vozila iz liste klikom na broj.");
        }
        private bool isPwdOk(string pwd)
        {
            MySqlDataReader rdr = null;

            try
            {

                string stm = "SELECT count(*) FROM servis where admin_pass='{0}';";
                stm = string.Format(stm, pwd);
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                if (int.Parse(cmd.ExecuteScalar().ToString()) > 0)
                    return true;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: {0}", ex.ToString());
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

            }
            return false;
        }
        private void setPWD(string pass)
        {
            Helper hl = new Helper();
            string str = "update servis set admin_pass='{0}' where admin_id='1';";
            str = string.Format(str, pass);
            MySqlCommand cmd = new MySqlCommand();
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password je promijenjen.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Helper hl = new Helper();
            if (isPwdOk(hl.GetMd5Hash(MD5.Create(), maskedTextBox1.Text)))
            {
                if (maskedTextBox2.Text.Length > 2)
                {
                    setPWD(hl.GetMd5Hash(MD5.Create(), maskedTextBox2.Text));
                    
                }
                else
                    MessageBox.Show("Password mora imati više od 2 karaktera." + Environment.NewLine);
            }
            else
                MessageBox.Show("Stari password nije korektno unijet." + Environment.NewLine );
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            mn.Visible = true;
            if (form4_open) form4.close();
        }
        string getString(string q)
        {
            MySqlDataReader rdr = null;
            string rep = "";
            try
            {

                string stm = q;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rep=rdr.GetString(0);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: {0}", ex.ToString());
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

            }
            return rep;
        }

        private void button8_Click(object sender, EventArgs e)
        {

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
            s = "CREATE TABLE poruke(sms_id int primary key auto_increment,sms_br text,txt text,vrijeme time,datum date,status int);";
            
            noSQL(s);
            string s1 = "drop table usluga;";
            noSQL(s1);
            s1 = "CREATE TABLE usluga(usl_id int primary key auto_increment,sms_id int,txt_odgovor text,br_vozila int,vrijeme time,datum date);";
            noSQL(s1);
            MessageBox.Show("Sve poruke su izbrisane!");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete sve poruke za danasnji dan?", "Brisanje danasnjih poruka!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseToday();
                    updateStats();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if(MessageBox.Show("Da li ste sigurni da zelite da obrisete sve poruke za ovu nedelju?","Brisanje poruka za zadnju nedelju!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseWeek();
                    updateStats();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete sve poruke za ovaj mjesec?", "Brisanje poruka za zadnji mjesec!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseMonth();
                    updateStats();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stop.CONFIGX"))
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da izbrisete sve poruke?", "Brisanje svih poruka!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eraseAll();
                    updateStats();
                    TextWriter t = File.CreateText("data.CONFIGX"); t.Close();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Brisanje onemoguceno!");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string sql = "update config set imav='{0}', nemav='{1}' where c_id>0;";
            
            if (textBox3.Text.Length > 2 && textBox4.Text.Length > 2)
            {
                int sz1=textBox3.Text.Length;
                int sz2=textBox4.Text.Length;
                if (sz1 <= 75 && sz2 <= 75)
                {
                    sql = string.Format(sql, textBox3.Text, textBox4.Text);
                    noSQL(sql);
                    MessageBox.Show("Poruke su sacuvane!");
                }
                else
                    MessageBox.Show("Maksimalna dužina poruke je 75 karaktera.\nProbaj ponovo.");
            }
            else
                MessageBox.Show("Popuni sva polja, pa pokušaj ponovo.");
            
        }

        private void aco_ucitajVozace_Click(object sender, EventArgs e)
        {
            ucitajVozace();
        }

        private void dataGrid_MouseEnter(object sender, EventArgs e)
        {
            this.form4_show.Visible = true;
        }

        private void dataGrid_MouseLeave(object sender, EventArgs e)
        {
            this.form4_show.Visible = false;
        }

        private void form4_show_MouseEnter(object sender, EventArgs e)
        {
            this.form4_show.ForeColor = Color.MediumBlue;
        }

        private void form4_show_MouseLeave(object sender, EventArgs e)
        {
            this.form4_show.ForeColor = Color.Black;
        }

        private void form4_show_Click(object sender, EventArgs e)
        {
            form4 = new Form4_lista(this);
            form4.Show();
            form4_open = true;
        }

        private void dataGrid_MouseEnter_1(object sender, EventArgs e)
        {
            this.form4_show.Visible = true;
        }
        
    }
}
