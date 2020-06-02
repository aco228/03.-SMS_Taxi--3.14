using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
namespace SMS_Taxi
{
    class StravaAndZasu
    {
        public AutoResetEvent receiveNow;
        static Dictionary<char,string> phoneDict=new Dictionary<char,string>();
        public SerialPort OpenPort(string p_strPortName, int p_uBaudRate, int p_uDataBits, int p_uReadTimeout, int p_uWriteTimeout)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();
            phoneDict.Clear();
                            phoneDict.Add('+', "002b");
                            phoneDict.Add('0', "0030");
                            phoneDict.Add('1', "0031");
                            phoneDict.Add('2', "0032");
                            phoneDict.Add('3', "0033");
                            phoneDict.Add('4', "0034");
                           phoneDict.Add('5', "0035");
            phoneDict.Add('6', "0036");
            phoneDict.Add('7', "0037");
            phoneDict.Add('8', "0038");
            phoneDict.Add('9', "0039");
            try
            {                

                port.PortName = p_strPortName;                 //COM1
                port.BaudRate = p_uBaudRate;                   //9600
                port.DataBits = p_uDataBits;                   //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = p_uReadTimeout;             //300
                port.WriteTimeout = p_uWriteTimeout;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
              MessageBox.Show("Greška: \n"+ex.Message+"\n Port najvjerovatnije koristi druga aplikacija.\n");
              return null;
            }
            return port;
        }

        
        public static string ConvertPhoneNumber(string phoneNumber)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in phoneNumber)
            {
                sb.Append(phoneDict[c]);
            }
            return sb.ToString();
        }
        public static string ConvertMessage(string input)
        {
            UnicodeEncoding uni = new UnicodeEncoding();
            byte[] encodedBytes = uni.GetBytes(input);
            string text = "";
            for (int i = 0; i < encodedBytes.Length; i += 2)
            {
                text += string.Format("{0:X2}", encodedBytes[i + 1]) + string.Format("{0:X2}", encodedBytes[i]);
            }
            return text;
        }
        public bool sendMsg(SerialPort port, string PhoneNo, string Message,string smsc)
        {
            bool isSend = true;

            //bool isThai = isHaveThai(Message);

            //string tmp = ConvertMessage(Message);
            //return true;

            try
            {
                string smsca = "AT+CSCA=\"" + smsc + "\"";
                    
                string recievedData= ExecCommand(port, "AT", 500, "Modem nije konektovan");
                recievedData = ExecCommand(port, "AT+CMGF=1", 500, "Ne može se setovati mod za poruke.\nModem treba restartovati.");
                recievedData = ExecCommand(port, "AT+CSCS=\"IRA\"", 500, "Ne može se setovati unicode format.");
                recievedData = ExecCommand(port, smsca, 500, "Ne moze setovati SMSCentar.");
                //recievedData = ExecCommand(port, "AT+CSMP=17,167,0,8", 300, "Ne može se setovati csmp.");

                String command = "AT+CMGS=\"" + PhoneNo +"\"";

                recievedData = ExecCommand(port, command, 3000, "Ne može se setovati broj telefona.");
                if (recievedData.Contains("ERROR"))
                {
                    recievedData = ExecCommand(port, "ATZ", 500, "Modem nije konektovan");
                    if (!recievedData.Contains("OK"))
                        return false;
                    recievedData = ExecCommand(port, "AT+CMGF=1", 500, "Ne može se setovati mod za poruke.\nModem treba restartovati.");
                    recievedData = ExecCommand(port, "AT+CSCS=\"IRA\"", 500, "Ne može se setovati unicode format.");
                    recievedData = ExecCommand(port, command, 3000, "Ne može se setovati broj telefona.");
                    if (!recievedData.Contains("OK"))
                        return false;
                }
                //command = Message + char.ConvertFromUtf32(26) + "\r";
                //command = "0E02" + "001A";// +"\r";//+ "240D";
                command = Message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port, command, 15000, "Poruka se ne može se poslati"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }
                return isSend;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Close Port
        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ExecCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            string input;
            try
            {

                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || input.Contains("ERROR"))
                    return "ERROR";
                return input;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: "+ex.Message);
                input= "ERROR";
            }
            return input;
        }

        //Receive data from port
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ReadResponse(SerialPort port, int timeout)
        {
            string buffer = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string t = port.ReadExisting();
                        buffer += t;
                    }
                    else
                    {
                        if (buffer.Length > 0)
                            return "ERROR: Dobijeni odgovor od modema je nekompletan.";
                        else
                            return "ERROR: Modem ne vraća odgovor.\nPonovo ga inicijalizovati.";
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return buffer;
        }
        public Dictionary<string, string> BuildPortNameHash(string[] portsToMap)
        {
            Dictionary<string, string> oReturnTable = new Dictionary<string, string>();
            MineRegistryForPortName("SYSTEM\\CurrentControlSet\\Enum", oReturnTable, portsToMap);
            return oReturnTable;
        }
        static void MineRegistryForPortName(string startKeyPath, Dictionary<string, string> targetMap,
            string[] portsToMap)
        {
            if (targetMap.Count >= portsToMap.Length)
                return;
            using (RegistryKey currentKey = Registry.LocalMachine)
            {
                try
                {
                    using (RegistryKey currentSubKey = currentKey.OpenSubKey(startKeyPath))
                    {
                        string[] currentSubkeys = currentSubKey.GetSubKeyNames();
                        if (currentSubkeys.Contains("Device Parameters") &&
                            startKeyPath != "SYSTEM\\CurrentControlSet\\Enum")
                        {
                            object portName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" +
                                startKeyPath + "\\Device Parameters", "PortName", null);
                            if (portName == null ||
                                portsToMap.Contains(portName.ToString()) == false)
                                return;
                            object friendlyPortName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" +
                                startKeyPath, "FriendlyName", null);
                            string friendlyName = "N/A";
                            if (friendlyPortName != null)
                                friendlyName = friendlyPortName.ToString();
                            if (friendlyName.Contains(portName.ToString()) == false)
                                friendlyName = string.Format("{0} ({1})", friendlyName, portName);
                            targetMap[portName.ToString()] = friendlyName;
                        }
                        else
                        {
                            foreach (string strSubKey in currentSubkeys)
                                MineRegistryForPortName(startKeyPath + "\\" + strSubKey, targetMap, portsToMap);
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
