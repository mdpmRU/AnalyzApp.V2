using AnalyzApp.V2.ViewModels;
using Contracts;
using RepositoriesXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzApp.V2.Service
{
    public class FileMenuService
    {
        IFileService fileService;
        IDialogService dialogService;
        ApplicationViewModel viewModel;
        public FileMenuService(ApplicationViewModel _viewModel)
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
