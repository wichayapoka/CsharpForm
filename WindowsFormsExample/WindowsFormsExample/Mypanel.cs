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
        //Point selectionStart; //drag
        
        List<int> selected_index = new List<int> { };
        
        List<Control> selected_panel = new List<Control>();
        
        int select_all = 0;
        enum Undo{
            Unknown, Position
        };
        class History
        {
            public int local_x;
            public int local_y;
            public int index_control;
            //public Panel target;
            public Control target1;
            public override string ToString()
            {
                if (target1 != null)
                {
                    
                } else
                {

                }
                return base.ToString();
            }
        }
        //List<History> panel_history = new List<History>();
        Stack<Control> history_u = new Stack<Control>();
        List<Control> panel_history = new List<Control>();
        List<History> history = new List<History>();
        //List<int> local_x = new List<int>();
        //List<int> local_y = new List<int>();

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
            
            



        }

        private void Bluepanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void Bluepanel_MouseUp(object sender, MouseEventArgs e)
        {
            
            Control c = sender as Control;
            if (Control.ModifierKeys == Keys.Control) //selected, stay yellow
            {
                c.BackColor = Color.Yellow;

            } else //click only
            {
                foreach (Control C in selected_panel)
                {
                    Control selected = (Control)C;
                    selected.BackColor = Color.Blue;
                }
                selected_panel.Clear();
                //c.BackColor = Color.Blue;
                //Console.WriteLine(panel_history.Count);
            }
            Focus_panel();
            select_all = 0;
            
            //throw new NotImplementedException();
        }


        

        

        private void Bluepanel_MouseMove(object sender, MouseEventArgs e)
        {

            Control c = sender as Control;

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Control)
            {
                foreach (Control C in selected_panel)
                {
                    Control selected = C as Control;
                    selected.Location = new Point(e.X + selected.Left - x, e.Y + selected.Top - y);
                    
                }
                
            }
            
            Focus_panel();
            
        }

        private void Bluepanel_MouseDown(object sender, MouseEventArgs e)
        {

            Control c = (Control)sender;

            if (e.Button == MouseButtons.Left)
            {
                History hx = new History();
                hx.target1 = sender as Control;

                if (Control.ModifierKeys == Keys.Control)
                {
                    c.BackColor = Color.Yellow;
                    if (!selected_panel.Contains(c))
                    {
                        selected_panel.Add(c);
                        hx.target1.Location = c.Location;
                        hx.local_x = c.Left;
                        hx.local_y = c.Top;
                        hx.index_control = this.Controls.IndexOf(c);
                        //panel_history.Add(c);
                        history.Add(hx);
                    } 
                    
                } else
                {
                    x = e.X;
                    y = e.Y;
                    c.BackColor = Color.Yellow;
                    hx.local_x = c.Left;
                    hx.local_y = c.Top;
                    history.Add(hx);


                    //hx.local_x = c.Left;
                    //hx.local_y = c.Top;
                    //hx.index_control = this.Controls.GetChildIndex(c);
                    if (!selected_panel.Contains(c))
                    {
                        selected_panel.Add(c);
                        hx.target1.Location = c.Location;
                        //panel_history.Add(c);
                        history.Add(hx);
                    }
                    
                    //Console.WriteLine(panel_history.Count);
                    //Console.WriteLine(panel_history[0].Location);
                }
                

            }
            
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
                        sel.BackColor = Color.Yellow;
                        if (!selected_panel.Contains(sel))
                        {
                            selected_panel.Add(sel);
                        }
                        

                    }
                    
                    
                }
                Focus_panel();
                //Console.WriteLine(local_x.Count);
                
                
            }
            if (e.KeyCode == Keys.Delete && select_all == 1) //select all
            {
                this.Controls.Clear();
                selected_index.Clear();
                selected_panel.Clear();
                Focus_panel();
                select_all = 0;
                
            }
            Control c = sender as Control;
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z) //undo
            {
                int index_u = history.Count();
                if (index_u != 0)
                {
                     //???
                     c.Location = new Point(history[index_u - 1].local_x, history[index_u - 1].local_y);
                    
                    

                    history.RemoveAt(index_u - 1);
                }
            } if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Y) //redo
            {

            }

        }

        private void Mypanel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Mypanel_MouseDown(object sender, MouseEventArgs e) //clear
        {
            
            
            select_all = 0;
            foreach (Control selected in selected_panel)
            {
                Control deselect = selected as Control;
                deselect.BackColor = Color.Blue;
            }
            selected_panel.Clear();
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
        public void Undo_(object sender)
        {
            
            int index_u = selected_panel.Count();
            if (index_u != 0) //not empty
            {
                /*Panel undo_p = new Panel();
                undo_p.Location = new Point(panel_history[index_u - 1].local_x, panel_history[index_u - 1].local_y);
                undo_p.BackColor = Color.Blue;
                undo_p.Size = new Size(10, 10);
                this.Controls.RemoveAt(panel_history[index_u - 1].index_control);
                panel_history.RemoveAt(index_u - 1);
                this.Controls.Add(undo_p);
                undo_p.MouseDown += Bluepanel_MouseDown;
                undo_p.MouseUp += Bluepanel_MouseUp;
                undo_p.MouseMove += Bluepanel_MouseMove;*/
                
                foreach (Control c in this.Controls)
                {
                    
                    c.Location = new Point(history[index_u - 1].local_x, history[index_u - 1].local_y);
                }
                //c.Location = new Point(history[index_u - 1].local_x, history[index_u - 1].local_y);
                
                history.RemoveAt(index_u - 1);

            }
           

        }
        public void Clear()
        {
            selected_panel.Clear();
        }
    }
}
