using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using VpnManager.Interface;
using VpnManager.Core;
using VpnManagerDAL;
using Security;
using System.Data.SqlClient;
using FileTransferTest;



namespace VpnManager
{
    public delegate void InternalEvent(string ConnectionInfo,bool test);
    public delegate void AddListBoxItemDelegate(object item);
    public partial class Main : DevComponents.DotNetBar.Office2007Form  , ISurface
    {
     
        public event StartConnection OnConnection;
        public event StartConnectionClient OnClientConnection;
        public event Disconnect OnDisconnection;
       // private event InternalEvent ConnectionChanged;
        private Controller _controller;
        private int SelectedNodeConnection;
        private string ComputerName;
        Panel pnl = new Panel();
        private bool connected = false;
       
      //  Logger logger = LogManager.GetLogger("Form");
        public Main()
        {
            InitializeComponent();
            
            WriteLine("Start Programm....." , false);
            WriteLine("Loading Controller.......", false);
            _controller = new Controller(this);
            LoadList();
            Security.LoggedUser.Autanticated += new OnUserAutanticated(UserLogged);
            Security.LoggedUser.Disconnected += new OnUserDisconnected(UserDisconnected);
           // lstClient.DoubleClick += new EventHandler(lstClient_DoubleClick);            
            lblComputerName.Text = _controller.GetComputerName;
         
          
        }
        private void LoadList()
        {
            if (treeClienti.Nodes[0].Nodes.Count > 0)
                treeClienti.Nodes[0].Nodes.Clear();

            foreach (VpnManagerDAL.DTO.PlantDTO client in _controller.GetCLient.Values.OrderBy(o => o.Name))
            {
             
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                node.Text = client.DisplayedName;
               // node.Image = Properties.Resources.Modem_icon;
                node.Tag = client.Id;
                node.Editable = false;
                node.DragDropEnabled = false;
                node.NodeDoubleClick += new EventHandler(node_NodeDoubleClick); //new EventHandler(lstClient_DoubleClick);
                node.Tooltip = String.Format("Right Click -> Connect to start the connection with {0}", client.Name);
                treeClienti.Nodes[0].Nodes.Add(node);
             

            }
        }

        private void UserLogged(string s)
        {
            lblLoggedUser.Text = string.Format("Logged User : {0}", s);
            loginToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Enabled = true;
            WriteInfo(string.Format("Logged User : {0}" , s), false);
        }

        private void UserDisconnected(string s)
        {
            lblLoggedUser.Text = "No user Logged";
            loginToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            WriteInfo("User Disconneted", false);
        }

        public void WriteInfo(string s , bool error)
        {
            WriteLine(s, error);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //if (!System.Diagnostics.Debugger.IsAttached)
            //    this.TopMost = true;
        }
        private void metroShell1_Resize(object sender, EventArgs e)
        {
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeClienti_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (treeClienti.SelectedNode == null)
                    mnuTree.Close();
            }
        }

        private void treeClienti_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (treeClienti.SelectedNode == null)
                    mnuTree.Close();
            }
        }

        private void treeClienti_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                if (treeClienti.SelectedNode == null)
                    mnuTree.Close();
                else
                {
                    if (treeClienti.SelectedNode.Parent != null)
                    {
                        if (treeClienti.SelectedNode.Parent.Parent == null)
                        {
                            mnuTree.Items[0].Text = String.Format("Connect To {0}", treeClienti.SelectedNode.Text);
                            cmdConnect.Visible = true;
                            disconnettiToolStripMenuItem.Visible = true;
                            editToolStripMenuItem.Visible = true;
                            connectToPCToolStripMenuItem.Visible = false;
                            toolStripSeparator2.Visible = true;
                            if (connected)
                            {
                                cmdConnect.Enabled = false;
                                disconnettiToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                cmdConnect.Enabled = true;
                                disconnettiToolStripMenuItem.Enabled = false;
                            }
                        }
                    
                        else
                        {
                            cmdConnect.Visible = false;
                            disconnettiToolStripMenuItem.Visible = false;
                            editToolStripMenuItem.Visible = false;
                            toolStripSeparator2.Visible = false;
                            connectToPCToolStripMenuItem.Visible = true;
                        }
                    }
                }
            }

        }

        private void treeClienti_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WriteLine(string text , bool errore)
        {
            if (lstConsole.Items.Count > 32000)
                lstConsole.Items.Clear();
            //logger.Trace(text);
            lstConsole.Items.Add(string.Format("{0} || {1}" , DateTime.Now.ToString("dd/MM/yyyy HH:mm") , text));
            lstConsole.SelectedIndex = lstConsole.Items.Count - 1;
            if (errore)
                MessageBox.Show(text);
            
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }



        private void Connect()
        {
            SelectedNodeConnection = treeClienti.SelectedIndex;
            if (_controller.ByPassMSAutantication || LoggedUser.CheckMembership("VPN"))
            {
                if (!connected)
                    if (MessageBox.Show("Do You Really Want Connet ?", "Attention", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        if (OnConnection != null)
                            OnConnection(Convert.ToInt32(treeClienti.SelectedNode.Tag));
            }
        }
        private void visualizzaVersioneAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            AssemblyInfo asinfo = new AssemblyInfo();
            asinfo.Show();                
        }

        #region InputDialog   
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            textBox.PasswordChar = Char.Parse("*");
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        #endregion

        private void treeClienti_SelectedValueChanged(object sender, EventArgs e)
        {
          
        }

        private void nodeParent_NodeMouseUp(object sender, MouseEventArgs e)
        {
            mnuTree.Close();
        }

        private void lstClient_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void disconnettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnDisconnection != null)
                OnDisconnection();
        }

        private void treeClienti_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            try
            {


                if (!connected)
                {
                    if (treeClienti.SelectedNode.Index > 0 || treeClienti.SelectedNode.Parent != null)
                    {


                        VpnManagerDAL.DTO.ExtensionObjectDTO ext = VpnManagerDAL.VpnManagerDal.GetExtensionObject(_controller.GetCLient[Convert.ToInt32(treeClienti.SelectedNode.Tag)].Id, VpnManagerDAL.DTO.TargetTable.Plant, "Note");
                        if (ext != null && !string.IsNullOrEmpty(ext.Value))
                        {
                            txtNote.Text = ext.Value;
                        }
                        else txtNote.Text = string.Empty; //reset info previously charged

                        LogConenction LastConenction = VpnManagerDal.GetLogForPlant(Convert.ToInt32(treeClienti.SelectedNode.Tag));
                        if (LastConenction != null)
                        {
                            string temp = @"Last Connection : {0}" + Environment.NewLine + "User : {1}" + Environment.NewLine + "Connection Succesful : {2}" +Environment.NewLine +"Virtual Machine : {3}";
                            txtLastConnectionInfo.Text = string.Format(temp, LastConenction.LastConenctionTime , LastConenction.UserName , LastConenction.ConncetionSuccesful.ToString(), LastConenction.VirtualMachineName);
                        }
                        else
                        { txtLastConnectionInfo.Text = ""; }

                    }

                    if (treeClienti.SelectedNode.Tag != null && treeClienti.SelectedNode.Parent == null)
                        plantDTOBindingSource.DataSource = _controller.GetCLient[Convert.ToInt32(treeClienti.SelectedNode.Tag)];
                }
                else
                {

                }
            }
            catch(Exception d)
            {

                WriteInfo(d.Message,true);
            }
        }

        private void lstClient_MouseHover(object sender, EventArgs e)
        {
//            if (lstClient.SelectedItems.Count> 0)
//            {
//                MachineDTO machine = VpnManagerDAL.VpnManagerDal.GetMachine(Convert.ToInt32(lstClient.SelectedItems[0].Tag));
//                string text = string.Format(@"User : {0} \n
//                                           Password : {1} \n", machine.Username, machine.Password);
//                toolInfoMachine.Show(text, lstClient);
//            }
        }

        private void lstClient_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //if (connected)
            //    machineDTOBindingSource.DataSource= VpnManagerDAL.VpnManagerDal.GetMachine(Convert.ToInt32(lstClient.SelectedItems[0].Tag));
        }

        private void txtRicerca_KeyUp(object sender, KeyEventArgs e)
        {
         //   int index = (treeClienti.Nodes.Find(txtRicerca.Text, true).FirstOrDefault()) as DevComponents.AdvTree.Node).Index;
            //treeClienti.SelectedIndex = index;
        }


    
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            e.Cancel = connected;
            //  _controller.DestroyAllClass();
            _controller = null;
            
        }

        private void nuovaConnessioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if (_controller.ByPassMSAutantication || LoggedUser.CheckMembership("H24"))
            {
                AddConnection add = new AddConnection();
                add.ShowDialog();
                _controller.ReloadAll();
                LoadList();
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                if (_controller.ByPassMSAutantication || LoggedUser.CheckMembership("H24"))
                {
                    AddConnection cn = new AddConnection((int)treeClienti.SelectedNode.Tag);
                    cn.ShowDialog();
                    _controller.ReloadAll();
                    LoadList();
                }
            }
            else
                MessageBox.Show("You Are Connected , Modification Not Alowed!");
            

        }

        private void manageExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_controller.ByPassMSAutantication || LoggedUser.CheckMembership("H24"))
            {
                Extension ex = new Extension();
                ex.ShowDialog();
            }
        }




        private void WriteConnection(string StringTowrite , bool spare)
        {

        }

        public void ChangeConnectionStatus(eConnectionState State)
        {
            switch (State)
            {
                case eConnectionState.Connected:
                    AddListBoxItem("Connected");
                    break;
                case eConnectionState.Disconnected:
                    {
                        AddListBoxItem("Disconneted");
                        break;
                    }
                case eConnectionState.Connecting:
                     AddListBoxItem("Connecting");
                    break;

            }

        }

        private void AddListBoxItem(object item)
        {
            if (this.lstConsole.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.lstConsole.Invoke(new AddListBoxItemDelegate(this.AddListBoxItem), item);
            }
            else
            {
                // This is the UI thread so perform the task.
                WriteInfo((string)item , false);
                lblStatus.Text = (string)item;

                if ((string)item == "Connected")
                {
                    lblStatus.Image = Properties.Resources.locked;
                    foreach (DevComponents.AdvTree.Node node in treeClienti.Nodes[0].Nodes)
                        if (node.Index != (SelectedNodeConnection - 1))
                            node.Visible = false;

                    foreach (DevComponents.AdvTree.Node node in treeClienti.Nodes[0].Nodes)
                        if (node.Nodes.Count > 0)
                            node.Nodes.Clear();

                    connected = true;
                    List<VpnManagerDAL.DTO.MachineDTO> Info = null;
                    Info = _controller.GetCLient[Convert.ToInt32(treeClienti.SelectedNode.Tag)].Machines.ToList(); //VpnManagerDAL.VpnManagerDal.GetMachinesByPlant(Convert.ToInt32(treeClienti.SelectedNode.Tag));

                    foreach (VpnManagerDAL.DTO.MachineDTO infomachine in Info)
                    {
                        string temp;

                        DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                        node.Text = infomachine.Name + " - " + infomachine.IPAddress  ;
                        node.Image = Properties.Resources.monitor;
                        node.Tag = infomachine.Id;
                        node.Editable = false;
                        node.DragDropEnabled = false;
                        node.NodeDoubleClick += new EventHandler(ConnectMachine);
                        node.NodeClick += null;
                        node.Tooltip = string.Format(@"User : {0} Password : {1}", infomachine.Username, infomachine.Password);
                        treeClienti.Nodes[0].Nodes[SelectedNodeConnection - 1].Nodes.Add(node);
                       
                    }
                   //treeClienti.Nodes[0].Nodes[SelectedNodeConnection].Style = DevComddponents.AdvTree.NodeStyles.Red;
                }
                else if ((string)item == "Disconneted")
                {
                    foreach (DevComponents.AdvTree.Node node in treeClienti.Nodes[0].Nodes)                       
                        node.Visible = true;


                    foreach (DevComponents.AdvTree.Node node in treeClienti.Nodes[0].Nodes)
                        if (node.Nodes.Count > 0)
                            node.Nodes.Clear();

                    treeClienti.Nodes[0].Nodes[0].Nodes.Clear();
                    treeClienti.SelectedNode.Style = null;
                    lblStatus.Image = Properties.Resources.unlocked;
                    connected = false;
                  
                }
                else if ((string)item == "Connecting")
                {

                }

            }
        }

        private void lstClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.LoggedUser.Connect();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.LoggedUser.Disconnect() ;
        }

        private void openClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileTransferTest.Client frm = new FileTransferTest.Client(false);
            frm.ShowDialog();

        }

        private void mnuTree_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtSearchClient_Enter(object sender, EventArgs e)
        {
          
         //  GrayedText = textBox1.Text; // Stores old text value if you want
            txtSearchClient.Text = ""; // Clears the text field
            txtSearchClient.ForeColor = Color.Black;
            txtSearchClient.ReadOnly = false; // Makes the field editable
        
        }

        private void txtSearchClient_Leave(object sender, EventArgs e)
        {
            if (txtSearchClient.Text == "")
            {
                txtSearchClient.ForeColor = Color.Gray;
                txtSearchClient.Text = "Enter Client Name";
                
            }
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {

            if (!connected)
            {
                if (txtSearchClient.Text != string.Empty && txtSearchClient.ForeColor != Color.Gray)
                {
                    treeClienti.Nodes[0].Nodes.Clear();
                    var temp = _controller.GetCLient.Values.Where(x => x.Name.ToUpper().Contains(txtSearchClient.Text.ToUpper())).OrderBy(o => o.Name);
                    IEnumerable<VpnManagerDAL.DTO.PlantDTO> list = (temp.ToList() as IEnumerable<VpnManagerDAL.DTO.PlantDTO>);
                    foreach (VpnManagerDAL.DTO.PlantDTO client in list)
                    {
                        DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                        node.Text = client.DisplayedName;
                        //node.Image = Properties.Resources.Modem_icon;
                        node.Tag = client.Id;
                        node.Editable = false;
                        node.DragDropEnabled = false;
                        node.NodeDoubleClick += new EventHandler(node_NodeDoubleClick);
                        node.Tooltip = String.Format("Right Click -> Connect to start the connection with {0}", client.Name);
                        treeClienti.Nodes[0].Nodes.Add(node);


                    }
                }
                else
                {
                    LoadList();
                }
            }
        }

        private void ConnectMachine(object sender, EventArgs e)
        {
            //if (lstClient.SelectedItems != null)
            //{
            //    if (_controller.ByPassMSAutantication || LoggedUser.CheckMembership("VPN"))
            //    {
            //        if (OnClientConnection != null)
            //            OnClientConnection(Convert.ToInt32(treeClienti.SelectedNode.Tag));
            //    }
            //    else
            //    {
            //        MessageBox.Show("User Not Allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            //    }
            //}
        }

        private void txtNote_DoubleClick(object sender, EventArgs e)
        {
            
            pnl.Width = this.Width;
            pnl.Height = this.Height;
            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.Height = this.Height;
            txt.Width = this.Width;
            pnl.Controls.Add(txt);
            txt.ReadOnly = true;
            txt.ScrollBars = ScrollBars.Both;
            txt.Text = txtNote.Text;
            this.Controls.Add(pnl);
            pnl.Visible = true;
            txt.DoubleClick += new System.EventHandler(CloseControl);
        }



        private void CloseControl(object sender, EventArgs e)
        {

            pnl.Controls.Clear();
            pnl.Visible = false;
            pnl = null;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        //private void lstClient_MouseClick(object sender, MouseEventArgs e)
        ////{
        ////    if ((MouseButtons.Left == e.Button) && (lstClient.SelectedItems.Count > 0))
        ////        ctMachine.Visible = true;
        ////    else
        ////        ctMachine.Visible = false;

        //}

        private void lstClient_MouseDown(object sender, MouseEventArgs e)
        {
            //if ((MouseButtons.Left == e.Button) && (lstClient.SelectedItems.Count > 0))
            //    ctMachine.Enabled = true;
            //else
            //    ctMachine.Enabled = false;
        }

        private void node_NodeDoubleClick(object sender, EventArgs e)
        {
            Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectToPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnClientConnection != null)
                OnClientConnection(Convert.ToInt32(treeClienti.SelectedNode.Tag));
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }



       
    }

}
