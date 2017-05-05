using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VpnManager
{
    public partial class PrintConnectionDetails : Form
    {
        public PrintConnectionDetails()
        {
            InitializeComponent();
        }

        private void PrintConnectionDetails_Load(object sender, EventArgs e)
        {
         
            this.reportViewer1.RefreshReport();
        }
    }
}
