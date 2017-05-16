using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VpnManager.Interface;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;
 
namespace CiscoVPN
{
    public class CiscoAnyConnect : IConnection
    {


        private string _FolderPath;
        private System.Diagnostics.Process p;
        private string pcfFileName;

        private bool activated;
        private bool connected;
        private bool firstConnection = true;
        bool nicFound = false;
        Thread threadConnectionCheck;

        public StringBuilder SB = new StringBuilder();
        StreamWriter wr;
        #region "Interface Fields"

        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionHost { get; set; }
        public string ConnectionEntry { get; set; }
        public Dictionary<string, string> Options { get; set; }

        #endregion

        public string gett()
        {
            return SB.ToString();

        }


        public void Connect()
        {
            p = new System.Diagnostics.Process();

            p.StartInfo = new System.Diagnostics.ProcessStartInfo(_FolderPath);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            wr = new StreamWriter("C:\\temp\\loggare.txt");

            p.Start();

            p.BeginOutputReadLine();


            //p.StandardInput.WriteLine("connect " + ConnectionHost);


            //p.StandardInput.WriteLine("barilla.h24");



            //activated = true;
            //threadConnectionCheck = new Thread(new ThreadStart(checkStatus));
            //threadConnectionCheck.Name = "CheckStatus";
            //threadConnectionCheck.IsBackground = true;
            //threadConnectionCheck.Start();

        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //SB.Append(e.Data);
            if (e.Data.Contains("contacting"))//[U6FD]
            {
                p.StandardInput.WriteLine("U6FD");
            }



            //wr.WriteLine(e.Data);
            //SB.Append(e.Data + Environment.NewLine);
            if (e.Data.Contains("VPN>"))
            {

                p.StandardInput.WriteLine("connect " + ConnectionHost);
            }
            else if (e.Data.Contains("[U6FD]"))
            {
                p.StandardInput.WriteLine("U6FD");
            }
            else if (e.Data.Contains("Password:"))
            {

                p.StandardInput.WriteLine("barilla.h24");
            }
            else if (e.Data.Contains("Proxy User:"))
            {

                p.StandardInput.WriteLine("Escriva.R");
            }
            else if (e.Data.Contains("Proxy Password:"))
            {

                p.StandardInput.WriteLine("Escriva.R");
            }
            SB.Append(e.Data);
        }

        private void SortOutputHandler(object sender, DataReceivedEventArgs e)
        {


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
            //connected = false;


            //if (!connected)
            //{
            //    if (ConnectionStatusChanged != null)
            //    {
            //        ConnectionStatusChanged(eConnectionState.Disconnected);

            //    }
            //}
        }





        public void Disconnect()
        {
            wr.Write(SB.ToString());
            wr.Dispose();
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

        public void CreateConnection()
        {
            //if (Options.ContainsKey("pcf_file_name"))
            //{
            //    pcfFileName = Options["pcf_file_name"];


            //}
            //else throw new Exception("pcf_file_name is not configured");
            WriteFile(true);

        }
        private void WriteFile(bool isConnectionFile)
        {
            string folder = "C:\\h24ConnectionManager\\";
            if (ConfigurationManager.AppSettings.AllKeys.Contains("FilesLocation")) folder = ConfigurationManager.AppSettings["FilesLocation"];
            DirectoryInfo dir = Directory.CreateDirectory(folder);
            FileInfo f = new FileInfo(dir.FullName + "directConnection.bat");


            //DirectoryInfo installationDir = new DirectoryInfo("C:\\program files (x86)\\Cisco Systems\\VPN CLIENT"); //64Bit Systems
            //if (!installationDir.Exists)
            //{
            //    installationDir = new DirectoryInfo("C:\\program files\\Cisco Systems\\VPN CLIENT"); //32 bit systems
            //    installationDir.Refresh();
            //    if (!installationDir.Exists)
            //    {
            //        installationDir = new DirectoryInfo("C:\\programmi\\Cisco Systems\\VPN CLIENT"); //32 bit systems
            //        installationDir.Refresh();

            //    }
            //    else throw new Exception("Installation path of Cisco VPN Client not found");
            //}

            DirectoryInfo installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Cisco\\Cisco AnyConnect VPN Client");
            if (!installationDir.Exists)
            {
                installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Cisco\\Cisco AnyConnect VPN Client");
                installationDir.Refresh();
                if (!installationDir.Exists)
                {
                    //installationDir = new DirectoryInfo("C:\\programmi\\Cisco Systems\\VPN CLIENT"); //32 bit systems
                    //installationDir.Refresh();
                    throw new Exception("Installation path of Cisco VPN Client not found");
                }

            }


            _FolderPath = f.FullName;
            StreamWriter wr = new StreamWriter(f.FullName);

            StringBuilder writer = new StringBuilder();

            //   writer.Append("CD C:\\program files (x86)\\Cisco Systems\\VPN CLIENT");
            writer.Append(string.Format("CD {0}", installationDir.FullName));
            writer.Append(Environment.NewLine);

            writer.Append("vpncli.exe");
            writer.Append(Environment.NewLine);
            if (isConnectionFile)
            {
                writer.Append("timeout /t 10");
                writer.Append(Environment.NewLine);
                //    writer.Append(string.Format("vpnclient connect {0} user {1} pwd {2}", pcfFileName, User, Password));
                //writer.Append(string.Format("connect {0}", ConnectionHost));
                //writer.Append(Environment.NewLine);

            }
            else
            {
                writer.Append(string.Format("vpnclient disconnect"));
                writer.Append(Environment.NewLine);

            }

            //writer.Append("timeout /t 5");
            //writer.Append(Environment.NewLine);
            //writer.Append("exit");

            wr.Write(writer.ToString());
            wr.Dispose();


        }




        public event ConnectionStatusChange ConnectionStatusChanged;
    }
}
