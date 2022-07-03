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
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        Analyzer selectedAnalyzer;
        Channel selectedChannel;

        public ApplicationViewModel(ObservableCollection<Analyzer> analyzers)
        {
            Analyzers = analyzers;
        }

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
        public Channel SelectedChannel
        {
            get { return selectedChannel; }
            set
            {
                selectedChannel = value;
                OnPropertyChanged("SelectedChannel");
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

        //Кнопки для Channel 
        private RelayCommand addChannel;
        public RelayCommand AddChannel
        {
            get
            {
                return addChannel ??
                  (addChannel = new RelayCommand(obj =>
                  {
                      //Channel channel = obj as Channel;
                      //if (channel != null)
                      //{
                      //    SelectedAnalyzer.Channels.Insert(0, channel);
                      //}
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
                          SelectedAnalyzer.Channels.Remove(SelectedChannel);
                      }
                  },
                 (obj) => SelectedAnalyzer.Channels.Count > 0));
                //return removeChannel ??
                //    (removeChannel = new RelayCommand(obj =>
                //    {
                //        Channel channel = new Channel();
                //        SelectedAnalyzer.Channels.Remove(channel);

                //    }
                //    ));
            }
        }
        //////////////////////////////////////////////////////////
    }
}
