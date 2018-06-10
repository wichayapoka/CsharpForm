using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExample
{
   
    public partial class Mypanel : UserControl
    {
        int x, y;
       
        int selected = 0;
        Control selectedControl;
        Point selectionStart;
        Point selectionEnd;
        Rectangle selection;
        List<int> selected_index = new List<int> { };
        int select_all = 0;
        

        public Mypanel()
        {
            InitializeComponent();
        }
        public void AddBluePanel(int x, int y)
        {
            Panel bluepanel = new Panel();
            bluepanel.Size = new Size(10, 10);
            bluepanel.Location = new Point(x, y);
            bluepanel.BackColor = Color.Blue;
            this.Controls.Add(bluepanel);
            bluepanel.MouseDown += Bluepanel_MouseDown;
            bluepanel.MouseMove += Bluepanel_MouseMove;
            bluepanel.MouseUp += Bluepanel_MouseUp;
            bluepanel.PreviewKeyDown += Bluepanel_PreviewKeyDown;
            



        }

        private void Bluepanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void Bluepanel_MouseUp(object sender, MouseEventArgs e)
        {
            
            Control c = sender as Control;
            if (Control.ModifierKeys == Keys.Control)
            {
                if (c != null)
                {
                    selectedControl = c;
                }
                //c.BackColor = Color.Yellow;
               

                Panel select = new Panel();
                select.Location = new Point(c.Left, c.Top);
                select.BackColor = c.BackColor;
                select.Size = new Size(10, 10);
                select.BackColor = Color.Yellow;
                
                select.MouseDown += Select_MouseDown;
                select.MouseMove += Select_MouseMove;
                select.MouseUp += Select_MouseUp;
                //location
                //local_x.Add(c.Left);
                //local_y.Add(c.Top);
                selected += 1;
                //Console.WriteLine(this.Controls.IndexOf(c));
                //selected_index.Add(this.Controls.IndexOf(c));
                this.Controls.Remove(c);
                this.Controls.Add(select);
                Console.WriteLine(this.Controls.IndexOf(select));
                //selected_index.Sort();
                
                
                


                //Console.WriteLine(local_x[0]);
                //c.Select();


            } else
            {
                c.BackColor = Color.Blue;
                
            }
            Focus_panel();
            

            //throw new NotImplementedException();
        }


        private void Select_MouseUp(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            int count = this.Controls.Count;
            //this.Controls.Clear();
            select_all = 0;
            foreach (Control sel in this.Controls)
            {
                Panel blue = new Panel();
                blue.Location = sel.Location;
                sel.BackColor = Color.Blue;
                blue.BackColor = sel.BackColor;
                blue.Size = new Size(10, 10);
                blue.MouseUp += Bluepanel_MouseUp;
                blue.MouseMove += Bluepanel_MouseMove;
                blue.MouseDown += Bluepanel_MouseDown;
                
                this.Controls.Add(blue);
                
            }
            for (int i = 0; i < count; i++)
            {
                this.Controls.RemoveAt(0);
            }
            
            
            Focus_panel();
            
            
            
            //throw new NotImplementedException();
        }

        private void Select_MouseMove(object sender, MouseEventArgs e)
        {

            Control s = sender as Control;
            
        
            
            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Control)
            {
                //sel.Location = new Point(e.X + sel.Left - x, e.Y + sel.Top - y);
                
                foreach (Control sel in this.Controls)
                {
                    if (sel.BackColor == Color.Yellow)
                    {
                        sel.Location = new Point(e.X + sel.Left - x, e.Y + sel.Top - y);
                    }
                    //sel.Location = new Point(e.X + sel.Left - x, e.Y + sel.Top - y);
                    
                }

            }
            
        }

        private void Select_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;

            }
            

            //throw new NotImplementedException();
        }

        private void Bluepanel_MouseMove(object sender, MouseEventArgs e)
        {

            Control c = sender as Control;

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Control)
            {
                c.Location = new Point(e.X + c.Left - x, e.Y + c.Top - y);

            }
            //throw new NotImplementedException();
        }

        private void Bluepanel_MouseDown(object sender, MouseEventArgs e)
        {

            Control c = (Control)sender;

            if (e.Button == MouseButtons.Left)
            {
                
                 x = e.X;
                 y = e.Y;
                 c.BackColor = Color.Yellow;
                
                

            }//throw new NotImplementedException();
        }

        private void Mypanel_KeyDown(object sender, KeyEventArgs e)
        {
            int count = this.Controls.Count;
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                if (select_all == 0 && this.Controls.Count > 0) 
                {
                    select_all = 1;
                    
                    foreach (Control sel in this.Controls)
                    {
                        Panel select = new Panel();
                        select.Location = sel.Location;
                        select.BackColor = Color.Yellow;
                        select.Size = new Size(10, 10);

                        select.MouseDown += Select_MouseDown;
                        select.MouseMove += Select_MouseMove;
                        select.MouseUp += Select_MouseUp;
                        selected_index.Add(this.Controls.IndexOf(sel));

                        //this.Controls.Remove(sel);
                        this.Controls.Add(select);

                    }
                    for (int i = 0; i < count; i++)
                    {
                        this.Controls.RemoveAt(0);
                    }
                }
                Focus_panel();
                //Console.WriteLine(local_x.Count);
                
                
            }
            if (e.KeyCode == Keys.Delete && select_all == 1)
            {

                this.Controls.Clear();
                selected_index.Clear();
                Focus_panel();
                select_all = 0;
                selected = 0;
            }

        }

        private void Mypanel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Mypanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectionStart = PointToClient(MousePosition);
                
            }
        }

        private void Mypanel_KeyUp(object sender, KeyEventArgs e)
        {
            this.Focus();
        }

        private void Mypanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void Mypanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Mypanel_Load(object sender, EventArgs e)
        {
            
            
        }
        public void Focus_panel()
        {
            this.Focus();
        }
        
    }
}
