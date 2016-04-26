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
    public partial class editequipment : Form
    {
        GymDetailsEntities db = new GymDetailsEntities();
       
        public editequipment()
        {
            InitializeComponent();
        }

        public editequipment(string str)
        {
            InitializeComponent();
            equipmentGridView.ReadOnly = true;
            bindingNavigator1.Visible = false;
            groupBox1.Text = "View All Data";
        }

        private void editequipment_Load(object sender, EventArgs e)
        {
            
            var equipments = db.equipments.ToList();
            this.equipmentGridView.DataSource = equipments;

        }

        private void equipmentGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var equipments = this.equipmentGridView.DataSource as List<equipment>;
            var deleteIndex = equipmentGridView.SelectedRows[0].Index;
            var deleteMember = equipments[deleteIndex];

            db.equipments.Remove(deleteMember);
            db.SaveChanges();
            this.equipmentGridView.DataSource = db.equipments.ToList();
            MessageBox.Show("row was successfully deleted.");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.equipmentGridView.EndEdit();

            var equipments = this.equipmentGridView.DataSource as List<equipment>;

            foreach (var member in equipments)
            {
                db.Entry(member).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            this.equipmentGridView.DataSource = db.equipments.ToList();
            MessageBox.Show("Database updated.");
        }
    }
}
