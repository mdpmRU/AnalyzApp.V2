using WpfServices;
using Contracts;
using RepositoriesXml;
using System;
using System.Linq;
using Business.Services;
using DataContracts.Models;

namespace WpfServices.Services
{
    public class FileCommand
    {
        private AnalyzerService analyzerService;
        private IDialogService dialogService;
        private ApplicationViewModel viewModel;
        public FileCommand(ApplicationViewModel _viewModel, IFileService fileService)
        {
            viewModel = _viewModel;
            analyzerService = new AnalyzerService(fileService);
            dialogService = new DialogService();
        }
        // команда открытия файла
        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                  (_openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var analysers = analyzerService.Open(dialogService.FilePath);
                              viewModel.ClearAnalyzers();
                              foreach (var p in analysers)
                                  viewModel.AddAnalyzers(p);
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                  (_saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              analyzerService.Save(dialogService.FilePath, viewModel.Analyzers.ToList());
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
