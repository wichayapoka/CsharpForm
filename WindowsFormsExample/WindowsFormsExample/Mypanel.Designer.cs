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
            this.SuspendLayout();
            // 
            // Undo_timer
            // 
            this.Undo_timer.Tick += new System.EventHandler(this.Undo_timer1_Tick);
            // 
            // Mypanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Mypanel";
            this.Size = new System.Drawing.Size(768, 386);
            this.Load += new System.EventHandler(this.Mypanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mypanel_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Mypanel_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Mypanel_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mypanel_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mypanel_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Bluepanel_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Undo_timer;
    }
}
