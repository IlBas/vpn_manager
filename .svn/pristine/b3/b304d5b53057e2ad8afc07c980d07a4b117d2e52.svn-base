using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VpnManagerDAL;
using VpnManagerDAL.DTO;

namespace VpnManager
{
    public partial class Extension : DevComponents.DotNetBar.Office2007Form
    {
        public Extension()
        {
            InitializeComponent();
        }
        private string sTargetTable;


        private void Extension_Load(object sender, EventArgs e)
        {          
             cmbType.Items.Add(TargetTable.ConnectionType.ToString());
             //cmbType.Items.Add(TargetTable.Machine.ToString());
             cmbType.Items.Add(TargetTable.Plant.ToString());
             cmbType.Items.Add(TargetTable.VpnType.ToString());       
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }


        private void loadExtension()
        {
           
            //else if (rdMAchine.Checked)
            //{

            //    foreach (MachineDTO cn in VpnManagerDal.get())
            //        lst.AddRange(VpnManagerDal.GetExtensionObjects(cn.Id, TargetTable.ConnectionType));
            //}



        }


        private void dataGridView1_SelectionChanged(object sender , EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
              // extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), VpnManagerDal.GetTargetTable(sTargetTable));
                LoadDataExtension(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));

            }
        }

        private void LoadDataExtension(int  id)
        {

            extensionObjectDTOBindingSource.DataSource = VpnManagerDal.GetExtensionObjects(id, (int) VpnManagerDal.GetTargetTable(sTargetTable));
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbType.Text)
            {
                case "ConnectionType":
                    dataGridView1.DataSource = ConnTypeDto;
                    ConnTypeDto.DataSource = VpnManagerDal.GetConnectionTypes();
                    sTargetTable = TargetTable.ConnectionType.ToString();
                    dataGridView1.Columns["Id"].Visible = false;
                    break;

                case "Machine":
                    //dataGridView1.DataSource = MachineDto;
                    //MachineDto.DataSource = VpnManagerDal.Get
                    break;

                case "Plant":
                    dataGridView1.DataSource = plantDTOBindingSource;
                    plantDTOBindingSource.DataSource = VpnManagerDal.GetPlants();
                    sTargetTable = "Plant";
                    dataGridView1.Columns["Id"].Visible = false;
                    break;


                case "VpnType":
                    dataGridView1.DataSource = VpnType;
                    VpnType.DataSource = VpnManagerDal.GetVpnTypes();
                    sTargetTable = "VpnType";
                    dataGridView1.Columns["Id"].Visible = false;
                    break;
                default:
                    break;

            }
        }

    }
}
