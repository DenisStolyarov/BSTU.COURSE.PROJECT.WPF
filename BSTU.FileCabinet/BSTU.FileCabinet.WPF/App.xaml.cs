using BSTU.FileCabinet.DAL.Infrastructures;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.State.Navigators;
using BSTU.FileCabinet.WPF.ViewModels;
using BSTU.FileCabinet.WPF.ViewModels.Factories;
using BSTU.FileCabinet.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BSTU.FileCabinet.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new AdminMainWindow();
            Window authorization = new AuthorizationWindow();
            IDbContextFactory<FileCabinetContext> dbContextFactory = new FileCabinetDbContextFactory();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContextFactory);
            ISimpleViewModelFactory simpleViewModelFactory = new SimpleViewModelFactory(unitOfWork);
            INavigator navigator = new Navigator(simpleViewModelFactory);
            window.DataContext = new MainViewModel(navigator);
            authorization.Show();

            base.OnStartup(e);  
        }
    }
}
