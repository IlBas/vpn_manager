using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreInterface;

namespace CiscoVpn
{
    public class CiscoConnection : IConnection
    {
        private string _user;
        private string _password;
        private string _connectionentry;
        private string _Connectionhost;
        private string _FolderPath;


        public CiscoConnection(string folderPath)
        {
            _FolderPath = folderPath;



        }
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string ConnectionHost
        {
            get
            {
                return _Connectionhost;
            }
            set
            {
                _Connectionhost = value;
            }
        }

        public string ConnectionEntry
        {
            get
            {
                return _connectionentry;
            }
            set
            {
                _connectionentry = value;
            }
        }



        public void CreateConnection()
        {
            throw new NotImplementedException();
        }

        public event ConnectionStatusChange Info;


        public Dictionary<string, string> Options
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
