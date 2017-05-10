using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using VpnManager.Interface;
using VpnManager.Core;
using Security;
namespace VpnManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///   public delegate void InternalEvent(string ConnectionInfo,bool test);
    public delegate void AddListBoxItemDelegate(object item);
    public delegate void InternalEvent(string ConnectionInfo, bool test);
    public partial class MainWindow   : ISurface
    {
        private Controller _controller;
        private int SelectedNodeConnection;
        private string ComputerName;
      
        private bool connected = false;
        public MainWindow()
        {
            InitializeComponent();
            _controller = new Controller(this);
            LoadList();
            Security.LoggedUser.Autanticated += new OnUserAutanticated(UserLogged);
            Security.LoggedUser.Disconnected += new OnUserDisconnected(UserDisconnected);
        }

        public event StartConnectionClient OnClientConnection;
        public event StartConnection OnConnection;
        public event Disconnect OnDisconnection;

        private void UserLogged(string s)
        {
            //lblLoggedUser.Text = string.Format("Logged User : {0}", s);
            //loginToolStripMenuItem.Enabled = false;
            //disconnectToolStripMenuItem.Enabled = true;
            //WriteInfo(string.Format("Logged User : {0}", s), false);
        }

        private void UserDisconnected(string s)
        {
            //lblLoggedUser.Text = "No user Logged";
            //loginToolStripMenuItem.Enabled = true;
            //disconnectToolStripMenuItem.Enabled = false;
            //WriteInfo("User Disconneted", false);
        }

        public void WriteInfo(string s, bool error)
        {
            //WriteLine(s, error);

        }
        public void ChangeConnectionStatus(eConnectionState State)
        {
            throw new NotImplementedException();
        }

      
        private void LoadList()
        {
            //if (treeClienti.Nodes[0].Nodes.Count > 0)
            //    treeClienti.Nodes[0].Nodes.Clear();

            //foreach (VpnManagerDAL.DTO.PlantDTO client in _controller.GetCLient.Values.OrderBy(o => o.Name))
            //{

            //    DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
            //    node.Text = client.DisplayedName;
            //    // node.Image = Properties.Resources.Modem_icon;
            //    node.Tag = client.Id;
            //    node.Editable = false;
            //    node.DragDropEnabled = false;
            //    node.NodeDoubleClick += new EventHandler(node_NodeDoubleClick); //new EventHandler(lstClient_DoubleClick);
            //    node.Tooltip = String.Format("Right Click -> Connect to start the connection with {0}", client.Name);
            //    treeClienti.Nodes[0].Nodes.Add(node);


            //}
        }
    }
}
