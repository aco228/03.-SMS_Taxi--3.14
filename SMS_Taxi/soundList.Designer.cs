namespace SMS_Taxi
{
    partial class soundList
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
            this.name = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Timer(this.components);
            this.down = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.name.ForeColor = System.Drawing.SystemColors.MenuText;
            this.name.Location = new System.Drawing.Point(2, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(61, 15);
            this.name.TabIndex = 0;
            this.name.Text = "ringing.wav";
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.SystemColors.Control;
            this.play.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.play.Location = new System.Drawing.Point(333, 1);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(57, 20);
            this.play.TabIndex = 1;
            this.play.Text = "Preslusaj";
            this.play.UseVisualStyleBackColor = false;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(392, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Izaberi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.SystemColors.Control;
            this.stop.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stop.Location = new System.Drawing.Point(300, 1);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(33, 20);
            this.stop.TabIndex = 3;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Visible = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // up
            // 
            this.up.Interval = 1;
            this.up.Tick += new System.EventHandler(this.up_Tick);
            // 
            // down
            // 
            this.down.Interval = 1;
            this.down.Tick += new System.EventHandler(this.down_Tick);
            // 
            // soundList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(194)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.stop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.play);
            this.Controls.Add(this.name);
            this.Name = "soundList";
            this.Size = new System.Drawing.Size(451, 22);
            this.Load += new System.EventHandler(this.soundList_Load);
            this.Click += new System.EventHandler(this.soundList_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Timer up;
        private System.Windows.Forms.Timer down;
    }
}
