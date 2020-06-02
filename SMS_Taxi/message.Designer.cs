namespace SMS_Taxi
{
    partial class message
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorUp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.naslov = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // colorUp
            // 
            this.colorUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.colorUp.Location = new System.Drawing.Point(4, 4);
            this.colorUp.Name = "colorUp";
            this.colorUp.Size = new System.Drawing.Size(444, 16);
            this.colorUp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(4, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 16);
            this.label1.TabIndex = 1;
            // 
            // naslov
            // 
            this.naslov.AutoSize = true;
            this.naslov.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.naslov.Location = new System.Drawing.Point(2, 4);
            this.naslov.Name = "naslov";
            this.naslov.Size = new System.Drawing.Size(84, 16);
            this.naslov.TabIndex = 2;
            this.naslov.Text = "MessageBox";
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit.ForeColor = System.Drawing.Color.Red;
            this.exit.Location = new System.Drawing.Point(425, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(22, 17);
            this.exit.TabIndex = 3;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text.Location = new System.Drawing.Point(4, 27);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(212, 45);
            this.text.TabIndex = 4;
            this.text.Text = "KJkdaskdalksdlasdlkasldkalsdkas\r\ndsa\r\ndajsadkhkajhsdjkahdkahsdkahkdhak";
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.text);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.naslov);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorUp);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "message";
            this.Size = new System.Drawing.Size(452, 100);
            this.Load += new System.EventHandler(this.message_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label colorUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label naslov;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Timer timer;
    }
}
