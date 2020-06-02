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
namespace SMS_Taxi
{
    public partial class Form2 : Form
    {
        Form mn;
        private MySqlConnection conn;
        public Form2(Form main)
        {
            mn = main;
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            mn.Visible = false;
            this.ActiveControl = maskedTextBox1;
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
        private bool isPwdOk(string pwd)
        {
            MySqlDataReader rdr = null;

            try
            {

                string stm = "SELECT count(*) FROM servis where admin_pass='{0}';";
                stm = string.Format(stm, pwd);
                MySqlCommand cmd = new MySqlCommand(stm, conn);
              //  rdr = cmd.ExecuteReader();
                if (int.Parse(cmd.ExecuteScalar().ToString())>0)
                    return true;
             //   while (rdr.Read())
             //   {
             //       int i = int.Parse(rdr.GetString(0));
              //  }

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
        private void runFm()
        {
            Form3 fm3 = new Form3(mn,this);
            fm3.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            potvrda();
        }
        private void potvrda()
        {
            Helper hl = new Helper();
            openConn();
            if (isPwdOk(hl.GetMd5Hash(MD5.Create(), maskedTextBox1.Text)))
            {
                runFm();
            }
            else
                MessageBox.Show("Pogrešna lozinka..");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mn.Visible = true;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            //mn.Visible = false;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                potvrda();
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                potvrda();
            } 
        }
    }
}
