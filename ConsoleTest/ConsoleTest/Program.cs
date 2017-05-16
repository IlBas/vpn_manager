using System;
using System.Collections.Generic;
using System.Linq;

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
                    test = new CiscoVPN.CiscoVPN();
                    test.ConnectionEntry = "vpn.elettric80.it";
                    test.ConnectionHost = "vpn.elettric80.it";
                    test.User = "genitoni.m";
                    test.Password = "fr5678tg";
                    break;
                case "2":
                  
                    //test.ConnectionEntry = "vpn.pregel.com";
                    //test.ConnectionHost = "vpn.pregel.com";
                    //test.User = "pregel.it\\user1e80";
                    //test.Password = "1q2w3e4";
                    break;


            }
            Assembly assembly = Assembly.LoadFile(string.Format(Application.StartupPath + "\\{0}.dll", "WindowsVpn"));
            test = new CiscoVPN.CiscoVPN();
            test.ConnectionEntry = "vpn.elettric80.it";
            test.ConnectionHost = "vpn.elettric80.it";
            test.User = "genitoni.m";
            test.Password = "fr5678tg";
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
