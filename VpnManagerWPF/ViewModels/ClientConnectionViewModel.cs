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
using VpnManagerDAL;
using VpnManagerDAL.DTO;

namespace VpnManagerWPF.ViewModels
{
   public class ClientConnectionViewModel : Screen
    {
         
        public event StartConnectionClient OnClientConnection;
        public event Disconnect OnDisconnection;

        IEventAggregator _events;
        private Visibility _WaitingProgressVisibility = Visibility.Hidden;
        private Controller _controller;
        private PlantDTO _Plant;
        private bool _Connected;
       

        public ClientConnectionViewModel(Controller controller , PlantDTO plant, IEventAggregator eventAggregator )
        {
            _events = eventAggregator;
            Controller = controller;
            Plant = plant;
            
            
        }


        public bool Connected
        {
            get
            {
                return _Connected;
            }

            set
            {
                _Connected = value;
                this.NotifyOfPropertyChange(() => this.Connected);
            }
        }

        public PlantDTO Plant
        {
            get
            {
                return _Plant;
            }

            set
            {
                _Plant = value;
                this.NotifyOfPropertyChange(() => this.Plant);
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


        public void Connect()
        {
            Controller.Connect(Plant.Id);
        }
        
        public void Disconnect()
        {
            Controller.Disconnect();
        }
    }
}
