using System;
using System.Collections.Generic;
using System.Linq;
using CiscoVPN;
using CiscoVPN;
using VpnManager.Interface;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnection test  ;                
            Console.WriteLine("Permi 1 per avviare connessione Cisco o 2 Per Windos Vpn");
            string i = Console.ReadLine();
            switch (i)
            {
                case "1":
                //    Assembly assembly = Assembly.LoadFile(string.Format(Application.StartupPath + "\\{0}.dll", "WindowsVpn"));
                  
                    break;
                case "2":
                  
                 
                    break;


            }
        //    Assembly assembly = Assembly.LoadFile(string.Format(Application.StartupPath + "\\{0}.dll", "WindowsVpn"));
            test = new CiscoVPN.CiscoAnyConnect();
            test.ConnectionEntry = "vpn.elettric80.it";
            test.ConnectionHost = "https://webvpn.niagarawater.com/E80_CON";
            test.User = "XXXX";
            test.Password = "XXXX";
            test.CreateConnection();
            test.Connect();
            Console.Read();
              //  test.Disconnect();
            
        }


        private void StartWindowsVpn()
        {

        }
    }
}
