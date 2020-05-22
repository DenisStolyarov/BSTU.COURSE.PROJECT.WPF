using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.DAL.Infrastructures;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.State.Navigators;
using BSTU.FileCabinet.WPF.ViewModels;
using BSTU.FileCabinet.WPF.ViewModels.Factories;
using BSTU.FileCabinet.WPF.ViewModels.User;
using System;
using System.Windows;

namespace BSTU.FileCabinet.WPF.Windows.Factories
{
    public class SimpleWindowFactory : ISimpleWindowFactory
    {
        private readonly int? userId;
        private readonly IUnitOfWork unitOfWork;

        public SimpleWindowFactory(IUnitOfWork unitOfWork, int? userId)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            this.userId = userId;
        }

        public Window CreateWindow(WindowType type)
        {
            switch (type)
            {
                case WindowType.Admin:
                    return CreateAdminWindow();
                case WindowType.User:
                    return CreateUserWindow();
                default:
                    throw new ArgumentException();
            }
        }

        private Window CreateAdminWindow()
        {
            ISimpleViewModelFactory simpleViewModelFactory = new AdminSimpleViewModelFactory(unitOfWork);
            INavigator navigator = new Navigator(simpleViewModelFactory);
            Window window = new AdminMainWindow
            {
                DataContext = new AdminMainViewModel(navigator)
            };
            return window;
        }

        private Window CreateUserWindow()
        {
            IDbContextFactory<FileCabinetContext> dbContextFactory = new FileCabinetDbContextFactory();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContextFactory);
            ISimpleViewModelFactory simpleViewModelFactory = new UserSimpleViewModelFactory(unitOfWork, userId);
            INavigator navigator = new Navigator(simpleViewModelFactory);
            Window window = new UserMainWindow
            {
                DataContext = new UserMainViewModel(navigator)
            };
            return window;
        }
    }
}
