namespace VpnManager
{
    partial class AddConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpPlant = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdAddConnectionType = new System.Windows.Forms.Button();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtServerHost = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtConfrimPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbVpnType = new System.Windows.Forms.ComboBox();
            this.vpnTypeDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpMachine = new System.Windows.Forms.GroupBox();
            this.txtIp = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtPasswordMachine = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUerMachine = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.chkCheckEnabled = new System.Windows.Forms.CheckBox();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cmbContype = new System.Windows.Forms.ComboBox();
            this.connectionTypeDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPcName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPreferredConnectionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pingResponseEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iPAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLastConnectedUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdPlant = new System.Windows.Forms.RadioButton();
            this.rdExtMachine = new System.Windows.Forms.RadioButton();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.AddExt = new System.Windows.Forms.Button();
            this.txtExtValue = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetTableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionObjectDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtExtName = new System.Windows.Forms.ComboBox();
            this.grpPlant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vpnTypeDTOBindingSource)).BeginInit();
            this.grpMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionTypeDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ctmGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machineDTOBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extensionObjectDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPlant
            // 
            this.grpPlant.Controls.Add(this.cmbCustomer);
            this.grpPlant.Controls.Add(this.button1);
            this.grpPlant.Controls.Add(this.cmdNext);
            this.grpPlant.Controls.Add(this.cmdAddConnectionType);
            this.grpPlant.Controls.Add(this.labelX6);
            this.grpPlant.Controls.Add(this.labelX5);
            this.grpPlant.Controls.Add(this.labelX4);
            this.grpPlant.Controls.Add(this.labelX3);
            this.grpPlant.Controls.Add(this.labelX2);
            this.grpPlant.Controls.Add(this.labelX1);
            this.grpPlant.Controls.Add(this.txtServerHost);
            this.grpPlant.Controls.Add(this.txtConfrimPassword);
            this.grpPlant.Controls.Add(this.txtUser);
            this.grpPlant.Controls.Add(this.txtPassword);
            this.grpPlant.Controls.Add(this.cmbVpnType);
            this.grpPlant.Location = new System.Drawing.Point(8, 2);
            this.grpPlant.Name = "grpPlant";
            this.grpPlant.Size = new System.Drawing.Size(593, 157);
            this.grpPlant.TabIndex = 0;
            this.grpPlant.TabStop = false;
            this.grpPlant.Text = "Plant";
            this.grpPlant.Enter += new System.EventHandler(this.grpPlant_Enter);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DisplayMember = "Id";
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(108, 21);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(177, 21);
            this.cmbCustomer.TabIndex = 15;
            this.cmbCustomer.ValueMember = "Id";
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(512, 127);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 24);
            this.cmdNext.TabIndex = 13;
            this.cmdNext.Text = "Add Plant";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdAddConnectionType
            // 
            this.cmdAddConnectionType.Image = global::VpnManager.Properties.Resources.down_arrow;
            this.cmdAddConnectionType.Location = new System.Drawing.Point(554, 80);
            this.cmdAddConnectionType.Name = "cmdAddConnectionType";
            this.cmdAddConnectionType.Size = new System.Drawing.Size(26, 23);
            this.cmdAddConnectionType.TabIndex = 12;
            this.cmdAddConnectionType.UseVisualStyleBackColor = true;
            this.cmdAddConnectionType.Click += new System.EventHandler(this.cmdAddConnectionType_Click);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(485, 80);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(63, 23);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "Vpn Type";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(485, 48);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(102, 23);
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "Confirm Password";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(485, 22);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "Password";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(15, 77);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(87, 23);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "User Name";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(15, 48);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 23);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "Server Adresses";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "Customer";
            // 
            // txtServerHost
            // 
            // 
            // 
            // 
            this.txtServerHost.Border.Class = "TextBoxBorder";
            this.txtServerHost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServerHost.Location = new System.Drawing.Point(108, 51);
            this.txtServerHost.Name = "txtServerHost";
            this.txtServerHost.Size = new System.Drawing.Size(177, 20);
            this.txtServerHost.TabIndex = 5;
            this.txtServerHost.TextChanged += new System.EventHandler(this.textBoxX5_TextChanged);
            // 
            // txtConfrimPassword
            // 
            // 
            // 
            // 
            this.txtConfrimPassword.Border.Class = "TextBoxBorder";
            this.txtConfrimPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfrimPassword.Location = new System.Drawing.Point(302, 51);
            this.txtConfrimPassword.Name = "txtConfrimPassword";
            this.txtConfrimPassword.PasswordChar = '*';
            this.txtConfrimPassword.Size = new System.Drawing.Size(177, 20);
            this.txtConfrimPassword.TabIndex = 4;
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Location = new System.Drawing.Point(108, 80);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(177, 20);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Location = new System.Drawing.Point(302, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(177, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // cmbVpnType
            // 
            this.cmbVpnType.DataSource = this.vpnTypeDTOBindingSource;
            this.cmbVpnType.DisplayMember = "Name";
            this.cmbVpnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVpnType.FormattingEnabled = true;
            this.cmbVpnType.Location = new System.Drawing.Point(302, 80);
            this.cmbVpnType.Name = "cmbVpnType";
            this.cmbVpnType.Size = new System.Drawing.Size(177, 21);
            this.cmbVpnType.TabIndex = 0;
            this.cmbVpnType.ValueMember = "Id";
            // 
            // vpnTypeDTOBindingSource
            // 
            this.vpnTypeDTOBindingSource.DataSource = typeof(VpnManagerDAL.DTO.VpnTypeDTO);
            // 
            // grpMachine
            // 
            this.grpMachine.Controls.Add(this.txtIp);
            this.grpMachine.Controls.Add(this.button2);
            this.grpMachine.Controls.Add(this.cmdAdd);
            this.grpMachine.Controls.Add(this.cmdEdit);
            this.grpMachine.Controls.Add(this.labelX11);
            this.grpMachine.Controls.Add(this.labelX10);
            this.grpMachine.Controls.Add(this.txtPasswordMachine);
            this.grpMachine.Controls.Add(this.txtUerMachine);
            this.grpMachine.Controls.Add(this.labelX9);
            this.grpMachine.Controls.Add(this.chkCheckEnabled);
            this.grpMachine.Controls.Add(this.labelX8);
            this.grpMachine.Controls.Add(this.labelX7);
            this.grpMachine.Controls.Add(this.cmbContype);
            this.grpMachine.Controls.Add(this.txtPcName);
            this.grpMachine.Controls.Add(this.dataGridView1);
            this.grpMachine.Enabled = false;
            this.grpMachine.Location = new System.Drawing.Point(7, 165);
            this.grpMachine.Name = "grpMachine";
            this.grpMachine.Size = new System.Drawing.Size(593, 247);
            this.grpMachine.TabIndex = 1;
            this.grpMachine.TabStop = false;
            this.grpMachine.Text = "Machine";
            this.grpMachine.Enter += new System.EventHandler(this.grpMachine_Enter);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(109, 92);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(177, 20);
            this.txtIp.TabIndex = 23;
            this.txtIp.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtIp_MaskInputRejected);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(344, 92);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 21;
            this.cmdAdd.Text = "Insert";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Location = new System.Drawing.Point(425, 92);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 19;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(303, 43);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(50, 23);
            this.labelX11.TabIndex = 18;
            this.labelX11.Text = "Password";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(303, 20);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(50, 23);
            this.labelX10.TabIndex = 17;
            this.labelX10.Text = "User";
            // 
            // txtPasswordMachine
            // 
            // 
            // 
            // 
            this.txtPasswordMachine.Border.Class = "TextBoxBorder";
            this.txtPasswordMachine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPasswordMachine.Location = new System.Drawing.Point(372, 45);
            this.txtPasswordMachine.Name = "txtPasswordMachine";
            this.txtPasswordMachine.Size = new System.Drawing.Size(177, 20);
            this.txtPasswordMachine.TabIndex = 16;
            // 
            // txtUerMachine
            // 
            // 
            // 
            // 
            this.txtUerMachine.Border.Class = "TextBoxBorder";
            this.txtUerMachine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUerMachine.Location = new System.Drawing.Point(372, 19);
            this.txtUerMachine.Name = "txtUerMachine";
            this.txtUerMachine.Size = new System.Drawing.Size(177, 20);
            this.txtUerMachine.TabIndex = 15;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(16, 92);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 14;
            this.labelX9.Text = "Ip";
            this.labelX9.Click += new System.EventHandler(this.labelX9_Click);
            // 
            // chkCheckEnabled
            // 
            this.chkCheckEnabled.AutoSize = true;
            this.chkCheckEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCheckEnabled.Checked = true;
            this.chkCheckEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckEnabled.Location = new System.Drawing.Point(7, 72);
            this.chkCheckEnabled.Name = "chkCheckEnabled";
            this.chkCheckEnabled.Size = new System.Drawing.Size(152, 17);
            this.chkCheckEnabled.TabIndex = 12;
            this.chkCheckEnabled.Text = "Ping Enabled                     ";
            this.chkCheckEnabled.UseVisualStyleBackColor = true;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(7, 43);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(87, 23);
            this.labelX8.TabIndex = 11;
            this.labelX8.Text = "Connection Type";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(7, 16);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 10;
            this.labelX7.Text = "PC Name";
            // 
            // cmbContype
            // 
            this.cmbContype.DataSource = this.connectionTypeDTOBindingSource;
            this.cmbContype.DisplayMember = "Name";
            this.cmbContype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContype.FormattingEnabled = true;
            this.cmbContype.Location = new System.Drawing.Point(109, 45);
            this.cmbContype.Name = "cmbContype";
            this.cmbContype.Size = new System.Drawing.Size(177, 21);
            this.cmbContype.TabIndex = 9;
            this.cmbContype.ValueMember = "Id";
            // 
            // connectionTypeDTOBindingSource
            // 
            this.connectionTypeDTOBindingSource.DataSource = typeof(VpnManagerDAL.DTO.ConnectionTypeDTO);
            // 
            // txtPcName
            // 
            // 
            // 
            // 
            this.txtPcName.Border.Class = "TextBoxBorder";
            this.txtPcName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPcName.Location = new System.Drawing.Point(109, 19);
            this.txtPcName.Name = "txtPcName";
            this.txtPcName.Size = new System.Drawing.Size(177, 20);
            this.txtPcName.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.idPreferredConnectionTypeDataGridViewTextBoxColumn,
            this.pingResponseEnabledDataGridViewCheckBoxColumn,
            this.iPAddressDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn,
            this.idLastConnectedUserDataGridViewTextBoxColumn,
            this.idPlantDataGridViewTextBoxColumn,
            this.extensionsDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.ctmGrid;
            this.dataGridView1.DataSource = this.machineDTOBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 121);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 119);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idPreferredConnectionTypeDataGridViewTextBoxColumn
            // 
            this.idPreferredConnectionTypeDataGridViewTextBoxColumn.DataPropertyName = "IdPreferredConnectionType";
            this.idPreferredConnectionTypeDataGridViewTextBoxColumn.HeaderText = "Connection Type";
            this.idPreferredConnectionTypeDataGridViewTextBoxColumn.Name = "idPreferredConnectionTypeDataGridViewTextBoxColumn";
            this.idPreferredConnectionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pingResponseEnabledDataGridViewCheckBoxColumn
            // 
            this.pingResponseEnabledDataGridViewCheckBoxColumn.DataPropertyName = "PingResponseEnabled";
            this.pingResponseEnabledDataGridViewCheckBoxColumn.HeaderText = "Ping Enabled";
            this.pingResponseEnabledDataGridViewCheckBoxColumn.Name = "pingResponseEnabledDataGridViewCheckBoxColumn";
            this.pingResponseEnabledDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // iPAddressDataGridViewTextBoxColumn
            // 
            this.iPAddressDataGridViewTextBoxColumn.DataPropertyName = "IPAddress";
            this.iPAddressDataGridViewTextBoxColumn.HeaderText = "IP";
            this.iPAddressDataGridViewTextBoxColumn.Name = "iPAddressDataGridViewTextBoxColumn";
            this.iPAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastSuccessfullConnectionDataGridViewTextBoxColumn
            // 
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn.DataPropertyName = "LastSuccessfullConnection";
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn.HeaderText = "LastSuccessfullConnection";
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn.Name = "lastSuccessfullConnectionDataGridViewTextBoxColumn";
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastSuccessfullConnectionDataGridViewTextBoxColumn.Visible = false;
            // 
            // idLastConnectedUserDataGridViewTextBoxColumn
            // 
            this.idLastConnectedUserDataGridViewTextBoxColumn.DataPropertyName = "IdLastConnectedUser";
            this.idLastConnectedUserDataGridViewTextBoxColumn.HeaderText = "IdLastConnectedUser";
            this.idLastConnectedUserDataGridViewTextBoxColumn.Name = "idLastConnectedUserDataGridViewTextBoxColumn";
            this.idLastConnectedUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLastConnectedUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPlantDataGridViewTextBoxColumn
            // 
            this.idPlantDataGridViewTextBoxColumn.DataPropertyName = "IdPlant";
            this.idPlantDataGridViewTextBoxColumn.HeaderText = "IdPlant";
            this.idPlantDataGridViewTextBoxColumn.Name = "idPlantDataGridViewTextBoxColumn";
            this.idPlantDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extensionsDataGridViewTextBoxColumn
            // 
            this.extensionsDataGridViewTextBoxColumn.DataPropertyName = "Extensions";
            this.extensionsDataGridViewTextBoxColumn.HeaderText = "Extensions";
            this.extensionsDataGridViewTextBoxColumn.Name = "extensionsDataGridViewTextBoxColumn";
            this.extensionsDataGridViewTextBoxColumn.ReadOnly = true;
            this.extensionsDataGridViewTextBoxColumn.Visible = false;
            // 
            // ctmGrid
            // 
            this.ctmGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.ctmGrid.Name = "ctmGrid";
            this.ctmGrid.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // machineDTOBindingSource
            // 
            this.machineDTOBindingSource.DataSource = typeof(VpnManagerDAL.DTO.MachineDTO);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExtName);
            this.groupBox1.Controls.Add(this.rdPlant);
            this.groupBox1.Controls.Add(this.rdExtMachine);
            this.groupBox1.Controls.Add(this.labelX13);
            this.groupBox1.Controls.Add(this.labelX12);
            this.groupBox1.Controls.Add(this.AddExt);
            this.groupBox1.Controls.Add(this.txtExtValue);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(8, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 191);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extension";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdPlant
            // 
            this.rdPlant.AutoSize = true;
            this.rdPlant.Checked = true;
            this.rdPlant.Location = new System.Drawing.Point(6, 19);
            this.rdPlant.Name = "rdPlant";
            this.rdPlant.Size = new System.Drawing.Size(49, 17);
            this.rdPlant.TabIndex = 14;
            this.rdPlant.TabStop = true;
            this.rdPlant.Text = "Plant";
            this.rdPlant.UseVisualStyleBackColor = true;
            this.rdPlant.CheckedChanged += new System.EventHandler(this.rdPlant_CheckedChanged);
            // 
            // rdExtMachine
            // 
            this.rdExtMachine.AutoSize = true;
            this.rdExtMachine.Location = new System.Drawing.Point(61, 19);
            this.rdExtMachine.Name = "rdExtMachine";
            this.rdExtMachine.Size = new System.Drawing.Size(66, 17);
            this.rdExtMachine.TabIndex = 13;
            this.rdExtMachine.Text = "Machine";
            this.rdExtMachine.UseVisualStyleBackColor = true;
            this.rdExtMachine.CheckedChanged += new System.EventHandler(this.rdExtMachine_CheckedChanged);
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(6, 87);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(75, 23);
            this.labelX13.TabIndex = 12;
            this.labelX13.Text = "Value";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(5, 32);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(75, 23);
            this.labelX12.TabIndex = 11;
            this.labelX12.Text = "Name";
            // 
            // AddExt
            // 
            this.AddExt.Location = new System.Drawing.Point(182, 87);
            this.AddExt.Name = "AddExt";
            this.AddExt.Size = new System.Drawing.Size(32, 23);
            this.AddExt.TabIndex = 3;
            this.AddExt.Text = "->";
            this.AddExt.UseVisualStyleBackColor = true;
            this.AddExt.Click += new System.EventHandler(this.AddExt_Click);
            // 
            // txtExtValue
            // 
            this.txtExtValue.Location = new System.Drawing.Point(6, 116);
            this.txtExtValue.Multiline = true;
            this.txtExtValue.Name = "txtExtValue";
            this.txtExtValue.Size = new System.Drawing.Size(161, 69);
            this.txtExtValue.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.valueDataGridViewTextBoxColumn,
            this.targetTableDataGridViewTextBoxColumn,
            this.targetIdDataGridViewTextBoxColumn});
            this.dataGridView2.ContextMenuStrip = this.ctmGrid;
            this.dataGridView2.DataSource = this.extensionObjectDTOBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(220, 10);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(367, 175);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targetTableDataGridViewTextBoxColumn
            // 
            this.targetTableDataGridViewTextBoxColumn.DataPropertyName = "TargetTable";
            this.targetTableDataGridViewTextBoxColumn.HeaderText = "TargetTable";
            this.targetTableDataGridViewTextBoxColumn.Name = "targetTableDataGridViewTextBoxColumn";
            this.targetTableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targetIdDataGridViewTextBoxColumn
            // 
            this.targetIdDataGridViewTextBoxColumn.DataPropertyName = "TargetId";
            this.targetIdDataGridViewTextBoxColumn.HeaderText = "TargetId";
            this.targetIdDataGridViewTextBoxColumn.Name = "targetIdDataGridViewTextBoxColumn";
            this.targetIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extensionObjectDTOBindingSource
            // 
            this.extensionObjectDTOBindingSource.DataSource = typeof(VpnManagerDAL.DTO.ExtensionObjectDTO);
            // 
            // txtExtName
            // 
            this.txtExtName.FormattingEnabled = true;
            this.txtExtName.Items.AddRange(new object[] {
            "Note"});
            this.txtExtName.Location = new System.Drawing.Point(5, 60);
            this.txtExtName.Name = "txtExtName";
            this.txtExtName.Size = new System.Drawing.Size(162, 21);
            this.txtExtName.TabIndex = 15;
            // 
            // AddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMachine);
            this.Controls.Add(this.grpPlant);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddConnection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddConnection";
            this.Load += new System.EventHandler(this.AddConnection_Load);
            this.grpPlant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vpnTypeDTOBindingSource)).EndInit();
            this.grpMachine.ResumeLayout(false);
            this.grpMachine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionTypeDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ctmGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.machineDTOBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extensionObjectDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPlant;
        private System.Windows.Forms.ComboBox cmbVpnType;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServerHost;
        private DevComponents.DotNetBar.Controls.TextBoxX txtConfrimPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button cmdAddConnectionType;
        private System.Windows.Forms.BindingSource vpnTypeDTOBindingSource;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.GroupBox grpMachine;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource machineDTOBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPreferredConnectionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pingResponseEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastSuccessfullConnectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLastConnectedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbContype;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPcName;
        private System.Windows.Forms.BindingSource connectionTypeDTOBindingSource;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPasswordMachine;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUerMachine;
        private DevComponents.DotNetBar.LabelX labelX9;
        private System.Windows.Forms.CheckBox chkCheckEnabled;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.ContextMenuStrip ctmGrid;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdPlant;
        private System.Windows.Forms.RadioButton rdExtMachine;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX12;
        private System.Windows.Forms.Button AddExt;
        private System.Windows.Forms.TextBox txtExtValue;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetTableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource extensionObjectDTOBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox txtIp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox txtExtName;
    }
}