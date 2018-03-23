using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro; 
using System.Data.SqlClient;
using System.ComponentModel.Composition;
using VpnManager.Core;
using VpnManager.Interface;
using VpnManagerDAL.DTO;
using VpnManagerWPF.Views;

namespace VpnManagerWPF.ViewModels
{
    public class ConnectionListViewModel :Screen
    {
        IEventAggregator _events;
        Controller _controller;
        private Visibility _WaitingProgressVisibility = Visibility.Hidden;
        private IList<PlantDTO> _plant;

        public ConnectionListViewModel(Controller controller , IEventAggregator eventAggregator)
        {
            _events = eventAggregator;
            Controller = controller;
            Connections = controller.GetCLient.Values.ToList();
        }
        public Controller Controller
        {
            get
            {
                return _controller;
            }

            set
            {
                _controller = value;
                this.NotifyOfPropertyChange(() => this.Controller);
            }
        }
        public IList<PlantDTO> Connections
        {
            get
            {
                return _plant;
            }

            set
            {
                _plant = value;
                this.NotifyOfPropertyChange(() => this.Connections);
            }
        }

        public Visibility WaitingProgressVisibility
        {
            get
            {
                return _WaitingProgressVisibility;
            }

            set
            {
                _WaitingProgressVisibility = value;
                this.NotifyOfPropertyChange(() => this.WaitingProgressVisibility);
            }
        }

        public void OpenInfo(ActionExecutionContext context)
        {
            _events.PublishOnUIThread(new ClientConnectionViewModel());

        }
    }
}
