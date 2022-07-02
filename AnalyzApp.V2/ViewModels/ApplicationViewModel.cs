﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Business;
using DataContracts.Models;
using Business.Services;
using AnalyzApp.V2.Service;
using System.Collections.ObjectModel;

namespace AnalyzApp.V2.ViewModels
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        Analyzer selectedAnalyzer;

        public ApplicationViewModel()
        {
            Analyzers = new ObservableCollection<Analyzer>();
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

    }
}
