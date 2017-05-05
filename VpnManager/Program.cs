using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VpnManager
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        ///  private static Mutex m_Mutex; 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "VpnManager", out ok); // single Istance

            if (!ok)
            {
                MessageBox.Show("Another instance is already running.");
                return;
            }

            Application.Run(new Main());   // or whatever was there
            GC.KeepAlive(m);
                  
        }
    }
}
