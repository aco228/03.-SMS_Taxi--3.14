namespace SMS_Taxi
{
    partial class Form1_BL
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("vbdfvdf");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("adgdsagsdf");
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.add_panel = new System.Windows.Forms.Panel();
            this.txt4 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.text3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.blue = new System.Windows.Forms.CheckBox();
            this.black = new System.Windows.Forms.CheckBox();
            this.number = new System.Windows.Forms.TextBox();
            this.txt_brTel = new System.Windows.Forms.Label();
            this.text = new System.Windows.Forms.Label();
            this.lista = new System.Windows.Forms.ListView();
            this.add_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(14, 232);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(126, 23);
            this.add.TabIndex = 2;
            this.add.Text = "Dodaj broj";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(146, 232);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(126, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "Izbrisi broj";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // add_panel
            // 
            this.add_panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.add_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.add_panel.Controls.Add(this.txt4);
            this.add_panel.Controls.Add(this.name);
            this.add_panel.Controls.Add(this.text3);
            this.add_panel.Controls.Add(this.button2);
            this.add_panel.Controls.Add(this.save);
            this.add_panel.Controls.Add(this.blue);
            this.add_panel.Controls.Add(this.black);
            this.add_panel.Controls.Add(this.number);
            this.add_panel.Controls.Add(this.txt_brTel);
            this.add_panel.Controls.Add(this.text);
            this.add_panel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.add_panel.Location = new System.Drawing.Point(278, 176);
            this.add_panel.Name = "add_panel";
            this.add_panel.Size = new System.Drawing.Size(265, 188);
            this.add_panel.TabIndex = 5;
            this.add_panel.Visible = false;
            // 
            // txt4
            // 
            this.txt4.AutoSize = true;
            this.txt4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt4.Location = new System.Drawing.Point(89, 118);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(167, 14);
            this.txt4.TabIndex = 9;
            this.txt4.Text = "(ovo polje ne morate popunjavati)";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(98, 93);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(147, 22);
            this.name.TabIndex = 8;
            // 
            // text3
            // 
            this.text3.AutoSize = true;
            this.text3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text3.Location = new System.Drawing.Point(5, 96);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(89, 16);
            this.text3.TabIndex = 7;
            this.text3.Text = "Ime korisnika:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(233, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(151, 143);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(94, 26);
            this.save.TabIndex = 5;
            this.save.Text = "Sacuvaj";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // blue
            // 
            this.blue.AutoSize = true;
            this.blue.Location = new System.Drawing.Point(70, 149);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(58, 20);
            this.blue.TabIndex = 4;
            this.blue.Text = "Plava";
            this.blue.UseVisualStyleBackColor = true;
            this.blue.CheckedChanged += new System.EventHandler(this.blue_CheckedChanged);
            // 
            // black
            // 
            this.black.AutoSize = true;
            this.black.Checked = true;
            this.black.CheckState = System.Windows.Forms.CheckState.Checked;
            this.black.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.black.Location = new System.Drawing.Point(13, 149);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(54, 20);
            this.black.TabIndex = 3;
            this.black.Text = "Crna";
            this.black.UseVisualStyleBackColor = true;
            this.black.CheckedChanged += new System.EventHandler(this.black_CheckedChanged);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(98, 65);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(147, 22);
            this.number.TabIndex = 2;
            // 
            // txt_brTel
            // 
            this.txt_brTel.AutoSize = true;
            this.txt_brTel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_brTel.Location = new System.Drawing.Point(5, 68);
            this.txt_brTel.Name = "txt_brTel";
            this.txt_brTel.Size = new System.Drawing.Size(89, 16);
            this.txt_brTel.TabIndex = 1;
            this.txt_brTel.Text = "*Broj telefona:";
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text.Location = new System.Drawing.Point(32, 27);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(200, 20);
            this.text.TabIndex = 0;
            this.text.Text = "Dodavanje novog broja u listu:";
            // 
            // lista
            // 
            this.lista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lista.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lista.Location = new System.Drawing.Point(14, 9);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(258, 212);
            this.lista.TabIndex = 6;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.List;
            this.lista.SelectedIndexChanged += new System.EventHandler(this.lista_SelectedIndexChanged);
            // 
            // Form1_BL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 268);
            this.Controls.Add(this.add_panel);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1_BL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uredjivanje liste";
            this.Load += new System.EventHandler(this.Form1_BL_Load);
            this.add_panel.ResumeLayout(false);
            this.add_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Panel add_panel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.CheckBox blue;
        private System.Windows.Forms.CheckBox black;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label txt_brTel;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Label txt4;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label text3;
        private System.Windows.Forms.ListView lista;
    }
}