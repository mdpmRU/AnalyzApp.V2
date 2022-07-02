﻿using System;
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
using AnalyzApp.V2.ViewModels;
using AnalyzApp.V2.Service;
using RepositoriesXml;

namespace AnalyzApp.V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationViewModel viewModel;
        FileMenuService fileMenuService;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel();
            fileMenuService = new FileMenuService(viewModel);
            DataContext = viewModel;
            OpenFile.Command = fileMenuService.OpenCommand;
            SaveFile.Command = fileMenuService.SaveCommand;
        }
    }
}
