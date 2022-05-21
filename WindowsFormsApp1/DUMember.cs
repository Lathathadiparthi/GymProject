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
    public partial class DUMember : Form
    {
        public DUMember()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-THP4IETJ\SQLEXPRESS;Initial Catalog=Gymdb;Integrated Security=True");
        private void DUMember_Load(object sender, EventArgs e)
        {
            Populate();
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
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Width = 150;
                Con.Close();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
          int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            MName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            PhoneNo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Gender.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Age.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            MAmount.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Timings.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MName.Text = "";
            PhoneNo.Text = "";
            Gender.Text = "";
            Age.Text = "";
            MAmount.Text = "";
            Timings.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm MF = new MainForm();
            MF.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Member To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MemberTb1 where Mid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Deleted");
                    Con.Close();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0 || MName.Text == "" || PhoneNo.Text == "" || Gender.Text == "" || Age.Text == "" || MAmount.Text == "" || Timings.Text == "")

            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update  MemberTb1  set MName='" + MName.Text + "', MPhone='" + PhoneNo.Text + "',MGen='" + Gender.Text + "', MAge='" + Age.Text + "',MAmount='" + MAmount.Text + "',MTiming='" + Timings.Text + "' where Mid="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Updated");
                    Con.Close();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);


                }
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
