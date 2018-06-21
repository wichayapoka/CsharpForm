using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

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
        //class History
        //{
        //    public int local_x;
        //    public int local_y;

        //    private Control target1;


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
        class Undo_json
        {
           
            public int X { get; set; }
            public int Y { get; set; }
            public int T { get; set; }

        }
        //drag selection
        private Point selectionStart;
        private Point selectionEnd;
        private Rectangle selection; 
        //Undo, Redo
        List<History> history_undo = new List<History>();
        List<History> history_redo = new List<History>();
        List<int> select_count = new List<int>(); //move selected panel
        List<int> select_count_r = new List<int>();
        List<Undo_json> undo_j = new List<Undo_json>();
        
        public Mypanel()
        {
            InitializeComponent();
        }
        public void AddBluePanel(int x, int y)
        {
            //event delegate
            Panel bluepanel = new Panel();
            bluepanel.Size = new Size(10, 10);
            bluepanel.Location = new Point(x, y);
            bluepanel.BackColor = Color.Blue;
            bluepanel.Tag = this.Controls.Count;
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
                    //AddSelect_count(); //save to json
                }
                //select_count.Add(selected_panel.Count);

            } else //click only
            {
                if (Control.ModifierKeys != Keys.Control)
                {
                    select_count.Add(selected_panel.Count);
                    //AddSelect_count(); //save to json
                }
               
                c.BackColor = Color.Blue;
                //Console.WriteLine(panel_history.Count);
                selected_panel.Clear();
            }
            Focus_panel();      
        }

        private void Bluepanel_MouseMove(object sender, MouseEventArgs e)
        {

            Control c = sender as Control;

            if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Control) //moving panel
            {
                foreach (Control C in selected_panel)
                {
                    if (selected_panel.Contains(C))
                    {
                        C.Location = new Point(e.X + C.Left - x, e.Y + C.Top - y);
                    }
                    
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
                //History hx = new History();
                //hx.target1 = sender as Control;
                if (Control.ModifierKeys == Keys.Control)
                {
                    c.BackColor = Color.Yellow;
                    if (!selected_panel.Contains(c))
                    {
                        selected_panel.Add(c);
                        hx.target1.Location = c.Location;
                        //hx.local_x = c.Left;
                        //hx.local_y = c.Top;
                        //panel_history.Add(c);
                        //AddUndo_json(hx);
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
                        //AddUndo_json(hx);
                        history_undo.Add(hx);

                    }
                    
                    
                }
                Console.WriteLine("Selected panel = {0}", selected_panel.Count);

            } //reference ident
            
        }

        private void Mypanel_KeyDown(object sender, KeyEventArgs e)
        {
            int count = this.Controls.Count;
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                if (this.Controls.Count > 0) 
                {
                    
                    foreach (Control sel in this.Controls)
                    {
                        sel.BackColor = Color.Yellow;
                        if (!selected_panel.Contains(sel))
                        {
                            History hx = new History(sel.Left, sel.Top, sel);
                            //History hx = new History();
                            //hx.target1 = sel as Control;
                            selected_panel.Add(sel);
                            //hx.local_x = sel.Left;
                            //hx.local_y = sel.Top;
                            hx.target1.Location = sel.Location;
                            
                            //AddUndo_json(hx);
                            history_undo.Add(hx);
                        }
                        

                    }
                    
                    
                }
                Focus_panel();
                //Console.WriteLine(local_x.Count);
                
                
            }
           
            else if (e.KeyCode == Keys.Delete)
            {
                
                foreach (Control C in selected_panel)
                {
                    Control selected = C as Control;
                    //this.Controls.Remove(selected);
                    this.Controls.Remove(C);
                    history_undo.RemoveAt(history_undo.Count - 1);
                    undo_j.RemoveAt(undo_j.Count - 1);

                }
                
                selected_panel.Clear();
                //history_undo.RemoveAt(history_undo.Count - 1);
                Focus_panel(); //delete and focus 
            }
            
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z && selected_panel.Count == 0) //unselect before undo
            {
                Undo_(sender, e);
                
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
            
            foreach (Control selected in selected_panel)
            {
                Control deselect = selected as Control;
                deselect.BackColor = Color.Blue;
                
                
                index -= 1;
            }
            selected_panel.Clear();
            //Point
            selectionStart = e.Location;
            
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
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            
        }

        private void Mypanel_MouseUp(object sender, MouseEventArgs e)
        {
            selectionEnd = e.Location;
            int x, y; //point
            int width, height; //size
            //Point
            if (selectionStart.X > selectionEnd.X)
            {
                x = selectionEnd.X;
            }
            else
            {
                x = selectionStart.X;
            }
            if (selectionStart.Y > selectionEnd.Y)
            {
                y = selectionEnd.Y;
            }
            else
            {
                y = selectionStart.Y;
            }

            //size
            if (selectionStart.X > selectionEnd.X)
            {
                width = selectionStart.X - selectionEnd.X;
            } else
            {
                width = selectionEnd.X - selectionStart.X;
            } if (selectionStart.Y > selectionEnd.Y)
            {
                height = selectionStart.Y - selectionEnd.Y;
            } else
            {
                height = selectionEnd.Y - selectionStart.Y;
            }
            //create rectangle
            selection = new Rectangle(x, y, width, height);
            GetSelectedPanel();
        }
        private void GetSelectedPanel()
        {
            foreach (Control c in this.Controls)
            {

                if (selection.Contains(c.Bounds)) //panel inside rectangle?
                {
                    
                    c.BackColor = Color.Yellow;
                    History hx = new History(c.Left, c.Top, c);
                    //History hx = new History();
                    //hx.local_x = c.Left;
                    //hx.local_y = c.Top;
                    //hx.target1 = c;
                    selected_panel.Add(c);
                    history_undo.Add(hx);   
                }
            }
            Console.WriteLine("SelectionStart = {0}", selectionStart);
            Console.WriteLine("SelectionEnd = {0}", selectionEnd);
            
        }

        private void Mypanel_Load(object sender, EventArgs e)
        {
            
            
        }
        public void Focus_panel()
        {
            this.Focus();
        }
        public void Undo_(object sender, EventArgs e)
        {
            
            //int index_u = history_undo.Count();
            Console.WriteLine("History = {0}", history_undo.Count);
            
            if ( selected_panel.Count == 0 && select_count.Count != 0)
            {
                for (int i = 0; i < select_count[select_count.Count - 1]; i++) //undo muitiple panels
                {
                    if (history_undo.Count == 0)
                    {
                        return;
                    }
                    
                    Control target = history_undo[history_undo.Count - 1].target1;
                    History hx = new History(target.Left, target.Top, target); //readonly
                    //History hx = new History();
                    //hx.local_x = target.Left;
                    //hx.local_y = target.Top;
                    //hx.target1 = target;
                   
                    history_redo.Add(hx);
                    Undo_with_animation(sender, e);
                    //history_undo[history_undo.Count - 1].target1.Location =
                    //new Point(history_undo[history_undo.Count - 1].local_x, history_undo[history_undo.Count - 1].local_y);
                    //history_undo.RemoveAt(history_undo.Count - 1); //remove last history undo


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
                    //History hx = new History();
                    //hx.local_x = history_redo[index_r - 1].local_x;
                    //hx.local_y = history_redo[index_r - 1].local_y;
                    //hx.target1 = target;
                    history_undo.Add(hx);
                    history_redo[history_redo.Count - 1].target1.Location = new Point(history_redo[history_redo.Count - 1].local_x, history_redo[history_redo.Count - 1].local_y);
                    Console.WriteLine(history_redo[history_redo.Count - 1].target1.Location);
                    history_redo.RemoveAt(history_redo.Count - 1);
                    
                }
                select_count.Add(select_count_r[select_count_r.Count - 1]);
                select_count_r.RemoveAt(select_count_r.Count - 1);
            }
        }
        private void Undo_with_animation(object sender, EventArgs e)
        {
            int undo_x, undo_y;
            int time = 5;
            float distance_x, distance_y;
            Console.WriteLine(history_undo[history_undo.Count - 1].local_x);
            undo_x = history_undo[history_undo.Count - 1].target1.Left;
            undo_y = history_undo[history_undo.Count - 1].target1.Top;
            //Invoke(Undo_timer);
            this.Undo_timer.Start();
            Undo_timer.Tick += (s2, e2) =>
            {
                if (history_undo.Count != 0) //
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        if (history_undo[history_undo.Count - 1].target1.Left != history_undo[history_undo.Count - 1].local_x
                        || history_undo[history_undo.Count - 1].target1.Top != history_undo[history_undo.Count - 1].local_y)
                        {
                            if (history_undo[history_undo.Count - 1].target1.Left > history_undo[history_undo.Count - 1].local_x) //current and history
                            {
                                history_undo[history_undo.Count - 1].target1.Left -= 1;
                            }
                            if (history_undo[history_undo.Count - 1].target1.Top > history_undo[history_undo.Count - 1].local_y)
                            {
                                history_undo[history_undo.Count - 1].target1.Top -= 1;
                            }
                            if (history_undo[history_undo.Count - 1].target1.Left < history_undo[history_undo.Count - 1].local_x)
                            {
                                history_undo[history_undo.Count - 1].target1.Left += 1;
                            }
                            if (history_undo[history_undo.Count - 1].target1.Top < history_undo[history_undo.Count - 1].local_y)
                            {
                                history_undo[history_undo.Count - 1].target1.Top += 1;
                            }


                        }
                        else
                        {
                            this.Undo_timer.Stop();
                            history_undo.RemoveAt(history_undo.Count - 1);
                        }
                    }));
                }
               
            };
        }
        private void AddUndo_json(History hx) //x, y Save to json
        {
           
                Undo_json one = new Undo_json();

                one.X = hx.local_x;
                one.Y = hx.local_y;
                one.T = (int)hx.target1.Tag;
                
                undo_j.Add(one);
            
            
            
        }
        
        public void Save_undo_Count()
        {
            undo_j.Clear();
            JsonSerializer json = new JsonSerializer();
            using (FileStream fs = new FileStream("ListCountHistory.json", FileMode.Create))
            using (StreamWriter s = new StreamWriter(fs))
            {

                json.Serialize(s, select_count);
                fs.Flush();

            }
            JsonSerializer json2 = new JsonSerializer();

            using (FileStream fs = new FileStream("History.json", FileMode.Create))
            using (StreamWriter s = new StreamWriter(fs))
            {
                foreach (History undo in history_undo)
                {
                    AddUndo_json(undo);
                }
                json2.Serialize(s, undo_j);
                fs.Flush();

            }


        }
        public void Load_History_undo(int x, int y, int tag) //load json
        {
            foreach (Control load in this.Controls)
            {
                if ((int)load.Tag == tag)
                {
                    History hx = new History(x, y, load);
                    history_undo.Add(hx);
                    //AddUndo_json(hx);
                }
            }
        }

        public void Load_Select_Count(int select) //load json
        {
            select_count.Add(select);
        }

        private void Undo_timer1_Tick(object sender, EventArgs e)
        {
            
        }

        public void Clear()
        {
            
            selected_panel.Clear();
            history_undo.Clear();
            history_redo.Clear();
            select_count.Clear();
            select_count_r.Clear();
           

        }
       
    }
}
