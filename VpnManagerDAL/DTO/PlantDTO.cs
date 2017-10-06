using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VpnManagerDAL.DTO
{
    public class PlantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdConnectionType { get; set; }
        public string ServerAddress { get; set; }
        public string DisplayedName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastSuccessfullConnection { get; set; }
        public int IdLastConnectedUser { get; set; }
        public List<string> WorkOnMachines  { get; set; }
    internal IEnumerable<ExtensionObjectDTO> ExtensionCollection
        {
            get;
            set;
        }
        public IDictionary<string, string> Extensions
        {
            get
            {
                Dictionary<string, string> res = new Dictionary<string, string>();
                foreach (ExtensionObjectDTO eo in ExtensionCollection) 
                    if (!res.Keys.Contains(eo.Name.ToLower())) res.Add(eo.Name.ToLower(), eo.Value);
                return res;

            }
        }

        public IEnumerable<MachineDTO> Machines { get; set; }

        public PlantDTO()
        {

        }

        public MachineDTO GetMachineById(int machineId)
        {
            return Machines != null ? Machines.Where(x => x.Id == machineId).FirstOrDefault() : null;

        }


    }
}
