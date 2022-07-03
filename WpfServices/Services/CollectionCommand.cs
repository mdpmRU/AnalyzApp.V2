using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models;
using Services;

namespace WpfServices.Services
{
    public class CollectionCommand : NotifyPropertyChanged
    {
        private Analyzer selectedAnalyzer;
        public ObservableCollection<Analyzer> Analyzers { get; set; }

        public Analyzer SelectedAnalyzer
        {
            get { return selectedAnalyzer; }
            set
            {
                selectedAnalyzer = value;
                OnPropertyChanged("SelectedAnalyzer");
            }
        }

        private RelayCommand addAnalyzer;
        public RelayCommand AddAnalyzer
        {
            get
            {
                return addAnalyzer ??
                  (addAnalyzer = new RelayCommand(obj =>
                  {
                      Analyzer analyzer = new Analyzer();
                      analyzer.Channels = new ObservableCollection<Channel>();
                      Analyzers.Insert(0, analyzer);
                      SelectedAnalyzer = analyzer;
                  }));
            }
        }
        private RelayCommand removeAnalyzer;
        public RelayCommand RemoveAnalyzer
        {
            get
            {
                return removeAnalyzer ??
                  (removeAnalyzer = new RelayCommand(obj =>
                  {
                      Analyzer analyzer = obj as Analyzer;
                      if (analyzer != null)
                      {
                          Analyzers.Remove(analyzer);
                      }
                  },
                 (obj) => Analyzers.Count > 0));
            }
        }

        public void ClearAnalyzers()
        {
            Analyzers.Clear();
        }
        public void AddAnalyzers(Analyzer analyzer)
        {
            Analyzers.Add(analyzer);
        }

        private RelayCommand addChannel;
        public RelayCommand AddChannel
        {
            get
            {
                return addChannel ??
                       (addChannel = new RelayCommand(obj =>
                           {
                               Channel channel = new Channel();
                               SelectedAnalyzer.Channels.Insert(0, channel);
                           }
                       ));
            }
        }

        private RelayCommand removeChannel;
        public RelayCommand RemoveChannel
        {
            get
            {
                if (SelectedAnalyzer == null) return null;
                return removeChannel ??
                    (removeChannel = new RelayCommand(obj =>
                           {
                               Channel channel = obj as Channel;
                               if (channel != null)
                               {
                                   SelectedAnalyzer.Channels.Remove(SelectedAnalyzer.SelectedChannel);
                               }
                           },
                           (obj) => SelectedAnalyzer.Channels.Count > 0));
            }
        }
    }
}
