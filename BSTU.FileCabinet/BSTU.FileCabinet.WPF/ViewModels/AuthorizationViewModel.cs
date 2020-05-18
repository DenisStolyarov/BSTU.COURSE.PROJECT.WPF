using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public AuthorizationViewModel(IRepository<Authorization, string> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
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

            this.repository.Create(value);
            UpdateCollection();
        }

        private void UpdateAuthorization(object parameter)
        {
            this.repository.Update(SelectedValue.Login, SelectedValue);
            UpdateCollection();
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
