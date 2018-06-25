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
            this.mypanel1 = new WindowsFormsExample.Mypanel();
            this.Time = new System.Windows.Forms.RadioButton();
            this.Speed = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show panel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save.Location = new System.Drawing.Point(268, 10);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(142, 34);
            this.save.TabIndex = 2;
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
            // 
            // load
            // 
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.load.Location = new System.Drawing.Point(416, 10);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(142, 34);
            this.load.TabIndex = 3;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // undo
            // 
            this.undo.Location = new System.Drawing.Point(565, 10);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(102, 34);
            this.undo.TabIndex = 4;
            this.undo.Text = "Undo";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Location = new System.Drawing.Point(673, 10);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(102, 34);
            this.redo.TabIndex = 5;
            this.redo.Text = "Redo";
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // mypanel1
            // 
            this.mypanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mypanel1.Location = new System.Drawing.Point(12, 103);
            this.mypanel1.Name = "mypanel1";
            this.mypanel1.Size = new System.Drawing.Size(776, 386);
            this.mypanel1.TabIndex = 8;
            this.mypanel1.Load += new System.EventHandler(this.mypanel1_Load);
            this.mypanel1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mypanel1_KeyDown);
            this.mypanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mypanel1_MouseDown);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(12, 48);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(291, 21);
            this.Time.TabIndex = 6;
            this.Time.TabStop = true;
            this.Time.Text = "1 Second undo animation (approximately)";
            this.Time.UseVisualStyleBackColor = true;
            this.Time.CheckedChanged += new System.EventHandler(this.Time_CheckedChanged);
            this.Time.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(12, 75);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(177, 21);
            this.Speed.TabIndex = 7;
            this.Speed.TabStop = true;
            this.Speed.Text = "Fixed speed (1 interval)";
            this.Speed.UseVisualStyleBackColor = true;
            this.Speed.CheckedChanged += new System.EventHandler(this.Speed_CheckedChanged);
            this.Speed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Speed_MouseClick);
            this.Speed.MouseCaptureChanged += new System.EventHandler(this.Speed_MouseCaptureChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.mypanel1);
            this.Controls.Add(this.redo);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.load);
            this.Controls.Add(this.NumofPanel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = "Form3";
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
        private System.Windows.Forms.RadioButton Time;
        private System.Windows.Forms.RadioButton Speed;
    }
}