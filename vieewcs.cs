using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManage
{
    public partial class vieewcs : Form
    {
        public vieewcs()
        {
            InitializeComponent();
        }

        //the button to get form1
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form v = new Form1();
            bunifuTransition1.ShowSync(v);
        }
    }
}
