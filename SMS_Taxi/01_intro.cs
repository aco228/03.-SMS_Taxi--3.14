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
    public partial class _01_intro : Form
    {
        public static bool load_acc = false;
        public bool form_ucitan = false;
        private dekripcija dcode = new dekripcija();

        public _01_intro()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                                //                   Greska pri zatvaranju aplikacije
                MessageBox.Show(dcode.unos("∄∂♜∜⊂♔≝÷∂∈≝á♔∞∦♔∂♔∏∋∠≝♔÷⊄∈⊂♔♘∈∋♜")[0] + "\r\n" + ex.ToString());
            }
        }

        public void kraj()
        {
            //MessageBox.Show("Ajmo");
            if (lbl_autorizacija.Visible) lbl_autorizacija.Visible = false;
            login_pass.Text = "";
            this.panel_control.Visible = false;
            loading();
        }
        //LOAD ---------------------------------------------------------------
        private void _01_intro_Load(object sender, EventArgs e)
        {
            loading();
                                        //Netacna sifra
            login_err.Text = dcode.unos("∑♜∞♔é∏♔≝ℚ∈≫∂♔℗")[0];
            //                                   Uspjesno izvrsena autorizacija
            lbl_autorizacija.Text = dcode.unos("∡∜÷∋♜ℚ∏Ω≝∈á∦∂ℚ♜∏♔≝♔∠∞Ω∂∈á♔♘∈∋♔℗")[0];
        }
        public void updateLoadInfo()
        {
            provjera p = new provjera(); this.l_loadTime.Text = ""; this.l_loadUsed.Text = "";
            this.ok_ucitaj.Enabled = true;
            if (var.koristiLoad)
            {
                load_acc = true;
                this.l_loadTime.Text = var.l_date;
                //                                      Fajl je koriscen             tolko i tolko                  puta
                this.l_loadUsed.Text = dcode.unos("∀♔∋⊄≝∋♜≝⊂Ω∂∈ℚÉ♜∏≝")[0] + var.l_koriscen + dcode.unos("≝÷∠∞♔℗")[0];
            }
            else
            {
                load_acc = false;
                //         Nema konfiguracije
                this.l_loadTime.Text = dcode.unos("∑♜⊅♔≝⊂Ω∏≫∈∃∠∂♔♘∈∋♜℗")[0];
            }
        }
        private void loading()
        {
            //LOADER
            if (var.postojiSK)
            {
                podesavanjeSKkonfiguracije();
                this.loader.Value = 50;
                if (var.postojiIK)
                {
                    //SVE USPJESNO
                    postojiIK();
                    if (var.postojiLoad)
                    {
                        updateLoadInfo();
                        //Premjesteno da bi se iz drugih klasa mogao updatovati
                    }
                    else this.ok_ucitaj.Enabled = false;
                }
                else
                {
                    this.err_screen.Visible = true;
                    this.err_message.Text = var.log;
                }
            }
            else
            {
                this.err_screen.Visible = true;
                this.err_message.Text = var.log;
            }
        }
        private void postojiIK()
        {
            this.loader.Value = 100;
            if (var.i_id == 0)
            {
                this.err_message.Visible = false;
                //NORMAL
                this.panel_control.Visible = true;
            }
            else if (var.i_id == 1)
            {
                this.err_message.Visible = false;
                panel_login.Visible = true;
            }
            else
            {
                this.loader.Value = 50;
                this.err_screen.Visible = true;
                //                                 Greška u čitanju konfiguracije!                                           Kontaktirajte administratora!
                this.err_message.Text = dcode.unos("∄∂♜ℚ⊂♔≝∠≝é∈∞♔∏∋∠≝⊂Ω∏≫∈∃∠∂♔♘∈∋♜℗")[0] + "\r\n" + dcode.unos("⊃Ω∏∞♔⊂∞∈∂♔∋∞♜≝♔♚⊅∈∏∈∜∞∂♔∞Ω∂♔℗")[0];
            }
        }
        private void podesavanjeSKkonfiguracije()
        {
            panel_info.Visible = true;
            lbl_verzija.Text = var.imeVerzije;
            lbl_ostalo.Text = var.ostalo;
            lbl_brt.Text = var.brTel;
            lbl_mail.Text = var.email;
            
        }

        private void ok_start_Click(object sender, EventArgs e)
        {
            if (!form_ucitan)
            {
                Form1 f1 = new Form1(this);
                f1.Show();
                if (lbl_autorizacija.Visible) lbl_autorizacija.Visible = false;
            }
            else
            {
                //                          Program je već učitan!
                MessageBox.Show(dcode.unos("∅∂Ω∃∂♔⊅≝∋♜≝∦♜É≝∠é∈∞♔∏℗")[0]);
            }
        }

        private void ok_pomoc_Click(object sender, EventArgs e)
        {
            // Funkcije za dugme "POMOC"
            if (lbl_autorizacija.Visible) lbl_autorizacija.Visible = false;
            //MessageBox.Show("Stranica jos ne postoji!");
        }
        private void ok_ucitaj_Click(object sender, EventArgs e)
        {
            // Funckije za dugme ucitaj
            if (load_acc)
            {
                if (!form_ucitan)
                {
                    provjera p = new provjera();
                    Form1 f2 = new Form1(this, true);
                    klikLoad();
                    f2.Show();
                    this.l_loadTime.Text = var.l_date;
                    //this.l_loadUsed.Visible = true;
                    //                                Fajl je korišćen                     tolko i tolko               puta!
                    this.l_loadUsed.Text = dcode.unos("∀♔∋⊄≝∋♜≝⊂Ω∂∈ℚÉ♜∏≝")[0] + var.l_koriscen + dcode.unos("≝÷∠∞♔℗")[0];
                }
                else
                {
                    //                           Program je već učitan!
                    MessageBox.Show(dcode.unos("∅∂Ω∃∂♔⊅≝∋♜≝∦♜É≝∠é∈∞♔∏℗")[0]);
                } 
            }
            else
            {
                //                                    Konfigurizacija je
                this.l_loadTime.Text = dcode.unos("⊃Ω∏≫∈∃∠∂∈á♔♘∈∋♔≝∋♜")[0];
                //                                   najvjerovatnije izbrisana!
                this.l_loadUsed.Text = dcode.unos("∏♔∋∦∋♜∂Ω∦♔∞∏∈∋♜≝∈á♖∂∈∜♔∏♔℗")[0];
            }
            if (lbl_autorizacija.Visible) lbl_autorizacija.Visible = false;
        }
        private void klikLoad()
        {
            TextWriter tw = File.CreateText(var.imeLoada);
            var.l_koriscen += 1;
            //                                  Fajl je korišćen          *tolko i tolko!                    puta!
            this.l_loadUsed.Text = dcode.unos("∀♔∋⊄≝∋♜≝⊂Ω∂∈ℚÉ♜∏≝")[0] + var.l_koriscen + dcode.unos("≝÷∠∞♔℗")[0];
            tw.WriteLine(var.l_koriscen);
            tw.WriteLine(var.l_sms_sp); tw.WriteLine(var.l_sms_pp);
            tw.WriteLine(var.l_scom); tw.WriteLine(var.l_pcom);
            tw.WriteLine(var.l_date);
            tw.Close();
        }
        private byte izvrsenoBrisanje = 0; private void setBrisanjeIzvrseno(byte a) { izvrsenoBrisanje = a; }
        private void login_potvrdi_Click(object sender, EventArgs e)
        {
            login_potvrdi_operacija();
        }
        private void login_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) login_potvrdi_operacija();
        }
        private void login_potvrdi_operacija()
        {
            if (login_pass.Text.Equals(var.code))
            {
                //Tacna Sifra
                brisanjeSifre();
                if (izvrsenoBrisanje == 1)
                {
                    panel_login.Visible = false;
                    panel_control.Visible = true;
                    this.lbl_autorizacija.Visible = true;

                    //                                              Uspješno izvršena autorizacija!
                    this.lbl_autorizacija.Text = dcode.unos("∡∜÷∋♜ℚ∏Ω≝∈á∦∂ℚ♜∏♔≝♔∠∞Ω∂∈á♔♘∈∋♔℗")[0];
                }
            }
            else
            {
                //Ne tacna sifra
                login_err.Visible = true;
            }
        }
        private void brisanjeSifre()
        {
            try
            {
                kripcija code = new kripcija();
                TextWriter tw = File.CreateText(@var.put);
                string datum = DateTime.Now.ToString();
                tw.WriteLine(code.unos(DateTime.Now.ToString() + "#0#" + var.code)[0]);
                tw.WriteLine(code.unos(var.i_putDoFajla + "#" + datum)[0]);
                tw.Close();
                setBrisanjeIzvrseno(1);
                regulacijaConfiga(code, datum);
            }
            catch (Exception)
            {
                //                                                     ŠIFRA JE TAČNA međutim operacija se ne može izvršiti!                                              Ako ste na Win7 operativnom sistemu pokusajte da upalite program sa administratorskim privilegijama!    
                System.Windows.Forms.MessageBox.Show(dcode.unos("€∉∀∛♕≝∌♝≝∁♕¥∑♕≝⊅♜∠∞∈⊅≝Ω÷♜∂♔♘∈∋♔≝∜♜≝∏♜≝⊅Ω£♜≝∈á∦∂ℚ∈∞∈℗≝")[0] + "\r\n" + dcode.unos("♕⊂Ω≝∜∞♜≝∏♔≝∫∈∏✵≝Ω÷♜∂♔∞∈∦∏Ω⊅≝∜∈∜∞♜⊅∠≝÷Ω⊂∠∜♔∋∞♜≝♚♔≝∠÷♔⊄∈∞♜≝÷∂Ω∃∂♔⊅≝∜♔≝♔♚⊅∈∏∈∜∞∂♔∞Ω∂∜⊂∈⊅≝÷∂∈∦∈⊄♜∃∈∋♔⊅♔℗")[0]);
            }
        }
        private void regulacijaConfiga(kripcija code, string datum)
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
                //                                    Konfiguracija je oštećena! Kontaktirajte administratora!
                MessageBox.Show(dcode.unos("⊃Ω∏≫∈∃∠∂♔♘∈∋♔≝∋♜≝Ωℚ∞♜É♜∏♔℗≝⊃Ω∏∞♔⊂∞∈∂♔∋∞♜≝♔♚⊅∈∏∈∜∞∂♔∞Ω∂♔℗")[0]);
                Application.Exit();
            }
        }

        private void login_err_MouseHover(object sender, EventArgs e)
        {
            this.login_err.Visible = false;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            this.podaci.ForeColor = Color.AliceBlue;
        }

        private void podaci_MouseLeave(object sender, EventArgs e)
        {
            this.podaci.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
        }

        private void podaci_Click(object sender, EventArgs e)
        {
                                                             //Podaci o administratoru:                                            Broj telefona:                                               Email adresa: 
            System.Windows.Forms.MessageBox.Show(dcode.unos("∅Ω♚♔♘∈≝Ω≝♔♚⊅∈∏∈∜∞∂♔∞Ω∂∠≚")[0] + "\r\n\r\n" + dcode.unos("♗∂Ω∋≝∞♜⊄♜≫Ω∏♔≚≝")[0] + var.brTel + "\r\n" + dcode.unos("♝⊅♔∈⊄≝♔♚∂♜∜♔≚≝")[0] + var.email + "\r\n\r\n" + var.imeVerzije + "\r\n" + var.ostalo);
        }

        //RESTART CONFIG
        public void restartApp()
        {
            Form1 f = new Form1(this, var.restart_smspp, var.l_sms_sp, var.restart_scom, var.restart_pcom, var.restart_fullScreen);
            f.Show();
        }
        
    }
}
