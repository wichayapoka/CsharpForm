using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsExample
{
    public partial class Form2 : Form
    {
        
        int x, y; //location
        bool drag; //mouseclick active or not
        public Form2()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = Numpanel.Text;
            if (!string.IsNullOrEmpty(input)) //not empty

            {
                int number = Convert.ToInt32(input);
                this.panel1.Controls.Clear();
                for (int i = 0; i < number; i++)
                {
                    Panel bluepanel = new Panel();
                    bluepanel.Size = new Size(10, 10);
                    bluepanel.Location = new Point(i * 10, i * 10);
                    bluepanel.BackColor = Color.Blue;
                    this.panel1.Controls.Add(bluepanel);
                    
                }
                foreach (Control c in this.panel1.Controls)
                {
                    
                    c.MouseUp += this.Panel1_MouseUp;
                    c.MouseMove += this.Panel1_MouseMove;
                    c.MouseDown += this.Panel1_MouseDown;
                    
                }
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            
            if (e.Button == MouseButtons.Left)
            {
                
                drag = true;
                x = e.X;
                y = e.Y;
                c.BackColor = Color.Yellow;

            }
            
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
           
            if (drag)
            {
                c.Location = new Point(e.X + c.Left - x, e.Y + c.Top - y);

            }
            
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            
            drag = false;
            c.BackColor = Color.Blue;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("bluepoint.bin", FileMode.Create))
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                foreach (Control c in this.panel1.Controls)
                {
                    //size
                    //w.Write(c.Width); 
                    //w.Write(c.Height);
                    //location
                    w.Write(c.Left); //X
                    w.Write(c.Top); //Y
                    
                    
                }
                fs.Flush();
                    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            int left, top;
            
            using (FileStream fs = new FileStream("bluepoint.bin", FileMode.Open))
            using (BinaryReader r = new BinaryReader(fs))
            {
                
                while (r.BaseStream.Position != r.BaseStream.Length)
                { 

                    Panel bluepanel = new Panel();
                    //size1 = r.ReadInt32();
                    //size2 = r.ReadInt32();
                    left = r.ReadInt32();
                    top = r.ReadInt32();
                    bluepanel.Size = new Size(10,10);
                    bluepanel.BackColor = Color.Blue;
                    bluepanel.Location = new Point(left, top); //X,Y
                    this.panel1.Controls.Add(bluepanel);
                    


                }
                fs.Flush();
                foreach (Control c in this.panel1.Controls)
                {

                    c.MouseUp += this.Panel1_MouseUp;
                    c.MouseMove += this.Panel1_MouseMove;
                    c.MouseDown += this.Panel1_MouseDown;

                }





            }
            

        }
       

        
    }
}
