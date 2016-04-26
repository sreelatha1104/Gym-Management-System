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
    public partial class addequipment : Form
    {
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Database\GymDetails.mdf';Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        public addequipment()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            try
            {
                int tot_quantity = Convert.ToInt32(textBox3.Text);
                int price_per_quantity = Convert.ToInt32(textBox4.Text);
                textBox5.Text = (tot_quantity * price_per_quantity) + "";
            }
            catch (Exception ee)
            {
                MessageBox.Show("Enter the data properly");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "insert into equipment(name,company,totalquantity,priceperquantity,totalprice,date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" +dateTimePicker1.Text + "')";
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
