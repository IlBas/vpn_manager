using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Reflection;
using VpnManager.Interface;
using VpnManagerDAL.DTO;
using System.Security.Cryptography;


namespace TestManagerService
{
    public partial class TestManager : ServiceBase
    {

        IConnection _IConnection;
        Thread _ThreadControlTest;
        private Dictionary<int, CustomerDTO> ListClients = new Dictionary<int, CustomerDTO>(); //Cliente e suo ID 
        private Dictionary<int, PlantDTO> ListPlants = new Dictionary<int, PlantDTO>(); //linkato tramite ID cliente
        private Dictionary<int, ConnectionTypeDTO> ListConnectionsType = new Dictionary<int, ConnectionTypeDTO>(); //linkato tramite listcliet.IDconnectionType  QUI CI METTO IL NOME DLL!!!!!!!!!!
        private Dictionary<int, VpnTypeDTO> VpnTypes = new Dictionary<int, VpnTypeDTO>();
        private Dictionary<int, MachineDTO> Machines = new Dictionary<int, MachineDTO>();
        private PlantDTO ConnectToClient;
        private IPAddress _IpAdresses;
        public TestManager()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _ThreadControlTest = new Thread(new ThreadStart(StartControl));
            _ThreadControlTest.Start();
        }


        private void StartControl()
        {
            bool Finished = true;
            while (true)
            {
                if (((int)DayOfWeek.Monday == DateTime.Now.Day) && !Finished)
                {
                }
                /*prima controllo se e lunedi , successivamente recupero tutte le connessioni con il controllo automatico della connessione 
                  successivamento carico assempli e impostazioni e lancio la connessione , se mi collego lancio un ping 
                */


            }
        }


        protected override void OnStop()
        {
        }

        private void Connect(int IDClient)
        {
            if (_IConnection == null)
            {

                ConnectToClient = ListPlants[IDClient];
                VpnTypeDTO vpntype = VpnTypes[ConnectToClient.IdConnectionType];
                if (ConnectToClient != null)
                {
                   
                    InitializeAssmebly(vpntype.Name);
                    if (_IConnection != null)
                    {
                        Dictionary<string, string> temp = new Dictionary<string, string>(vpntype.Extensions);
                        Dictionary<string, string> temp2 = new Dictionary<string, string>(ConnectToClient.Extensions);
                        _IConnection.ConnectionEntry = ConnectToClient.Name;
                        _IConnection.Password = ConnectToClient.Password;
                        _IConnection.User = ConnectToClient.Username;
                        _IConnection.ConnectionHost = ConnectToClient.ServerAddress;
                        _IConnection.ConnectionStatusChanged += new ConnectionStatusChange(_connetion_Info); //<--- Stato collegato o meno
                        _IConnection.Options = (temp.Concat(temp2)).ToDictionary(x => x.Key, x => x.Value);
                        _IConnection.CreateConnection();
                        _IConnection.Connect();
                    }

                }
            }
          
        }


        private void _connetion_Info(eConnectionState state)
        {
          
         
             

        }

        public string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }



        #region Caricamento Assembly

    

        private void InitializeAssmebly(string AssemblyName)
        {
            try
            {
                //OnInfoFromCore("Core: Caricamento Assembly", true);
                System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
                string path = Directory.GetCurrentDirectory(); // ".";
                //string[] files = Directory.GetFileSystemEntries(path, "*.dll");           
                Assembly ass = Assembly.LoadFrom(AssemblyName);

                List<Type> types = ExamineAssembly(ass, typeof(IConnection));
                if (types.Count > 0)
                    _IConnection = (IConnection)Activator.CreateInstance(types[0]);

            }
            catch (Exception e)
            {
               
            }
        }
        private List<Type> ExamineAssembly(Assembly assembly, Type type)
        {
            List<Type> types = new List<Type>();
            foreach (Type t in assembly.GetTypes())
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

     
    }
}
