using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.BLL.Services;
using BSTU.FileCabinet.DAL.Infrastructures;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.State.Navigators;
using BSTU.FileCabinet.WPF.ViewModels;
using BSTU.FileCabinet.WPF.ViewModels.Factories;
using BSTU.FileCabinet.WPF.ViewModels.User;
using BSTU.FileCabinet.WPF.Windows;
using BSTU.FileCabinet.WPF.Windows.Factories;
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
            IDbContextFactory<FileCabinetContext> dbContextFactory = new FileCabinetDbContextFactory();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContextFactory);
            //IAuthorizationService service = new AuthorizationService(unitOfWork);
            //Window authorization = new AuthorizationWindow(service, unitOfWork);
            //authorization.Show();
            var windowFactory = new SimpleWindowFactory(unitOfWork, 87);
            var window = windowFactory.CreateWindow(WindowType.Admin);
            window.Show();
            base.OnStartup(e);  
        }
    }
}
