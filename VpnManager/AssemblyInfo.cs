using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using VpnManager.Core.DTO;

namespace VpnManager
{
    public partial class AssemblyInfo : Form
    {
        public AssemblyInfo()
        {
            InitializeComponent();
        }

        private void AssemblyInfo_Load(object sender, EventArgs e)
        {
            List<InfoDto> listassmebly = new List<InfoDto>();
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            string path = Directory.GetCurrentDirectory(); // ".";
            string[] files = Directory.GetFileSystemEntries(path, "*.dll");
            foreach (string file in files)
            {
                Assembly ass = Assembly.LoadFrom(file);
                InfoDto info = new InfoDto();
                info.Info = ass.FullName;
                info.Value = ass.GetName().Version.ToString();
                listassmebly.Add(info);
            }
            infoDtoBindingSource.DataSource = listassmebly;
        }
    }
}
