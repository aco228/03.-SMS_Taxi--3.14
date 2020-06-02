namespace SMS_Taxi
{
    partial class Form4_lista
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sve = new System.Windows.Forms.Button();
            this.mjesec = new System.Windows.Forms.Button();
            this.nedelja = new System.Windows.Forms.Button();
            this.danas = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.zatvori = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.sve);
            this.groupBox4.Controls.Add(this.mjesec);
            this.groupBox4.Controls.Add(this.nedelja);
            this.groupBox4.Controls.Add(this.danas);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox4.Location = new System.Drawing.Point(149, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(408, 53);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "::Brisanje poruka::";
            // 
            // sve
            // 
            this.sve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sve.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sve.Location = new System.Drawing.Point(332, 20);
            this.sve.Name = "sve";
            this.sve.Size = new System.Drawing.Size(69, 25);
            this.sve.TabIndex = 3;
            this.sve.Text = "Sve";
            this.sve.UseVisualStyleBackColor = true;
            this.sve.Click += new System.EventHandler(this.sve_Click);
            // 
            // mjesec
            // 
            this.mjesec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mjesec.Location = new System.Drawing.Point(97, 20);
            this.mjesec.Name = "mjesec";
            this.mjesec.Size = new System.Drawing.Size(113, 25);
            this.mjesec.TabIndex = 2;
            this.mjesec.Text = "Zadnji mjesec";
            this.mjesec.UseVisualStyleBackColor = true;
            this.mjesec.Click += new System.EventHandler(this.mjesec_Click);
            // 
            // nedelja
            // 
            this.nedelja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nedelja.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nedelja.Location = new System.Drawing.Point(217, 20);
            this.nedelja.Name = "nedelja";
            this.nedelja.Size = new System.Drawing.Size(106, 25);
            this.nedelja.TabIndex = 1;
            this.nedelja.Text = "Zadnju nedelju";
            this.nedelja.UseVisualStyleBackColor = true;
            this.nedelja.Click += new System.EventHandler(this.nedelja_Click);
            // 
            // danas
            // 
            this.danas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.danas.Location = new System.Drawing.Point(7, 20);
            this.danas.Name = "danas";
            this.danas.Size = new System.Drawing.Size(78, 25);
            this.danas.TabIndex = 0;
            this.danas.Text = "Današnje";
            this.danas.UseVisualStyleBackColor = true;
            this.danas.Click += new System.EventHandler(this.danas_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(10, 67);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(684, 388);
            this.grid.TabIndex = 5;
            // 
            // zatvori
            // 
            this.zatvori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zatvori.Location = new System.Drawing.Point(619, 26);
            this.zatvori.Name = "zatvori";
            this.zatvori.Size = new System.Drawing.Size(75, 23);
            this.zatvori.TabIndex = 6;
            this.zatvori.Text = "Zatvori";
            this.zatvori.UseVisualStyleBackColor = true;
            this.zatvori.Click += new System.EventHandler(this.zatvori_Click);
            // 
            // Form4_lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 467);
            this.Controls.Add(this.zatvori);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form4_lista";
            this.Text = "Lista poruka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_lista_FormClosing);
            this.Load += new System.EventHandler(this.Form4_lista_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button sve;
        private System.Windows.Forms.Button mjesec;
        private System.Windows.Forms.Button nedelja;
        private System.Windows.Forms.Button danas;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button zatvori;

    }
}