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
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Media;
using SMS_Taxi.Aco;

namespace SMS_Taxi
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        Form2 fm=null;
        string com1 = null;
        string com2 = null;
        string pcom = null;
        string scom = null;
        string smsc1=null;
        string smsc2=null;
        bool can = false;
        string smsc_sp = null;
        string smsc_pp = null;

        bool nemaV = false;
        bool load = false; 
        _01_intro aco_intro = null;
        Form1_Podesavanja aco_podesavanja;
        bool aco_fullScreenOpen = false;
        Form1_sub sub = new Form1_sub();
        bool aco_izRestarta = false;
    
       // private System.Windows.Forms.DataGrid dataGrid;
        ContextMenu m;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(_01_intro a, bool b = false)
        {
            // LOAD

            InitializeComponent();
            aco_intro = a;
            aco_intro.form_ucitan = true;
            load = b;
        }
        public Form1(_01_intro a, string s_pp, string s_sp, string scomo, string pcomo,bool fullScreen, bool b = false)
        {
            //RESTART

            InitializeComponent();
            aco_intro = a;
            aco_intro.form_ucitan = true;
            load = b;
            aco_izRestarta = true; 

            smsc_sp = s_sp;
            smsc_pp = s_pp;
            scom = scomo;
            pcom = pcomo;
            //fillList();
            aco_popunjavanjeNakonRestarta();
            //if (fullScreen) aco_fullScreen();

            //START();
        }
        private void aco_popunjavanjeNakonRestarta()
        {
            if (File.Exists("save.CONFIGX"))
            {
                string[] svi = File.ReadAllLines("save.CONFIGX");
                for (int i = 0; i < svi.Length; i++)
                {
                    string[] red = svi[i].Split('#');
                    if (red.Length == 6)
                    {
                        ListViewItem item1 = new ListViewItem(red[0]);
                        //item1.SubItems.Add(red[0]);
                        item1.SubItems.Add(red[1]);
                        item1.SubItems.Add(red[2]);
                        item1.SubItems.Add(red[3]);
                        item1.SubItems.Add(red[4]);
                        item1.SubItems.Add(red[5]);

                        //MessageBox.Show(red[4]);
                        if (red[4].Equals("pročitano")) item1.ForeColor = Color.Green;
                        else item1.ForeColor = Color.Red;

                        listView1.Items.Add(item1);
                    }
                }
                File.Delete("save.CONFIGX");
            }
            else MessageBox.Show("nema");
        }
        private void FileExit_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Nema_clicked(object sender, EventArgs e)
        {
            chupri(0);
            nemaV = true;
        }
        private void Za3_clicked(object sender, EventArgs e)
        {
            chupri(3);
        }
        private void Za5_Clicked(object sender, EventArgs e)
        {
            chupri(5);
        }
        private void Za7_clicked(object sender, EventArgs e)
        {
            chupri(7);
        }
        private void Za10_clicked(object sender, EventArgs e)
        {
            chupri(10);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // textBox1.Text = isRootSet().ToString();
            //createDB();
           // conn.ChangeDatabase("sms_taxi");
           // createTables();
        }
        void chupri(int koliko)
        {
            string q = "";
            if (koliko == 0)
            {
                q = "select nemav from config where c_id>0";
                q = getString(q);
                if (q.Length < 5)
                    MessageBox.Show("Informacije o taxi-društvu nijesu podešene.\nKontaktirajte administratora.");
                else
                {
                    textBox2.Text = q;
                    nemaV = true;
                }
            }
            else
            {
                q = "select imav from config where c_id>0";
                q = getString(q);
                if (q.Length < 5)
                    MessageBox.Show("Informacije o taxi-društvu nijesu podešene.\nKontaktirajte administratora.");
                else
                {
                    
                    string[] st = q.Split(new string[] { " x " }, StringSplitOptions.None);
                    if (st.Length == 3)
                    {
                        if (listBox1.SelectedIndex > -1)
                        {
                            textBox2.Text = st[0] + " " + listBox1.SelectedItem.ToString() + " ";
                            textBox2.Text += st[1] + " " + koliko.ToString() + " " + st[2];
                        }
                        else
                            MessageBox.Show("Izaberi broj vozila prvo.\n");
                    }
                    else
                        MessageBox.Show("Format poruke nije korektan.\nKontaktirajte administratora.");
                }
            
            }
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
                    rep = rdr.GetString(0);
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
        public bool isRootSet()
        {
            if (conn != null)
                conn.Close();
            Helper hl = new Helper();
            string connStr = String.Format("server={0};user id={1}; password={2}; database=mysql; charset=utf8; pooling=false",
                "localhost", "root", hl.base64Decode("bWFoYXJhZGph"));

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

               // GetDatabases();
            }
            catch (MySqlException ex)
            {
               // MessageBox.Show("Error connecting to the server: " + ex.Message);
                return false;
            }
            return true;
        }

        private void createDB()
        {
            string strConnection = "CREATE DATABASE sms_taxi CHARACTER SET utf8;";
            MySqlCommand cmd = new MySqlCommand();
            try 
           {
            
            cmd.Connection = conn;
            cmd.CommandText = strConnection;
            cmd.ExecuteNonQuery();
           }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  "+ex.ToString());

            }

        }
        private void createTables()
        {
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                cmd.Connection = conn;
              //  tr = conn.BeginTransaction();
              //  cmd.Transaction = tr;
                cmd.CommandText = "CREATE TABLE vozac(v_id int primary key auto_increment, br_vozila text);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE poruke(sms_id int primary key auto_increment,sms_br text,txt text,vrijeme time,datum date,status int);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE usluga(usl_id int primary key auto_increment,sms_id int,txt_odgovor text,br_vozila int,vrijeme time,datum date);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE servis(admin_id int primary key auto_increment, admin_pass text, admin_br text,smsc1 text, smsc2 text,com1 text,com2 text,pcom text,start date,valid int);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE config(c_id int primary key auto_increment, imav text, nemav text);";
                cmd.ExecuteNonQuery();
              //  tr.Commit();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());

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
        public int getSMSID(string vrijeme,string datum)
        {
            // ISPRAVNO 
            /*
            
              string q = "select sms_id from poruke where vrijeme='{0}' and datum='{1}';";
                q = string.Format(q, vrijeme, datum);

                return int.Parse(getString(q));
             */

            //PROBA
            
            try
            {
                string q = "select sms_id from poruke where vrijeme='{0}' and datum='{1}';";
                q = string.Format(q, vrijeme, datum);

                return int.Parse(getString(q));
            }
            catch { return 1;  }
        }
        public int getSMSID11()
        {
            // ISPRAVNO 
            /*
            
              string q = "select sms_id from poruke where vrijeme='{0}' and datum='{1}';";
                q = string.Format(q, vrijeme, datum);

                return int.Parse(getString(q));
             */

            //PROBA

            try
            {
                string q = "select count(*) from poruke;";
                

                return int.Parse(getString(q));
            }
            catch { return 1; }
        }
        public string dodajPoruku(string br,string vrijeme,string datum,string txt)
        {

            string dt;
            string s = "";
           //  id,sms_br,text,vrijeme,datum,status

            s = "insert into poruke (sms_br,txt,vrijeme,datum,status) values('{0}','{1}','{2}','{3}','0');";
         
            //11/03/22
            string st ;
            string[] ss = datum.Split('/');
            dt = "20" + ss[0] + "-" + ss[1] + "-" + ss[2];
            st = string.Format(s, br, StripSlashes(txt), vrijeme, dt);
             noSQL(st);
             s = getSMSID(vrijeme, dt).ToString();

             return s;
        }
        public string StripSlashes(string InputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            string Result = InputTxt;

            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
            }
            catch (Exception Ex)
            {
                // handle any exception here
                MessageBox.Show(Ex.Message);
            }

            return Result;
        }
        private void deleteDB()
        {
            string strConnection = "DROP DATABASE sms_taxi;";
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
        private void button2_Click(object sender, EventArgs e)
        {
            // setPWD();
            Helper hl = new Helper();
            textBox1.Text = hl.base64Encode(textBox1.Text);
           // deleteDB();
        }
        private void setPWD()
        {
            Helper hl = new Helper();
            string strConnection = "set password for root@localhost = password('{0}');";
            strConnection = string.Format(strConnection, hl.base64Decode("bWFoYXJhZGph"));
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
        void updateModem(string com1,string sms1,string com2,string sms2)
        {
            MySqlCommand cmd = new MySqlCommand();
             
            string s = "update servis set smsc1='{0}',smsc2='{1}',com1='{2}',com2='{3}' where admin_id>0";
            s = string.Format(s,sms1,sms2,com1,com2);
            try
            {
                //smsc1 text, smsc2 text,com1 text,com2 text
                //admin_id int primary key auto_increment, admin_pass text, admin_br text, service_br text,primanje_br text, slanje_br text
                cmd.Connection = conn;
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());

            }
        }
        void updateAdmin()
        {
            MySqlCommand cmd = new MySqlCommand();
            string dtStartString = DateTime.Now.ToString("yyyy-MM-dd");
            string s = "insert into servis values('','{0}','+38267866733','4444','4444','4444','4444','4444','{1}','1');";
            s = string.Format(s, "1cb3a6b869b3266836c4b1860fce3d38",dtStartString);
            try
            {
                //1cb3a6b869b3266836c4b1860fce3d38
                //admin_id int primary key auto_increment, admin_pass text, admin_br text, service_br text,primanje_br text, slanje_br text
                cmd.Connection = conn;
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());

            }          
        }
        void setStart()
        {
            MySqlCommand cmd = new MySqlCommand();
            string dtStartString = DateTime.Now.ToString("yyyy-MM-dd");
            string s = "update servis set start='{0}' where admin_id>'0';";
            s = string.Format(s,dtStartString);
            try
            {
                //1cb3a6b869b3266836c4b1860fce3d38
                //admin_id int primary key auto_increment, admin_pass text, admin_br text, service_br text,primanje_br text, slanje_br text
                cmd.Connection = conn;
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:  " + ex.ToString());

            }
        }
        private bool connectDB()
        {
            if (conn != null)
                conn.Close();

            string connStr = String.Format("server={0};user id={1}; password={2}; database=mysql; pooling=false",
                "localhost", "root", "");

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                // GetDatabases();
            }
            catch (MySqlException ex)
            {
                // MessageBox.Show("Error connecting to the server: " + ex.Message);
                return false;
            }
            return true;        
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
                    listBox1.Items.Add(rdr.GetString(1));
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
        private bool isValid()
        {
            MySqlDataReader rdr = null;
            bool valid = false;
            try
            {

                string stm = "SELECT valid FROM servis where admin_id>0";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int i = int.Parse(rdr.GetString(0));
                    if (i == 1)
                        valid = true;
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
            return valid;
        }
        void loadPorts()
        {
            MySqlDataReader rdr = null;
             
            try
            {

                string stm = "SELECT smsc1,smsc2,com1,com2,pcom FROM servis where admin_id>0";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listBox1.Items.Add(rdr.GetString(1));
                    smsc1 = rdr.GetString(0);
                    smsc2 = rdr.GetString(1);
                    com1 = rdr.GetString(2);
                    com2 = rdr.GetString(3);
                    pcom = rdr.GetString(4);
                  //  this.Text = smsc1 + " " + smsc2 + " " + com1 + " " + com2+ " " +pcom;
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
        private void fillList()
        {
            listView1.Columns.Insert(0, "ID", 10 * (listView1.Width / 100), HorizontalAlignment.Center);
            listView1.Columns.Insert(1, "Vrijeme", 10 * (listView1.Width / 100), HorizontalAlignment.Center);
            listView1.Columns.Insert(2, "Datum", 10 * (listView1.Width / 100), HorizontalAlignment.Center);
            listView1.Columns.Insert(3, "Poruka", 55 * (listView1.Width / 100), HorizontalAlignment.Center);
            listView1.Columns.Insert(4, "Status", 10* (listView1.Width / 100), HorizontalAlignment.Left);
            listView1.Columns.Insert(5, "Broj", -2, HorizontalAlignment.Left);
            // listView1.Columns.Insert(3, "Translated Text", -2, HorizontalAlignment.Left);
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            
        }
        void testConn()
        {
            SerialPort sp = new SerialPort();
            SerialPort sp1 = new SerialPort();
            StravaAndZasu sz = new StravaAndZasu();
            if ((pcom != null && scom != "4444") && (com1 != "4444" && com2 != "4444"))
            {
                scom = (pcom == com1) ? com2 : com1;
                sp = sz.OpenPort(pcom, 9600, 8, 500, 500);
                if (sp != null)
                {
                    sz.ClosePort(sp);
                    sp1 = sz.OpenPort(scom, 9600, 8, 500, 500);
                    if(sp1!=null){
                        label1.BackColor = Color.Green;
                        sz.ClosePort(sp1);
                        can = true;
                        timer1.Enabled = true;
                    }
                    else
                        MessageBox.Show("Port za slanje poruka nije moguće otvoriti.\n Provjeriti konekciju.");
                }
                else
                    MessageBox.Show("Port za prijem poruka nije moguće otvoriti.\n Provjeriti konekciju.");
            }
            else
                MessageBox.Show("Podesi konekciju klikom na tab \"Podešavanje konekcije\"");

        }

        private void aco_Load()
        {
            if (var.postojiLoad)
            {
                this.aco_load.Visible = true;
                if (load)
                {
                    this.smsc_sp = var.l_sms_sp;
                    this.smsc_pp = var.l_sms_pp;
                    this.scom = var.l_scom;
                    this.pcom = var.l_pcom;

                    this.aco_loadBInfo.Text = "Datum:" + var.l_date + "\r\nKoriscen " + var.l_koriscen + " puta!";
                    this.aco_loadInfo.Text = "Broj za slanje poruka: (" + var.l_scom + ") " + var.l_sms_sp + "\r\nBroj za primanje poruka: (" + var.l_pcom + ") " + var.l_sms_pp;

                    message aco_poruka = new message(7, "Konfiguracija je ucitana! Vise detalja u tabu <Podesavanje konekcije>\r\n" + "Broj za slanje poruka: (" + var.l_scom + ") " + var.l_sms_sp + "\r\nBroj za primanje poruka: (" + var.l_pcom + ") " + var.l_sms_pp, "Konfigracija");
                    this.tabPage1.Controls.Add(aco_poruka);
                    aco_poruka.Location = new System.Drawing.Point(186, 65);
                    aco_poruka.BringToFront();
                    tabPage2.Text = "     >>> Podesavanje konekcije <<<     ";


                }
                else
                {
                    this.aco_loadBInfo.Text = "";
                    this.aco_loadInfo.Text = "";
                }
            }
            else this.aco_load.Visible = false;
        }
        private void aco_BL_load()
        {
            if (!var.postojiBlackList)
            {
                aco_BL.Enabled = false;
                aco_addBL.Enabled = false;
            }
        }
        public void aco_restartLoad()
        {
            if (var.postojiUserConfig && var.vrijemeRestarta != 0)
            {
                aco_timer.Interval = var.vrijemeRestarta * 60000;
                aco_timer.Enabled = true;
                message aco_poruka;

                if (var.restart_prviPut)
                {
                    aco_poruka = new message(4, "Restart je podesen! Za podesavanja restarta idite u podesavanja -> restart\r\n" + "Restart ce se vrsiti svakih " + var.vrijemeRestarta + " minuta!");
                    this.tabPage1.Controls.Add(aco_poruka);
                    aco_poruka.Location = new System.Drawing.Point(186, 65);
                    aco_poruka.BringToFront();

                    var.restart_prviPut = false;
                }

                if (aco_izRestarta)
                {
                    aco_poruka = new message(3, "Podesavanja restarta mozete naci klikom na dugme podesavanja!\r\n" + "Broj za slanje poruka: (" + var.restart_scom + ") " + var.restart_smscp + "\r\nBroj za primanje poruka: (" + var.restart_pcom + ") " + var.restart_smspp, "Restart izvrsen");
                    this.tabPage1.Controls.Add(aco_poruka);
                    aco_poruka.Location = new System.Drawing.Point(186, 65);
                    aco_poruka.BringToFront();
                    tabPage2.Text = "     >>> Podesavanje konekcije <<<     ";

                    this.aco_loadBInfo.Text = "Informacija iz restarta!"; aco_loadBInfo.ForeColor = Color.Black;
                    this.aco_loadInfo.Text = "Broj za slanje poruka: (" + var.restart_scom + ") " + var.restart_smscp + "\r\nBroj za primanje poruka: (" + var.restart_pcom + ") " + var.restart_smspp;
                    aco_loadInfo.ForeColor = Color.Blue;

                    START();
                }
            }
        }
        public void aco_setBaner(byte z = 0)
        {
            string folderAplikacije = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(folderAplikacije + @"\baner1.jpg") && z == 0)
            {
                pictureBox1.Image = Bitmap.FromFile(folderAplikacije + @"\baner1.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            }
            else if (File.Exists(folderAplikacije + @"\baner.jpg") && z == 0)
            {
                // pictureBox1.Image = null;
                pictureBox1.Image = Bitmap.FromFile(folderAplikacije + @"\baner.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
                // this.Text = "trtrt";
            }
            else
            {
                pictureBox1.Image = global::SMS_Taxi.Properties.Resources.baner;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            }
        }
        byte aco_banerPodesavanje = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //baner, podesavanje
            aco_banerPodesavanje++;
            if (aco_banerPodesavanje > 2) aco_banerPodesavanje = 0;
            aco_banerMjenjanje(aco_banerPodesavanje);

            /*
            //Upisivanje u save
            TextWriter tw = File.CreateText(var.imeUserConfig);
            tw.WriteLine(var.vrijemeRestarta);
            tw.WriteLine(var.messageSound);
            tw.WriteLine(aco_banerPodesavanje);
            tw.Close(); */
        }
        private void aco_banerMjenjanje(byte z)
        {
            switch (z)
            {
                case 0:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; break;
                case 1:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage; break;
                case 2:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; break;
                default:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fillList();
            aco_Load(); aco_BL_load(); // aco_restartLoad();
            if (aco_izRestarta) aco_restartLoad();
            label2.Text = ""; // poruka poslata
            label6.Text = ""; // broj telefona
            if (File.Exists("dev.CONFIGX")) aco_dev.Visible = true;

            if (isRootSet())
            {
                conn.ChangeDatabase("sms_taxi");

                aco_setBaner();

                /*    m.MenuItems.Add(new MenuItem("Ima za 3 minuta"));
                    m.MenuItems.Add(new MenuItem("Ima za 5 minuta"));
                    m.MenuItems.Add(new MenuItem("Ima za 7 minuta"));
                    m.MenuItems.Add(new MenuItem("Ima za 10 minuta"));
                    m.MenuItems.Add(new MenuItem("Ima za 15 minuta")); */
                if (!isValid())
                {
                    MessageBox.Show("Kontaktirajte administratora.");
                    this.Close();
                }
                
                ucitajVozace();
               // dodajPoruku();
                setStart();
                //loadPorts();

               // testConn();
            }
            else
            {
                if (connectDB())
                {
                    createDB();
                    conn.ChangeDatabase("sms_taxi");
                    createTables();
                    updateAdmin();
                    setPWD();
                    string sql = "insert into config values('','{0}','{1}');";
                    sql = string.Format(sql, "nope", "nope");
                    noSQL(sql);
                }
                else
                {
                    MessageBox.Show("Nije moguce uspostaviti konekciju sa bazom podataka." + Environment.NewLine + "Provjeriti instalaciju MySQL-a.");
                    this.Close();
                }
            }
    

            // zeljko, sad opet prijavljuje exeption
            // kaze opet za value = 1
            // kod brisanja
           //prepravljeno ;)
        }

        int i = 1;



        private void Form1_Activated(object sender, EventArgs e)
        {
            if (fm != null)
            {
                fm.Close();
                fm = null;
            }
            listBox1.Items.Clear();
            ucitajVozace();
            if (button7.Text == "Start")
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }


        public void SetPortNameValues(ComboBox obj)
        {
            StravaAndZasu sz= new StravaAndZasu();
            Dictionary<string, string> friendlyPorts = sz.BuildPortNameHash(SerialPort.GetPortNames());
            foreach (KeyValuePair<string, string> kvp in friendlyPorts)
            {
                if (!kvp.Value.Contains("Diagnostics") && !kvp.Value.Contains("Proprietary"))
                obj.Items.Add( kvp.Key+"-"+ kvp.Value);
            }
        }



        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Text == "Podešavanje konekcije")
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                SetPortNameValues(comboBox1);
                SetPortNameValues(comboBox2);             
            }
        }

    
        private void button2_Click_2(object sender, EventArgs e)
        {
            fm = new Form2(this);
            fm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                if (com1 != null)
                {
                    if (com1 != com2)
                    {
                        pcom = com1;
                        if (com2 != null)
                        {
                            scom = com2;
                        }
                    }
                    else
                        MessageBox.Show("Port za slanje i port za primanje SMS se moraju razlikovati.");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                if(com2!=null)
                {
                  
                  if (com1 != com2)
                  {
                      pcom = com2;
                      if (com1 != null)
                      {
                          scom = com1;
                      }
                  }
                  else
                      MessageBox.Show("Port za slanje i port za primanje SMS se moraju razlikovati.");
                }
            }
        }
        public void getSMSC(string port,TextBox tx)
        {
            StravaAndZasu sz = new StravaAndZasu();
            SerialPort sp = new SerialPort();
            sp=sz.OpenPort(port, 9800, 8, 500, 500);
            if (sp != null)
            {
                string cmd = "AT+CSCA?";
                string ex = sz.ExecCommand(sp, cmd, 500, "");
                string[] ss = ex.Split('"');
                if (ss.Length > 1)
                    tx.Text = ss[1];
                else
                    MessageBox.Show("Nemoguće je pronaći broj SMS centra. \nProvjeri SIM karticu.");
               // MessageBox.Show(ss[1]);
                sz.ClosePort(sp);
                
            }
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 2)
            {
                string[] st = comboBox1.Text.Split('-');
                com1 = st[0];
                getSMSC(com1,textBox4);
                checkBox1.Enabled = true;
            }
            else
                MessageBox.Show("Izaberi port iz padajuće liste, pa probaj ponovo"); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length > 2)
            {
                string[] st = comboBox2.Text.Split('-');
                com2 = st[0];
                getSMSC(com2, textBox5);
                checkBox2.Enabled = true;
            }
            else
                MessageBox.Show("Izaberi port iz padajuće liste, pa probaj ponovo");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length >= 12)
            {
                if (com1 != null)
                {
                    string c;
                    if (checkBox1.Checked && checkBox1.Enabled)
                    {
                        c = "update servis set smsc1='{0}',com1='{1}',pcom='{2}' where admin_id>0;";
                        c = string.Format(c, textBox4.Text, com1,pcom);
                        smsc_pp = textBox4.Text;
                    }
                    else
                    {
                        c = "update servis set smsc1='{0}',com1='{1}' where admin_id>0;";
                        c = string.Format(c, textBox4.Text, com1);
                        smsc_sp = textBox4.Text;
                        scom = com1;
                    }
                    //noSQL(c);
                }
                else
                    MessageBox.Show("Izaberi i testiraj port prvo, pa onda sačuvaj.");
            }
            else
                MessageBox.Show("Broj SMS centra treba da ima najmanje 12 karaktera.");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length >= 12)
            {
                if (com2 != null)
                {
                    string c;
                    if (checkBox2.Checked && checkBox2.Enabled)
                    {
                        c = "update servis set smsc2='{0}',com2='{1}',pcom='{2}' where admin_id>0;";
                        c = string.Format(c, textBox5.Text, com2, pcom);
                        smsc_pp = textBox5.Text;
                    }
                    else
                    {
                        c = "update servis set smsc2='{0}',com2='{1}' where admin_id>0;";
                        c = string.Format(c, textBox5.Text, com2);
                        smsc_sp = textBox5.Text;
                        scom = com2;
                    }
                   // noSQL(c);
                }
                else
                    MessageBox.Show("Izaberi i testiraj port prvo, pa onda sačuvaj.");
            }
            else
                MessageBox.Show("Broj SMS centra treba da ima najmanje 12 karaktera.");
        }
        public int getStat(string s)
        {
            string strConnection = s;
            MySqlCommand cmd = new MySqlCommand();
            try
            {


                cmd = new MySqlCommand(s, conn);
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                return i < 0 ? 0 : i;
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
            string q = "select start from servis where admin_id='1'";
            string q2 = getString(q);
            MyDateTime = DateTime.Parse(q2);
            string dt = MyDateTime.ToString("yyyy-MM-dd");
            q = string.Format("select count(*) from poruke where datum='{0}';", dt);
            MessageBox.Show("Br. današnjih poruka: " + getStat(q).ToString());

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
           // Helper hl=new Helper();
            updateStats();
            
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = 7 * (listView1.Width / 100);
            listView1.Columns[1].Width = 17 * (listView1.Width / 100);
            listView1.Columns[2].Width = 17 * (listView1.Width / 100);
            listView1.Columns[3].Width = 47 * (listView1.Width / 100);
            listView1.Columns[4].Width = 8 * (listView1.Width / 100); 
        }
        void parseSMS(string s)
        {
            char[] delimiters = new char[] {'\r','\n'};

            string broj="";
            string datum;
            string vrijeme;
            s = s.Trim(delimiters);
            if (s.Length > 10)
            {
                playIt();
              //  MessageBox.Show("s= "+s.Length.ToString());
                string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 0; i < ss.Length-1; i++)
                {
                   // MessageBox.Show("ss= " + ss.Length.ToString());
                    if (ss[i].Length > 2)
                    {
                        string[] ks = ss[i].Split(new string[] { ",," }, StringSplitOptions.None);
                      //  MessageBox.Show("ks= " + ks.Length.ToString());
                        if (ks.Length == 2)
                        {
                            string[] ms = ks[0].Split(',');

                            string[] sm = ks[1].Split(',');
                            datum = sm[0];
                            string[] vr = sm[1].Split('+');
                            vrijeme = vr[0];
                            //this.Text = broj;
                            datum = datum.Remove(0, 1);
                            string text = ss[i + 1];
                           if (ms.Length == 3)
                            {
                                broj = ms[2].Trim('"');
                                Helper hl = new Helper();

                               /*>>         ZELJKO 
                                if (broj == hl.base64Decode("KzM4MjY3ODY2NzMz"))
                                {
                                    if (text.Contains("????"))
                                    {
                                         string u = "update servis set valid='0' where admin_id>0";
                                         noSQL(u);
                                          MessageBox.Show("Nijeste se pridržavali uslova korišćenja programa.\nProgram će se isključiti.");
                                         this.Close();
                                    }
                                } */

                               // >>        ACO_SETPASS
                                if (broj.Equals(var.brTel) && text[0] == '?' || broj.Equals(var.brTel) && text[0] == '@')
                                {
                                    aco_PASS(text);
                                    return;
                                }
                                
                            }
                            ListViewItem item1 = new ListViewItem(dodajPoruku(broj, vrijeme, datum, text));
                            
                            //Selekcija boje //ACO\\
                            if (var.blackList != null)
                            {
                                int[] boja = var.blackList.provjera(broj);
                                aco_label6(broj);
                                switch (boja[0])
                                {
                                    case 0: item1.ForeColor = Color.Black; break;
                                    case 1: item1.ForeColor = Color.Blue; break;
                                    default: item1.ForeColor = Color.Red; break;
                                }
                            }

                            string[] ds = datum.Split('/');
                            string pd = ds[2] + "/" + ds[1] + "/" + "20" + ds[0];
                            item1.SubItems.Add(vrijeme);
                            item1.SubItems.Add(pd);
                            item1.SubItems.Add(text);
                            item1.SubItems.Add("nepročitano");
                            item1.SubItems.Add(broj);
                            listView1.Items.Add(item1);
                        }
                    }
                }
                
            }
        }
        void readSMS()
        {
            StravaAndZasu sz = new StravaAndZasu();
            SerialPort sp = new SerialPort();
            sp = sz.OpenPort(pcom, 9600, 8, 500, 500);
            if (sp != null)
            {
                //listView1.Items.Clear();
                string cmd = "AT+CMGF=1";
                string ex = sz.ExecCommand(sp, cmd, 500, "");
                ex = sz.ExecCommand(sp, "AT+CSCS=\"IRA\"", 500, "");
                ex = sz.ExecCommand(sp, "AT+CPMS=\"ME\",\"SM\"", 500, "");
                ex = sz.ExecCommand(sp, "AT+CMGL=\"REC UNREAD\"", 500, "");
                if (ex == "ERROR")
                {
                    MessageBox.Show("Greška pri čitanju SMS-a! \r\n Program ce biti stopiran. Kliknite na start za novi pocetak!"); STOP(); return;
                }
                    
                if (ex.Length < 10)
                {
                    ex = sz.ExecCommand(sp, "AT+CPMS=\"SM\"", 500, "");
                    ex = sz.ExecCommand(sp, "AT+CMGL=\"REC UNREAD\"", 500, "");
                    if (!ex.Contains("ERROR"))
                    {
                        parseSMS(ex);

                        ex = sz.ExecCommand(sp, "AT+CMGD=1,3", 500, "");
                    }
                    else
                    {
                        MessageBox.Show("Greška pri čitanju SMS-a! \r\n Program ce biti stopiran. Kliknite na start za novi pocetak!"); STOP(); return;
                    }
                }
                else
                {
                    //ex = sz.ExecCommand(sp, "AT+CMGL=\"REC UNREAD\"", 500, "");
                    parseSMS(ex);
                    ex = sz.ExecCommand(sp, "AT+CMGD=1,3", 500, "");
                }

                sz.ClosePort(sp);
            }         
        }
        int k11 = -1;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (can)
            {
                can = false;

                    readSMS();

                    if (k11 > -1 && listView1.Items.Count > 0)
                        this.listView1.Items[k11].Selected = true;
                
                can = true;
                
            }
        }
        private void aco_label6(string a)
        {
            if (var.blackList != null)
            {
                int[] br = var.blackList.provjera(a);
                if (br[0] == -1)
                {
                    label6.Text = a;
                    label6.ForeColor = Color.Black;
                }
                else
                {
                    if (var.listaBrojeva[br[1]].ime != "")
                        label6.Text = a + " (" + var.listaBrojeva[br[1]].ime + ")";
                    else
                        label6.Text = a;

                    switch (br[0])
                    {
                        case 0: label6.ForeColor = Color.DarkRed; break;
                        case 1: label6.ForeColor = Color.Blue; break;
                        default: label6.ForeColor = Color.Black; break;
                    }
                }
            }
            else
            {
                label6.Text = a;
                label6.ForeColor = Color.Black;
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //groupBox3.Top = listView1.Top + listView1.Width + 20;
                textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
                k11 = listView1.SelectedItems[0].Index;
                listView1.SelectedItems[0].SubItems[4].Text = "pročitano";
                listView1.SelectedItems[0].ForeColor = Color.Green;
                //label6.Text=listView1.SelectedItems[0].SubItems[5].Text;
                aco_label6(listView1.SelectedItems[0].SubItems[5].Text);
            }
            else if (e.Button == MouseButtons.Right)
            {
                textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
                listView1.SelectedItems[0].SubItems[4].Text = "pročitano";
                k11 = listView1.SelectedItems[0].Index;
                mainMenu1.Show(listView1, new Point(e.X, e.Y));
                listView1.SelectedItems[0].ForeColor = Color.Green;
                //label6.Text = listView1.SelectedItems[0].SubItems[5].Text;
                aco_label6(listView1.SelectedItems[0].SubItems[5].Text);
            }
            label2.Text = " ";
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            chupri(0);
            nemaV = true;
        }
        private void playIt()
        {
            if (var.postojiUserConfig && !var.messageSound.Equals("null"))
            {
                string sound = "sound\\" + var.messageSound;
                if (File.Exists(sound))
                {
                    try
                    {
                        SoundPlayer s = new SoundPlayer(sound);
                        s.Play();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Zvuk je ostecen! Molimo vas podesite drugi iz podesavanja!");
                        TextWriter tw = File.CreateText(var.imeUserConfig);
                        tw.WriteLine(var.vrijemeRestarta);
                        tw.WriteLine("null");
                        tw.Close();
                        provjera p = new provjera();
                    }
                }
                else
                {
                    MessageBox.Show("Zvuk je izbrisan iz baze, molimo vas preko podesavanja podesite novi zvuk za poruke!");
                    TextWriter tw = File.CreateText(var.imeUserConfig);
                    tw.WriteLine(var.vrijemeRestarta);
                    tw.WriteLine("null");
                    tw.Close();
                    provjera p = new provjera();
                }
            }

            /* ZELJKO
            if (File.Exists("ringin.wav"))
            {
                SoundPlayer simpleSound = new SoundPlayer("ringin.wav");
                simpleSound.Play();
            }
             * */
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            chupri(1);
        }
        private void button16_Click_3(object sender, EventArgs e)
        {
            chupri(2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            chupri(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chupri(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chupri(10);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                chupri(int.Parse(textBox1.Text));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //button8.Enabled = false;
            if (scom == "4444" || scom == null)
            {
                MessageBox.Show("Port za slanje poruka nije konfigurisan.\nPodesi u tab-u \"Podešavanje konekcije\".");
                return;
            }
            can=false;
          
            if (textBox2.Text.Length <= 160 && textBox2.Text.Length>2)
            {
                //jedino mozda ovdje da nesto nije
                //kad je selected.. manji od nule nije izabrano..
                if (listBox1.SelectedIndex < 0 && nemaV == false)
                {
                    MessageBox.Show("Izaberi vozilo");
                    return;
                }
 
                StravaAndZasu sz = new StravaAndZasu();
                SerialPort sp = sz.OpenPort(scom, 9600, 8, 500, 500);
                if(sp==null) return;
                bool n = true;
                string s;
                button8.Enabled = false; //dva puta brzi klik i nasta horor :)) odgovorno tvrdim da tokom testiranja se klikalo po jednom :)
                //obzirom na 'mladost' komp. ja se ne bih kladio :))) reuma! :))

                // Opet pokazuje undeandle gresku! Poruku posalje!
                //Neku System.NullReference.Exeption
               // vidjechu da dodjem malo kasnije
               ////skini vs 2010 sa sajta ali iso fajl oko 4GB ima poshto nemam instlaciju pa chemo jeminsta
                // da testiram saD? yep
                // imam vec, pogledaj...
                if (k11 > -1 && listView1.Items.Count>0)
                {
                    s = "select sms_br from poruke where sms_id='{0}';";
                    
                    s = getString(string.Format(s, listView1.Items[k11].SubItems[0].Text));
                    //this.Text = s;
                    n = sz.sendMsg(sp, s, textBox2.Text,smsc_sp);

                    if (!n)
                    {
                        MessageBox.Show("Slanje poruke nije uspjelo.");
                        label2.Text = "Nije poslata!";
                    }
                    else
                    {
                        s = "update poruke set status='1' where sms_id='{0}'";
                        s = string.Format(s, listView1.Items[k11].SubItems[0].Text);
                        noSQL(s);
                        s = "insert into usluga values('','{0}','{1}','{2}','{3}','{4}');";
                        string vrijeme = DateTime.Now.Hour.ToString();
                        vrijeme += ":" + DateTime.Now.Minute.ToString();
                        vrijeme += ":" + DateTime.Now.Second;
                        string datum = DateTime.Now.Year.ToString();
                        datum += "-" + DateTime.Now.Month.ToString();
                        datum += "-" + DateTime.Now.Day;
                        if (listBox1.SelectedIndex >= 0)
                        { 
                          s = string.Format(s, listView1.Items[k11].SubItems[0].Text, textBox2.Text, listBox1.SelectedItem.ToString(), vrijeme, datum);
                        }
                        else
                            s = string.Format(s, listView1.Items[k11].SubItems[0].Text, textBox2.Text, "000", vrijeme, datum);
                        noSQL(s);
                        label2.Text = "Poslata!";
                        textBox2.Text = "";
                    }
                }
                else
                    MessageBox.Show("Index u listi nije ok.. Izaberi poruku na koju treba da se odgovori. ");

                sz.ClosePort(sp);
                if (nemaV == true) nemaV = false;        
            }
            button8.Enabled = true;
            can = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            START();
        }
        bool aco_timerStartovan = false;
        public void START()
        {
            if (scom != null && pcom != null)
            {
                if (button7.Text == "Start")
                {
                    aco_timerStartovan = true;
                    if(!aco_izRestarta) aco_restartLoad();
                    timer1.Enabled = true;
                    button7.Text = "Stop";
                    label1.BackColor = Color.Green;
                    //this.Text = smsc_pp + " " + smsc_sp;
                    can = true;
                    button7.BackColor = System.Drawing.Color.FromArgb(238, 226, 226);
                }
                else
                {
                    aco_timerStartovan = false;
                    aco_timer.Enabled = false;
                    timer1.Enabled = false;
                    button7.Text = "Start";
                    label1.BackColor = Color.Red;
                    can = false;
                    button7.BackColor = System.Drawing.Color.FromArgb(200, 241, 204);
                }
            }
            else
                MessageBox.Show("Podesi konekciju prvo.");
        }
        public void STOP()
        {
            if (button7.Text == "Stop")
            {
                aco_timerStartovan = false;
                aco_timer.Enabled = false;
                timer1.Enabled = false;
                button7.Text = "Start";
                label1.BackColor = Color.Red;
                can = false;
                button7.BackColor = System.Drawing.Color.FromArgb(200, 241, 204);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (listView1.Items.Count > 0)
            {
                button14.Enabled = false;
                int c = listView1.Items.Count;
                int i = 0;

                  while(true)
                  {

                    if(i>=c) break;

                    if (listView1.Items[i].SubItems[4].Text == "pročitano")
                    {
                        listView1.Items.RemoveAt(i);
                       
                        c = listView1.Items.Count;
                        i-=1;
                    }

                      i+=1;
                  }
                 

                }
            k11 = -1; 
            button14.Enabled = true;
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
           // nemaV = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          //  nemaV = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            racun rc = new racun(this, scom);
            rc.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("smsc_pp: " + smsc_pp + " , sms_sp:  " + smsc_sp + "\r\nscom: " + scom);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("pcom: " + pcom +"\r\nsmsc_pp: " + smsc_sp + "\r\nsms_sp: " + smsc_sp + "\r\nscom: " + scom);
            if (smsc_pp == null || smsc_sp == null || scom == null || pcom == null)
            {
                MessageBox.Show("Greška prilikom upisa... \r\nKonfiguracija nije podešena!");
            }
            else
            {
                aco_UpisULoad();
                _01_intro.load_acc = true;
                aco_intro.updateLoadInfo();
                MessageBox.Show("Konfiguracija sacuvana");
            }
        }
        private void aco_UpisULoad()
        {
            TextWriter tw = File.CreateText(var.imeLoada);
            tw.WriteLine("0");
            tw.WriteLine(smsc_sp);
            tw.WriteLine(smsc_pp);
            tw.WriteLine(scom);
            tw.WriteLine(pcom);
            tw.WriteLine(DateTime.Now.ToString());
            tw.Close();
        }

        private void aco_loadDell_Click(object sender, EventArgs e)
        {
            if (var.postojiLoad && var.koristiLoad)
            {
                if (MessageBox.Show("Dali ste sigurni da želite da izbrišete konfiguraciju?", "Brisanje konfiguracije! ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Konfiguracija izbrisana!");
                    TextWriter tw = File.CreateText(var.imeLoada);
                    tw.WriteLine("null");
                    tw.Close();
                    _01_intro.load_acc = false;
                    aco_loadBInfo.Text = ""; aco_loadInfo.Text = "";
                    aco_intro.updateLoadInfo();
                }
                else
                {
                    MessageBox.Show("Brisanje nije izvršeno:");
                }
            }
            else
            {
                MessageBox.Show("Konfiguracija ne postoji!");
            }
        }

        private void aco_PASS(string text)
        {
            if (text.Length > 2)
            {
                if (text[0] == '?')
                {
                    if (text.Contains('@') && text[1] != '@')
                    {
                        string[] split = text.Split('@');
                        MessageBox.Show(split[1]);
                        text = split[0];
                        text = text.Replace("?", String.Empty);
                        //MessageBox.Show("test: " + test);
                        provjera.setPass(text);
                        provjera p = new provjera();
                        aco_intro.kraj();
                        this.Dispose();
                        aco_intro.form_ucitan = false;
                    }
                    else
                    {
                        text = text.Replace("?", String.Empty);
                        //MessageBox.Show("test: " + test);
                        provjera.setPass(text);
                        provjera p = new provjera();
                        aco_intro.kraj();
                        this.Dispose();
                        aco_intro.form_ucitan = false;
                    }
                }
                else if (text[0] == '@')
                {
                    text = text.Replace("@", string.Empty);
                    string[] a = text.Split('+');
                    string poruka = "";
                    for (int i = 0; i < a.Length; i++)
                    {
                        if(i == a.Length - 1)
                            poruka += a[i];
                        else
                            poruka += a[i] + "\r\n";
                    }
                    MessageBox.Show(poruka);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            aco_intro.form_ucitan = false;
            if (aco_podesavanja != null && !aco_podesavanja.IsDisposed) aco_podesavanja.Dispose();
        }

        private void button16_Click_2(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString() + " / " + e.ToString());
            aco_fullScreen();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1 && !aco_fullScreenOpen)
            {
                aco_fullScreen();
                return true;
            }
            else if (keyData == Keys.Escape && aco_fullScreenOpen)
            {
                aco_exitFullScreen();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void aco_fullScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

            this.aco_FS.Visible = false;
            this.aco_exitApp.Visible = true;
            this.aco_exitFS.Visible = true;
            this.aco_fullScreenOpen = true;
        }

        private void aco_exitFS_Click(object sender, EventArgs e)
        {
            aco_exitFullScreen();
        }
        private void aco_exitFullScreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false;

            this.aco_FS.Visible = true;
            this.aco_exitApp.Visible = false;
            this.aco_exitFS.Visible = false;
            this.aco_fullScreenOpen = false;
        }

        private void aco_exitApp_Click(object sender, EventArgs e)
        {
            this.Dispose();
            aco_intro.form_ucitan = false;
        }


        private void aco_addBL_Click(object sender, EventArgs e)
        {
            //string a = label6.Text;
            if (listView1.Items.Count > 0)
            {
                string a = listView1.SelectedItems[0].SubItems[5].Text;
                Form1_BL add = new Form1_BL(a);
                add.Show();
            }
            else MessageBox.Show("Klikni na poruku koju je broj poslao kako bi ga memorisao!");

        }

        public bool aco_podesavanjaUcitana = false;
        private void aco_BL_Click(object sender, EventArgs e)
        {
            if (!aco_fullScreenOpen)
            {
                if (!aco_podesavanjaUcitana)
                {
                    aco_podesavanja = new Form1_Podesavanja(this, aco_timerStartovan);
                    if (aco_timerStartovan) STOP();
                    aco_podesavanja.Show();
                    aco_podesavanjaUcitana = true;
                }
                else MessageBox.Show("Podesavanja su vec ucitana!");
            }
            else
            {
                MessageBox.Show("Izadjite iz FullScreena kako bi mogli da udjete u podesavanja!");
            }

            /*
            aco_podesavanja = new Form1_Podesavanja(this);
            aco_podesavanja.Show();
            this.Visible = false;*/
        }

        private void aco_timer_Tick(object sender, EventArgs e)
        {
            if (pcom != "" && scom != "" && smsc_pp != "" && smsc_sp != "")
            {
                var.restart_pcom = this.pcom;
                var.restart_scom = this.scom;
                var.restart_smscp = this.smsc_sp;
                var.restart_smspp = this.smsc_pp;
                var.restart_fullScreen = this.aco_fullScreenOpen;

                sub.aco_saveLista(listView1);
                aco_intro.restartApp();
                this.Dispose();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void aco_dev_Click(object sender, EventArgs e)
        {
            //_02_into dev = new _02_into(this);
        }


    }
}
