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

namespace WindowsFormsApp1
{
    public partial class AddMember: Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-THP4IETJ\SQLEXPRESS;Initial Catalog=Gymdb;Integrated Security=True");

        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            if(MNameTb.Text ==""  || PhoneTb.Text =="" || AgeTb.Text=="" ||AmountTb.Text=="")
            {
                MessageBox.Show("Missing Details");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "Insert into MemberTb1 values ('" + MNameTb.Text + "','" + PhoneTb.Text + "','"+GenderCb.SelectedItem.ToString()+ "','" + AgeTb.Text + "','" + AmountTb.Text+"','"+TimingsCb.SelectedItem.ToString()+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added");
                    Con.Close();
                    MNameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.Text = "";
                    AgeTb.Text = "";
                    AmountTb.Text = "";
                    TimingsCb.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }        

        private void RESET_Click(object sender, EventArgs e)
        {
            MNameTb.Text = "";
            PhoneTb.Text = "";
            GenderCb.Text= "";
            AgeTb.Text = "";
            AmountTb.Text = "";
            TimingsCb.Text = "";

        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm MF = new MainForm();
            MF.Show();
            this.Hide();
        }
    }
}
