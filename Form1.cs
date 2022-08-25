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
namespace BookManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //for move the form
        public int move;
        public int movex;
        public int movey;


        //deal with database 
        SqlConnection con = new SqlConnection();
        //perform the SQL operations like Select , Insert 
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        //for maximize,minimize and close the web form
        #region for maximize,minimize and close the web form
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
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


        //for move the form
        #region for move the form
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


              
        #region  deal with database 
        private void Form1_Activated(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection();
            ////perform the SQL operations like Select , Insert 
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();

            DataTable dt = new DataTable();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\top\Desktop\projects\BookManage\Bookdb.mdf;Integrated Security=True";
            var sql = "SELECT id,title,author,price,category,rate FROM Books";
            da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        #endregion


        //button of add book to move to next form
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form obj1 = new add_Form2();
            bunifuTransition1.ShowSync(obj1);
        }


        //delete
        #region delete 
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\top\Desktop\projects\BookManage\Bookdb.mdf;Integrated Security=True");
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from Books where id=@id";
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();

        }
        #endregion


        //edit
        #region part of edit(not all code of edit, anoter part in form4)
        List<String> lis = new List<string>();
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form4 d = new Form4();

            bunifuTransition1.ShowSync(d);

            con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\top\Desktop\projects\BookManage\Bookdb.mdf;Integrated Security=True");
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select title,author,price,category,date,rate from Books where id=@id";
            cmd.Parameters.AddWithValue("@id", Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lis.Add(Convert.ToString(rd[0]));
                lis.Add(Convert.ToString(rd[1]));
                lis.Add(Convert.ToString(rd[2]));
                lis.Add(Convert.ToString(rd[3]));
                lis.Add(Convert.ToString(rd[4]));
                lis.Add(Convert.ToString(rd[5]));
            }

            d.bunifuMaterialTextbox11.Text = lis[0];
            d.bunifuMaterialTextbox2.Text = lis[1];
            d.bunifuMaterialTextbox3.Text = lis[2];
            d.comboBox1.Text = lis[3];
            d.bunifuDatepicker1.Text = lis[4];
            d.bunifuRating1.Text = lis[5];

            con.Close();
            cmd.Parameters.Clear();
        }
        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_BackgroundColorChanged(object sender, EventArgs e)
        {

        }
     
    }
}
