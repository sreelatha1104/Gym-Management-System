using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class editplan : Form
    {
        GymDetailsEntities db = new GymDetailsEntities();


        public editplan()
        {
            InitializeComponent();
        }

        public editplan(string str)
        {
            InitializeComponent();
            planDataGridView.ReadOnly = true;
            bindingNavigator1.Visible = false;
            groupBox1.Text = "View All Data";
        }

        private void editplan_Load(object sender, EventArgs e)
        {
            var plans = db.plans.ToList();
            this.planDataGridView.DataSource = plans;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.planDataGridView.EndEdit();

            var plans = this.planDataGridView.DataSource as List<plan>;

            foreach (var plan in plans)
            {
                db.Entry(plan).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            this.planDataGridView.DataSource = db.plans.ToList();
            MessageBox.Show("Database updated.");
        }

        private void planDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var plans = this.planDataGridView.DataSource as List<plan>;
            var deleteIndex = planDataGridView.SelectedRows[0].Index;
            var deleteMember = plans[deleteIndex];

            db.plans.Remove(deleteMember);
            db.SaveChanges();
            this.planDataGridView.DataSource = db.plans.ToList();
            MessageBox.Show("row was successfully deleted.");
        }
    }
}
