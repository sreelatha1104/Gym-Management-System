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
    public partial class Jobs : Form
    {
        public Jobs()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBasic.Clear();
            txtCode.Clear();
            txtHour.Clear();
            txtPoss.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String code = txtCode.Text;
            String position = txtCode.Text;
            String pay = txtHour.Text;
            String fixpay = txtBasic.Text;
            if (code.Trim() == "")
            {
                MessageBox.Show("Enter Job Code");
            }

            else if (position.Trim() == "")
            {
                MessageBox.Show("Enter Job Position");
            }
            else if (pay.Trim() == "")
            {
                MessageBox.Show("Enter Hourly Pay Rate");
            }
            else if (fixpay.Trim() == "")
            {
                MessageBox.Show("Enter Fixed Pay Rate");
            }
            else
            {
                string query = "";
               SqlConnection SqlConn = null;
                try
                {
                    string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Gym_Management_System\Utility.mdf';Integrated Security=True";
                    SqlConn = new SqlConnection(connString);

                    query = "insert into Positions values('" + txtCode.Text + "','" + txtPoss.Text + "','" + txtBasic.Text + "','" + txtHour.Text + "');";
                   SqlCommand SqlCmd = new SqlCommand(query, SqlConn);


                    SqlConn.Open();
                    int status = SqlCmd.ExecuteNonQuery();

                    if (status > 0)
                    {
                        MessageBox.Show("Job Type Saved!!");
                        txtBasic.Clear();
                        txtCode.Clear();
                        txtHour.Clear();
                        txtPoss.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " " + query);
                }
                finally
                {
                    if (SqlConn != null)
                        SqlConn.Close();
                }
            }
        }
    }
}
