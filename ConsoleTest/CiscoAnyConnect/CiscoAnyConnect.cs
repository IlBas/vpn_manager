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
        bool wait = false;
        public string gett()
        {
            return SB.ToString();

        }


        public void Connect()
        {
            var file = "C:\\Program Files (x86)\\Cisco\\Cisco AnyConnect Secure Mobility Client\\vpncli.exe";
            DirectoryInfo installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Cisco\\Cisco AnyConnect Secure Mobility Client");
            if (!installationDir.Exists)
            {
                installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Cisco\\Cisco AnyConnect Secure Mobility Client");
                installationDir.Refresh();
                if (!installationDir.Exists)
                {
                    //installationDir = new DirectoryInfo("C:\\programmi\\Cisco Systems\\VPN CLIENT"); //32 bit systems
                    //installationDir.Refresh();
                    throw new Exception("Installation path of Cisco VPN Client not found");
                }

            }
            var host = ConnectionHost;
            var profile = ConnectionEntry;
            var user = User;
            var pass = Password;     

             p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = file,
                   Arguments = string.Format("-s"),
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };

            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += (s, a) => SB.AppendLine(a.Data);

            var procFilter = new HashSet<string>() { "vpnui", "vpncli" };
            var existingProcs = Process.GetProcesses().Where(pr => procFilter.Contains(pr.ProcessName));
            if (existingProcs.Any())
            {
                foreach (var pr in existingProcs)
                {
                    pr.Kill();
                }
            }

            p.Start();
            p.BeginOutputReadLine();

            var simProfile = string.Format("{1}{0}"
            , Environment.NewLine
            , string.Format("connect {0}", ConnectionHost)
     
            );

            p.StandardInput.Write(simProfile);
            p.StandardInput.Flush();
            p.StandardInput.WriteLine(User);
            p.StandardInput.Flush();
            p.StandardInput.WriteLine(Password);
            p.StandardInput.Flush();
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
              
            Console.WriteLine(e.Data.ToString());           
        

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
            p.StandardInput.WriteLine("disconncet");
            p.StandardInput.Flush();
            p.WaitForExit();
 
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

            DirectoryInfo installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Cisco\\Cisco AnyConnect Secure Mobility Client");
            if (!installationDir.Exists)
            {
                installationDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Cisco\\Cisco AnyConnect Secure Mobility Client");
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
                //writer.Append("timeout /t 10");
                //writer.Append(Environment.NewLine);
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
