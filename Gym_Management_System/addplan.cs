using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class addplan : Form
    {
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Database\GymDetails.mdf';Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        public addplan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strn = "insert into [plan](Type,amount) values('" + textBox1.Text + "','" + textBox2.Text + "') ";
                con = new SqlConnection(scon);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = strn;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully insterted");

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
