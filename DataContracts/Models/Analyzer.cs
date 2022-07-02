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
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //    }
        //}

        public StatusAnalyzer StatusA { get; set; }
        //{
        //    get { return _statusA; }
        //    set
        //    {
        //        _statusA = value;
        //    }
        //}

        public string Type { get; set; }
        //{
        //    get { return _type; }
        //    set
        //    {
        //        _type = value;
        //    }
        //}

        public int MeasureInterval { get; set; }
        //{
        //    get { return _measureInterval; }
        //    set
        //    {
        //        _measureInterval = value;
        //    }
        //}

        public ObservableCollection<Channel> Channels { get; set; }
        //{
        //    get { return _channels; }
        //    set
        //    {
        //        _channels = value;
        //    }
        //}
    }
}
