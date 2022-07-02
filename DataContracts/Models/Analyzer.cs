using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models.Enums;
using Services;
using System.Collections.ObjectModel;

namespace DataContracts.Models
{
    public class Analyzer
    {
        public string Name { get; set; }

        public StatusAnalyzer StatusA { get; set; }

        public string Type { get; set; }

        public int MeasureInterval { get; set; }

        public ObservableCollection<Channel> Channels { get; set; }
    }
}
