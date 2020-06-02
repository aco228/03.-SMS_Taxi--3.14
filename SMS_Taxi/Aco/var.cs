using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace SMS_Taxi.Aco
{
    class var
    {
        public static bool provjeraUradjena = false; // Zastita odredjenih metoda da se nebi ponovo ucitavale

        public static string imeSkonfig = "NE_BRISI.CONFIGX";
        public static string imeLoada = "LOADER.CONFIGX";
        public static string imeBlackList = "BL.CONFIGX";
        public static string imeUserConfig = "USER.CONFIGX";

        public static bool postojiSK = false;
        public static string put = "";
        public static string imeVerzije = "";
        public static string brTel = "";
        public static string email = "";
        public static string ostalo = "";

        public static string date_congif = "";
        public static string date_install = "";

        public static bool postojiIK = false;
        public static string i_putDoFajla = "";
        public static int i_id = 1;
        public static string code = "";

        public static bool postojiLoad = false;
        public static bool koristiLoad = false;
        public static int l_koriscen = -1;
        public static string l_sms_sp = "";
        public static string l_sms_pp = "";
        public static string l_scom = "";
        public static string l_pcom = "";
        public static string l_date = "";

        public static string log = "Nema Upisa!";

        public static bool postojiBlackList = false;
        public static br[] listaBrojeva = null;
        public static blackList blackList = null;

        public static bool postojiUserConfig = false;
        public static int vrijemeRestarta = 0;
        public static string messageSound = "";
        public static string restart_smscp;
        public static string restart_smspp;
        public static string restart_scom;
        public static string restart_pcom;
        public static bool restart_fullScreen;
        public static bool restart_prviPut = true;
    }

    class provjera
    {
        public provjera()
        {
            provjeraSoftverskogKonfiga();
            if (var.postojiSK) provjeraInstalacionogKonfiga();
            if (var.postojiIK)
            {
                provjeraLoada();
                provjeraBlackList();
                provjeraUserConfiga();
                brisanjeBaneraNakonDodavanja(); // Iz podesavanja Form1 (Dodavanje novog banera)
            }
            //test();
            var.provjeraUradjena = true;
        }
        private void test()
        {
            //string a = File.GetLastWriteTime(@var.i_putDoFajla).ToString();
            MessageBox.Show(File.GetLastWriteTime(var.imeSkonfig).ToString() + "\r\n" + File.GetCreationTime(var.imeSkonfig).ToString());
        }
        private void brisanjeBaneraNakonDodavanja()
        {
            string folderAplikacije = Path.GetDirectoryName(Application.ExecutablePath);
            //Brise "baner1.jpg"
            if (!var.provjeraUradjena)
            {
                if (File.Exists(folderAplikacije + @"\baner1.jpg"))
                {
                    File.Delete(folderAplikacije + @"\baner.jpg");
                    File.Copy(folderAplikacije + @"\baner1.jpg", folderAplikacije + @"\baner.jpg");
                    File.Delete(folderAplikacije + @"\baner1.jpg");
                }
                if (File.Exists(folderAplikacije + @"\command.CONFIGX"))
                {
                    File.Delete(folderAplikacije + @"\command.CONFIGX");
                    File.Delete(folderAplikacije + @"\baner.jpg");
                }
            }
        }

        //Postavljanje passworda nakon slanja poruke za zakljucavanje
        public static void setPass(string u)
        {
            if (var.postojiIK)
            {
                string datum = DateTime.Now.ToString();
                kripcija code = new kripcija();
                TextWriter tw = File.CreateText(@var.put);
                tw.WriteLine(code.unos(datum + "#1#" + u)[0]);
                tw.WriteLine(code.unos(var.i_putDoFajla + "#" + datum)[0]);
                tw.Close();

                regulacijaConfiga(code, datum);
            }
            else Application.Exit();
        }
        public static void regulacijaConfiga(kripcija code, string datum)
        {
            string[] izFajla = File.ReadAllLines(var.imeSkonfig);
            if (izFajla.Length == 5)
            {
                TextWriter tw = File.CreateText(var.imeSkonfig);
                tw.WriteLine(code.unos(var.put + "#" + datum)[0]);
                for (int i = 1; i < izFajla.Length; i++)
                {
                    tw.WriteLine(izFajla[i]);
                }
                tw.Close();
            }
            else
            {
                dekripcija dcode = new dekripcija();
                //                                    Konfiguracija je oštećena! Kontaktirajte administratora!
                MessageBox.Show(dcode.unos("⊃Ω∏≫∈∃∠∂♔♘∈∋♔≝∋♜≝Ωℚ∞♜É♜∏♔℗≝⊃Ω∏∞♔⊂∞∈∂♔∋∞♜≝♔♚⊅∈∏∈∜∞∂♔∞Ω∂♔℗")[0]);
                Application.Exit();
            }
        }

        // Provjera NEBRISI.CONFIGX
        private void provjeraSoftverskogKonfiga()
        {
            if (File.Exists(var.imeSkonfig))
            {
                var.postojiSK = true;
                uzimenjaPodatakaIzSK();
            }
            else
            {
                var.postojiSK = false;
                var.log = "Nemoguće pronaći softversku konfigurizaciju! Fajl <NE_BRISI.CONFIGX> se ne nalazi u istom folderu kao i program!";
            }
        }
        private void uzimenjaPodatakaIzSK()
        {
            dekripcija dcode = new dekripcija();
            string[] info = File.ReadAllLines(var.imeSkonfig);
            if (info.Length == 5)
            {
                string[] first = dcode.unos(info[0])[0].Split('#');
                if (first.Length == 2)
                {
                    var.put = first[0];
                    var.date_congif = first[1];
                    if (var.date_congif.Equals(File.GetLastWriteTime(var.imeSkonfig).ToString()))
                    {
                        var.imeVerzije = dcode.unos(info[1])[0].Split('#')[0];
                        var.brTel = dcode.unos(info[2])[0].Split('#')[0];
                        var.email = dcode.unos(info[3])[0].Split('#')[0];
                        var.ostalo = dcode.unos(info[4])[0].Split('#')[0];
                    }
                    else
                    {
                        var.postojiSK = false;
                        var.log = "Korisnik softvera je vršio zabranjene modifikacije nad fajlovima baze.\r\nKontaktirajte administratora!\r\n";
                    }
                }
                else
                {
                    var.postojiSK = false;
                    var.log = "Greška u softverskoj konfiguraciji.\r\nNemoguće pročitati iz baze!";
                }
            }
            else
            {
                var.postojiSK = false;
                var.log = "Greška u softverskoj konfiguraciji.\r\nNemoguće pročitati iz baze!";
            }
        }

        //Provjera skrivene konfiguracije
        private void provjeraInstalacionogKonfiga()
        {
            if (File.Exists(@var.put))
            {
                var.postojiIK = true;
                preuzimanjeIzIf();
            }
            else var.log = "Greska prilikom instalacije!\r\nKontaktirajte administratora!";
        }
        private void preuzimanjeIzIf()
        {
            dekripcija dcode = new dekripcija();
            string[] file = File.ReadAllLines(@var.put);
            if (file.Length == 2)
            {
                var.i_putDoFajla = dcode.unos(file[1])[0].Split('#')[0];
                string[] spli = dcode.unos(file[0].Split('#'));
                if (spli.Length == 3)
                {
                    if (Int32.TryParse(spli[1], out var.i_id))
                    {
                        var.code = spli[2];
                        var.date_install = dcode.unos(file[1].Split('#')[1])[0];
                        if (var.date_install.Equals(File.GetLastWriteTime(@var.put).ToString()))
                        {
                            if (var.date_install.Equals(var.date_congif)) var.postojiIK = true;
                            else
                            {
                                var.postojiIK = false;
                                var.log = "Korisnik softvera je vršio zabranjene modifikacije nad fajlovima baze.\r\nKontaktirajte administratora!\r\n";
                            }
                        }
                        else
                        {
                            var.postojiIK = false;
                            var.log = "Korisnik softvera je vršio zabranjene modifikacije nad fajlovima baze.\r\nKontaktirajte administratora!\r\n";
                        }
                    }
                    else
                    {
                        var.postojiIK = false;
                        var.log = "3 int: " +spli[2] + "Greska!!\r\nGreska u instalacionoj konfiguraciji!\r\nKontaktirajte administratora!";
                    }
                }
                else
                {
                    var.postojiIK = false;
                    var.log = "2 Greska!!\r\nGreska u instalacionoj konfiguraciji!\r\nKontaktirajte administratora!";
                }
            }
            else
            {
                var.postojiIK = false;
                var.log = "1 Greska!!\r\nGreska u instalacionoj konfiguraciji!\r\nKontaktirajte administratora!";
            }
        }

        // Provjera ucitavanja portova
        private void  provjeraLoada()
        {
            if (File.Exists(var.imeLoada))
            {
                var.postojiLoad = true;
                string[] fajl = File.ReadAllLines(var.imeLoada);
                if (fajl.Length == 6)
                {
                    if(Int32.TryParse(fajl[0], out var.l_koriscen) && fajl[1].Length >= 12 && fajl[2].Length >= 12 && fajl[3].Contains("COM") && fajl[4].Contains("COM")) 
                    {
                        var.l_sms_sp = fajl[1];
                        var.l_sms_pp = fajl[2];
                        var.l_scom = fajl[3];
                        var.l_pcom = fajl[4];
                        var.l_date = fajl[5];
                        var.koristiLoad = true;
                        return;
                    }
                }
            } var.koristiLoad = false;
        }//provjera loada

        //BLACK LIST
        private void provjeraBlackList()
        {
            if (File.Exists(var.imeBlackList))
            {
                var.postojiBlackList = true;
                var.blackList = new blackList();
            }
        }

        // USER CONGFIG
        private void provjeraUserConfiga()
        {
            if (File.Exists(var.imeUserConfig))
            {
                string[] a = File.ReadAllLines(var.imeUserConfig);
                if (a.Length == 2)
                {
                    int br = 0; 
                    if(int.TryParse(a[0], out br)) 
                    {
                        var.postojiUserConfig = true;
                        var.vrijemeRestarta = br;
                        var.messageSound = a[1];
                        //MessageBox.Show(var.vrijemeRestarta.ToString() + "\r\n" + var.messageSound);
                    }
                }
            }
        }
    }


    //--- BLACKLIST
    struct br
    {
        public byte boja;
        public void setBoja(byte a) 
        {
            boja = a;
        } 

        public string broj;
        public void setBroj(string a) 
        {
            broj = a;
        }

        public string ime;
        public void setIme(string a)
        {
            ime = a;
        }
    }
    class blackList
    {
        string[] info;

        public blackList()
        {
            read();
        }
        //citannje
        
        private void read()
        {
            info = File.ReadAllLines(var.imeBlackList);
            var.listaBrojeva = new br[info.Length];
            preuzimanjeUListu();
        }
        private void preuzimanjeUListu()
        {
            //Prenosenje podataka iz info u listu brojeva

            string[] a;
            for (int i = 0; i < info.Length; i++)
            {
                a = info[i].Split('#');
                if (a.Length == 3)
                {
                    byte br;
                    if (byte.TryParse(a[0], out br))
                    {
                        var.listaBrojeva[i].setBoja(br);
                        var.listaBrojeva[i].setBroj(a[1]);
                        var.listaBrojeva[i].setIme(a[2]);
                    }
                    else MessageBox.Show("Greska u listi brojeva");
                }
                else
                {
                    MessageBox.Show("Greska u listi brojeva.\r\nMolimo vas kontaktirajte administratora!");
                    break;
                }   
            }
        }

        //provjera dali se broj nalazi u bazi
        public int[] provjera(string a)
        {
            int[] back = new int[2]; back[0] = -1;
            for (int i = 0; i < var.listaBrojeva.Length; i++)
            {
                if (var.listaBrojeva[i].broj.Equals(a))
                {
                    back[0] = var.listaBrojeva[i].boja;
                    back[1] = i;
                    break;
                }
            }
            return back;
        }

        //dodavanje
        public void add(byte boja, string broj, string ime)
        {
            if (!provjeraPostojnja(broj) && !provjeraBroja(broj) && !provjeraImena(ime))
            {
                TextWriter tw = File.CreateText(var.imeBlackList);
                for (int i = 0; i < info.Length; i++)
                {
                    tw.WriteLine(info[i]);
                }
                tw.WriteLine(boja + "#" + broj + "#" + ime);
                tw.Close();
                read();
                MessageBox.Show("Broj " + broj + " je ubacen u bazu!");
            }
        }
        private bool provjeraBroja(string a)
        {
            bool greska = false;
            if (a[0] == '+')
            {
                for (int i = 1; i < a.Length; i++)
                {
                    if (!char.IsDigit(a[i]))
                    {
                        MessageBox.Show("Broj sadrzi nedozvoljeni znak!");
                        greska = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Greska u formatu broja!");
                greska = true;
            }
            return greska;
        }
        private bool provjeraImena(string a)
        {
            bool greska = true;
            if (a.Contains('#')) MessageBox.Show("Greska u formatu imena!");
            else greska = false;
            return greska;
        }
        private bool provjeraPostojnja(string a)
        {
            // Provjerava dali je broj vec unijet u bazu
            bool greska = false;
            for (int i = 0; i < var.listaBrojeva.Length; i++)
            {
                if (a.Equals(var.listaBrojeva[i].broj))
                {
                    greska = true;
                    break;
                }
            }

            if (greska) MessageBox.Show("Broj se vec nalazi u bazi!"); ;
            return greska;
        }


        //Brisanje
        public void dell(string a)
        {
            int brisanje = indeksBrojaZaBrisanje(a);
            if (brisanje != -1)
            {
                TextWriter tw = File.CreateText(var.imeBlackList);
                for (int i = 0; i < info.Length; i++)
                {
                    if (i != brisanje) tw.WriteLine(info[i]);
                }
                tw.Close();
                read();
                //MessageBox.Show("Broj " + a + " je izbrisan!");
            }
            else MessageBox.Show("Greska prilikom brisanja!");
        }
        public int indeksBrojaZaBrisanje(string a)
        {
            //Vraca indeks broja koji treba da bude izbrisan
            int back = -1;
            for (int i = 0; i < var.listaBrojeva.Length; i++)
            {
                if (var.listaBrojeva[i].broj.Equals(a))
                {
                    back = i;
                    break;
                }
            }
            return back;
        }
    }
}
