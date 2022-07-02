using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models.Enums;
using Services;

namespace DataContracts.Models
{
    public class Channel
    {
        private string _name;
        private StatusChannel _statusC;
        private int? _isHot;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public StatusChannel StatusC
        {
            get { return _statusC; }
            set
            {
                _statusC = value;
            }
        }

        public int? IsHot
        {
            get { return _isHot; }
            set
            {
                _isHot = value;
            }
        }
    }
}
