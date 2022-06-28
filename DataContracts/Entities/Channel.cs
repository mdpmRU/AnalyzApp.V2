using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities.Enums;

namespace DataContracts.Entities
{
    public class Channel
    {
        public string Name { get; set; }

        public StatusChannel StatusC { get; set; }

        public int IsHot { get; set; }
    }
}
