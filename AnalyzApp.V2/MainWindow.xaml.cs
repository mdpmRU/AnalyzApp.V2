using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfServices;
using WpfServices.Services;
using RepositoriesXml;
using System.Collections.ObjectModel;
using DataContracts.Models;

namespace AnalyzApp.V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationViewModel _viewModel;
        private FileCommand _fileMenuService;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ApplicationViewModel(new ObservableCollection<Analyzer>());
            _fileMenuService = new FileCommand(_viewModel, new FileService());
            DataContext = _viewModel;
            OpenFile.Command = _fileMenuService.OpenCommand;
            SaveFile.Command = _fileMenuService.SaveCommand;
        }
    }
}
