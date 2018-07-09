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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
namespace WindowsFormsExample
{
    public partial class Form3 : Form
    {
        List<Control> selected = new List<Control>();
        public Form3()
        {
            //Undo_timer.Stop();
            InitializeComponent();
            this.ActiveControl = NumofPanel;
            Time.Checked = true;
            
        }
        
        public class Blue
        {
            public int X { get; set; }
            public int Y
            {
                get; set;
            }
            public int T { get; set; }
        }
        List<Blue> p = new List<Blue>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }
            string input = NumofPanel.Text;
            if (!string.IsNullOrEmpty(input) && 
               (!string.IsNullOrEmpty(Time_or_speed.Text))) //not empty

            {
                //input validation (ctrl+v)
                if (Time.Checked == true)
                {
                    mypanel1.Set_Step(Convert.ToInt32(Time_or_speed.Text));
                }
                if (Speed.Checked == true)
                {
                    mypanel1.Set_Speed(Convert.ToInt32(Time_or_speed.Text));
                }   

                //create panel
                int number = Convert.ToInt32(input);
                this.mypanel1.Controls.Clear();
                for (int i = 0; i < number; i++)
                {
                    mypanel1.AddBluePanel(i * 10, i * 10);
                    mypanel1.Tag = i;
                }
                mypanel1.Focus_panel();  
            } else
            {
                this.ActiveControl = NumofPanel; //input number
                MessageBox.Show("Please enter a valid number.");
                if (string.IsNullOrEmpty(Time_or_speed.Text))
                {
                    this.ActiveControl = Time_or_speed;
                }
            }
            mypanel1.Clear();
            
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            
            if (mypanel1.Undo_timer.Enabled) { return; }
            using (FileStream fs = new FileStream("SavePanel.json", FileMode.Create))
            using (StreamWriter file = new StreamWriter(fs))
               
            {
                JsonSerializer json = new JsonSerializer();

                //Blue one = new Blue();

                foreach (Control c in this.mypanel1.Controls)
                {
                    Blue one = new Blue();

                    one.X = c.Left;
                    one.Y = c.Top;
                    one.T = (int)c.Tag;
                    p.Add(one);

                }
                json.Serialize(file, p);
                
                //json.Serialize(post, p);

            }
            mypanel1.Save_undo_Count();
            //uploadstring
            using (StreamReader fs1 = new StreamReader("SavePanel.json"))
            using (StreamReader fs2 = new StreamReader("History.json"))
            using (StreamReader fs3 = new StreamReader("ListCountHistory.json"))
            {
                string json1 = fs1.ReadToEnd();
                string json2 = fs2.ReadToEnd();
                string json3 = fs3.ReadToEnd();
                string all = json1 + "|" + json2 + "|" + json3;
                WebClient wb = new WebClient();
                
                
                string result = wb.UploadString("http://localhost:8081/Undo_Data/post", all);
            }
            mypanel1.Focus_panel();
            p.Clear();
            

        }
        
        private void load_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }

            this.mypanel1.Controls.Clear();
            mypanel1.Clear();
            int left = 0, top = 0, tag = 0;

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
                            tag = (int)p.Value;
                        }
                        //Console.WriteLine(p.Name);
                    }
                    mypanel1.AddBluePanel(left, top);
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
                            tag = (int)p.Value;
                        }
                        //Console.WriteLine(p.Name);
                        
                    }
                    mypanel1.Load_History_undo(left, top, tag);
                    
                }
                //mypanel1.Clear();

            }
            using (StreamReader fs = new StreamReader("ListCountHistory.json"))
            {
                string json = fs.ReadToEnd();
                if (json != "")
                {
                    JArray undo = JArray.Parse(json);
                    foreach (JValue o in undo)
                    {
                        //Console.WriteLine(o);
                        mypanel1.Load_Select_Count((int)o);
                    }
                }
            }
            if (!string.IsNullOrEmpty(Time_or_speed.Text))
            {
                if (Time.Checked == true)
                {
                    mypanel1.Set_Step(Convert.ToInt32(Time_or_speed.Text));
                }
                if (Speed.Checked == true)
                {
                    mypanel1.Set_Speed(Convert.ToInt32(Time_or_speed.Text));
                }
            }
            
            mypanel1.Focus_panel();
            
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }

            mypanel1.Undo_(sender, e);
            mypanel1.Focus_panel();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }

            mypanel1.Redo_();
            mypanel1.Focus_panel();
        }

        private void mypanel1_Load(object sender, EventArgs e)
        {

        }

        private void mypanel1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void mypanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //this.Text = "Clear";
        }

        

        private void Time_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void Speed_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void Time_MouseClick(object sender, MouseEventArgs e) //selected
        {
            this.ActiveControl = Time_or_speed;
        }

        private void Speed_MouseClick(object sender, MouseEventArgs e) //selected
        {
            this.ActiveControl = Time_or_speed;
        }

        private void Speed_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void Speed_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Time_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Time_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //number only
            {
                e.Handled = true;
            }
        }

        private void NumofPanel_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumofPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //number only
            {
                e.Handled = true;
            }
        }

        private void Set_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }
            if (Time.Checked == true)
            {
                mypanel1.Set_Step(Convert.ToInt32(Time_or_speed.Text));
            }
            if (Speed.Checked == true)
            {
                mypanel1.Set_Speed(Convert.ToInt32(Time_or_speed.Text));
            }
            mypanel1.Focus_panel();
        }

        private void save_server_Click(object sender, EventArgs e)
        {
            JsonSerializer json = new JsonSerializer();

            //Blue one = new Blue();

            foreach (Control c in this.mypanel1.Controls)
            {
                Blue one = new Blue();

                one.X = c.Left;
                one.Y = c.Top;
                one.T = (int)c.Tag;
                p.Add(one);

            }
            
            
        }

        private void Load_server_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }
            WebClient wb = new WebClient();
            string result = wb.DownloadString("http://localhost:8081/Undo_Data/post");
            string[] Data = result.Split("|".ToCharArray());
            JArray Blue_Panel = JArray.Parse(Data[0]);
            JArray History = JArray.Parse(Data[1]);
            JArray ListCount = JArray.Parse(Data[2]);
            

            this.mypanel1.Controls.Clear();
            mypanel1.Clear();
            int left = 0, top = 0, tag = 0;
            //Panel
            foreach (JObject o in Blue_Panel.Children<JObject>())
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
                    
                    //Console.WriteLine(p.Name);
                }
                mypanel1.AddBluePanel(left, top);
            }
            //Undo
            foreach (JObject o in History.Children<JObject>())
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
                        tag = (int)p.Value;
                    }
                    //Console.WriteLine(p.Name);

                }
                mypanel1.Load_History_undo(left, top, tag);

            }
            mypanel1.Focus();
            //ListCount
            
            foreach (JValue o in ListCount)
            {
                //Console.WriteLine(o);
                mypanel1.Load_Select_Count((int)o);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Time_or_speed.Text = "1"; //default 1 second time
        }
    }
}
