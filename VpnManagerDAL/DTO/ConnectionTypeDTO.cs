using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VpnManagerDAL.DTO
{
    public class ConnectionTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
                foreach (ExtensionObjectDTO eo in ExtensionCollection) res.Add(eo.Name.ToLower(), eo.Value);
                return res;

            }
        }


        public ConnectionTypeDTO()
        {

        }
    }
}
