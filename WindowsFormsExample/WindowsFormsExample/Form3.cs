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
using System.Net.Sockets;
using SharpConnect.MySql;
using SharpConnect.MySql.SyncPatt;

namespace WindowsFormsExample
{
    public partial class Form3 : Form
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                    return ip.ToString();

                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        string ipv4;
        List<Control> selected = new List<Control>();
        public Form3()
        {
            //Undo_timer.Stop();
            InitializeComponent();
            this.ActiveControl = NumofPanel;
            Time.Checked = true;
            ipv4 = GetLocalIPAddress();
        }
        
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
        static MySqlConnectionString GetMySqlConnString()
        {
            string h = "127.0.0.1";
            string u = "root";
            string p = "";
            string d = "panel";
            return new MySqlConnectionString(h, u, p, d);
        }
        private void Set_Panel(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }
            //string input = NumofPanel.Text;
            if (!string.IsNullOrEmpty(NumofPanel.Text) && 
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
                int number = Convert.ToInt32(NumofPanel.Text);

                //this.mypanel1.Controls.Clear();
                int control_count = mypanel1.Controls.Count;
                for (int i = 0; i < control_count - 1; i++) //except textbox1 for focus
                {
                    mypanel1.Controls.RemoveAt(mypanel1.Controls.Count - 1);
                }

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
            if (this.mypanel1.Controls.Count == 1)
            {
                MessageBox.Show("No data has been saved");
                return;
            }
            mypanel1.ExportPictureBox();
            using (FileStream fs = new FileStream("SavePanel.json", FileMode.Create))
            using (StreamWriter file = new StreamWriter(fs))
               
            {
                JsonSerializer json = new JsonSerializer();

                
                foreach (Control c in this.mypanel1.Controls)
                {
                    if (c.Tag.ToString() == "focus")
                    {
                        continue;
                    }
                    Blue one = new Blue();

                    one.X = c.Left;
                    one.Y = c.Top;
                    one.T = c.Tag;
                    if (c is TextBox && c.Text == "")
                    {
                        one.Text = "TextBox";
                    } else if (c.Tag.ToString() == "PicBox")
                    {
                        one.Text = mypanel1.base64String;
                    }
                    else { one.Text = c.Text; }
                    
                    p.Add(one);

                }
                json.Serialize(file, p);
                
                //json.Serialize(post, p);

            }
            mypanel1.Save_undo_Count();
            mypanel1.Focus_panel();
            p.Clear();
            


        }
        
        private void load_Click(object sender, EventArgs e)
        {
            if (mypanel1.Undo_timer.Enabled) { return; }

            //this.mypanel1.Controls.Clear();
            int control_count = mypanel1.Controls.Count;
            for (int i = 0; i < control_count - 1; i++) //except textbox1 for focus
            {
                mypanel1.Controls.RemoveAt(mypanel1.Controls.Count - 1);
            }
            mypanel1.Clear();
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
                            left = (int)p.Value; //x
                        } if (p.Name == "Y")
                        {
                            top = (int)p.Value; //y
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
                        mypanel1.LoadPictureBox(left, top, text);
                    }
                    else if (text == "TextBox" || text != "")
                    {
                        if (text == "TextBox")
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
            //Size size = TextRenderer.MeasureText(Time_or_speed.Text, Time_or_speed.Font);
            //Time_or_speed.Width = size.Width;
            //Time_or_speed.Height = size.Height;
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
            Console.WriteLine(Name_ip.SelectedItem);
            int count = Name_ip.Items.Count;
            if (Name_ip.SelectedItem == null) //
            {
                MessageBox.Show("Please select name and ip to load data.");
                return;
            }
            string name = (string)Name_ip.SelectedItem;
            string[] name_only = name.Split(null);
            //WebClient wb = new WebClient();
            
            //string result = wb.DownloadString("http://localhost:8081/Undo_Data/post");
            //string result = wb.DownloadString("http://"+ ipv4 +":8081/Undo_Data/Panel_Data");

            MySqlConnectionString connStr = GetMySqlConnString();
            var conn = new MySqlConnection(connStr);
            conn.UseConnectionPool = true;
            conn.Open();
            MySqlDataReader data;
            MySqlCommand cmd = new MySqlCommand("SELECT textJson FROM json WHERE sender=@sender", conn);
            cmd.Parameters.AddWithValue("@sender", name_only[0]);
            data = cmd.ExecuteReader();
            string main = "";
            while (data.Read())
            {
                main = data.GetString("textJson");
                
            }
            if (main == "")
            {
                MessageBox.Show("No data from server.");
                return;
            }
            string[] Data = main.Split("|".ToCharArray());

            //if (result == "No Data")
            //{
            //    MessageBox.Show("No data from a server.");
            //    return;
            //}
            //string[] Data = result.Split("|".ToCharArray());

            data.Close();
            conn.Close();
            JArray Blue_Panel = JArray.Parse(Data[0]);
            JArray History = JArray.Parse(Data[1]);
            JArray ListCount = JArray.Parse(Data[2]);


            //this.mypanel1.Controls.Clear();
            int control_count = mypanel1.Controls.Count;
            for (int i = 0; i < control_count - 1; i++) //except textbox1 for focus
            {
                mypanel1.Controls.RemoveAt(mypanel1.Controls.Count - 1);
            }
            mypanel1.Clear();
            int left = 0, top = 0;
            string tag = null;
            string text = "";
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
                    mypanel1.LoadPictureBox(left, top, text);
                }
                else if (text == "TextBox" || text != "")
                {
                    if (text == "TextBox")
                    {
                        text = "";
                    }
                    mypanel1.Create_Textbox(left, top, text);
                }
                else
                {
                    mypanel1.AddBluePanel(left, top);
                }
                
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
                        tag = (string)p.Value;
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
            MySqlConnectionString connStr = GetMySqlConnString();
            var conn = new MySqlConnection(connStr);
            conn.UseConnectionPool = true;
            conn.Open();
            try
            {
                MySqlDataReader data;
                MySqlCommand cmd = new MySqlCommand("SELECT sender, ip FROM json", conn);
                data = cmd.ExecuteReader();
                
                while (data.Read())
                {
                    string name = data.GetString("sender");
                    string ip = data.GetString("ip");
                    Name_ip.Items.Add(name + "  " + ip);
                }
                data.Close();
            } catch (Exception)
            {
                
            }
            conn.Close();
        }
        int createTextbox_count = 0;

        private void Add_textbox_Click(object sender, EventArgs e)
        {
            //if (mypanel1.Controls.Count == 0) { MessageBox.Show("Please set panel first."); return; }
            mypanel1.Create_Textbox(0, createTextbox_count * 40, "");
            //createTextbox_count += 1;
        }

        private void picture_Click(object sender, EventArgs e)
        {
            //if (mypanel1.Controls.Count == 0) { MessageBox.Show("Please set panel first."); return; }
            mypanel1.ImportPictureBox();
        }

        private void Load_from_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_Server(object sender, EventArgs e)
        {
            //save with
            if (string.IsNullOrEmpty(sender_name.Text))
            {
                MessageBox.Show("Please input your name");
                this.ActiveControl = sender_name;
                return;
            }
            Save_Click(sender, e);
            if (this.mypanel1.Controls.Count == 1) { return; }
            using (StreamReader fs1 = new StreamReader("SavePanel.json"))
            using (StreamReader fs2 = new StreamReader("History.json"))
            using (StreamReader fs3 = new StreamReader("ListCountHistory.json")) 
            {
                string json1 = fs1.ReadToEnd();
                string json2 = fs2.ReadToEnd();
                string json3 = fs3.ReadToEnd();
                string all = json1 + "|" + json2 + "|" + json3;
                WebClient wb = new WebClient();
                MySqlConnectionString connStr = GetMySqlConnString();
                var conn = new MySqlConnection(connStr);
                conn.UseConnectionPool = true;
                conn.Open();
                try
                {
                    var cmd = new MySqlCommand("UPDATE json SET textJson=@textJson WHERE sender=@sender", conn);
                    cmd.Parameters.AddWithValue("@textJson", all);
                    cmd.Parameters.AddWithValue("@ip", ipv4);
                    cmd.Parameters.AddWithValue("@sender", "mick");
                    cmd.ExecuteNonQuery();
                    if (cmd.AffectedRows == 0) //no data
                    {
                        cmd = new MySqlCommand("INSERT INTO json(textJson, 	sender ,ip)VALUES(@textJson, @sender, @ip)", conn);
                        cmd.Parameters.AddWithValue("@textJson", all);
                        cmd.Parameters.AddWithValue("@ip", ipv4);
                        cmd.Parameters.AddWithValue("@sender", "mick");
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception) { }

                conn.Close();

                
                //string result = wb.UploadString("http://" + ipv4 + ":8081/Undo_Data/Panel_Data", all);
                MessageBox.Show("Save success");
            }
            mypanel1.Focus_panel();
            p.Clear();
        }

        private void Name_ip_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Add_name_ip(object sender, EventArgs e)
        {
            bool update = false; //same name, different ip
            string name, ip;
            //check input
            if (string.IsNullOrWhiteSpace(add_name.Text) || string.IsNullOrWhiteSpace(add_ip.Text))
            {
                MessageBox.Show("Please input both name and ip");
                this.ActiveControl = add_name;
                return;
            }
            name = add_name.Text;
            ip = add_ip.Text;
            string[] splitValues = ip.Split('.');
            //check ip format
            if (splitValues.Length != 4)
            {
                MessageBox.Show("Please input ip in the correct format");
                this.ActiveControl = add_ip;
                return;
            }
            int count = Name_ip.Items.Count;
            //check name
            for (int i = 0; i < count; i++)
            {
                string name_check = (string)Name_ip.Items[i];
                string[] aaa = name_check.Split(null);
                if (name == aaa[0])
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to replace IP Address?", "Name is already exist!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Name_ip.Items.RemoveAt(i);
                        update = true;
                        break;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        
                        return;
                    }
                    
                    return;
                }
            }
            //add ip and name
            MySqlConnectionString connStr = GetMySqlConnString();
            var conn = new MySqlConnection(connStr);
            conn.UseConnectionPool = true;
            conn.Open();
            try
            {
                if (update == false)
                {
                    var cmd = new MySqlCommand("INSERT INTO json(sender, ip) VALUE (@sender, @ip)", conn);
                    cmd.Parameters.AddWithValue("@sender", name);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.ExecuteNonQuery();
                    Name_ip.Items.Add(name + ip);
                } else
                {
                    var cmd = new MySqlCommand("UPDATE json SET ip=@ip WHERE sender=@sender", conn);
                    cmd.Parameters.AddWithValue("@sender", name);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.ExecuteNonQuery();
                    Name_ip.Items.Clear();
                    Form3_Load(sender, e); //listbox
                }
            } catch
            {
                MessageBox.Show("Error");
            }
            conn.Close();
        }

        private void add_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void sender_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
