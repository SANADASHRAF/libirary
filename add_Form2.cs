using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace BookManage
{
    public partial class add_Form2 : Form
    {
        
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        List<String> lis = new List<string>();

        public add_Form2()
        {
            InitializeComponent();
        }

        #region  for maximize,minimize and close the web form
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        #endregion


        #region for move web form 
        public int move;
        public int movex;
        public int movey;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movey = e.Y;
            movex = e.X;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movex, MousePosition.Y - movey);
            }
        }
        #endregion


        //button of add category
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Form addcat = new addcat();
            bunifuTransition1.ShowSync(addcat);
        }


        //add book
        #region add book

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            //convert img to binary
            MemoryStream ma = new MemoryStream();
            pictureBox1.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);
            var coverr = ma.ToArray();


            con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\top\Desktop\projects\BookManage\Bookdb.mdf;Integrated Security=True");
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Books (title,author,price,category,date,rate,cover) VALUES (@title,@author,@price,@category,@date,@rate,@cover)";
            cmd.Parameters.AddWithValue("@title", bunifuMaterialTextbox1.Text);
            cmd.Parameters.AddWithValue("@author", bunifuMaterialTextbox2.Text);
            cmd.Parameters.AddWithValue("@price", bunifuMaterialTextbox3.Text);
            cmd.Parameters.AddWithValue("@category", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", bunifuDatepicker1.Value);
            cmd.Parameters.AddWithValue("@rate", bunifuRating1.Value);
            cmd.Parameters.AddWithValue("@cover", coverr);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Close();
        }
        #endregion

        #region to choose photo from my pc and show it in combobox

        //to lood photo from my pc and show it in coverbox
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var x = new OpenFileDialog();
            var result = x.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(x.FileName);
            }
        }
        #endregion

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        
       private void add_Form2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void add_Form2_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void add_Form2_MouseMove(object sender, MouseEventArgs e)
        {
           
              
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
       



        
    }
}
