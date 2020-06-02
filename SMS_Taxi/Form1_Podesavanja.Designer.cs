namespace SMS_Taxi
{
    partial class Form1_Podesavanja
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

        

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1_Podesavanja));
            this.btn_lista = new System.Windows.Forms.Label();
            this.btn_sound = new System.Windows.Forms.Label();
            this.btn_restart = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_baner = new System.Windows.Forms.Label();
            this.panel_restart = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.restart_BTN_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.restart_timeZero = new System.Windows.Forms.CheckBox();
            this.restart_trackBar = new System.Windows.Forms.TrackBar();
            this.restart_BTN_exit = new System.Windows.Forms.Button();
            this.restart_time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.restart_opis = new System.Windows.Forms.Label();
            this.panel_baner = new System.Windows.Forms.Panel();
            this.baner_delete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.baner_save = new System.Windows.Forms.Button();
            this.baner_exit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_sound = new System.Windows.Forms.Panel();
            this.sound_list = new System.Windows.Forms.FlowLayoutPanel();
            this.sound_uppload = new System.Windows.Forms.Button();
            this.sound_save = new System.Windows.Forms.Button();
            this.sound_izabrano = new System.Windows.Forms.Label();
            this.sound_exit = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel_restart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restart_trackBar)).BeginInit();
            this.panel_baner.SuspendLayout();
            this.panel_sound.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_lista
            // 
            this.btn_lista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.btn_lista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_lista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lista.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_lista.Location = new System.Drawing.Point(11, 32);
            this.btn_lista.Name = "btn_lista";
            this.btn_lista.Size = new System.Drawing.Size(519, 18);
            this.btn_lista.TabIndex = 0;
            this.btn_lista.Text = "Lista kontakata";
            this.btn_lista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_lista.Click += new System.EventHandler(this.btn_lista_Click);
            this.btn_lista.MouseEnter += new System.EventHandler(this.btn_lista_MouseEnter);
            this.btn_lista.MouseLeave += new System.EventHandler(this.btn_lista_MouseLeave);
            // 
            // btn_sound
            // 
            this.btn_sound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.btn_sound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sound.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sound.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_sound.Location = new System.Drawing.Point(11, 57);
            this.btn_sound.Name = "btn_sound";
            this.btn_sound.Size = new System.Drawing.Size(519, 18);
            this.btn_sound.TabIndex = 1;
            this.btn_sound.Text = "Podešavanje zvuka poruke";
            this.btn_sound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_sound.Click += new System.EventHandler(this.btn_sound_Click);
            this.btn_sound.MouseEnter += new System.EventHandler(this.btn_sound_MouseEnter);
            this.btn_sound.MouseLeave += new System.EventHandler(this.btn_sound_MouseLeave);
            // 
            // btn_restart
            // 
            this.btn_restart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_restart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.btn_restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_restart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restart.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_restart.Location = new System.Drawing.Point(11, 83);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(519, 18);
            this.btn_restart.TabIndex = 2;
            this.btn_restart.Text = "Podešavanje restarta";
            this.btn_restart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            this.btn_restart.MouseEnter += new System.EventHandler(this.btn_restart_MouseEnter);
            this.btn_restart.MouseLeave += new System.EventHandler(this.btn_restart_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Podešavanja:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_baner
            // 
            this.btn_baner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_baner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.btn_baner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_baner.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_baner.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_baner.Location = new System.Drawing.Point(11, 109);
            this.btn_baner.Name = "btn_baner";
            this.btn_baner.Size = new System.Drawing.Size(519, 18);
            this.btn_baner.TabIndex = 4;
            this.btn_baner.Text = "Podešavanje banera";
            this.btn_baner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_baner.Click += new System.EventHandler(this.btn_baner_Click);
            this.btn_baner.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.btn_baner.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // panel_restart
            // 
            this.panel_restart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel_restart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_restart.Controls.Add(this.label6);
            this.panel_restart.Controls.Add(this.label4);
            this.panel_restart.Controls.Add(this.restart_BTN_save);
            this.panel_restart.Controls.Add(this.label3);
            this.panel_restart.Controls.Add(this.restart_timeZero);
            this.panel_restart.Controls.Add(this.restart_trackBar);
            this.panel_restart.Controls.Add(this.restart_BTN_exit);
            this.panel_restart.Controls.Add(this.restart_time);
            this.panel_restart.Controls.Add(this.label1);
            this.panel_restart.Controls.Add(this.restart_opis);
            this.panel_restart.Location = new System.Drawing.Point(13, 550);
            this.panel_restart.Name = "panel_restart";
            this.panel_restart.Size = new System.Drawing.Size(518, 250);
            this.panel_restart.TabIndex = 5;
            this.panel_restart.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(235, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Promjena ce biti odmah primjenjena!";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(9, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(501, 50);
            this.label4.TabIndex = 8;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // restart_BTN_save
            // 
            this.restart_BTN_save.Location = new System.Drawing.Point(156, 209);
            this.restart_BTN_save.Name = "restart_BTN_save";
            this.restart_BTN_save.Size = new System.Drawing.Size(75, 23);
            this.restart_BTN_save.TabIndex = 7;
            this.restart_BTN_save.Text = "Sacuvaj";
            this.restart_BTN_save.UseVisualStyleBackColor = true;
            this.restart_BTN_save.Click += new System.EventHandler(this.restart_BTN_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(337, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "min";
            // 
            // restart_timeZero
            // 
            this.restart_timeZero.AutoSize = true;
            this.restart_timeZero.Location = new System.Drawing.Point(156, 184);
            this.restart_timeZero.Name = "restart_timeZero";
            this.restart_timeZero.Size = new System.Drawing.Size(283, 17);
            this.restart_timeZero.TabIndex = 5;
            this.restart_timeZero.Text = "Iskljuci restart (Restart je iskljucen kada je vrijednost 0)";
            this.restart_timeZero.UseVisualStyleBackColor = true;
            this.restart_timeZero.CheckedChanged += new System.EventHandler(this.restart_timeZero_CheckedChanged);
            // 
            // restart_trackBar
            // 
            this.restart_trackBar.Location = new System.Drawing.Point(156, 104);
            this.restart_trackBar.Maximum = 60;
            this.restart_trackBar.Name = "restart_trackBar";
            this.restart_trackBar.Size = new System.Drawing.Size(227, 45);
            this.restart_trackBar.TabIndex = 4;
            this.restart_trackBar.Scroll += new System.EventHandler(this.restart_trackBar_Scroll);
            // 
            // restart_BTN_exit
            // 
            this.restart_BTN_exit.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restart_BTN_exit.ForeColor = System.Drawing.Color.Red;
            this.restart_BTN_exit.Location = new System.Drawing.Point(490, 2);
            this.restart_BTN_exit.Name = "restart_BTN_exit";
            this.restart_BTN_exit.Size = new System.Drawing.Size(22, 22);
            this.restart_BTN_exit.TabIndex = 3;
            this.restart_BTN_exit.Text = "X";
            this.restart_BTN_exit.UseVisualStyleBackColor = true;
            this.restart_BTN_exit.Click += new System.EventHandler(this.restart_BTN_exit_Click);
            // 
            // restart_time
            // 
            this.restart_time.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart_time.Location = new System.Drawing.Point(272, 151);
            this.restart_time.Name = "restart_time";
            this.restart_time.Size = new System.Drawing.Size(60, 22);
            this.restart_time.TabIndex = 2;
            this.restart_time.TextChanged += new System.EventHandler(this.restart_time_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(153, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vrijeme restarta :";
            // 
            // restart_opis
            // 
            this.restart_opis.AutoSize = true;
            this.restart_opis.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restart_opis.Location = new System.Drawing.Point(8, 10);
            this.restart_opis.Name = "restart_opis";
            this.restart_opis.Size = new System.Drawing.Size(218, 17);
            this.restart_opis.TabIndex = 0;
            this.restart_opis.Text = "Podešavanje restarta programa!";
            // 
            // panel_baner
            // 
            this.panel_baner.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel_baner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_baner.Controls.Add(this.baner_delete);
            this.panel_baner.Controls.Add(this.label5);
            this.panel_baner.Controls.Add(this.baner_save);
            this.panel_baner.Controls.Add(this.baner_exit);
            this.panel_baner.Controls.Add(this.label8);
            this.panel_baner.Location = new System.Drawing.Point(12, 395);
            this.panel_baner.Name = "panel_baner";
            this.panel_baner.Size = new System.Drawing.Size(518, 149);
            this.panel_baner.TabIndex = 6;
            this.panel_baner.Visible = false;
            // 
            // baner_delete
            // 
            this.baner_delete.Location = new System.Drawing.Point(260, 102);
            this.baner_delete.Name = "baner_delete";
            this.baner_delete.Size = new System.Drawing.Size(124, 23);
            this.baner_delete.TabIndex = 6;
            this.baner_delete.Text = "Koristi osnovni baner!";
            this.baner_delete.UseVisualStyleBackColor = true;
            this.baner_delete.Click += new System.EventHandler(this.baner_delete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(74, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(383, 45);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kliknite na \"Promjeni\" i nađite sliku koju želite da postavite kao baner.\r\nDozvol" +
                "jeni su samo fajlovi sa .jpg ekstenzijom!\r\nPreporučena veličina je 769x191px!";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baner_save
            // 
            this.baner_save.Location = new System.Drawing.Point(179, 102);
            this.baner_save.Name = "baner_save";
            this.baner_save.Size = new System.Drawing.Size(75, 23);
            this.baner_save.TabIndex = 4;
            this.baner_save.Text = "Promjeni";
            this.baner_save.UseVisualStyleBackColor = true;
            this.baner_save.Click += new System.EventHandler(this.baner_save_Click);
            // 
            // baner_exit
            // 
            this.baner_exit.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.baner_exit.ForeColor = System.Drawing.Color.Red;
            this.baner_exit.Location = new System.Drawing.Point(492, 3);
            this.baner_exit.Name = "baner_exit";
            this.baner_exit.Size = new System.Drawing.Size(22, 22);
            this.baner_exit.TabIndex = 3;
            this.baner_exit.Text = "X";
            this.baner_exit.UseVisualStyleBackColor = true;
            this.baner_exit.Click += new System.EventHandler(this.baner_exit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(7, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Podešavanje banera!!";
            // 
            // panel_sound
            // 
            this.panel_sound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(219)))));
            this.panel_sound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_sound.Controls.Add(this.sound_list);
            this.panel_sound.Controls.Add(this.sound_uppload);
            this.panel_sound.Controls.Add(this.sound_save);
            this.panel_sound.Controls.Add(this.sound_izabrano);
            this.panel_sound.Controls.Add(this.sound_exit);
            this.panel_sound.Controls.Add(this.label12);
            this.panel_sound.Location = new System.Drawing.Point(12, 137);
            this.panel_sound.Name = "panel_sound";
            this.panel_sound.Size = new System.Drawing.Size(518, 250);
            this.panel_sound.TabIndex = 10;
            this.panel_sound.Visible = false;
            // 
            // sound_list
            // 
            this.sound_list.AutoScroll = true;
            this.sound_list.Location = new System.Drawing.Point(15, 34);
            this.sound_list.Name = "sound_list";
            this.sound_list.Size = new System.Drawing.Size(487, 177);
            this.sound_list.TabIndex = 8;
            // 
            // sound_uppload
            // 
            this.sound_uppload.Location = new System.Drawing.Point(316, 217);
            this.sound_uppload.Name = "sound_uppload";
            this.sound_uppload.Size = new System.Drawing.Size(102, 23);
            this.sound_uppload.TabIndex = 7;
            this.sound_uppload.Text = "Ubaci svoj zvuk";
            this.sound_uppload.UseVisualStyleBackColor = true;
            this.sound_uppload.Click += new System.EventHandler(this.sound_uppload_Click);
            // 
            // sound_save
            // 
            this.sound_save.Location = new System.Drawing.Point(423, 217);
            this.sound_save.Name = "sound_save";
            this.sound_save.Size = new System.Drawing.Size(75, 23);
            this.sound_save.TabIndex = 6;
            this.sound_save.Text = "Sacuvaj";
            this.sound_save.UseVisualStyleBackColor = true;
            this.sound_save.Click += new System.EventHandler(this.sound_save_Click);
            // 
            // sound_izabrano
            // 
            this.sound_izabrano.AutoSize = true;
            this.sound_izabrano.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sound_izabrano.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.sound_izabrano.Location = new System.Drawing.Point(16, 218);
            this.sound_izabrano.Name = "sound_izabrano";
            this.sound_izabrano.Size = new System.Drawing.Size(64, 16);
            this.sound_izabrano.TabIndex = 5;
            this.sound_izabrano.Text = "ringin.wav";
            // 
            // sound_exit
            // 
            this.sound_exit.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sound_exit.ForeColor = System.Drawing.Color.Red;
            this.sound_exit.Location = new System.Drawing.Point(491, 2);
            this.sound_exit.Name = "sound_exit";
            this.sound_exit.Size = new System.Drawing.Size(22, 22);
            this.sound_exit.TabIndex = 3;
            this.sound_exit.Text = "X";
            this.sound_exit.UseVisualStyleBackColor = true;
            this.sound_exit.Click += new System.EventHandler(this.sound_exit_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(6, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(187, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Podešavanje zvuka poruke!";
            // 
            // Form1_Podesavanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(243)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(541, 803);
            this.Controls.Add(this.panel_sound);
            this.Controls.Add(this.panel_baner);
            this.Controls.Add(this.panel_restart);
            this.Controls.Add(this.btn_baner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.btn_sound);
            this.Controls.Add(this.btn_lista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(551, 835);
            this.MinimumSize = new System.Drawing.Size(551, 176);
            this.Name = "Form1_Podesavanja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Podesavanja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Podesavanja_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Podesavanja_Load);
            this.panel_restart.ResumeLayout(false);
            this.panel_restart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restart_trackBar)).EndInit();
            this.panel_baner.ResumeLayout(false);
            this.panel_baner.PerformLayout();
            this.panel_sound.ResumeLayout(false);
            this.panel_sound.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label btn_lista;
        private System.Windows.Forms.Label btn_sound;
        private System.Windows.Forms.Label btn_restart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btn_baner;
        private System.Windows.Forms.Panel panel_restart;
        private System.Windows.Forms.Button restart_BTN_exit;
        private System.Windows.Forms.TextBox restart_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label restart_opis;
        private System.Windows.Forms.TrackBar restart_trackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox restart_timeZero;
        private System.Windows.Forms.Button restart_BTN_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_baner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button baner_save;
        private System.Windows.Forms.Button baner_exit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_sound;
        private System.Windows.Forms.Button sound_exit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button sound_save;
        private System.Windows.Forms.Label sound_izabrano;
        private System.Windows.Forms.Button sound_uppload;
        private System.Windows.Forms.FlowLayoutPanel sound_list;
        private System.Windows.Forms.Button baner_delete;


    }
}