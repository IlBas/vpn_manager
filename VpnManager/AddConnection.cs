using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Net;
using VpnManagerDAL;
using VpnManagerDAL.DTO;

namespace VpnManager
{
    public partial class AddConnection : DevComponents.DotNetBar.Office2007Form
    {
        bool Loading = true;
        bool Modifing = false;
        int _plant;
        int _machineID;

        public AddConnection()
        {
            InitializeComponent();
            vpnTypeDTOBindingSource.DataSource = VpnManagerDal.GetVpnTypes();
            connectionTypeDTOBindingSource.DataSource = VpnManagerDal.GetConnectionTypes();
            cmbCustomer.DataSource = VpnManagerDal.GetCustomersList();
            
        }



        public AddConnection(int Plant)
        {
            InitializeComponent();
            vpnTypeDTOBindingSource.DataSource = VpnManagerDal.GetVpnTypes();
            connectionTypeDTOBindingSource.DataSource = VpnManagerDal.GetConnectionTypes();
            machineDTOBindingSource.DataSource = VpnManagerDal.GetMachinesByPlant(Plant);
            PlantDTO plant = VpnManagerDal.GetPlant(Plant);
            cmbCustomer.DataSource = VpnManagerDal.GetCustomersList();
            cmbCustomer.Text = plant.DisplayedName;
            //cmbCustomer.Text = plant.Name;
            txtServerHost.Text = plant.ServerAddress;
            txtUser.Text = plant.Username;
            txtPassword.Text = plant.Password;
            txtConfrimPassword.Text = plant.Password;
            cmbVpnType.SelectedValue = plant.IdConnectionType;
            Loading = false;
            Modifing = true;
            grpMachine.Enabled = true;
            _plant = Plant;
            cmdNext.Text = "Modify Plant";
            extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(_plant, (int)TargetTable.Plant);
           // cmdMachine.Text = "Edit";
           
        }


        private void AddConnection_Load(object sender, EventArgs e)
        {
            Loading = false;
        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }


        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (!Modifing)
            {
                if (txtPassword.Text == txtConfrimPassword.Text)
                {
                    if (VpnManagerDal.InsertNewPlant(cmbCustomer.Text, (int)cmbVpnType.SelectedValue, txtServerHost.Text, txtUser.Text, txtPassword.Text))
                    {

                        grpMachine.Enabled = true;
                        grpPlant.Enabled = false;

                    }
                }
                else
                {
                    MessageBox.Show("Passwords Don't Match!!'");

                }
            }
            else
            {
                if (txtPassword.Text == txtConfrimPassword.Text)
                {
                    if (VpnManagerDal.EditPlant(_plant,cmbCustomer.Text, (int)cmbVpnType.SelectedValue, txtServerHost.Text, txtUser.Text, txtPassword.Text))
                    {

                      


                    }
                }
                else
                {
                    MessageBox.Show("Passwords Don't Match!!'");

                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(Modifing & !Loading )
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    _machineID = (int)row.Cells[0].Value;
                    txtPcName.Text = row.Cells[1].Value.ToString();
                    txtPasswordMachine.Text = row.Cells[6].Value.ToString();
                    txtUerMachine.Text = row.Cells[5].Value.ToString();
                    txtIp.Text = row.Cells[4].Value.ToString();
                    cmbContype.SelectedValue = (int)row.Cells[2].Value;
                    chkCheckEnabled.Checked = Convert.ToBoolean(row.Cells[3].Value);
                    cmdAdd.Enabled = false;
                }
             }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdateMachine(true);
        }
        

        private void ClearField()
        {

            foreach (Control txt in grpMachine.Controls)
                if (txt.GetType() == typeof(DevComponents.DotNetBar.Controls.TextBoxX))
                    txt.Text = string.Empty;
            txtIp.Text = "";
            cmdAdd.Enabled = true;
            cmdEdit.Enabled = false;

        }



        private void AddOrUpdateMachine(bool Update)
        {
            IPAddress ipadresses ;
            if ( IPAddress.TryParse(txtIp.Text , out  ipadresses))
            {
                int i = VpnManagerDal.GetPlant(cmbCustomer.Text).Id;
                if (!Update)
                {
                    VpnManagerDAL.VpnManagerDal.InsertNewMachine(i, txtPcName.Text, txtIp.Text, txtUerMachine.Text, txtPasswordMachine.Text, Convert.ToBoolean(chkCheckEnabled.CheckState), Convert.ToInt32(cmbContype.SelectedValue));
                    machineDTOBindingSource.DataSource = VpnManagerDal.GetMachinesByPlant(i);

                }
                else
                {
                    VpnManagerDal.EditMachine(_machineID, txtPcName.Text, txtIp.Text, txtUerMachine.Text, txtPassword.Text, Convert.ToBoolean(chkCheckEnabled.CheckState), _plant, (int)cmbContype.SelectedValue);
                    
                    cmdEdit.Enabled = false;
                }
                foreach (Control txt in grpMachine.Controls)
                    if (txt.GetType() == typeof(DevComponents.DotNetBar.Controls.TextBoxX))
                        txt.Text = string.Empty;
            }
            else 
                MessageBox.Show("Ip Not Valid");
           // txtIp.Text = "";

        }

        private void grpMachine_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Focused)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                VpnManagerDal.DeleteMachine(Convert.ToInt32(row.Cells[0].Value));
            }
            else
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView2.SelectedRows[0];
                    VpnManagerDal.DeleteExtensionObject(Convert.ToInt32(row.Cells[0].Value));
                    if (rdPlant.Checked)
                        extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(_plant, (int)TargetTable.Plant);
                    else
                        extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(_machineID, (int)TargetTable.Machine);
                }
                else
                {
                    MessageBox.Show("Select a Object before");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddOrUpdateMachine(false);
        }

        private void cmdAddConnectionType_Click(object sender, EventArgs e)
        {
            WizardConnection wzrd = new WizardConnection();
            wzrd.ShowDialog();
            vpnTypeDTOBindingSource.DataSource = VpnManagerDal.GetVpnTypes();
        }

        private void rdExtMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (rdExtMachine.Checked)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(_machineID, (int)TargetTable.Machine);
                }
                else
                {
                    MessageBox.Show("Select First a Machine!");
                    rdExtMachine.Checked = false;
                    rdPlant.Checked = true;
                }
            }

        }

        private void AddExt_Click(object sender, EventArgs e)
        {
            if (txtExtName.Text != string.Empty && txtExtValue.Text != string.Empty)
            {
                PlantDTO plant = VpnManagerDal.GetPlant(cmbCustomer.Text);
                bool mustUpdateExtensionObj = false; //added refresh of ext objs if needed
                if (rdPlant.Checked)
                {
                  
                    if (plant.Id> 0)
                    {
                        mustUpdateExtensionObj = VpnManagerDal.AddExtensionObject(plant.Id, (int)TargetTable.Plant, txtExtName.Text, txtExtValue.Text);
                    }

                }
                else
                {
                    if (_machineID > 0)
                    {
                        mustUpdateExtensionObj = VpnManagerDal.AddExtensionObject(_machineID, (int)TargetTable.Machine, txtExtName.Text, txtExtValue.Text);

                    }


                }
                if (mustUpdateExtensionObj) extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(_plant, (int)TargetTable.Plant);

            }
        }

        private void rdPlant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPlant.Checked)
                extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(_plant, (int)TargetTable.Plant);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtIp_Click(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void txtIp_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void grpPlant_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
