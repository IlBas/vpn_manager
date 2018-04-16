using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using System.Data.SqlClient;
using VpnManagerWPF.Interfaces;
using System.ComponentModel.Composition;
using VpnManager.Interface;
using VpnManager;
using VpnManager.Core;
using VpnManagerWPF.Views;

namespace VpnManagerWPF.ViewModels
{

    [Export(typeof(IShell))]
    public class MainViewModel : Conductor<Screen>.Collection.OneActive, IShell, IHandle<Screen> , ISurface
    {

        public event StartConnection OnConnection;
        public event StartConnectionClient OnClientConnection;
        public event Disconnect OnDisconnection;
        ConnectionListViewModel Home;
        private List<string> _Info = new List<string>();
        IEventAggregator _events = new EventAggregator();
        private Visibility _WaitingProgressVisibility = Visibility.Hidden;
       Controller controller;
        public MainViewModel()
        {
            controller = new Controller(this);
            _events.Subscribe(this);
            Home = new ConnectionListViewModel(controller, _events);
            ActivateItem(Home);
        }

        public Controller Controller
        {
            get
            {
                return controller;
            }

            set
            {
                controller = value;
                this.NotifyOfPropertyChange(() => this.Controller);
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
        public  List<string> Info
        {
            get
            {
                return _Info;
            }

            set
            {
                _Info = value;
                this.NotifyOfPropertyChange(() => this.Info);
            }
        }


        public void ChangeConnectionStatus(eConnectionState State)
        {
            if (State == eConnectionState.Connecting)
                WaitingProgressVisibility = Visibility.Visible;
            else
                WaitingProgressVisibility = Visibility.Hidden;

        }


        public void GoHome()
        {
            ActivateItem(Home);
        }
        public void Handle(Screen message)
        {
            ActivateItem(message);
        }

        public void WriteInfo(string s, bool Error)
        {
            if (Info.Count > 32000)
                Info.Clear();
            //logger.Trace(text);
            Info.Add($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} || {s}");
             
        
        }
    }
}
