using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using DataContracts.Models;
using WpfServices.Services;
using System.Collections.ObjectModel;

namespace WpfServices
{
    public class ApplicationViewModel : CollectionCommand
    {
        public ApplicationViewModel(ObservableCollection<Analyzer> analyzers)
        {
            Analyzers = analyzers;
        }
    }
}
