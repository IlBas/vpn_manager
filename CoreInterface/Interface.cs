using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VpnManager.Interface
{


    public enum eConnectionState
    {
        Connected = 1,
        Disconnected = 2,
        Connecting = 3,
    }
    public interface IConnection
    {
        event ConnectionStatusChange ConnectionStatusChanged;

          void Connect();
          void Disconnect();
          void CreateConnection();
          string User { get; set; }
          string Password { get; set; }
          string ConnectionHost { get; set; }
          string ConnectionEntry { get; set; }
          Dictionary<string , string > Options { get; set; }
         
    }


    #region Interface For main form
    
    public  delegate void ConnectionStatusChange(eConnectionState ConnectionState);
    public  delegate void StartConnection(int IdCliente);
    public delegate void Disconnect();
    public delegate void StartConnectionClient(int idConnectionType);
    public delegate void InformConnectionChanged(eConnectionState State);
    public interface ISurface
    {
        event StartConnection OnConnection;
        void ChangeConnectionStatus(eConnectionState State);
        void WriteInfo(string s , bool Error);
        event StartConnectionClient OnClientConnection;
        event Disconnect OnDisconnection;
    }
    #endregion


    //  [ServiceContract(Namespace = "http://www.peppedotnet.it", Name = "DataService")] 
    //public interface IComunicationService 
    //{
    //    event StartConnection OnConnection;
    //    void ChangeConnectionStatus(eConnectionState State);
    //    void WriteInfo(string s, bool Error);
    //    event StartConnectionClient OnClientConnection;
    //    event Disconnect OnDisconnection;
    //}
    
}
