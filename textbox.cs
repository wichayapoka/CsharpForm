public class Blue
        {
            public int X { get; set; }
            public int Y
            {
                get; set;
            }
            public object T { get; set; }
            public string Text = null;
        }
        List<Blue> p = new List<Blue>();
                private void Save_Click(object sender, EventArgs e)
        {
            
            
            if (this.mypanel1.Controls.Count == 0) //no panel or textbox
            {
                MessageBox.Show("No data has been saved");
                return;
            }
            using (FileStream fs = new FileStream("SavePanel.json", FileMode.Create))
            using (StreamWriter file = new StreamWriter(fs))
               
            {
                JsonSerializer json = new JsonSerializer();

                
                foreach (Control c in this.mypanel1.Controls)
                {
                    Blue one = new Blue();

                    one.X = c.Left;
                    one.Y = c.Top;
                    one.T = c.Tag;
                    if (c is TextBox && c.Text == "")
                    {
                        one.Text = "TextBox";
                    }
                    else { one.Text = c.Text; }
                    
                    
                    p.Add(one);

                }
                json.Serialize(file, p);
                
                //json.Serialize(post, p);

            }
        private void load_Click(object sender, EventArgs e)
        {
            
            int left = 0, top = 0;
            string tag = null;
            string text = "";
            using (StreamReader fs = new StreamReader("SavePanel.json"))
            {
                string json = fs.ReadToEnd();
                JArray a = JArray.Parse(json);
                //Console.WriteLine(a);
                foreach (JObject o in a.Children<JObject>())
                { 
                    foreach (JProperty p in o.Properties())
                    {
                        if (p.Name == "X")
                        {
                            left = (int)p.Value;
                        } if (p.Name == "Y")
                        {
                            top = (int)p.Value;
                        } if (p.Name == "T")
                        {
                            tag = (string)p.Value;
                        } if (p.Name == "Text")
                        {
                            text = (string)p.Value;
                        }
                        //Console.WriteLine(p.Name);
                    }
                    if (tag == "PicBox")
                    {

                    }
                    if (text == "textbox" || text != "")
                    {
                        if (text == "textbox")
                        {
                            text = "";
                        }
                        mypanel1.Create_Textbox(left, top, text);
                    } else
                    {
                        mypanel1.AddBluePanel(left, top);
                    }
                    
                }
                
            }
            using (StreamReader fs = new StreamReader("History.json")) //undo
            {
                string json = fs.ReadToEnd();
                JArray undo = JArray.Parse(json);
                foreach (JObject o in undo.Children<JObject>())
                {

                    foreach (JProperty p in o.Properties())
                    {
                        if (p.Name == "X")
                        {
                            left = (int)p.Value;
                        }
                        if (p.Name == "Y")
                        {
                            top = (int)p.Value;
                        }
                        if (p.Name == "T")
                        {
                            tag = (string)p.Value;

                        }
                        //Console.WriteLine(p.Name);
                    }
                    mypanel1.Load_History_undo(left, top, tag);
                    
                }
                //mypanel1.Clear();

        }
        public void Create_Textbox(int x, int y, string text)
        {
            TextBox txt = new TextBox();
            txt.Name = "text" + this.Controls.Count;
            txt.Text = text;
            txt.Location = new Point(x, y);
            txt.Multiline = true;
            txt.Size = new Size(90, 30);
            txt.Tag = this.Controls.Count;
            txt.MouseDown += Txt_MouseDown;
            txt.MouseMove += Txt_MouseMove;
            txt.MouseUp += Txt_MouseUp;
            txt.MouseDown += Bluepanel_MouseDown;
            txt.MouseMove += Bluepanel_MouseMove;
            txt.MouseUp += Bluepanel_MouseUp;
            
            this.Controls.Add(txt); 
            
        }
        bool resize = false; //textBox
        private void Txt_MouseUp(object sender, MouseEventArgs e)
        {
            resize = false; //finished resize textbox
        }

        private void Txt_MouseMove(object sender, MouseEventArgs e)
        {
            if (resize == false) { return; }
            if (e.Button == MouseButtons.Left && resize == true)
            {
                Control c = (Control)sender;
                var height = Math.Abs(c.Top + e.Y - c.Location.Y);
                var width = Math.Abs(c.Left + e.X - c.Location.X);
                c.Size = new Size(width, height);
            }
            

        }

        

        private void Txt_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            Console.WriteLine(e.Location);
            Console.WriteLine(c.Size);
            resize = false;
            if (Math.Abs(e.X - c.Width) <= 7 && Math.Abs(e.Y - c.Height) <= 7) //bottom right
            {
                resize = true;
            }
            else if (Math.Abs(e.X - c.Width) <= 7 && e.Y <= 5) //top right
            {
                resize = true;
            }
            else if (e.X <= 2 && e.Y <= 2) //top left
            {
                resize = true;
            } 
            else if (e.X <= 2 && Math.Abs(e.Y - c.Height) <= 7) // bottom left
            {
                resize = true;
            }
            
        }