using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VpnManagerDAL.DTO;


namespace VpnManagerDAL
{
    public static class VpnManagerDal
    {


        /// <summary>
        /// Returns Customers list
        /// </summary>
        /// <returns></returns>
        public static List<CustomerDTO> GetCustomers()
        {
            List<CustomerDTO> retVal = null;
            try
            {
                using (VpnManagerEntities entities = new VpnManagerEntities())
                {

                    string tbName = TargetTable.Customer.ToString();
                    retVal = (from c in entities.Customer
                              orderby c.Name
                              select new CustomerDTO
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  ExtensionCollection = (from eo in entities.ExtensionObjects
                                                         where eo.IdTargetElement == c.Id && eo.TargetTableName == tbName
                                                         select new ExtensionObjectDTO
                                                         {
                                                             Name = eo.Name,
                                                             Value = eo.Value
                                                         })

                              }).ToList();

                }
            }
            catch (Exception ex)
            {


            }


            return retVal;
        }


        
        public static void AddLog(LogConenction obj)
        {
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                entities.LogConenction.Add(obj);
                entities.SaveChanges();
            }
        }

        public static void UpdateLog(LogConenction obj)
        {
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
               // entities.LogConenction.Add(obj);
                LogConenction _log =(from x in entities.LogConenction where x.Id == obj.Id select x).FirstOrDefault();
                _log.ConncetionSuccesful = obj.ConncetionSuccesful;
                entities.SaveChanges();
            }
        }


        public static List<string> GetCustomersList()
        {
            List<string> retVal = null;
            try
            {
                using (VpnManagerEntities entities = new VpnManagerEntities())
                {

                    string tbName = TargetTable.Customer.ToString();
                    retVal = (from c in entities.Customer
                              orderby c.Name
                              select c.Name).ToList();

                }
            }
            catch (Exception ex)
            {


            }


            return retVal;
        }
        /// <summary>
        /// Returns plants list
        /// </summary>
        /// <returns></returns>
        public static List<PlantDTO> GetPlants()
        {

            List<PlantDTO> retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = TargetTable.Plant.ToString();
                retVal = (from p in entities.Plant
                          orderby p.Name
                          select new PlantDTO
                          {
                              Id = p.Id,
                              Name = p.Name,
                              ServerAddress = p.ServerAddress,
                              Username = p.Username,
                              Password = p.Password,
                              DisplayedName = (from x in entities.Customer where x.Id == p.Id_Customer select x.Name).FirstOrDefault(),
                              IdConnectionType = p.IdConnectionType,
                              Machines = (from m in entities.Machine
                                          where m.IdPlant == p.Id
                                          select new MachineDTO
                                          {
                                              Id = m.Id,
                                              Name = m.Name,
                                              IPAddress = m.IpAddress,
                                              Username = m.Username,
                                              Password = m.Password,
                                              PingResponseEnabled = m.PingResponseEnabled.Value,
                                              IdLastConnectedUser = m.IdLastConnectedUser.HasValue ? m.IdLastConnectedUser.Value : 0,
                                              LastSuccessfullConnection = m.LastSuccessfulConnection.Value,

                                              IdPreferredConnectionType = m.IdPreferredConnectionType,
                                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                                     where eo.IdTargetElement == m.Id && eo.TargetTableName == tbName
                                                                     select new ExtensionObjectDTO
                                                                     {
                                                                         Name = eo.Name,
                                                                         Value = eo.Value
                                                                     })

                                          }),
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == p.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })

                          }).ToList();

            }

            return retVal;
        }

        /// <summary>
        /// Returns plants list
        /// </summary>
        /// <returns></returns>
        public static PlantDTO GetPlant(int plantId)
        {

            PlantDTO retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = TargetTable.Plant.ToString();

                retVal = (from p in entities.Plant
                          where p.Id == plantId
                          select new PlantDTO
                          {
                              Id = p.Id,
                              Name = p.Name,
                              ServerAddress = p.ServerAddress,
                              Username = p.Username,
                              Password = p.Password,
                              IdConnectionType = p.IdConnectionType,
                              DisplayedName = (from x in entities.Customer where x.Id == p.Id_Customer select x.Name).FirstOrDefault(),
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == p.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })
                          }).FirstOrDefault();

            }

            return retVal;
        }


        public static LogConenction GetLogForPlant(int IdPlant)
        {
            LogConenction RetVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                RetVal = (from x in entities.LogConenction where x.Id_ConnectionPlant == IdPlant orderby x.LastConenctionTime descending select x).FirstOrDefault();
            }
            return RetVal;
        }
        public static PlantDTO GetPlant(string plantName)
        {

            PlantDTO retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = TargetTable.Plant.ToString();
                retVal = (from p in entities.Plant
                          where p.Name.Contains(plantName)

                          select new PlantDTO
                          {
                              Id = p.Id,
                              Name = p.Name,
                              ServerAddress = p.ServerAddress,
                              Username = p.Username,
                              Password = p.Password,
                              IdConnectionType = p.IdConnectionType,
                             DisplayedName = (from x in entities.Customer where x.Id == p.Id_Customer select x.Name).FirstOrDefault(),
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == p.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })
                          }).FirstOrDefault();

            }

            return retVal;
        }

        public static VpnTypeDTO GetVpnType(int vpnTypeId)
        {
            VpnTypeDTO retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = TargetTable.VpnType.ToString();

                retVal = (from vpnType in entities.VpnType
                          where vpnType.Id == vpnTypeId
                          select new VpnTypeDTO
                          {
                              Id = vpnType.Id,
                              Name = vpnType.Name,

                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == vpnType.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })
                          }).FirstOrDefault();

            }

            return retVal;

        }
        /// <summary>
        /// Returns VpnTypesList
        /// </summary>
        /// <returns></returns>
        public static List<VpnTypeDTO> GetVpnTypes()
        {
            List<VpnTypeDTO> retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = TargetTable.VpnType.ToString();

                retVal = (from vpnType in entities.VpnType

                          select new VpnTypeDTO
                          {
                              Id = vpnType.Id,
                              Name = vpnType.Name,


                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == vpnType.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })
                          }).ToList();

            }

            return retVal;

        }

        public static MachineDTO GetMachine(int machineId)
        {
            MachineDTO retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                string tbName = TargetTable.Machine.ToString();

                retVal = (from m in entities.Machine
                          where m.Id == machineId
                          select new MachineDTO
                          {
                              Id = m.Id,
                              Name = m.Name,
                              IPAddress = m.IpAddress,
                              Username = m.Username,
                              Password = m.Password,
                              PingResponseEnabled = m.PingResponseEnabled.Value,
                              IdLastConnectedUser = m.IdLastConnectedUser.HasValue ? m.IdLastConnectedUser.Value : 0,
                              LastSuccessfullConnection = m.LastSuccessfulConnection.Value,
                              IdPreferredConnectionType = m.IdPreferredConnectionType,
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == m.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })

                          }).FirstOrDefault();

            }

            return retVal;


        }
        public static List<MachineDTO> GetMachinesByPlant(int plantId)
        {
            List<MachineDTO> retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {


                string tbName = TargetTable.Machine.ToString();
                retVal = (from m in entities.Machine
                          where m.IdPlant == plantId
                          orderby m.Name
                          select new MachineDTO
                          {
                              Id = m.Id,
                              Name = m.Name,
                              IPAddress = m.IpAddress,
                              Username = m.Username,
                              Password = m.Password,
                              PingResponseEnabled = m.PingResponseEnabled.Value,
                              IdLastConnectedUser = m.IdLastConnectedUser.HasValue ? m.IdLastConnectedUser.Value : 0,
                              LastSuccessfullConnection = m.LastSuccessfulConnection.Value,
                              IdPreferredConnectionType = m.IdPreferredConnectionType,
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == m.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })

                          }).ToList();

            }

            return retVal;


        }
        public static List<MachineDTO> GetMachinesByPlant(string plantName)
        {
            List<MachineDTO> retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                string tbName = TargetTable.Machine.ToString();

                int plantId = (from p in entities.Plant where p.Name.Contains(plantName) select p.Id).FirstOrDefault();



                retVal = (from m in entities.Machine
                          where m.IdPlant == plantId
                          orderby m.Name
                          select new MachineDTO
                          {
                              Id = m.Id,
                              Name = m.Name,
                              IPAddress = m.IpAddress,
                              Username = m.Username,
                              Password = m.Password,
                              PingResponseEnabled = m.PingResponseEnabled.Value,
                              IdLastConnectedUser = m.IdLastConnectedUser.HasValue ? m.IdLastConnectedUser.Value : 0,
                              LastSuccessfullConnection = m.LastSuccessfulConnection.Value,
                              IdPreferredConnectionType = m.IdPreferredConnectionType,
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == m.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })

                          }).ToList();

            }

            return retVal;


        }

        /// <summary>
        /// Returns the Connection types list to connect to a machine
        /// </summary>
        /// <returns></returns>
        public static List<ConnectionTypeDTO> GetConnectionTypes()
        {

            List<ConnectionTypeDTO> retVal = null;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = TargetTable.ConnectionType.ToString();

                retVal = (from ct in entities.ConnectionType
                          orderby ct.Name
                          select new ConnectionTypeDTO
                          {
                              Id = ct.Id,
                              Name = ct.Name,
                              ExtensionCollection = (from eo in entities.ExtensionObjects
                                                     where eo.IdTargetElement == ct.Id && eo.TargetTableName == tbName
                                                     select new ExtensionObjectDTO
                                                     {
                                                         Name = eo.Name,
                                                         Value = eo.Value
                                                     })
                          }).ToList();

            }

            return retVal;
        }

        /// <summary>
        /// Add a new plant from the passed params
        /// </summary>
        /// <param name="name">Name of the plant (CocaCola Femsa)</param>
        /// <param name="connectionType">The id of VPN connection Type</param>
        /// <param name="serverAddress">Ip or public address to connect with</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool InsertNewPlant(string name, int connectionType, string serverAddress, string username, string password)
        {


            bool retVal = false;

            using (VpnManagerEntities entities = new VpnManagerEntities())
            {


                Plant p = new Plant();
                p.Id_Customer = (int)(from s in entities.Customer where s.Name.Contains(name) select s.Id).FirstOrDefault();
                p.Name = name;
                p.IdConnectionType = connectionType;
                p.ServerAddress = serverAddress;
                p.Username = username;
                p.Password = password;
                entities.Plant.Add(p);
                retVal = entities.SaveChanges() > 0;

            }

            return retVal;

        }
        /// <summary>
        /// Edit the plant with the passed params
        /// </summary>
        /// <param name="plantId"></param>
        /// <param name="name"></param>
        /// <param name="connectionType"></param>
        /// <param name="serverAddress"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool EditPlant(int plantId, string name, int connectionType, string serverAddress, string username, string password)
        {


            bool retVal = false;

            using (VpnManagerEntities entities = new VpnManagerEntities())
            {


                Plant p = (from plants in entities.Plant where plants.Id == plantId select plants).FirstOrDefault();
                if (p != null)
                {
                    p.Name = name;
                    p.IdConnectionType = connectionType;
                    p.ServerAddress = serverAddress;
                    p.Username = username;
                    p.Password = password;
                    p.Id_Customer = (int)(from s in entities.Customer where s.Name.Contains(name) select s.Id).FirstOrDefault();
                    retVal = entities.SaveChanges() > 0;

                }


            }

            return retVal;

        }

        public static bool DeletePlant(int plantId)
        {
            bool retVal = false;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                Plant p = (from plants in entities.Plant where plants.Id == plantId select plants).FirstOrDefault();
                if (p != null)
                {
                    entities.Plant.Remove(p);

                    retVal = entities.SaveChanges() > 0;

                }
            }
            return retVal;


        }

        /// <summary>
        /// Add a new machine into the machine list to the passed plant and with the specified data 
        /// </summary>
        /// <param name="plantId"></param>
        /// <param name="machineName"></param>
        /// <param name="ipAddress"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="pingResponsive"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        public static bool InsertNewMachine(int plantId, string machineName, string ipAddress, string username, string password, bool? pingResponsive, int? connectionType)
        {


            bool retVal = false;

            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                Machine m = new Machine();
                m.IdPlant = plantId;
                m.Name = machineName;
                m.IpAddress = ipAddress;
                m.Username = username;
                m.Password = password;
                m.PingResponseEnabled = pingResponsive;
                m.IdPreferredConnectionType = connectionType.Value;

                entities.Machine.Add(m);
                retVal = entities.SaveChanges() > 0;

            }

            return retVal;

        }

        public static bool EditMachine(int machineId, string machineName, string ipAddress, string username, string password, bool? pingResponsive, int? plantId, int? connectionType)
        {


            bool retVal = false;
            if (machineId != 0)
            {
                using (VpnManagerEntities entities = new VpnManagerEntities())
                {

                    Machine machine = (from m in entities.Machine where m.Id == machineId select m).FirstOrDefault();

                    if (machine != null)
                    {
                        machine.IdPlant = plantId.Value;
                        machine.Name = machineName;
                        machine.IpAddress = ipAddress;
                        machine.Username = username;
                        machine.Password = password;
                        machine.IdPreferredConnectionType = connectionType.Value;
                        machine.PingResponseEnabled = pingResponsive;


                        retVal = entities.SaveChanges() > 0;
                    }


                }


            }


            return retVal;

        }

        public static bool DeleteMachine(int machineId)
        {

            bool retVal = false;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                Machine m = (from machines in entities.Machine where machines.Id == machineId select machines).FirstOrDefault();
                if (m != null)
                {
                    entities.Machine.Remove(m);

                    retVal = entities.SaveChanges() > 0;

                }
            }
            return retVal;

        }

        public static bool InsertNewVpnType(string name)
        {
            bool retVal = false;

            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                VpnType conn = new VpnType();
                conn.Name = name;

                entities.VpnType.Add(conn);
                retVal = entities.SaveChanges() > 0;

            }

            return retVal;

        }

        public static bool EditVpnType(int connectioTypeId, string name)
        {
            bool retVal = false;
            if (connectioTypeId != 0 && !string.IsNullOrEmpty(name))
            {
                using (VpnManagerEntities entities = new VpnManagerEntities())
                {

                    VpnType conn = (from ct in entities.VpnType where ct.Id == connectioTypeId select ct).FirstOrDefault();
                    if (conn != null)
                    {

                        conn.Name = name;

                        retVal = entities.SaveChanges() > 0;
                    }

                }
            }

            return retVal;

        }

        public static bool InsertNewConnectionType(string name)
        {
            bool retVal = false;

            using (VpnManagerEntities entities = new VpnManagerEntities())
            {

                ConnectionType conn = new ConnectionType();
                conn.Name = name;

                entities.ConnectionType.Add(conn);
                retVal = entities.SaveChanges() > 0;

            }

            return retVal;

        }

        public static bool AddExtensionObject(int targetId, TargetTable table, string name, string value)
        {
            bool retVal = false;

            if (table != null)
            {

                using (VpnManagerEntities entities = new VpnManagerEntities())
                {

                    var checkedTargetId = 0;
                    var targetTable = string.Empty;

                    switch (table)
                    {
                        case TargetTable.VpnType:
                            checkedTargetId = (from vpn in entities.VpnType where vpn.Id == targetId select vpn.Id).FirstOrDefault();
                            targetTable = TargetTable.VpnType.ToString();
                            break;
                        case TargetTable.Machine:
                            checkedTargetId = (from machine in entities.Machine where machine.Id == targetId select machine.Id).FirstOrDefault();
                            targetTable = TargetTable.Machine.ToString();
                            break;

                        case TargetTable.Customer:
                            checkedTargetId = (from customer in entities.Customer where customer.Id == targetId select customer.Id).FirstOrDefault();
                            targetTable = TargetTable.Customer.ToString();
                            break;

                    }

                    if (checkedTargetId != 0)
                    {
                        ExtensionObjects eObj = new ExtensionObjects();
                        eObj.Name = name;
                        eObj.Value = value;
                        eObj.IdTargetElement = targetId;
                        eObj.TargetTableName = targetTable;
                        entities.ExtensionObjects.Add(eObj);

                    }

                    retVal = entities.SaveChanges() > 0;

                }
            }



            return retVal;


        }
        public static bool AddExtensionObject(int targetId, int table, string name, string value)
        {
            bool retVal = false;

            if (table != null)
            {

                using (VpnManagerEntities entities = new VpnManagerEntities())
                {

                    var checkedTargetId = 0;
                    var targetTable = string.Empty;

                    switch (table)
                    {
                        case (int)TargetTable.VpnType:
                            checkedTargetId = (from vpn in entities.VpnType where vpn.Id == targetId select vpn.Id).FirstOrDefault();
                            targetTable = TargetTable.VpnType.ToString();
                            break;
                        case (int)TargetTable.Machine:
                            checkedTargetId = (from machine in entities.Machine where machine.Id == targetId select machine.Id).FirstOrDefault();
                            targetTable = TargetTable.Machine.ToString();
                            break;

                        case (int)TargetTable.Customer:
                            checkedTargetId = (from customer in entities.Customer where customer.Id == targetId select customer.Id).FirstOrDefault();
                            targetTable = TargetTable.Customer.ToString();
                            break;

                        case (int)TargetTable.Plant:
                            checkedTargetId = (from plant in entities.Plant where plant.Id == targetId select plant.Id).FirstOrDefault();
                            targetTable = TargetTable.Plant.ToString();
                            break;

                    }

                    if (checkedTargetId != 0)
                    {
                        ExtensionObjects eObj = new ExtensionObjects();
                        eObj.Name = name;
                        eObj.Value = value;
                        eObj.IdTargetElement = targetId;
                        eObj.TargetTableName = targetTable;
                        entities.ExtensionObjects.Add(eObj);

                    }

                    retVal = entities.SaveChanges() > 0;

                }
            }



            return retVal;


        }
        /// <summary>
        /// Delete the extension obj from the passe id (Id of the table Extension objects)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteExtensionObject(int id)
        {

            bool retVal = false;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                ExtensionObjects eobj = (from extObj in entities.ExtensionObjects where extObj.Id == id select extObj).FirstOrDefault();
                if (eobj != null)
                {

                    entities.ExtensionObjects.Remove(eobj);
                    retVal = entities.SaveChanges() > 0;
                }
            }
            return retVal;

        }
        public static bool DeleteExtensionObject(int targetId, TargetTable table, string name)
        {

            bool retVal = false;
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                ExtensionObjects eobj = (from extObj in entities.ExtensionObjects
                                         where extObj.TargetTableName == table.ToString() && extObj.IdTargetElement == targetId && extObj.Name == name
                                         select extObj).FirstOrDefault();
                if (eobj != null)
                {

                    entities.ExtensionObjects.Remove(eobj);
                    retVal = entities.SaveChanges() > 0;
                }
            }
            return retVal;

        }
        public static ExtensionObjectDTO GetExtensionObject(int targetId, TargetTable table, string name)
        {
            ExtensionObjectDTO retVal = null;

            string tabName = table.ToString();
            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                retVal = (from eobj in entities.ExtensionObjects
                          where eobj.IdTargetElement == targetId && eobj.Name == name && eobj.TargetTableName == tabName
                          select new ExtensionObjectDTO
                          {
                              Id = eobj.Id,
                              Name = eobj.Name,
                              Value = eobj.Value,
                              TargetTable = (int)table,

                          }).FirstOrDefault();
            }

            return retVal;

        }

        /// <summary>
        /// Get the extension object from the passed params
        /// </summary>
        /// <param name="targetId"></param>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ExtensionObjectDTO GetExtensionObject(int id)
        {
            ExtensionObjectDTO retVal = null;

                using (VpnManagerEntities entities = new VpnManagerEntities())
                {
                retVal = (from eobj in entities.ExtensionObjects
                          where eobj.Id == id
                          select new ExtensionObjectDTO
                          {
                              Id = eobj.Id,
                              Name = eobj.Name,
                              Value = eobj.Value,
                              TargetTable = GetTargetTable(eobj.TargetTableName),

                          }).FirstOrDefault();
            }

            return retVal;

        }
        /// <summary>
        /// Get the list of extension objects
        /// </summary>
        /// <param name="targetId">Id of the target object (the id field in the target table)</param>
        /// <param name="table"></param>
        /// <returns></returns>
        //public static List<ExtensionObjectDTO> GetExtensionObjects(int targetId,  TargetTable table)
        //{
        //    List<ExtensionObjectDTO> retVal = null;


        //    using (VpnManagerEntities entities = new VpnManagerEntities())
        //    {
        //        string tbName = table.ToString();
        //        retVal = (from eobj in entities.ExtensionObjects
        //                  where eobj.IdTargetElement == targetId && eobj.TargetTableName == tbName
        //                  select new ExtensionObjectDTO
        //                  {
        //                      Id = eobj.Id,
        //                      Name = eobj.Name,
        //                      Value = eobj.Value,
        //                      TargetTable = (int)table, //there may be a problemi in this line, need to be modified to manage an int value instead of enum

        //                  }).ToList();
        //    }

        //    return retVal;

        //}

        public static List<ExtensionObjectDTO> GetExtensionObjects(int targetId, int table)
        {
            List<ExtensionObjectDTO> retVal = null;


            using (VpnManagerEntities entities = new VpnManagerEntities())
            {
                string tbName = string.Empty;
                switch (table)
                {
                    case (int)TargetTable.Plant:
                        tbName = TargetTable.Plant.ToString();
                        break;
                    case (int)TargetTable.Customer:
                        tbName = TargetTable.Customer.ToString();
                        break;
                    case (int)TargetTable.Machine:
                        tbName = TargetTable.Machine.ToString();
                        break;
                    case (int)TargetTable.ConnectionType:
                        tbName = TargetTable.ConnectionType.ToString();
                        break;
                    case (int)TargetTable.VpnType:
                        tbName = TargetTable.VpnType.ToString();
                        break;
                }

                retVal = (from eobj in entities.ExtensionObjects
                          where eobj.IdTargetElement == targetId && eobj.TargetTableName == tbName
                          select new ExtensionObjectDTO
                          {
                              Id = eobj.Id,
                              Name = eobj.Name,
                              Value = eobj.Value,
                              TargetTable = (int)table, //there may be a problemi in this line, need to be modified to manage an int value instead of enum

                          }).ToList();
            }

            return retVal;

        }
        //public static targettable gettargettable(string _targettable)
        //{
        //    targettable table = targettable.notfound;

        //    if (!string.isnullorempty(_targettable))
        //    {

        //        switch (_targettable)
        //        {

        //            case "vpntype":
        //                table = targettable.vpntype;
        //                break;
        //            case "machine":
        //                table = targettable.machine;
        //                break;
        //            case "plant":
        //                table = targettable.plant;
        //                break;
        //            case "customer":
        //                table = targettable.customer;
        //                break;
        //            case "connectiontype":
        //                break;


        //        }

        //    }

        //    return table;

        //}

        public static int GetTargetTable(string _targetTable)
        {
            TargetTable table = TargetTable.NotFound;

            if (!string.IsNullOrEmpty(_targetTable))
            {

                switch (_targetTable)
                {

                    case "VpnType":
                        table = TargetTable.VpnType;
                        break;
                    case "Machine":
                        table = TargetTable.Machine;
                        break;
                    case "Plant":
                        table = TargetTable.Plant;
                        break;
                    case "Customer":
                        table = TargetTable.Customer;
                        break;
                    case "ConnectionType":
                        break;


                }

            }

            return (int)table;

        }


    }



}
