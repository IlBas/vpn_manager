using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections;
using VpnManager.Interface;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using DotRas;

namespace WindowsVpn
{
    public class WindowsConnection : IConnection
    {
        private string _user;
        private string _password;
        private string _connectionentry;
        private string _Connectionhost;
        private Dictionary<string, string> _oprions = new Dictionary<string,string>();
        private RasDialer _Dialer = new RasDialer();
        private RasHandle _handle = new RasHandle();
        private Thread ThrCheckConnect ;

        private bool CloseThre;
       // public event ConnectionStatusChange Info;
        public  void Connect()
        {
            // This button will be used to dial the connection.
            _Dialer.EntryName = _connectionentry;
            _Dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            ThrCheckConnect = new Thread(new ThreadStart(DoWork));
            try
            {
                // Set the credentials the dialer should use.
                _Dialer.Credentials = new NetworkCredential(_user,_password);
                
                // NOTE: The entry MUST be in the phone book before the connection can be dialed.
                // Begin dialing the connection; this will raise events from the dialer instance.
                _handle = _Dialer.DialAsync();

                ThrCheckConnect.Start();
            }
            catch (Exception ex)
            {
               
            }
        }


        private void DoWork()
        {

            //while (!CloseThre)
            //{
            //    List<NetworkInterface> fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces().ToList();

            //    foreach (NetworkInterface neti in fNetworkInterfaces)
            //    {
            //       neti.Supports().
            //    }
            //}

        }





        private void ConnectionStateChanged(object sender, StateChangedEventArgs e)
        {

            if (ConnectionStatusChanged != null)
            {
                switch (e.State)
                {
                    case RasConnectionState.Connected:
                        ConnectionStatusChanged(eConnectionState.Connected);
                      
                        break;
                    case RasConnectionState.Disconnected:
                        ConnectionStatusChanged(eConnectionState.Disconnected);                
                        break;
                    default:
                        ;
                        break;
                }


            }
                
        }

        private void ErrorEvent(object sender, ErrorEventArgs e)
        {



       

        }

        public void Disconnect()
        {
            if (_Dialer.IsBusy)
            {
                // The connection attempt has not been completed, cancel the attempt.
                this._Dialer.DialAsyncCancel();
            }
            else
            {
                // The connection attempt has completed, attempt to find the connection in the active connections.
                RasConnection connection = RasConnection.GetActiveConnectionByHandle(_handle);
                if (connection != null)
                {
                    // The connection has been found, disconnect it.
                    connection.HangUp();
                    ConnectionStatusChanged(eConnectionState.Disconnected);

                }
                RasPhoneBook AllUsersPhoneBook = new RasPhoneBook();
                AllUsersPhoneBook.Open();
                if ((AllUsersPhoneBook.Entries.Contains(_connectionentry)))
                {
                   // AllUsersPhoneBook.Entries[_connectionentry].Remove();
                }
             }
        }

        public string User
        {
            get {return _user;}
            set { _user = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string ConnectionEntry
        {
            get { return _connectionentry; }
            set { _connectionentry = value; }
        }
        public string ConnectionHost
        {
            get { return _Connectionhost; }
            set { _Connectionhost = value; }
        }


        public void CreateConnection()
        {
          
                RasPhoneBook AllUsersPhoneBook = new RasPhoneBook();
                AllUsersPhoneBook.Open();

                // Create the entry that will be used by the dialer to dial the connection. Entries can be created manually, however the static methods on
                // the RasEntry class shown below contain default information matching that what is set by Windows for each platform.
                RasEntry entry = RasEntry.CreateVpnEntry(_connectionentry, _Connectionhost, RasVpnStrategy.Default,
                    RasDevice.GetDeviceByName("(PPTP)", RasDeviceType.Vpn));
                _Dialer.StateChanged += new EventHandler<StateChangedEventArgs>(ConnectionStateChanged);
                _Dialer.Error += new EventHandler<ErrorEventArgs>(ErrorEvent);
           
                // Add the new entry to the phone book.
                if (!(AllUsersPhoneBook.Entries.Contains(_connectionentry)))
                {
                    AllUsersPhoneBook.Entries.Add(entry);
                }
           
           
        }
    
        // inserisci campo INDIRIZZO e FUNZIONE CREATE








        public Dictionary<string, string> Options
        {
            get
            {
                return _oprions;
            }
            set
            {
                _oprions = value;

            }
        }

        public event ConnectionStatusChange ConnectionStatusChanged;
    }



    //public static class WindowsEntitieConnection
    //{
        

    //}
}
