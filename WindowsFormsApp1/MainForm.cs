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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            AddMember AM = new AddMember();
            AM.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MList ML = new MList();
            ML.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DUMember DUM = new DUMember();
            DUM.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Payments P = new Payments();
            P.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
