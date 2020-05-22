using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.BLL.Services.Exceptions;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.WPF.Windows.Factories;
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
using System.Windows.Shapes;

namespace BSTU.FileCabinet.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private readonly IAuthorizationService service;
        private readonly IUnitOfWork unitOfWork;
        public AuthorizationWindow(IAuthorizationService service, IUnitOfWork unitOfWork)
        {
            this.service = service ?? throw new NullReferenceException(nameof(service));
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            InitializeComponent();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            var login = this.Login.Text;
            var password = this.Password.Password;
            try
            {
                var windowType = this.service.GetWindowType(login, password, out var userId);
                var windowFactory = new SimpleWindowFactory(unitOfWork, userId);
                var window = windowFactory.CreateWindow(windowType);
                window.Show();
                this.Close();
            }
            catch (WrongAuthorizationParameterException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
