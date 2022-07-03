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
        private AnalyzerService _analyzerService;
        private IDialogService _dialogService;
        private ApplicationViewModel _viewModel;
        public FileCommand(ApplicationViewModel viewModel, IFileService fileService)
        {
            _viewModel = viewModel;
            _analyzerService = new AnalyzerService(fileService);
            _dialogService = new DialogService();
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
                          if (_dialogService.OpenFileDialog() == true)
                          {
                              var analysers = _analyzerService.Open(_dialogService.FilePath);
                              _viewModel.ClearAnalyzers();
                              foreach (var p in analysers)
                                  _viewModel.AddAnalyzers(p);
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
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
                          if (_dialogService.SaveFileDialog() == true)
                          {
                              _analyzerService.Save(_dialogService.FilePath, _viewModel.Analyzers.ToList());
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
    }
}
