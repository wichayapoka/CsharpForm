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
        
        
        List<Control> selected_panel = new List<Control>();
        
        //int select_all = 0;
        enum Undo {
            Unknown, Position
        };
        //public struct History
        //{
        //    public int local_x;
        //    public int local_y;

        //    public Control target1 { get; set; }

        //}
        class History
        {
            public readonly int local_x;
            public readonly int local_y;
            
            public readonly Control target1;
            public History(int local_x, int local_y, Control target1)
            {
                this.local_x = local_x;
                this.local_y = local_y;
                this.target1 = target1;
            }
        }


        

        List<Control> panel_history = new List<Control>();
        List<History> history_undo = new List<History>();
        List<History> history_redo = new List<History>();
        List<int> select_count = new List<int>();
        List<int> select_count_r = new List<int>();
        
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
            if (Control.ModifierKeys == Keys.Control || selected_panel.Count > 1) //selected, stay yellow
            {
                c.BackColor = Color.Yellow;
                if (Control.ModifierKeys != Keys.Control)
                {
                    select_count.Add(selected_panel.Count); //move selected
                }
                //select_count.Add(selected_panel.Count);

            } else //click only
            {
                if (Control.ModifierKeys != Keys.Control)
                {
                    select_count.Add(selected_panel.Count);
                }
               
                c.BackColor = Color.Blue;
                //Console.WriteLine(panel_history.Count);
                selected_panel.Clear();
            }
            Focus_panel();
            //select_all = 0;
            
            
        }


        

        

        private void Bluepanel_MouseMove(object sender, MouseEventArgs e)
        {

            Control c = sender as Control;

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Control)
            {
                foreach (Control C in selected_panel)
                {
                    if (selected_panel.Contains(C))
                    {
                        C.Location = new Point(e.X + C.Left - x, e.Y + C.Top - y);
                    }
                    //C.Location = new Point(e.X + C.Left - x, e.Y + C.Top - y);
                    
                }
                //select_count.Add(selected_panel.Count);


                history_redo.Clear();
            }
            
            Focus_panel();
            
        }

        private void Bluepanel_MouseDown(object sender, MouseEventArgs e)
        {

            Control c = (Control)sender;

            if (e.Button == MouseButtons.Left)
            {
                History hx = new History(c.Left, c.Top, c);
                //hx.target1 = sender as Control;
                

                if (Control.ModifierKeys == Keys.Control)
                {
                    c.BackColor = Color.Yellow;
                    if (!selected_panel.Contains(c))
                    {
                        selected_panel.Add(c);
                        //hx.target1.Location = c.Location;
                        //hx.local_x = c.Left;
                        //hx.local_y = c.Top;
                        
                        //panel_history.Add(c);
                        history_undo.Add(hx);
                    } 
                    
                } else
                {
                    x = e.X;
                    y = e.Y;
                    
                    c.BackColor = Color.Yellow;

                    




                    if (!selected_panel.Contains(c))
                    {
                        
                        selected_panel.Add(c);
                        //hx.target1.Location = c.Location;
                        //hx.local_x = c.Left;
                        //hx.local_y = c.Top;
                        //panel_history.Add(c);
                        history_undo.Add(hx);

                    }
                    
                    //Console.WriteLine(panel_history.Count);
                    //Console.WriteLine(panel_history[0].Location);
                }
                Console.WriteLine("panel = {0}", selected_panel.Count);

            }
            
        }

        private void Mypanel_KeyDown(object sender, KeyEventArgs e)
        {
            int count = this.Controls.Count;
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                if (this.Controls.Count > 0) 
                {
                    //select_all = 1;
                    
                    foreach (Control sel in this.Controls)
                    {
                        sel.BackColor = Color.Yellow;
                        if (!selected_panel.Contains(sel))
                        {
                            History hx = new History(sel.Left, sel.Top, sel);
                            //hx.target1 = sel as Control;
                            selected_panel.Add(sel);
                            //hx.local_x = sel.Left;
                            //hx.local_y = sel.Top;
                            //hx.target1.Location = sel.Location;
                            //panel_history.Add(c);
                            history_undo.Add(hx);
                        }
                        

                    }
                    
                    
                }
                Focus_panel();
                //Console.WriteLine(local_x.Count);
                
                
            }
            /*else if (e.KeyCode == Keys.Delete && select_all == 1) //select all
            {
                
                this.Controls.Clear();
                
                selected_panel.Clear();
                Focus_panel();
                select_all = 0;
                
            }*/
            else if (e.KeyCode == Keys.Delete)
            {
                
                foreach (Control C in selected_panel)
                {
                    Control selected = C as Control;
                    //this.Controls.Remove(selected);
                    this.Controls.Remove(C);

                }
                selected_panel.Clear();
                Focus_panel(); //delete and focus 
            }
            
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z && selected_panel.Count == 0) //unselect before undo
            {
                Undo_();
                
            } else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Y) //redo
            {
                Redo_();
                
            }

        }

        private void Mypanel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Mypanel_MouseDown(object sender, MouseEventArgs e) //clear
        {

            int index = history_undo.Count - 1;
            //select_all = 0;
            foreach (Control selected in selected_panel)
            {
                Control deselect = selected as Control;
                deselect.BackColor = Color.Blue;
                
                //history_undo.RemoveAt(index);
                index -= 1;
            }
            selected_panel.Clear();
            //history_undo.Clear();
        }

        private void Mypanel_KeyUp(object sender, KeyEventArgs e)
        {
            this.Focus();
            /*Queue<string> queue = new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");

            while (queue.Count > 0)
            {
                MessageBox.Show(queue.Dequeue());
            }
            Stack<string> stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.

            while (stack.Count > 0)
            {
                MessageBox.Show(stack.Pop());
            }*/
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
        public void Undo_()
        {
            //int index_u = history_undo.Count();
            Console.WriteLine("History = {0}", history_undo.Count);

            if (history_undo.Count != 0 && selected_panel.Count == 0)
            {
                for (int i = 0; i < select_count[select_count.Count - 1]; i++) //undo muitiple panels
                {
                    if (history_undo.Count == 0)
                    {
                        return;
                    }
                    Control target = history_undo[history_undo.Count - 1].target1;
                    History hx = new History(target.Left, target.Top, target); //readonly
                    history_redo.Add(hx);
                    history_undo[history_undo.Count - 1].target1.Location =
                        new Point(history_undo[history_undo.Count - 1].local_x, history_undo[history_undo.Count - 1].local_y);
                    history_undo.RemoveAt(history_undo.Count - 1); //remove last history undo

                }
                select_count_r.Add(select_count[select_count.Count - 1]); // redo multiple panel
                select_count.RemoveAt(select_count.Count - 1); // undo multiple panel
                                                               //Control target = history_undo[index_u - 1].target1;
                                                               //History hx = new History(target.Left, target.Top, target);

                //hx.target1 = target;
                //hx.local_x = history_undo[index_u - 1].local_x;
                //hx.local_y = history_undo[index_u - 1].local_y;
                //hx.target1.Location = history_undo[index_u - 1].target1.Location;

                //history_redo.Add(hx);

                //history_redo.Add(history_undo[index_u - 1]);
                //redo_x.Add(history_undo[index_u - 1].local_x);
                //redo_y.Add(history_undo[index_u - 1].local_y);
                //location
                //Console.WriteLine(history_redo[history_redo.Count - 1].target1.Location);
                //Console.WriteLine("undo");

                //history_undo[index_u - 1].target1.Location = new Point(history_undo[index_u - 1].local_x, history_undo[index_u - 1].local_y);

                //Console.WriteLine(history_redo[history_redo.Count - 1].target1.Location);

                //history_undo.RemoveAt(index_u - 1);


            }
        }
        public void Redo_()
        {
            int index_r = history_redo.Count();
            int index_u = history_undo.Count();
            if (history_redo.Count != 0 && select_count_r.Count != 0)
            {
                //Control target = history_redo[index_r - 1].target1;
                //History hx = new History(target.Left, target.Top, target);

                //Console.WriteLine("redo");
                //hx.local_x = history_redo[index_r - 1].local_x;
                //hx.local_y = history_redo[index_r - 1].local_y;
                //hx.target1 = target;
                //Console.WriteLine(history_redo[index_r - 1].target1.Location);
                //Console.WriteLine("a");
                //history_undo.Add(history_redo[index_r - 1]);

                //history_undo.Add(hx);
                //history_redo[index_r - 1].target1.Location = new Point(history_redo[index_r - 1].local_x, history_redo[index_r - 1].local_y);
                //Console.WriteLine(history_redo[index_r - 1].target1.Location);
                //history_redo.RemoveAt(index_r - 1);

                //Console.WriteLine(history_redo[index_r - 1].target1.Location);
                for (int i = 0; i < select_count_r[select_count_r.Count - 1]; i++)
                {
                    Control target = history_redo[history_redo.Count - 1].target1;
                    History hx = new History(target.Left, target.Top, target);
                    history_undo.Add(hx);
                    history_redo[history_redo.Count - 1].target1.Location = new Point(history_redo[history_redo.Count - 1].local_x, history_redo[history_redo.Count - 1].local_y);
                    Console.WriteLine(history_redo[history_redo.Count - 1].target1.Location);
                    history_redo.RemoveAt(history_redo.Count - 1);

                }
                select_count.Add(select_count_r[select_count_r.Count - 1]);
                select_count_r.RemoveAt(select_count_r.Count - 1);
            }
        }

        
        public void Clear()
        {
            Console.WriteLine(history_undo.Count);
            selected_panel.Clear();
            history_undo.Clear();
            history_redo.Clear();
            select_count.Clear();
            select_count_r.Clear();
        }
    }
}
