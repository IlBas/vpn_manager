using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VpnManager.Interface;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;

namespace CheckPoint
{
    public class CheckPoint : IConnection
    {
        public event ConnectionStatusChange ConnectionStatusChanged;
        private string _user;
        private string _password;
        private string _connectionentry;
        private string _Connectionhost;
        private Dictionary<string, string> _oprions = new Dictionary<string, string>();
        private Thread ThrCheckConnect;
        private string ConnectionString, DisconnectionString;
        private string _FolderPath;
        private System.Diagnostics.Process p;
        private string pcfFileName;

        private bool activated;
        private bool connected;
        private bool firstConnection = true;
        bool nicFound = false;
        Thread threadConnectionCheck;



        public void Connect()
        {
            p = new System.Diagnostics.Process();

            p.StartInfo = new System.Diagnostics.ProcessStartInfo(_FolderPath);
            p.StartInfo.UseShellExecute = false;


            p.Start();
            activated = true;
            threadConnectionCheck = new Thread(new ThreadStart(checkStatus));
            threadConnectionCheck.Name = "CheckStatus";
            threadConnectionCheck.IsBackground = true;
            threadConnectionCheck.Start();
        }

        public void Disconnect()
        {
            activated = false;
            WriteFile(false);
            p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(_FolderPath);
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();


            //      threadConnectionCheck.Abort();
            threadConnectionCheck = null;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            nicFound = false;
            foreach (NetworkInterface nic in nics)
            {
                if (nic.Description.Contains("Cisco System")) nicFound = true;

            }

            if (!nicFound)
            {

                if (ConnectionStatusChanged != null)
                {
                    ConnectionStatusChanged(eConnectionState.Disconnected);

                    connected = false;


                }



            }
        }


        public void checkStatus()
        {
            while (activated)
            {

                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                nicFound = false;
                foreach (NetworkInterface nic in nics)
                {
                    if (nic.Description.Contains("Cisco System"))
                    {
                        nicFound = true;

                        Ping p = new Ping();
                        PingReply reply = p.Send(nic.GetIPProperties().DnsAddresses[0], 2000);
                        if (reply.Status == IPStatus.Success)
                        {

                            firstConnection = false;

                            if (!connected)
                            {

                                ConnectionStatusChanged(eConnectionState.Connected);
                                connected = true;
                            }
                            else
                            {
                                connected = true;

                            }

                        }
                        else
                        {
                            if (!firstConnection)
                            {

                                if (connected)
                                {
                                    ConnectionStatusChanged(eConnectionState.Disconnected);
                                    connected = false;
                                }
                                else
                                {
                                    connected = false;

                                }
                            }
                        }

                    }
                }

                if (!nicFound)
                {
                    if (!firstConnection)
                    {
                        if (ConnectionStatusChanged != null)
                        {
                            ConnectionStatusChanged(eConnectionState.Disconnected);

                            connected = false;


                        }
                    }


                }
                Thread.Sleep(5000);
            }

            if (!activated)
            {


            }         
        }
        private void WriteFile(bool isConnectionFile)
        {
            string folder = "C:\\h24ConnectionManager\\";
            if (ConfigurationSettings.AppSettings.AllKeys.Contains("FilesLocation")) folder = System.Configuration.ConfigurationSettings.AppSettings["FilesLocation"];
            DirectoryInfo dir = Directory.CreateDirectory(folder);
            FileInfo f = new FileInfo(dir.FullName + "directConnection.bat");

            DirectoryInfo installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\CheckPoint\\EndPoint Connect");
            if (!installationDir.Exists)
            {
                installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\CheckPoint\\EndPoint Connect");
                installationDir.Refresh();
                if (!installationDir.Exists)
                {
                    //installationDir = new DirectoryInfo("C:\\programmi\\Cisco Systems\\VPN CLIENT"); //32 bit systems
                    //installationDir.Refresh();
                    throw new Exception("Installation path of CheckPoint Client not found");
                }

            }

            //ConnectionString = Options["CheckPointPath"].ToString() + " " + " " + Options["ConnectionCommand"].ToString() + ConnectionEntry + " " + User + " " + Password;
          //  DisconnectionString = Options["CheckPointPath"].ToString() + " " + Options["DisconnectCommand"].ToString();

            _FolderPath = f.FullName;
            StreamWriter wr = new StreamWriter(f.FullName);

            StringBuilder writer = new StringBuilder();

            //   writer.Append("CD C:\\program files (x86)\\Cisco Systems\\VPN CLIENT");
            writer.Append(string.Format("CD {0}", installationDir.FullName));
            writer.Append(Environment.NewLine);

            if (isConnectionFile)
            {
                writer.Append(string.Format("trac connect -s '{0}' -u {1} -p {2}", pcfFileName, User, Password));
                writer.Append(Environment.NewLine);

            }
            else
            {
                writer.Append(string.Format("trac disconnect"));
                writer.Append(Environment.NewLine);

            }

            //writer.Append("timeout /t 5");
            //writer.Append(Environment.NewLine);
            //writer.Append("exit");

            wr.Write(writer.ToString());
            wr.Dispose();


        }
        public void CreateConnection()
        {
            pcfFileName = ConnectionHost;
            WriteFile(true);

        }

        public string User
        {
            get { return _user; }
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
    }
}
