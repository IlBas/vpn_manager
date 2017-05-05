using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VpnManagerDAL.DTO
{
    public class MachineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdPreferredConnectionType { get; set; }
        public bool PingResponseEnabled { get; set; }
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastSuccessfullConnection { get; set; }
        public int IdLastConnectedUser { get; set; }
        public int IdPlant { get; set; }
        private IEnumerable<ExtensionObjectDTO> extCollection;
        internal IEnumerable<ExtensionObjectDTO> ExtensionCollection
        {
            get;
            set;
        }
        /// <summary>
        /// Extensions added to the class, available by the string key
        /// </summary>
        public IDictionary<string, string> Extensions
        {
            get
            {
                Dictionary<string, string> res = new Dictionary<string, string>();
                foreach (ExtensionObjectDTO eo in ExtensionCollection) res.Add(eo.Name.ToLower(), eo.Value);
                return res;

            }
        }
        public MachineDTO()
        {

        }


    }
}
