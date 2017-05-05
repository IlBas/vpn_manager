using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Configuration;

namespace FileTransferServer
{
    
    public class Server
    {
        private bool _Exit = false;
        public TcpListener Listener;

        private string _FileName = string.Empty;
        public void StartListener(int portN)
        {
            TcpListener Listener = null;
            try
            {
                Thread tr = new Thread(new ThreadStart(Dowork));
                tr.Start();
               
                Thread tr2 = new Thread(new ThreadStart(DoworkUdp));
                tr2.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Disconnect()
        {
            _Exit = true;

        }


        private void DoworkUdp()
        {
            byte[] data = new byte[1024];
            //    IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 3201);
            UdpClient newsock = new UdpClient(3201);


            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
       
            while (!_Exit)
            {
          
                data = newsock.Receive(ref sender);

                 _FileName = Encoding.ASCII.GetString(data, 0, data.Length);
            }
        }

          [STAThreadAttribute]
        private void Dowork()
        {
            byte[] RecData = new byte[1024];
            int RecBytes;
            Listener = new TcpListener(IPAddress.Any, 3200);
            Listener.Start();
              bool fileTransfered = false;
            while (!_Exit)
            {
                TcpClient client = null;
                NetworkStream netstream = null;
                
                try
                {
               
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    string SaveFileName;                                           
                      
                    SaveFileName = ConfigurationSettings.AppSettings["ShareFolder"].ToString();
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                      
                         
                        if (!Directory.Exists(SaveFileName))
                            Directory.CreateDirectory(SaveFileName);
                            
                        int totalrecbytes = 0;
                        using (FileStream Fs = new FileStream
                            (SaveFileName + "//temp", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            while ((RecBytes = netstream.Read
                                (RecData, 0, RecData.Length)) > 0)
                            { 
                                Fs.Write(RecData, 0, RecBytes);
                                totalrecbytes += RecBytes;
                            }

                        }
                                       
                        netstream.Close();
                        client.Close();
                        fileTransfered = true;
                    }
                    if (fileTransfered && _FileName != string.Empty)
                    {
                        FileInfo flinfo = new FileInfo( SaveFileName + @"\temp");
                        flinfo.MoveTo(SaveFileName + _FileName);
                        flinfo = null;
                        File.Delete(SaveFileName + @"\temp");
                        fileTransfered = false;
                        _FileName = string.Empty;
                    }
                    Thread.Sleep(1000);
                    Listener.Stop();
                   
                }
              
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //netstream.Close();
                }
            }
           
        }



    }
}
    

