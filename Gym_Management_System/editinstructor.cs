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
    public partial class editinstructor : Form
    {
        GymDetailsEntities db = new GymDetailsEntities();
       
        public editinstructor()
        {
            InitializeComponent();
        }

        public editinstructor(string str)
        {
            InitializeComponent();
            instructorDataGridView.ReadOnly = true;
            bindingNavigator1.Visible = false;
            groupBox1.Text = "View All Data";
        }

        private void editinstructor_Load(object sender, EventArgs e)
        {
            var instructors = db.instructors.ToList();
            this.instructorDataGridView.DataSource = instructors;
        }

        private void instructorDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.instructorDataGridView.EndEdit();

            var instructors = this.instructorDataGridView.DataSource as List<instructor>;

            foreach (var instructor in instructors)
            {
                db.Entry(instructor).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            this.instructorDataGridView.DataSource = db.instructors.ToList();
            MessageBox.Show("Database updated.");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var instructors = this.instructorDataGridView.DataSource as List<instructor>;
            var deleteIndex = instructorDataGridView.SelectedRows[0].Index;
            var deleteMember = instructors[deleteIndex];

            db.instructors.Remove(deleteMember);
            db.SaveChanges();
            this.instructorDataGridView.DataSource = db.instructors.ToList();
            MessageBox.Show("row was successfully deleted.");
        }
    }
}
