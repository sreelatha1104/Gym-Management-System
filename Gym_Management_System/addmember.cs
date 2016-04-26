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

namespace Gym_Management_System
{
    public partial class addmember : Form
    {
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Database\GymDetails.mdf';Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();

        public addmember()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "insert into member(firstname,lastname,contactno,address,PlanType,dateofjoining,amount) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+comboBox1.Text+"','" + dateTimePicker1.Text + "','" + textBox5.Text + "')";
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
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select amount from [plan] where Type='" + comboBox1.Text + "'";
            con = new SqlConnection(scon);
            con.Open();
            cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                textBox5.Text=dr[0].ToString();
            }         
        }

        private void addmember_Load(object sender, EventArgs e)
        {
            string str = "select Type from [plan]";
            con = new SqlConnection(scon);
            cmd = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
}
