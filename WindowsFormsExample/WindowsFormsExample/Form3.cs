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
    public partial class Form3 : Form
    {
        List<Control> selected = new List<Control>();
        public Form3()
        {
            InitializeComponent();
            this.ActiveControl = NumofPanel;
        }
        

        

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
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("bluepoint_user.bin", FileMode.Create))
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                foreach (Control c in this.mypanel1.Controls)
                {

                    //location
                    w.Write(c.Left); //X
                    w.Write(c.Top); //Y
                    
                }
                fs.Flush();
                mypanel1.Focus_panel();
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            this.mypanel1.Controls.Clear();

            int left, top;

            using (FileStream fs = new FileStream("bluepoint_user.bin", FileMode.Open))
            using (BinaryReader r = new BinaryReader(fs))
            {

                while (r.BaseStream.Position != r.BaseStream.Length)
                {
                    Panel bluepanel = new Panel();
                    //location
                    left = r.ReadInt32();
                    top = r.ReadInt32();
                    //show blue panels
                    mypanel1.AddBluePanel(left, top);

                }
                mypanel1.Focus_panel();
                fs.Flush();
                mypanel1.Clear();
                
            }
        }

        private void undo_Click(object sender, EventArgs e)
        {
            mypanel1.Undo_(mypanel1);
        }

        private void redo_Click(object sender, EventArgs e)
        {

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
