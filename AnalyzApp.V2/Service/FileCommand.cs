using AnalyzApp.V2.ViewModels;
using Contracts;
using RepositoriesXml;
using System;
using System.Linq;

namespace AnalyzApp.V2.Service
{
    public class FileCommand
    {
        IFileService fileService;
        IDialogService dialogService;
        ApplicationViewModel viewModel;
        public FileCommand(ApplicationViewModel _viewModel)
        {
            viewModel = _viewModel;
            fileService = new FileService();
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
                              var analysers = fileService.Open(dialogService.FilePath);
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
                              fileService.Save(dialogService.FilePath, viewModel.Analyzers.ToList());
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
