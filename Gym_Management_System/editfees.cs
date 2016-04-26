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
    public partial class editfees : Form
    {
        GymDetailsEntities db = new GymDetailsEntities();
       
        public editfees()
        {
            InitializeComponent();
        }

        public editfees(string str)
        {
            InitializeComponent();
            feesGridView.ReadOnly = true;
            bindingNavigator1.Visible = false;
            groupBox1.Text = "View All Data";
        }

        private void editfees_Load(object sender, EventArgs e)
        {
            var fees = db.fees.ToList();
            this.feesGridView.DataSource = fees;
        }

        private void feesGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.feesGridView.EndEdit();

            var fees = this.feesGridView.DataSource as List<fee>;

            foreach (var member in fees)
            {
                db.Entry(member).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            this.feesGridView.DataSource = db.fees.ToList();
            MessageBox.Show("Database updated.");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var fees = this.feesGridView.DataSource as List<fee>;
            var deleteIndex = feesGridView.SelectedRows[0].Index;
            var deleteFee = fees[deleteIndex];

            db.fees.Remove(deleteFee);
            db.SaveChanges();
            this.feesGridView.DataSource = db.fees.ToList();
            MessageBox.Show("row was successfully deleted.");

        }
    }
}
