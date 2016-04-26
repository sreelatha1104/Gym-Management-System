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
    public partial class addinstructor : Form
    {
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Database\GymDetails.mdf';Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        public addinstructor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "insert into instructor(firstname,lastname,contactno,address,dateofjoining,schedule,salary) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','"+textBox5.Text+"')";
                con = new SqlConnection(scon);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = str;
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
