using System;
using System.IO;
using System.Windows.Forms;



namespace WindowsFormsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ListDirectory(treeView1, "C:\\Users\\NITRO 5 Spin I7\\Documents\\Computer Science\\ฝึกงาน\\WindowsFormsExample\\WindowsFormsExample");
            string curDir = Directory.GetCurrentDirectory();

            curDir = "..\\..";
            ListDirectory(treeView1, curDir);
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void Write_Click(object sender, EventArgs e) //method parameter, no return value
        {

            // string text_box = this.txtLineNum.Text;

            string input = Numinput.Text;
            if (!string.IsNullOrEmpty(input)) //not empty

            {
                int number = Convert.ToInt32(input);
                string text = "Hello";
                using (var word = new System.IO.StreamWriter("file1.txt"))
                {
                    for (int i = 0; i < number; ++i)
                    {
                        word.WriteLine(text);
                    }

                }
            }
            
            textBoxRead.Text = File.ReadAllText("file1.txt");


        }
        

        private void textBox1_TextChanged(object sender, EventArgs e) //read
        {
            
        }

        private void Folder_Click(object sender, EventArgs e) //preview
        {
            
            string curDir = Directory.GetCurrentDirectory();

            curDir = "..\\..";
            string[] dirs = Directory.GetDirectories(curDir);
            
            int k = dirs.Length;
            
            for (int i = 0; i < k; ++i)
            {
                showpath.Items.Add(dirs[i]);
            }
           
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBoxRead.Text = File.ReadAllText(file1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }

        private void files_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();

            curDir = "..\\..";
            string[] files = Directory.GetFiles(curDir);
            foreach (string file in files)
            {
                showpath.Items.Add(file);
            }
        }
    }
}
