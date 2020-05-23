using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Commands;
using PropertyChanged;

namespace BSTU.FileCabinet.WPF.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AuthorizationViewModel : BaseViewModel
    {
        private readonly IRepository<Authorization, string> repository;
        private readonly IFileRecordService<Authorization> service;

        public AuthorizationViewModel(IRepository<Authorization, string> repository, IFileRecordService<Authorization> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Authorization SelectedValue { get; set; }

        public ObservableCollection<Authorization> Authorizations { get; set; }

        public ICommand Create => new BaseCommand(CreateAuthorization);
        public ICommand Update => new BaseCommand(UpdateAuthorization);
        public ICommand Delete => new BaseCommand(DeleteAuthorization);

        private void CreateAuthorization(object parameter)
        {
            var value = new Authorization()
            {
                Login = SelectedValue.Login,
                Password = SelectedValue.Password,
                Role = SelectedValue.Role,
                UserId = SelectedValue.UserId,
            };

            try
            {
                this.repository.Create(value);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Create", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateAuthorization(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.Login, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteAuthorization(object parameter)
        {
            this.repository.Delete(SelectedValue.Login);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Authorizations = new ObservableCollection<Authorization>(this.repository.GetAll());
        }
    }
}
