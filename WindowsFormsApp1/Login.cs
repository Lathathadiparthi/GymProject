using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            usertb.Text = "";
            passwordtb.Text = "";
        }

        private void log_Click(object sender, EventArgs e)
        {
            if(usertb.Text=="" || passwordtb.Text=="")
            {
                MessageBox.Show("Information Missing");
            }
            else if(usertb.Text=="Admin"  && passwordtb.Text=="Admin")
            {
                MainForm MF = new MainForm();
                MF.Show();
                this.Hide();    
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

}   