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
    public partial class fees : Form
    {
        string scon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Database\GymDetails.mdf';Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        public fees()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "insert into fees(name,plantype,dateofjoining,amount) values('" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "')";
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

        private void fees_Load(object sender, EventArgs e)
        {
            string str = "select firstname from member";
            con = new SqlConnection(scon);
            cmd = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            string str = "select * from member where firstname='" + comboBox1.Text + "'";
            con = new SqlConnection(scon);
            con.Open();
            cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader(); 
            while(dr.Read())
            {              
                textBox1.Text = dr["plantype"].ToString();
                dateTimePicker1.Text = dr["dateofjoining"].ToString();
                textBox3.Text = dr["amount"].ToString();
            }
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
