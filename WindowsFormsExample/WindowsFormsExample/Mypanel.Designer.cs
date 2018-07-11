namespace WindowsFormsExample
{
    partial class Mypanel
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
            this.Undo_timer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Undo_timer
            // 
            this.Undo_timer.Tick += new System.EventHandler(this.Undo_timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(667, 363);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Mypanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.textBox1);
            this.Name = "Mypanel";
            this.Size = new System.Drawing.Size(768, 386);
            this.Load += new System.EventHandler(this.Mypanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mypanel_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Mypanel_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Mypanel_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mypanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mypanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mypanel_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer Undo_timer;
        private System.Windows.Forms.TextBox textBox1;
    }
}
