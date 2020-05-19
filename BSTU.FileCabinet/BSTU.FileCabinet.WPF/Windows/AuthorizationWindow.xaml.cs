using BSTU.FileCabinet.DAL.Interfaces;
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
        private readonly Window window;
        private readonly IUnitOfWork unitOfWork;

        public AuthorizationWindow(Window window, IUnitOfWork unitOfWork)
        {
            this.window = window ?? throw new NullReferenceException();
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();

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
            var user = this.unitOfWork.Authorizations.Get(login);

            if (user is null)
            {
                MessageBox.Show("No user!");
            }

            if (!user.Password.Equals(password))
            {
                MessageBox.Show("Wrong user or password!");
            }

            this.window.Show();
            this.Close();
        }
    }
}
