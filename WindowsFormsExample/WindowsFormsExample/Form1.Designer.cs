namespace WindowsFormsExample
{
    partial class Form1
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
            this.Numinput = new System.Windows.Forms.TextBox();
            this.textBoxRead = new System.Windows.Forms.TextBox();
            this.Preview = new System.Windows.Forms.Button();
            this.showpath = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(171, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Write";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Write_Click);
            // 
            // Numinput
            // 
            this.Numinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Numinput.Location = new System.Drawing.Point(12, 12);
            this.Numinput.Name = "Numinput";
            this.Numinput.Size = new System.Drawing.Size(137, 30);
            this.Numinput.TabIndex = 2;
            this.Numinput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxRead
            // 
            this.textBoxRead.Location = new System.Drawing.Point(12, 48);
            this.textBoxRead.Multiline = true;
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.Size = new System.Drawing.Size(424, 390);
            this.textBoxRead.TabIndex = 3;
            this.textBoxRead.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Preview
            // 
            this.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Preview.Location = new System.Drawing.Point(306, 12);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(130, 30);
            this.Preview.TabIndex = 4;
            this.Preview.Text = "Preview";
            this.Preview.UseVisualStyleBackColor = true;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // showpath
            // 
            this.showpath.FormattingEnabled = true;
            this.showpath.ItemHeight = 16;
            this.showpath.Location = new System.Drawing.Point(442, 12);
            this.showpath.Name = "showpath";
            this.showpath.Size = new System.Drawing.Size(346, 196);
            this.showpath.TabIndex = 6;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.treeView1.Location = new System.Drawing.Point(442, 214);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(346, 224);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.showpath);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.textBoxRead);
            this.Controls.Add(this.Numinput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Numinput;
        private System.Windows.Forms.TextBox textBoxRead;
        private System.Windows.Forms.Button Preview;
        private System.Windows.Forms.ListBox showpath;
        private System.Windows.Forms.TreeView treeView1;
    }
}

