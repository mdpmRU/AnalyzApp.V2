using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Business;
using DataContracts.Models;
using Business.Services;
using WpfServices.Services;
using System.Collections.ObjectModel;

namespace WpfServices
{
    public class ApplicationViewModel : CollectionCommand
    {
        Channel selectedChannel;
        private CollectionCommand _collectionCommand;

        public ApplicationViewModel(ObservableCollection<Analyzer> analyzers)
        {
            Analyzers = analyzers;
        }
        public Channel SelectedChannel
        {
            get { return selectedChannel; }
            set
            {
                selectedChannel = value;
                OnPropertyChanged("SelectedChannel");
            }
        }
    }
}
