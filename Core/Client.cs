using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Client
    {
        private string _connectionEntry;
        private string _ClientName;
        private string _ConnectionType;
        private string _ConnectioHost;
        private string _User;
        private string _Pasword;
        private List<PcClient> PcList = new List<PcClient>();



        public string ConnectionEntry
        {
            get { return _connectionEntry; }
            set { _connectionEntry = value; }
        }

        public string ConnectionHost
        {
            get { return _ConnectioHost; }
            set { _ConnectioHost = value; }
        }
        public string ClientName
        {
            get { return _ClientName; }
            set { _ClientName = value; }
        }
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        public string Password
        {
            get { return _Pasword; }
            set { _Pasword = value; }
        }

        public string ConnectionType
        {
            get { return _ConnectionType; }
            set { _ConnectionType = value; }

        }
    }

    internal class PcClient
    {
        string Ip{get; set;}
        string Type{get; set;}

    }
}
