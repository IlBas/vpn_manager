using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemoteViewing.Utility;
using RemoteViewing.Vnc;
namespace VpnManager.UC
{
    public partial class VNC : UserControl
    {
        public VNC()
        {
            InitializeComponent();
        }

        private void vncControl1_Load(object sender, EventArgs e)
        {
            VncClient vnc = new VncClient();
          
        }
    }
}
