using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VpnManagerDAL.DTO
{


    public class ExtensionObjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        //public TargetTable TargetTable { get; set; }
        public int TargetTable { get; set; }
        public int TargetId { get; set; }


        public ExtensionObjectDTO()
        {

        }

        public override string ToString()
        {
            return Name + " - " + Value;
        }
    }

    public enum TargetTable { NotFound = 0, Machine = 1, Plant = 2, VpnType = 3, Customer = 4, ConnectionType = 5, User = 6 };

}
