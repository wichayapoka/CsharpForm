namespace WindowsFormsExample
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.NumofPanel = new System.Windows.Forms.TextBox();
            this.load = new System.Windows.Forms.Button();
            this.undo = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.Time_or_speed = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.RadioButton();
            this.Time = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.Load_server = new System.Windows.Forms.Button();
            this.Add_textbox = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Name_ip = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.add_name = new System.Windows.Forms.TextBox();
            this.add_ip = new System.Windows.Forms.TextBox();
            this.mypanel1 = new WindowsFormsExample.Mypanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sender_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(129, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Set panel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Set_Panel);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save.Location = new System.Drawing.Point(431, 10);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(141, 34);
            this.save.TabIndex = 5;
            this.save.Text = "Save to local";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // NumofPanel
            // 
            this.NumofPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.NumofPanel.Location = new System.Drawing.Point(12, 12);
            this.NumofPanel.Name = "NumofPanel";
            this.NumofPanel.Size = new System.Drawing.Size(111, 30);
            this.NumofPanel.TabIndex = 0;
            this.NumofPanel.TextChanged += new System.EventHandler(this.NumofPanel_TextChanged);
            this.NumofPanel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumofPanel_KeyPress);
            // 
            // load
            // 
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.load.Location = new System.Drawing.Point(268, 10);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(157, 34);
            this.load.TabIndex = 6;
            this.load.Text = "load from local";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // undo
            // 
            this.undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.undo.Location = new System.Drawing.Point(578, 10);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(102, 34);
            this.undo.TabIndex = 7;
            this.undo.Text = "Undo";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.redo.Location = new System.Drawing.Point(686, 10);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(102, 34);
            this.redo.TabIndex = 8;
            this.redo.Text = "Redo";
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // Time_or_speed
            // 
            this.Time_or_speed.Location = new System.Drawing.Point(12, 61);
            this.Time_or_speed.Name = "Time_or_speed";
            this.Time_or_speed.Size = new System.Drawing.Size(111, 22);
            this.Time_or_speed.TabIndex = 3;
            this.Time_or_speed.TextChanged += new System.EventHandler(this.Time_input_TextChanged);
            this.Time_or_speed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Time_input_KeyPress);
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(129, 76);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(113, 21);
            this.Speed.TabIndex = 2;
            this.Speed.TabStop = true;
            this.Speed.Text = "Speed (Pixel)";
            this.Speed.UseVisualStyleBackColor = true;
            this.Speed.CheckedChanged += new System.EventHandler(this.Speed_CheckedChanged);
            this.Speed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Speed_MouseClick);
            this.Speed.MouseCaptureChanged += new System.EventHandler(this.Speed_MouseCaptureChanged);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(129, 48);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(221, 21);
            this.Time.TabIndex = 1;
            this.Time.TabStop = true;
            this.Time.Text = "Time undo animation (second)";
            this.Time.UseVisualStyleBackColor = true;
            this.Time.CheckedChanged += new System.EventHandler(this.Time_CheckedChanged);
            this.Time.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(355, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Set_Click);
            // 
            // Load_server
            // 
            this.Load_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Load_server.Location = new System.Drawing.Point(853, 310);
            this.Load_server.Name = "Load_server";
            this.Load_server.Size = new System.Drawing.Size(144, 35);
            this.Load_server.TabIndex = 12;
            this.Load_server.Text = "Load from server";
            this.Load_server.UseVisualStyleBackColor = true;
            this.Load_server.Click += new System.EventHandler(this.Load_server_Click);
            // 
            // Add_textbox
            // 
            this.Add_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Add_textbox.Location = new System.Drawing.Point(453, 52);
            this.Add_textbox.Name = "Add_textbox";
            this.Add_textbox.Size = new System.Drawing.Size(139, 35);
            this.Add_textbox.TabIndex = 13;
            this.Add_textbox.Text = "Add textbox";
            this.Add_textbox.UseVisualStyleBackColor = true;
            this.Add_textbox.Click += new System.EventHandler(this.Add_textbox_Click);
            // 
            // picture
            // 
            this.picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.picture.Location = new System.Drawing.Point(655, 52);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(133, 35);
            this.picture.TabIndex = 14;
            this.picture.Text = "browse file";
            this.picture.UseVisualStyleBackColor = true;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(900, 461);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 33);
            this.button3.TabIndex = 17;
            this.button3.Text = "Save to server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Save_Server);
            // 
            // Name_ip
            // 
            this.Name_ip.FormattingEnabled = true;
            this.Name_ip.ItemHeight = 16;
            this.Name_ip.Location = new System.Drawing.Point(819, 44);
            this.Name_ip.Name = "Name_ip";
            this.Name_ip.Size = new System.Drawing.Size(206, 260);
            this.Name_ip.TabIndex = 18;
            this.Name_ip.SelectedIndexChanged += new System.EventHandler(this.Name_ip_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(853, 379);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 34);
            this.button4.TabIndex = 19;
            this.button4.Text = "Add name and ip";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Add_name_ip);
            // 
            // add_name
            // 
            this.add_name.Location = new System.Drawing.Point(819, 351);
            this.add_name.Name = "add_name";
            this.add_name.Size = new System.Drawing.Size(75, 22);
            this.add_name.TabIndex = 20;
            this.add_name.Text = "Name";
            this.add_name.TextChanged += new System.EventHandler(this.add_ip_TextChanged);
            // 
            // add_ip
            // 
            this.add_ip.Location = new System.Drawing.Point(900, 351);
            this.add_ip.Name = "add_ip";
            this.add_ip.Size = new System.Drawing.Size(125, 22);
            this.add_ip.TabIndex = 21;
            this.add_ip.Text = "ip";
            // 
            // mypanel1
            // 
            this.mypanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mypanel1.Location = new System.Drawing.Point(12, 103);
            this.mypanel1.Name = "mypanel1";
            this.mypanel1.Size = new System.Drawing.Size(776, 386);
            this.mypanel1.TabIndex = 10;
            this.mypanel1.Load += new System.EventHandler(this.mypanel1_Load);
            this.mypanel1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mypanel1_KeyDown);
            this.mypanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mypanel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(850, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name and IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(794, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Save with your own name";
            // 
            // sender_name
            // 
            this.sender_name.Location = new System.Drawing.Point(794, 466);
            this.sender_name.Name = "sender_name";
            this.sender_name.Size = new System.Drawing.Size(100, 22);
            this.sender_name.TabIndex = 24;
            this.sender_name.TextChanged += new System.EventHandler(this.sender_name_TextChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 501);
            this.Controls.Add(this.sender_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_ip);
            this.Controls.Add(this.add_name);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Name_ip);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.Add_textbox);
            this.Controls.Add(this.Load_server);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Time_or_speed);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.mypanel1);
            this.Controls.Add(this.redo);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.load);
            this.Controls.Add(this.NumofPanel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Panel";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox NumofPanel;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button redo;
        private Mypanel mypanel1;
        private System.Windows.Forms.TextBox Time_or_speed;
        private System.Windows.Forms.RadioButton Speed;
        private System.Windows.Forms.RadioButton Time;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Load_server;
        private System.Windows.Forms.Button Add_textbox;
        private System.Windows.Forms.Button picture;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox Name_ip;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox add_name;
        private System.Windows.Forms.TextBox add_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sender_name;
    }
}