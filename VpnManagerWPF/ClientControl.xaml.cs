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
using VpnManagerDAL;

namespace VpnManagerWPF
{
    /// <summary>
    /// Interaction logic for ClientControl.xaml
    /// </summary>
    public partial class ClientControl : UserControl
    {
        private VpnManagerDAL.DTO.PlantDTO Plant;
      
        public ClientControl(VpnManagerDAL.DTO.PlantDTO plant)
        {
            InitializeComponent();
            Plant = plant;
            this.DataContext = this;
        }
        public ClientControl()
        {
            InitializeComponent();
           
            this.DataContext = this;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
           
        }
        public static readonly DependencyProperty ucStringProperty =
         DependencyProperty.Register("ucString", typeof(String), typeof(ClientControl));

    }
}
