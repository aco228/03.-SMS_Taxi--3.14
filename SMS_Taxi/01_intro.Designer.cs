using System.Drawing;
namespace SMS_Taxi
{
    partial class _01_intro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_01_intro));
            this.btn_exit = new System.Windows.Forms.Label();
            this.panel_info = new System.Windows.Forms.Panel();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.lbl_brt = new System.Windows.Forms.Label();
            this.podaci = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loader = new System.Windows.Forms.ProgressBar();
            this.lbl_verzija = new System.Windows.Forms.Label();
            this.lbl_ostalo = new System.Windows.Forms.Label();
            this.err_screen = new System.Windows.Forms.Label();
            this.err_message = new System.Windows.Forms.Label();
            this.panel_control = new System.Windows.Forms.Panel();
            this.l_loadTime = new System.Windows.Forms.Label();
            this.l_loadUsed = new System.Windows.Forms.Label();
            this.ok_ucitaj = new System.Windows.Forms.Label();
            this.ok_pomoc = new System.Windows.Forms.Label();
            this.ok_start = new System.Windows.Forms.Label();
            this.lbl_autorizacija = new System.Windows.Forms.Label();
            this.panel_login = new System.Windows.Forms.Panel();
            this.login_pass = new System.Windows.Forms.TextBox();
            this.login_err = new System.Windows.Forms.Label();
            this.login_potvrdi = new System.Windows.Forms.Label();
            this.panel_info.SuspendLayout();
            this.panel_control.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Image = global::SMS_Taxi.Properties.Resources.btn_izlaz;
            this.btn_exit.Location = new System.Drawing.Point(586, 19);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(64, 26);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel_info
            // 
            this.panel_info.BackColor = System.Drawing.Color.Transparent;
            this.panel_info.Controls.Add(this.lbl_mail);
            this.panel_info.Controls.Add(this.lbl_brt);
            this.panel_info.Controls.Add(this.podaci);
            this.panel_info.Controls.Add(this.label2);
            this.panel_info.Controls.Add(this.label1);
            this.panel_info.Location = new System.Drawing.Point(20, 263);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(236, 56);
            this.panel_info.TabIndex = 2;
            this.panel_info.Visible = false;
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbl_mail.Location = new System.Drawing.Point(70, 35);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(0, 13);
            this.lbl_mail.TabIndex = 4;
            // 
            // lbl_brt
            // 
            this.lbl_brt.AutoSize = true;
            this.lbl_brt.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbl_brt.Location = new System.Drawing.Point(71, 21);
            this.lbl_brt.Name = "lbl_brt";
            this.lbl_brt.Size = new System.Drawing.Size(0, 13);
            this.lbl_brt.TabIndex = 3;
            // 
            // podaci
            // 
            this.podaci.AutoSize = true;
            this.podaci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.podaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podaci.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.podaci.Location = new System.Drawing.Point(1, 5);
            this.podaci.Name = "podaci";
            this.podaci.Size = new System.Drawing.Size(144, 13);
            this.podaci.TabIndex = 2;
            this.podaci.Text = "Podaci o administratoru:";
            this.podaci.Click += new System.EventHandler(this.podaci_Click);
            this.podaci.MouseEnter += new System.EventHandler(this.label3_MouseEnter);
            this.podaci.MouseLeave += new System.EventHandler(this.podaci_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(2, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj telefona:";
            // 
            // loader
            // 
            this.loader.Location = new System.Drawing.Point(49, 334);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(585, 10);
            this.loader.TabIndex = 3;
            // 
            // lbl_verzija
            // 
            this.lbl_verzija.AutoSize = true;
            this.lbl_verzija.BackColor = System.Drawing.Color.Transparent;
            this.lbl_verzija.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbl_verzija.Location = new System.Drawing.Point(21, 237);
            this.lbl_verzija.Name = "lbl_verzija";
            this.lbl_verzija.Size = new System.Drawing.Size(0, 13);
            this.lbl_verzija.TabIndex = 5;
            // 
            // lbl_ostalo
            // 
            this.lbl_ostalo.AutoSize = true;
            this.lbl_ostalo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ostalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ostalo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbl_ostalo.Location = new System.Drawing.Point(21, 249);
            this.lbl_ostalo.Name = "lbl_ostalo";
            this.lbl_ostalo.Size = new System.Drawing.Size(0, 12);
            this.lbl_ostalo.TabIndex = 6;
            // 
            // err_screen
            // 
            this.err_screen.BackColor = System.Drawing.Color.Transparent;
            this.err_screen.Image = global::SMS_Taxi.Properties.Resources.greska;
            this.err_screen.Location = new System.Drawing.Point(432, 81);
            this.err_screen.Name = "err_screen";
            this.err_screen.Size = new System.Drawing.Size(177, 180);
            this.err_screen.TabIndex = 7;
            this.err_screen.Visible = false;
            // 
            // err_message
            // 
            this.err_message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.err_message.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.err_message.Location = new System.Drawing.Point(444, 159);
            this.err_message.Name = "err_message";
            this.err_message.Size = new System.Drawing.Size(141, 93);
            this.err_message.TabIndex = 8;
            // 
            // panel_control
            // 
            this.panel_control.BackColor = System.Drawing.Color.Transparent;
            this.panel_control.Controls.Add(this.l_loadTime);
            this.panel_control.Controls.Add(this.l_loadUsed);
            this.panel_control.Controls.Add(this.ok_ucitaj);
            this.panel_control.Controls.Add(this.ok_pomoc);
            this.panel_control.Controls.Add(this.ok_start);
            this.panel_control.Location = new System.Drawing.Point(462, 87);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(168, 181);
            this.panel_control.TabIndex = 9;
            this.panel_control.Visible = false;
            // 
            // l_loadTime
            // 
            this.l_loadTime.AutoSize = true;
            this.l_loadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_loadTime.ForeColor = System.Drawing.SystemColors.Control;
            this.l_loadTime.Location = new System.Drawing.Point(35, 147);
            this.l_loadTime.Name = "l_loadTime";
            this.l_loadTime.Size = new System.Drawing.Size(0, 12);
            this.l_loadTime.TabIndex = 4;
            // 
            // l_loadUsed
            // 
            this.l_loadUsed.AutoSize = true;
            this.l_loadUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_loadUsed.ForeColor = System.Drawing.SystemColors.Control;
            this.l_loadUsed.Location = new System.Drawing.Point(35, 156);
            this.l_loadUsed.Name = "l_loadUsed";
            this.l_loadUsed.Size = new System.Drawing.Size(0, 12);
            this.l_loadUsed.TabIndex = 3;
            // 
            // ok_ucitaj
            // 
            this.ok_ucitaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_ucitaj.Enabled = false;
            this.ok_ucitaj.Image = global::SMS_Taxi.Properties.Resources.btn_laod;
            this.ok_ucitaj.Location = new System.Drawing.Point(11, 131);
            this.ok_ucitaj.Name = "ok_ucitaj";
            this.ok_ucitaj.Size = new System.Drawing.Size(74, 26);
            this.ok_ucitaj.TabIndex = 2;
            this.ok_ucitaj.Click += new System.EventHandler(this.ok_ucitaj_Click);
            // 
            // ok_pomoc
            // 
            this.ok_pomoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_pomoc.Image = global::SMS_Taxi.Properties.Resources.pomoc;
            this.ok_pomoc.Location = new System.Drawing.Point(1, 69);
            this.ok_pomoc.Name = "ok_pomoc";
            this.ok_pomoc.Size = new System.Drawing.Size(126, 41);
            this.ok_pomoc.TabIndex = 1;
            this.ok_pomoc.Click += new System.EventHandler(this.ok_pomoc_Click);
            // 
            // ok_start
            // 
            this.ok_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_start.Image = global::SMS_Taxi.Properties.Resources.start;
            this.ok_start.Location = new System.Drawing.Point(2, 24);
            this.ok_start.Name = "ok_start";
            this.ok_start.Size = new System.Drawing.Size(126, 41);
            this.ok_start.TabIndex = 0;
            this.ok_start.Click += new System.EventHandler(this.ok_start_Click);
            // 
            // lbl_autorizacija
            // 
            this.lbl_autorizacija.AutoSize = true;
            this.lbl_autorizacija.BackColor = System.Drawing.Color.Transparent;
            this.lbl_autorizacija.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_autorizacija.Location = new System.Drawing.Point(484, 314);
            this.lbl_autorizacija.Name = "lbl_autorizacija";
            this.lbl_autorizacija.Size = new System.Drawing.Size(152, 13);
            this.lbl_autorizacija.TabIndex = 3;
            this.lbl_autorizacija.Text = "Uspješno izvršena autorizacija!";
            this.lbl_autorizacija.Visible = false;
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.Transparent;
            this.panel_login.BackgroundImage = global::SMS_Taxi.Properties.Resources.login_forma;
            this.panel_login.Controls.Add(this.login_pass);
            this.panel_login.Controls.Add(this.login_err);
            this.panel_login.Controls.Add(this.login_potvrdi);
            this.panel_login.Location = new System.Drawing.Point(417, 60);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(219, 217);
            this.panel_login.TabIndex = 10;
            this.panel_login.Visible = false;
            // 
            // login_pass
            // 
            this.login_pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_pass.Location = new System.Drawing.Point(111, 168);
            this.login_pass.Name = "login_pass";
            this.login_pass.Size = new System.Drawing.Size(81, 11);
            this.login_pass.TabIndex = 2;
            this.login_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.login_pass_KeyDown);
            // 
            // login_err
            // 
            this.login_err.AutoSize = true;
            this.login_err.ForeColor = System.Drawing.Color.Red;
            this.login_err.Location = new System.Drawing.Point(27, 189);
            this.login_err.Name = "login_err";
            this.login_err.Size = new System.Drawing.Size(73, 13);
            this.login_err.TabIndex = 1;
            this.login_err.Text = "Netačna šifra!";
            this.login_err.Visible = false;
            this.login_err.MouseHover += new System.EventHandler(this.login_err_MouseHover);
            // 
            // login_potvrdi
            // 
            this.login_potvrdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_potvrdi.Image = global::SMS_Taxi.Properties.Resources.login_potvrdi;
            this.login_potvrdi.Location = new System.Drawing.Point(138, 186);
            this.login_potvrdi.Name = "login_potvrdi";
            this.login_potvrdi.Size = new System.Drawing.Size(55, 19);
            this.login_potvrdi.TabIndex = 0;
            this.login_potvrdi.Click += new System.EventHandler(this.login_potvrdi_Click);
            // 
            // _01_intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.BackgroundImage = global::SMS_Taxi.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(682, 382);
            this.Controls.Add(this.lbl_autorizacija);
            this.Controls.Add(this.panel_login);
            this.Controls.Add(this.panel_control);
            this.Controls.Add(this.err_message);
            this.Controls.Add(this.err_screen);
            this.Controls.Add(this.lbl_ostalo);
            this.Controls.Add(this.lbl_verzija);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.btn_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_01_intro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS_Taxi";
            this.TransparencyKey = System.Drawing.Color.Indigo;
            this.Load += new System.EventHandler(this._01_intro_Load);
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            this.panel_control.ResumeLayout(false);
            this.panel_control.PerformLayout();
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btn_exit;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.ProgressBar loader;
        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.Label lbl_brt;
        private System.Windows.Forms.Label podaci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_verzija;
        private System.Windows.Forms.Label lbl_ostalo;
        private System.Windows.Forms.Label err_screen;
        private System.Windows.Forms.Label err_message;
        private System.Windows.Forms.Panel panel_control;
        private System.Windows.Forms.Label ok_pomoc;
        private System.Windows.Forms.Label ok_start;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.TextBox login_pass;
        private System.Windows.Forms.Label login_err;
        private System.Windows.Forms.Label login_potvrdi;
        private System.Windows.Forms.Label ok_ucitaj;
        private System.Windows.Forms.Label lbl_autorizacija;
        private System.Windows.Forms.Label l_loadTime;
        private System.Windows.Forms.Label l_loadUsed;
    }
}