using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Business;
using DataContracts.Entities;

namespace AnalyzApp.V2.ViewModels
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        public struct Item //определил тип
        {
            public Analyzer selectedAnalyzer;
            public Channel selectedChannel;
        }

        Analyzer selectedAnalyzer;
        Channel selectedChannel;
        public Item selectedItem;
        public List<Analyzer> Analyzers { get; set; }

        public Analyzer SelectedAnalyzer
        {
            get { return selectedAnalyzer; }
            set
            {
                selectedAnalyzer = value;
                selectedItem.selectedAnalyzer = value;
                OnPropertyChanged("SelectedAnalyzer");
            }
        }

        public Channel SelectedChannel
        {
            get { return selectedChannel; }
            set
            {
                selectedChannel = value;
                selectedItem.selectedChannel = value;
                OnPropertyChanged("SelectedChannel");
            }
        }
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public ApplicationViewModel()
        {
            Analyzers = Business.Stub.Analyzers;
        }
    }
}
