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
        ApplicationViewModel viewModel;
        FileCommand fileMenuService;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel(new ObservableCollection<Analyzer>());
            fileMenuService = new FileCommand(viewModel);
            DataContext = viewModel;
            OpenFile.Command = fileMenuService.OpenCommand;
            SaveFile.Command = fileMenuService.SaveCommand;
        }
    }
}
