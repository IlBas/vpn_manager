using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using VpnManager.Interface;
using System.Net;

using System.Diagnostics;
using Security;
using System.Configuration;
using VpnManagerDAL.DTO;
using VpnManagerDAL;
using System.Threading;
using Microsoft.Win32;


/*
 * TODO :
 * - Evento che riceve dalle dll info sullo stato connesione X
 * - Creare Classe per le Connessioni , comprendetne di tutti i campi necessari alla visualizzaizione e alla connessione
 *   ritornera alla interfaccia una Dictionary con tutte le connessioni , con chiave dizionario il nome del clinte.
 *   passare tramite l'evento  X
 * - Disabilitare la possibilia di collegamento ad una nuova connessione  sulla grafica se la connessione è gia attiva. X
 * - Funzione Caricamento dell'assembly quando si effettua la connessione   X
*/
namespace VpnManager.Core
{
    public delegate void InfoFromCore(string s, bool error);
     public delegate void InfoConnectionStatusChanged(eConnectionState state);
    public class Controller
    {


        private IConnection _connetion = null; //<-- una sola connessione alla volta
        //  Dictionary<string, Client> ListClients = new Dictionary<string, Client>();
        public InfoFromCore OnInfoFromCore;
        public InfoConnectionStatusChanged ConnectionChanged;
        public Thread tTimeout;
        private Dictionary<int, CustomerDTO> ListClients = new Dictionary<int, CustomerDTO>(); //Cliente e suo ID 
        private Dictionary<int, PlantDTO> ListPlants = new Dictionary<int, PlantDTO>(); //linkato tramite ID cliente
        private Dictionary<int, ConnectionTypeDTO> ListConnectionsType = new Dictionary<int, ConnectionTypeDTO>(); //linkato tramite listcliet.IDconnectionType  QUI CI METTO IL NOME DLL!!!!!!!!!!
        private Dictionary<int, VpnTypeDTO> VpnTypes = new Dictionary<int, VpnTypeDTO>();
        private Dictionary<int, MachineDTO> Machines = new Dictionary<int, MachineDTO>();
        private PlantDTO ConnectToClient;
        private string ComputerName;
        private bool _Connected = false;
        private LogConenction Log;
            //private FileTransferServer.Server srv;
        private bool _BypassMSAutantication = false;

        public Controller(ISurface frm)
        {
            frm.OnConnection += new StartConnection(Connect);
            OnInfoFromCore = new InfoFromCore(frm.WriteInfo);
            frm.OnClientConnection += new StartConnectionClient(frm_OnClientConnection);
            frm.OnDisconnection += new Interface.Disconnect(frm_OnDisconnection);
            ConnectionChanged += new InfoConnectionStatusChanged(frm.ChangeConnectionStatus);
            //Evento per scrittura log          
            LoadListClients();
            ComputerName = Environment.MachineName;  
            CheckBaypassAutentication();
            OnInfoFromCore("Controller: Controller Loaded!", false);
            tTimeout = new Thread(new ThreadStart(CheckTimeoutConnetcion));
            //srv = new Server();
            //srv.StartListener(3200);
           
        }

        public string GetComputerName
        {

            get { return ComputerName; }
        }

        public bool ByPassMSAutantication
        {

            get { return _BypassMSAutantication; }
        }

        private void CheckBaypassAutentication()
        {
            RegistryKey HkLocal = Registry.CurrentUser;
            RegistryKey RegKey = HkLocal.OpenSubKey(@"SOFTWARE\asdewq\0987" ,true);
            if (RegKey != null)
            {
                string regKey = (string)RegKey.GetValue("BPSMSAU");
                if (regKey == "1")
                {
                    _BypassMSAutantication = true;
                    OnInfoFromCore("Controller:********* Bypass Autanticaton Active!!!*********", false);
                }
                else
                    OnInfoFromCore("Controller: MS Domain Autantication Active", false);

            }
            else
                OnInfoFromCore("Controller: MS Domain Autantication Active", false);
        }


        

        private void frm_OnDisconnection()
        {
            if (_connetion != null)
            {
               // _Connected = false;
                OnInfoFromCore("Controller: Disconnetcing..... ", false);
              //  ConnectToClient = null;
                _connetion.Disconnect();
             //   _connetion = null;
                Log.ConncetionSuccesful = true;
             //   VpnManagerDal.UpdateLog(Log);
            }
            else
                OnInfoFromCore("Controller: You're not Connected to any VPN!", false);
        }


        private void Connect(int IDClient)
        {
          
            if (_connetion == null)
            {
                
                ConnectToClient = ListPlants[IDClient];
                VpnTypeDTO vpntype = VpnTypes[ConnectToClient.IdConnectionType];
                if (ConnectToClient != null)
                {
                    OnInfoFromCore(String.Format("Connecting To {0}", ConnectToClient.Name), false);

                    if (!System.Diagnostics.Debugger.IsAttached)
                        InitializeAssmebly(vpntype.Name);
                    else
                        _connetion = new CiscoVPN.CiscoAnyConnect();

                    if (_connetion != null)
                    {
                         Log = new LogConenction();
                        Log.Id_ConnectionPlant = IDClient;
                        Log.UserName = !_BypassMSAutantication ?  Security.LoggedUser.ActualUser.user : "Baypass Active";
                        Log.VirtualMachineName = ComputerName;
                        Log.LastConenctionTime = DateTime.Now;
                        VpnManagerDal.AddLog(Log);
                        Machines = VpnManagerDAL.VpnManagerDal.GetMachinesByPlant(ConnectToClient.Name).ToDictionary( f => f.Id);
                        Dictionary<string, string> temp = new Dictionary<string, string>(vpntype.Extensions);
                        Dictionary<string, string> temp2 = new Dictionary<string, string>(ConnectToClient.Extensions);
                        _connetion.ConnectionEntry = ConnectToClient.Name;
                        _connetion.Password = ConnectToClient.Password;
                        _connetion.User = ConnectToClient.Username;
                        _connetion.ConnectionHost = ConnectToClient.ServerAddress;
                        _connetion.ConnectionStatusChanged += new ConnectionStatusChange(_connetion_Info);
                        _connetion.Options = (temp.Concat(temp2)).ToDictionary(x => x.Key, x => x.Value);
                        _connetion.CreateConnection();
                        _connetion.Connect();                      
                        _Connected = false;
                        tTimeout = new Thread(new ThreadStart(CheckTimeoutConnetcion));
                        tTimeout.Start();
                        ConnectionChanged(eConnectionState.Connecting);

                    }

                }
            }
            else
                OnInfoFromCore(String.Format("Controller : You are alredy Connected  to {0} !!!", _connetion.ConnectionEntry) , true);   
        }


        private void _connetion_Info(eConnectionState state)
        {
            try
            {
                ConnectionChanged(state);
                if (state == eConnectionState.Disconnected)
                {
                    _connetion = null;
                    ConnectToClient = null;
                    _Connected = false;
                    Log.ConncetionSuccesful = true;
                    VpnManagerDal.UpdateLog(Log);
                    tTimeout.Abort();
                    tTimeout = null;
                }
                else if (state == eConnectionState.Connected)
                    _Connected = true;
            }
            catch { }

        }

        private void CheckTimeoutConnetcion()
        {
            DateTime starttimeout = DateTime.Now;
            while (starttimeout.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(10000);
                if (_Connected )
                    continue;                
              //  ConnectionChanged(eConnectionState.Connecting);
                Thread.Sleep(10000);
           
               
            }
            if (!_Connected)
            {
                try
                {
                    _connetion.Disconnect();
                }
                catch
                { }
                _connetion = null;
                ConnectionChanged(eConnectionState.Disconnected);
            }
           // else ConnectionChanged(eConnectionState.Connected);
        }

        private void frm_OnClientConnection(int IdMachine)
        {
            if (_connetion != null)
            {
                MachineDTO machine = Machines[IdMachine];//(from x in Machines where Machines.Keys == IdMachine).ToList().FirstOrDefault();
                ConnectionTypeDTO conntype = ListConnectionsType.Values.Where(f => f.Id == machine.IdPreferredConnectionType).FirstOrDefault();
                if (conntype.Name.ToUpper() == "RDP")
                {
                    if (conntype.Extensions.Keys.Contains("cmdstart"))
                    {
                        OnInfoFromCore(String.Format("Try to connecting with {0}", machine.Name), false);
                        Process.Start(conntype.Extensions["cmdstart"].ToString(), string.Format("/v:{0}", machine.IPAddress));
                    }
                }
                else
                {
                    if (conntype.Name.ToUpper() == "VNC")
                    {
                        if (conntype.Extensions.Keys.Contains("cmdstart"))
                        {
                            OnInfoFromCore(String.Format("Try to connecting with {0}", machine.Name), false);
                            Process.Start(conntype.Extensions["cmdstart"].ToString(), machine.IPAddress.ToString() + " -password " + machine.Password.ToString());
                        }
                    }

                }
            }
            else
                OnInfoFromCore("Controller:  You're not Connected to any VPN!", false);
        }

        private void LoadListClients()
        {

            OnInfoFromCore("Controller: Loading VPN", false);
            try
            {

                ListClients = VpnManagerDal.GetCustomers().ToDictionary(x => x.Id);
                ListPlants = VpnManagerDal.GetPlants().ToDictionary(f => f.Id);
                ListConnectionsType = VpnManagerDal.GetConnectionTypes().ToDictionary(g => g.Id);
                VpnTypes = VpnManagerDal.GetVpnTypes().ToDictionary(j => j.Id);
                OnInfoFromCore("Core: Loaded Completed", false);
            }
            catch (Exception e)
            {
                OnInfoFromCore("Controller: Error in Loading  Vpn", false);
                OnInfoFromCore(e.Message, false);
            }



        }
        #region Caricamento Assembly
        
        public void ReloadAll()
        {
            OnInfoFromCore("Controller: Reloading VPN", false);
            try
            {

                ListClients = VpnManagerDal.GetCustomers().ToDictionary(x => x.Id);
                ListPlants = VpnManagerDal.GetPlants().ToDictionary(f => f.Id);
                ListConnectionsType = VpnManagerDal.GetConnectionTypes().ToDictionary(g => g.Id);
                VpnTypes = VpnManagerDal.GetVpnTypes().ToDictionary(j => j.Id);
             //   OnInfoFromCore("Core: Loaded Completed", false);
            }
            catch (Exception e)
            {
                OnInfoFromCore("Controller: Error in Loading  Vpn", false);
                OnInfoFromCore(e.Message, false);
            }
        }

        private void InitializeAssmebly(string AssemblyName)
        {
            try
            {
                //OnInfoFromCore("Core: Caricamento Assembly", true);
                System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory +"\\VPN");
                string path = Directory.GetCurrentDirectory(); // ".";
                //string[] files = Directory.GetFileSystemEntries(path, "*.dll");           
                Assembly ass = Assembly.LoadFrom(AssemblyName);

                List<Type> types = ExamineAssembly(ass, typeof(IConnection));
                if (types.Count > 0)
                    _connetion = (IConnection)Activator.CreateInstance(types[0]);

            }
            catch (Exception e)
            {
                OnInfoFromCore("Controller: Error Loading Assembly", false);
            }
        }

        //private List<Type> GetLoadableTypes(this Assembly assembly)
        //{
        //    if (assembly == null) throw new ArgumentNullException(nameof(assembly));
        //    try
        //    {
        //        return assembly.GetTypes().ToList();
        //    }
        //    catch (ReflectionTypeLoadException e)
        //    {
        //        return e.Types.Where(t => t != null).ToList();
        //    }
        //}

        private List<Type> ExamineAssembly(Assembly assembly, Type type)
        {


            List<Type> types = new List<Type>();
            var type1 = assembly.GetTypes();
            foreach (Type t in type1)
            {
                if (t.IsPublic && (t.Attributes & TypeAttributes.Abstract) == 0)
                {
                    if (ImplementInterface(t, type))
                        types.Add(t);
                }
            }
            return types;
        }

        private bool ImplementInterface(Type t, Type matchType)
        {
            Type[] interfaces = t.GetInterfaces();
            foreach (Type i in interfaces)
            {
                if (i == matchType)
                    return true;
            }
            return false;
        }
        #endregion



        public void Disconnect()
        {
            if (_Connected)
            {
                Log.ConncetionSuccesful = true;
                VpnManagerDal.UpdateLog(Log);
            }

            _connetion.Disconnect();
          
        }

        //public void DestroyAllClass()
        //{
        //    srv.Disconnect();
        //    srv = null;
        //    if (_connetion != null)
        //        _connetion.Disconnect();
        //    _connetion = null;

        //}
        //~Controller()
        //{
        //    srv.Disconnect();

        //}

        public Dictionary<int, PlantDTO> GetCLient
        {
            get { return ListPlants; }
        }

        public Dictionary<int, VpnTypeDTO> GetVpnTypes
        {
            get { return VpnTypes; }
        }


    }
}
