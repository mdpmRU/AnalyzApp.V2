using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities.Enums;

namespace DataContracts.Entities
{
    public class Analyzer
    {
        public string Name { get; set; }

        public StatusAnalyzer StatusA { get; set; }

        public string Type { get; set; }

        public int MeasureInterval { get; set; }
        
        public List<Channel> Channels { get; set; }
    }
}
