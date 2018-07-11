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
            this.mypanel1 = new WindowsFormsExample.Mypanel();
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
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save.Location = new System.Drawing.Point(268, 10);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(113, 34);
            this.save.TabIndex = 5;
            this.save.Text = "Save";
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
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.load.Location = new System.Drawing.Point(387, 10);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(102, 34);
            this.load.TabIndex = 6;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // undo
            // 
            this.undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.undo.Location = new System.Drawing.Point(495, 10);
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
            this.redo.Location = new System.Drawing.Point(603, 10);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(102, 34);
            this.redo.TabIndex = 8;
            this.redo.Text = "Redo";
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // Time_or_speed
            // 
            this.Time_or_speed.Location = new System.Drawing.Point(162, 64);
            this.Time_or_speed.Name = "Time_or_speed";
            this.Time_or_speed.Size = new System.Drawing.Size(100, 22);
            this.Time_or_speed.TabIndex = 3;
            this.Time_or_speed.TextChanged += new System.EventHandler(this.Time_input_TextChanged);
            this.Time_or_speed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Time_input_KeyPress);
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(268, 79);
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
            this.Time.Location = new System.Drawing.Point(268, 51);
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
            this.button2.Location = new System.Drawing.Point(495, 58);
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
            this.Load_server.Location = new System.Drawing.Point(12, 58);
            this.Load_server.Name = "Load_server";
            this.Load_server.Size = new System.Drawing.Size(144, 35);
            this.Load_server.TabIndex = 12;
            this.Load_server.Text = "Load from server";
            this.Load_server.UseVisualStyleBackColor = true;
            this.Load_server.Click += new System.EventHandler(this.Load_server_Click);
            // 
            // Add_textbox
            // 
            this.Add_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Add_textbox.Location = new System.Drawing.Point(593, 58);
            this.Add_textbox.Name = "Add_textbox";
            this.Add_textbox.Size = new System.Drawing.Size(130, 35);
            this.Add_textbox.TabIndex = 13;
            this.Add_textbox.Text = "Add textbox";
            this.Add_textbox.UseVisualStyleBackColor = true;
            this.Add_textbox.Click += new System.EventHandler(this.Add_textbox_Click);
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(730, 58);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(98, 35);
            this.picture.TabIndex = 14;
            this.picture.Text = "browse file";
            this.picture.UseVisualStyleBackColor = true;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // mypanel1
            // 
            this.mypanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mypanel1.Location = new System.Drawing.Point(12, 103);
            this.mypanel1.Name = "mypanel1";
            this.mypanel1.Size = new System.Drawing.Size(816, 386);
            this.mypanel1.TabIndex = 10;
            this.mypanel1.Load += new System.EventHandler(this.mypanel1_Load);
            this.mypanel1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mypanel1_KeyDown);
            this.mypanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mypanel1_MouseDown);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 501);
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
    }
}