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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-THP4IETJ\SQLEXPRESS;Initial Catalog=Gymdb;Integrated Security=True");
        private void button5_Click(object sender, EventArgs e)
        {
            MainForm FM = new MainForm();
            FM.Show();
            this.Hide();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
           FillName();
            Populate();
        } 
        private void Populate()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select *from PaymentTb1", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                Con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FilterByName()
        {
            try
            {
                Con.Open();
                string query = "select *from PaymentTb1 where MName='" + searchtb.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void FillName()
        {
            try
            {
                Con.Open();
                SqlCommand  cmd=new  SqlCommand("select MName from MemberTb1",Con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("MName", typeof(string));
                dt.Load(dr);
                MNameCb.ValueMember = "MName";
                MNameCb.DataSource = dt;
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MNameCb.Text = "";
            AmountTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MNameCb.Text=="" || AmountTb.Text=="")
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    Con.Open();
                    string month = Pmonth.Value.Month.ToString() +"/"+ Pmonth.Value.Year.ToString();
                    string query="select count(*)  from PaymentTb1 where MName='"+MNameCb.SelectedValue.ToString()+"' and PMonth='"+month+"'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    
                    if(dt.Rows[0][0].ToString()=="1")
                    {
                        MessageBox.Show("Already paid For This Month");
                    }
                    else
                    {
                        string query1 = "insert into PaymentTb1 values('" + month + "','" + MNameCb.SelectedValue.ToString() + "','" + AmountTb.Text + "')";
                        SqlCommand cmd = new SqlCommand(query1, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Amount paid Successfully");

                    }
                    Con.Close();
                    Populate();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
