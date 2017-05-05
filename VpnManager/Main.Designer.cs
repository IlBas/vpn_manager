namespace VpnManager
{
    partial class Main 
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
     
        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.treeClienti = new DevComponents.AdvTree.AdvTree();
            this.mnuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnettiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeParent = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.plantDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ctMachine = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovaConnessioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoDEbuggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaVersioneAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTransefrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoggedUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblComputerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstConsole = new System.Windows.Forms.ListBox();
            this.infoDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolInfoMachine = new System.Windows.Forms.ToolTip(this.components);
            this.txtSearchClient = new System.Windows.Forms.TextBox();
            this.infoDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtLastConnectionInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeClienti)).BeginInit();
            this.mnuTree.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plantDTOBindingSource)).BeginInit();
            this.ctMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machineDTOBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDtoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // treeClienti
            // 
            this.treeClienti.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeClienti.AllowDrop = true;
            this.treeClienti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeClienti.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.treeClienti.BackgroundStyle.Class = "TreeBorderKey";
            this.treeClienti.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeClienti.ContextMenuStrip = this.mnuTree;
            this.treeClienti.ForeColor = System.Drawing.Color.Black;
            this.treeClienti.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeClienti.Location = new System.Drawing.Point(7, 61);
            this.treeClienti.Name = "treeClienti";
            this.treeClienti.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.nodeParent});
            this.treeClienti.NodesConnector = this.nodeConnector1;
            this.treeClienti.NodeStyle = this.elementStyle1;
            this.treeClienti.PathSeparator = ";";
            this.treeClienti.Size = new System.Drawing.Size(237, 390);
            this.treeClienti.Styles.Add(this.elementStyle1);
            this.treeClienti.Styles.Add(this.elementStyle2);
            this.treeClienti.TabIndex = 2;
            this.treeClienti.Text = "advTree1";
            this.treeClienti.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.treeClienti_NodeClick);
            this.treeClienti.SelectedValueChanged += new System.EventHandler(this.treeClienti_SelectedValueChanged);
            this.treeClienti.Click += new System.EventHandler(this.treeClienti_Click);
            this.treeClienti.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeClienti_MouseClick);
            this.treeClienti.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeClienti_MouseDown);
            this.treeClienti.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeClienti_MouseUp);
            // 
            // mnuTree
            // 
            this.mnuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdConnect,
            this.disconnettiToolStripMenuItem,
            this.toolStripSeparator2,
            this.editToolStripMenuItem,
            this.connectToPCToolStripMenuItem});
            this.mnuTree.Name = "mnuTree";
            this.mnuTree.Size = new System.Drawing.Size(152, 98);
            this.mnuTree.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTree_Opening);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Image = global::VpnManager.Properties.Resources.link;
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(151, 22);
            this.cmdConnect.Text = "Connect to ";
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // disconnettiToolStripMenuItem
            // 
            this.disconnettiToolStripMenuItem.Image = global::VpnManager.Properties.Resources.shut_down;
            this.disconnettiToolStripMenuItem.Name = "disconnettiToolStripMenuItem";
            this.disconnettiToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.disconnettiToolStripMenuItem.Text = "Disconnect";
            this.disconnettiToolStripMenuItem.Click += new System.EventHandler(this.disconnettiToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::VpnManager.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.editToolStripMenuItem.Text = "Edit..";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // connectToPCToolStripMenuItem
            // 
            this.connectToPCToolStripMenuItem.Image = global::VpnManager.Properties.Resources.link;
            this.connectToPCToolStripMenuItem.Name = "connectToPCToolStripMenuItem";
            this.connectToPCToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.connectToPCToolStripMenuItem.Text = "Connect to PC";
            this.connectToPCToolStripMenuItem.Visible = false;
            this.connectToPCToolStripMenuItem.Click += new System.EventHandler(this.connectToPCToolStripMenuItem_Click);
            // 
            // nodeParent
            // 
            this.nodeParent.DragDropEnabled = false;
            this.nodeParent.Editable = false;
            this.nodeParent.Expanded = true;
            this.nodeParent.Image = global::VpnManager.Properties.Resources.info;
            this.nodeParent.Name = "nodeParent";
            this.nodeParent.Text = "Customers";
            this.nodeParent.NodeMouseUp += new System.Windows.Forms.MouseEventHandler(this.nodeParent_NodeMouseUp);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Description = "Blue";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtLastConnectionInfo);
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(250, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 419);
            this.panel1.TabIndex = 3;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNote.Location = new System.Drawing.Point(3, 3);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(341, 300);
            this.txtNote.TabIndex = 4;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            this.txtNote.DoubleClick += new System.EventHandler(this.txtNote_DoubleClick);
            // 
            // plantDTOBindingSource
            // 
            this.plantDTOBindingSource.DataSource = typeof(VpnManagerDAL.DTO.PlantDTO);
            // 
            // ctMachine
            // 
            this.ctMachine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingToolStripMenuItem});
            this.ctMachine.Name = "ctMachine";
            this.ctMachine.Size = new System.Drawing.Size(99, 26);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // machineDTOBindingSource
            // 
            this.machineDTOBindingSource.DataSource = typeof(VpnManagerDAL.DTO.MachineDTO);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.infoDEbuggerToolStripMenuItem,
            this.fileTransefrToolStripMenuItem,
            this.securityToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(609, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaConnessioneToolStripMenuItem,
            this.manageExtensionToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "Edit";
            // 
            // nuovaConnessioneToolStripMenuItem
            // 
            this.nuovaConnessioneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuovaConnessioneToolStripMenuItem.Image")));
            this.nuovaConnessioneToolStripMenuItem.Name = "nuovaConnessioneToolStripMenuItem";
            this.nuovaConnessioneToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nuovaConnessioneToolStripMenuItem.Text = "New Connection";
            this.nuovaConnessioneToolStripMenuItem.Click += new System.EventHandler(this.nuovaConnessioneToolStripMenuItem_Click);
            // 
            // manageExtensionToolStripMenuItem
            // 
            this.manageExtensionToolStripMenuItem.Image = global::VpnManager.Properties.Resources.process;
            this.manageExtensionToolStripMenuItem.Name = "manageExtensionToolStripMenuItem";
            this.manageExtensionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.manageExtensionToolStripMenuItem.Text = "Manage Extension";
            this.manageExtensionToolStripMenuItem.Click += new System.EventHandler(this.manageExtensionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VpnManager.Properties.Resources.delete;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Visible = false;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // infoDEbuggerToolStripMenuItem
            // 
            this.infoDEbuggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizzaVersioneAssemblyToolStripMenuItem});
            this.infoDEbuggerToolStripMenuItem.Name = "infoDEbuggerToolStripMenuItem";
            this.infoDEbuggerToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.infoDEbuggerToolStripMenuItem.Text = "Info Debugger";
            // 
            // visualizzaVersioneAssemblyToolStripMenuItem
            // 
            this.visualizzaVersioneAssemblyToolStripMenuItem.Name = "visualizzaVersioneAssemblyToolStripMenuItem";
            this.visualizzaVersioneAssemblyToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.visualizzaVersioneAssemblyToolStripMenuItem.Text = "Visualizza Versione Assembly";
            this.visualizzaVersioneAssemblyToolStripMenuItem.Click += new System.EventHandler(this.visualizzaVersioneAssemblyToolStripMenuItem_Click);
            // 
            // fileTransefrToolStripMenuItem
            // 
            this.fileTransefrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openClientToolStripMenuItem});
            this.fileTransefrToolStripMenuItem.Name = "fileTransefrToolStripMenuItem";
            this.fileTransefrToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.fileTransefrToolStripMenuItem.Text = "File Transefer";
            // 
            // openClientToolStripMenuItem
            // 
            this.openClientToolStripMenuItem.Image = global::VpnManager.Properties.Resources.refresh;
            this.openClientToolStripMenuItem.Name = "openClientToolStripMenuItem";
            this.openClientToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.openClientToolStripMenuItem.Text = "Open Client";
            this.openClientToolStripMenuItem.Click += new System.EventHandler(this.openClientToolStripMenuItem_Click);
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.securityToolStripMenuItem.Text = "Security";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Image = global::VpnManager.Properties.Resources.key;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Image = global::VpnManager.Properties.Resources.unlocked;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToToolStripMenuItem
            // 
            this.howToToolStripMenuItem.Image = global::VpnManager.Properties.Resources.light_bulb;
            this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
            this.howToToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.howToToolStripMenuItem.Text = "How to..";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::VpnManager.Properties.Resources.info;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblLoggedUser,
            this.lblComputerName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(609, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Image = global::VpnManager.Properties.Resources.unlocked;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(198, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Not Connected";
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(198, 17);
            this.lblLoggedUser.Spring = true;
            this.lblLoggedUser.Text = "No user logged";
            this.lblLoggedUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblComputerName
            // 
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(198, 17);
            this.lblComputerName.Spring = true;
            this.lblComputerName.Text = "ComputerName";
            // 
            // lstConsole
            // 
            this.lstConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConsole.BackColor = System.Drawing.SystemColors.InfoText;
            this.lstConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstConsole.ForeColor = System.Drawing.SystemColors.Info;
            this.lstConsole.FormattingEnabled = true;
            this.lstConsole.ItemHeight = 16;
            this.lstConsole.Location = new System.Drawing.Point(7, 457);
            this.lstConsole.Name = "lstConsole";
            this.lstConsole.Size = new System.Drawing.Size(590, 100);
            this.lstConsole.TabIndex = 6;
            // 
            // toolInfoMachine
            // 
            this.toolInfoMachine.IsBalloon = true;
            // 
            // txtSearchClient
            // 
            this.txtSearchClient.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSearchClient.Location = new System.Drawing.Point(7, 35);
            this.txtSearchClient.Name = "txtSearchClient";
            this.txtSearchClient.Size = new System.Drawing.Size(237, 20);
            this.txtSearchClient.TabIndex = 7;
            this.txtSearchClient.Text = "Find Client";
            this.txtSearchClient.TextChanged += new System.EventHandler(this.txtSearchClient_TextChanged);
            this.txtSearchClient.Enter += new System.EventHandler(this.txtSearchClient_Enter);
            this.txtSearchClient.Leave += new System.EventHandler(this.txtSearchClient_Leave);
            // 
            // infoDtoBindingSource1
            // 
            this.infoDtoBindingSource1.DataSource = typeof(VpnManager.Core.DTO.InfoDto);
            // 
            // txtLastConnectionInfo
            // 
            this.txtLastConnectionInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLastConnectionInfo.Location = new System.Drawing.Point(3, 309);
            this.txtLastConnectionInfo.Multiline = true;
            this.txtLastConnectionInfo.Name = "txtLastConnectionInfo";
            this.txtLastConnectionInfo.ReadOnly = true;
            this.txtLastConnectionInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLastConnectionInfo.Size = new System.Drawing.Size(341, 107);
            this.txtLastConnectionInfo.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 595);
            this.Controls.Add(this.txtSearchClient);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstConsole);
            this.Controls.Add(this.treeClienti);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vpn Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeClienti)).EndInit();
            this.mnuTree.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plantDTOBindingSource)).EndInit();
            this.ctMachine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.machineDTOBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDtoBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.AdvTree.AdvTree treeClienti;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.BindingSource infoDtoBindingSource;
        private System.Windows.Forms.ToolStripMenuItem nuovaConnessioneToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip mnuTree;
        private System.Windows.Forms.ToolStripMenuItem cmdConnect;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lstConsole;
        private System.Windows.Forms.BindingSource infoDtoBindingSource1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem infoDEbuggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaVersioneAssemblyToolStripMenuItem;
        private DevComponents.AdvTree.Node nodeParent;
        private System.Windows.Forms.ToolStripMenuItem disconnettiToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolInfoMachine;
        private System.Windows.Forms.BindingSource machineDTOBindingSource;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageExtensionToolStripMenuItem;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private System.Windows.Forms.ToolStripStatusLabel lblLoggedUser;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblComputerName;
        private System.Windows.Forms.BindingSource plantDTOBindingSource;
        private System.Windows.Forms.ToolStripMenuItem fileTransefrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openClientToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearchClient;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctMachine;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToPCToolStripMenuItem;
        private System.Windows.Forms.TextBox txtLastConnectionInfo;
    }
}

