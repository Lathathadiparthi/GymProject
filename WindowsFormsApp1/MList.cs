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
    public partial class MList : Form
    {
        public MList()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-THP4IETJ\SQLEXPRESS;Initial Catalog=Gymdb;Integrated Security=True");
        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Populate()
        {
            try
            {
                Con.Open();
                string query = "select * from MemberTb1";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void FilterByName()
        {
            try
            {
                Con.Open();
                string query = "select * from MemberTb1 where MName='"+searchtb.Text+"' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void MList_Load(object sender, EventArgs e)
        {
           Populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm MF = new MainForm();           
            MF.Show();
            this.Hide();
        }

        private void search_Click(object sender, EventArgs e)
        {
            FilterByName();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
