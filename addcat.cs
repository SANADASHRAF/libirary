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
    public partial class addcat : Form
    {

        //variable for add to database
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public addcat()
        {
            InitializeComponent();
        }


       //close window
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        #region for adding to the database(adding to combobox)
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
            if (addcatbut.Text!="")
            {
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\top\Desktop\projects\BookManage\Bookdb.mdf;Integrated Security=True";
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO TbCategory (cat) VALUES (@cat)";
                cmd.Parameters.AddWithValue("@cat", addcatbut.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.Close();

            }
            else
            {
                MessageBox.Show("please enter category");
            }



            #endregion
        }

       
    }
}
