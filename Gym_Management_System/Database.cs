using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Gym_Management_System
{
   public class Database
    {
        public SqlConnection con;
        public string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\sreelatha\Documents\Visual Studio 2015\Projects\Gym_Management_System\Gym_Management_System\Utility.mdf';Integrated Security=True";
        public SqlDataAdapter sda;
        public DataSet ds;
        public DataTable dt;

        public Database()
        {
            con = new SqlConnection();
            con.ConnectionString = str;
            ds = new DataSet();
            dt = new DataTable();
        }
        public void open()
        {
            con.Open();
        }

        public void execute(string com)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = com;
            cmd.ExecuteNonQuery();
        }

        public void close()
        {
            con.Close();
        }
    }
}
