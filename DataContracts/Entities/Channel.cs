using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities.Enums;
using Services;

namespace DataContracts.Entities
{
    public class Channel : NotifyPropertyChanged
    {
        private string _name;
        private StatusChannel _statusC;
        private int _isHot;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public StatusChannel StatusC
        {
            get { return _statusC; }
            set
            {
                _statusC = value; OnPropertyChanged("StatusC");
            }
        }

        public int IsHot
        {
            get { return _isHot; }
            set
            {
                _isHot = value;
                OnPropertyChanged("IsHot");
            }
        }
    }
}
