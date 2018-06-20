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

namespace WindowsFormsExample
{
    public partial class Form3 : Form
    {
        List<Control> selected = new List<Control>();
        public Form3()
        {
            InitializeComponent();
            this.ActiveControl = NumofPanel;
        }
        
        public class Blue
        {
            public int x { get; set; }
            public int y
            {
                get; set;
            }
            
        }
        List<Blue> p = new List<Blue>();

        private void button1_Click(object sender, EventArgs e)
        {
            string input = NumofPanel.Text;
            if (!string.IsNullOrEmpty(input)) //not empty

            {
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
            }
            mypanel1.Clear();
            
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            
            using (FileStream fs = new FileStream("bluepoint_json.json", FileMode.Create))
            using (StreamWriter file = new StreamWriter(fs))
               
            {
                JsonSerializer json = new JsonSerializer();

                //Blue one = new Blue();

                foreach (Control c in this.mypanel1.Controls)
                {
                    Blue one = new Blue();

                    one.x = c.Left;
                    one.y = c.Top;
                    p.Add(one);

                }
                json.Serialize(file, p);

            }
            mypanel1.Save_undo_Count();
            mypanel1.Focus_panel();
            p.Clear();
            //using (FileStream fs = new FileStream("bluepoint_user.bin", FileMode.Create))
            //using (BinaryWriter w = new BinaryWriter(fs))
            //{
            //    foreach (Control c in this.mypanel1.Controls)
            //    {

            //        //location
            //        w.Write(c.Left); //X
            //        w.Write(c.Top); //Y

            //    }
            //    fs.Flush();
            //    mypanel1.Focus_panel();
            //}

        }

        private void load_Click(object sender, EventArgs e)
        {
            this.mypanel1.Controls.Clear();
            mypanel1.Clear();
            int left = 0, top = 0, tag = 0;

            using (StreamReader fs = new StreamReader("bluepoint_json.json"))
            
            {
                
                string json = fs.ReadToEnd();

                JArray a = JArray.Parse(json);
                //Console.WriteLine(a);
                foreach (JObject o in a.Children<JObject>())
                {
                    
                    foreach (JProperty p in o.Properties())
                    {
                        if (p.Name == "x")
                        {
                            left = (int)p.Value;
                        } if (p.Name == "y")
                        {
                            top = (int)p.Value;
                        }
                        //Console.WriteLine(p.Name);
                    }
                    mypanel1.AddBluePanel(left, top);
                }
                mypanel1.Clear();
            }
            using (StreamReader fs = new StreamReader("undo.json"))
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
            using (StreamReader fs = new StreamReader("select_count.json"))
            {
                string json = fs.ReadToEnd();
                JArray undo = JArray.Parse(json);
                foreach (JValue o in undo)
                {
                    //Console.WriteLine(o);
                    mypanel1.Load_Select_Count((int)o);
                }
            }
            mypanel1.Focus_panel();
            //using (FileStream fs = new FileStream("bluepoint_user.bin", FileMode.Open))
            //using (BinaryReader r = new BinaryReader(fs))
            //{

            //    while (r.BaseStream.Position != r.BaseStream.Length)
            //    {
            //        Panel bluepanel = new Panel();
            //        //location
            //        left = r.ReadInt32();
            //        top = r.ReadInt32();
            //        //show blue panels
            //        mypanel1.AddBluePanel(left, top);

            //    }
            //    mypanel1.Focus_panel();
            //    fs.Flush();
            //    mypanel1.Clear();

            //}
        }

        private void undo_Click(object sender, EventArgs e)
        {
            mypanel1.Undo_();
            mypanel1.Focus_panel();
        }

        private void redo_Click(object sender, EventArgs e)
        {
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
    }
}
