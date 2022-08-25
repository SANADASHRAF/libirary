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
    public partial class Form4 : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //close web form
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region the second bart of edit(first bart in form1)
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form1 d = new Form1();
            con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\top\Desktop\projects\BookManage\Bookdb.mdf;Integrated Security=True");
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Books SET title=@title,author=@author,price=@price,category=@category,date=@date,rate=@rate ";
            cmd.Parameters.AddWithValue("@title", bunifuMaterialTextbox11.Text);
            cmd.Parameters.AddWithValue("@author", bunifuMaterialTextbox2.Text);
            cmd.Parameters.AddWithValue("@price", bunifuMaterialTextbox3.Text);
            cmd.Parameters.AddWithValue("@category", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", bunifuDatepicker1.Value);
            cmd.Parameters.AddWithValue("@rate", bunifuRating1.Value);
            

            cmd.ExecuteNonQuery();
            
            con.Close();
            this.Close();
            cmd.Parameters.Clear();

        }
        #endregion
    }
}
