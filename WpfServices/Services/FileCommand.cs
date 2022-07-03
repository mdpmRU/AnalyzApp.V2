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
        IDialogService dialogService;
        ApplicationViewModel viewModel;
        public FileCommand(ApplicationViewModel _viewModel, IFileService fileService)
        {
            viewModel = _viewModel;
            analyzerService = new AnalyzerService(fileService);
            dialogService = new DialogService();
        }
        // команда открытия файла
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
                              var analysers = analyzerService.Open(dialogService.FilePath);
                              //Добавить инвок
                              viewModel.ClearAnalyzers();
                              foreach (var p in analysers)
                                  viewModel.AddAnalyzers(p);
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
        // команда сохранения файла

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
                              analyzerService.Save(dialogService.FilePath, viewModel.Analyzers.ToList());
                              //dialogService.ShowMessage("Файл сохранен");
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
