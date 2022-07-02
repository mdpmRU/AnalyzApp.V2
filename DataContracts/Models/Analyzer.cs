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
        private string _name;
        private StatusAnalyzer _statusA;
        private string _type;
        private int _measureInterval;
        private ObservableCollection<Channel> _channels;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public StatusAnalyzer StatusA
        {
            get { return _statusA; }
            set
            {
                _statusA = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public int MeasureInterval
        {
            get { return _measureInterval; }
            set
            {
                _measureInterval = value;
            }
        }

        public ObservableCollection<Channel> Channels
        {
            get { return _channels; }
            set
            {
                _channels = value;
            }
        }
    }
}
