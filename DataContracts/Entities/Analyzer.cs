using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities.Enums;
using Services;

namespace DataContracts.Entities
{
    public class Analyzer : NotifyPropertyChanged
    {
        private string _name;
        private StatusAnalyzer _statusA;
        private string _type;
        private int _measureInterval;
        private List<Channel> _channels;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public StatusAnalyzer StatusA
        {
            get { return _statusA; }
            set
            {
                _statusA = value; OnPropertyChanged("StatusA");
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value; OnPropertyChanged("Type");
            }
        }

        public int MeasureInterval
        {
            get { return _measureInterval; }
            set
            {
                _measureInterval = value; OnPropertyChanged("MeasureInterval");
            }
        }

        public List<Channel> Channels
        {
            get { return _channels; }
            set
            {
                _channels = value;
                OnPropertyChanged("Channels");
            }
        }
    }
}
