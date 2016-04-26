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
    public partial class editmember : Form
    {
        GymDetailsEntities db = new GymDetailsEntities();

        public editmember()
        {
            InitializeComponent();
        }
        public editmember(string str)
        { 
            InitializeComponent();
            memberDataGridView.ReadOnly = true;
            bindingNavigator1.Visible = false;
            groupBox1.Text = "View All Data";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var members = this.memberDataGridView.DataSource as List<member>;
            var deleteIndex = memberDataGridView.SelectedRows[0].Index;
            var deleteMember = members[deleteIndex];

            db.members.Remove(deleteMember);
            db.SaveChanges();
            this.memberDataGridView.DataSource = db.members.ToList();
            MessageBox.Show("row was successfully deleted.");
        }

        private void memberDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.memberDataGridView.EndEdit();             
            var members = this.memberDataGridView.DataSource as List<member>;

            foreach (var member in members)
            {
             db.Entry(member).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            this.memberDataGridView.DataSource = db.members.ToList();
            MessageBox.Show("Database updated.");
        }

        private void editmember_Load(object sender, EventArgs e)
        {
            var members = db.members.ToList();
            this.memberDataGridView.DataSource = members;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
