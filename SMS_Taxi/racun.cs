using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO.Ports;

namespace SMS_Taxi
{
    public partial class racun : Form
    {
        Form main;
        string pcom;
        public racun(Form fm,string port)
        {
            main = fm;
            pcom = port;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 2)
            {
                if(pcom!=null)
                 sendSMS();
                else
                    MessageBox.Show("Provjeri port.\nPotrbno je da se predhodno konfigurišu u glavnom programu.");
            }
            else
                MessageBox.Show("Broj za provjeru SMS-a se sastoji od zvezdice, broja i tarabe.\nNpr: *100#");
        }
        void sendSMS()
        {

            StravaAndZasu sz = new StravaAndZasu();
            SerialPort sp = sz.OpenPort(pcom, 9600, 8, 500, 500);

            if (sp == null)
                return;

            bool n = true;
            string mf = "AT+CUSD=1,\"{0}\",15";
            mf = string.Format(mf, textBox1.Text.Trim());
            string s = sz.ExecCommand(sp, mf, 500, "");

            if (s.Contains("OK"))
            {
                s = sz.ReadResponse(sp, 5000);
                 
                if (s.Contains("CUSD"))
                    parseSMS(s);
                else
                    MessageBox.Show("Greška pri odgovoru od mreže.\nProbaj ponovo.");
            }
            else
                MessageBox.Show("Greška pri slanju komande.\nProbaj ponovo.");

            sz.ClosePort(sp);

        }
        void parseSMS(string s1)
        {
            char[] delimiters = new char[] { '\r', '\n' };
            char[] delimiters1 = new char[] { '0', '0' };
            string s = s1;
            string k;
            s = s.Trim(delimiters);
            string[] ss = s.Split(',');
            string msg = ss[1].Trim('"');
         
            string r = "";
            for (int i = 0; i < msg.Length - 4; i += 4)
            {
                k = msg.Substring(i, 4);
                k = k.Substring(2, 2);
                //int m=int.Parse(k);
                r += k;
            }
            // byte[] bt = Encoding.ASCII.GetBytes(r);
             MessageBox.Show(Encoding.ASCII.GetString(ConvertHexStringToByteArray(r)));
        }
        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }
        private void racun_Activated(object sender, EventArgs e)
        {
            main.Visible = false;
        }

        private void racun_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Visible=true;
        }
    }
}
