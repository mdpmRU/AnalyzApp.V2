using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Business;
using DataContracts.Entities;
using Business.Services;
using Contracts;
using AnalyzApp.V2.Service;

namespace AnalyzApp.V2.ViewModels
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;

        private Analyzer selectedAnalyzer;
        private Channel selectedChannel;
        public AnalyzerService analyzerService = new();
        public Item selectedItem;

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Analyzers = analyzerService.CheckStatus(Stub.Analyzers);
        }

        public struct Item
        {
            public Analyzer selectedAnalyzer;
            public Channel selectedChannel;
        }

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

        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var analysers = fileService.Open(dialogService.FilePath);
                              Analyzers.Clear();
                              foreach (var p in analysers)
                                  Analyzers.Add(p);
                              //dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Analyzers);
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
    }
}
