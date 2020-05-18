using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BSTU.FileCabinet.WPF.ViewModels
{
    class GroupViewModel : BaseViewModel
    {
        private readonly IRepository<Group, int> repository;

        public GroupViewModel(IRepository<Group, int> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Group SelectedValue { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public ICommand Create => new BaseCommand(CreateGroup);
        public ICommand Update => new BaseCommand(UpdateGroup);
        public ICommand Delete => new BaseCommand(DeleteGroup);

        private void CreateGroup(object parameter)
        {
            var value = new Group()
            {
                Course = SelectedValue.Course,
                FacultyCode = SelectedValue.FacultyCode,
                GroupNumber = SelectedValue.GroupNumber,
                SpecialtyCode = SelectedValue.SpecialtyCode,
            };

            this.repository.Create(value);
            UpdateCollection();
        }

        private void UpdateGroup(object parameter)
        {
            this.repository.Update(SelectedValue.GroupId, SelectedValue);
            UpdateCollection();
        }

        private void DeleteGroup(object parameter)
        {
            this.repository.Delete(SelectedValue.GroupId);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Groups = new ObservableCollection<Group>(this.repository.GetAll());
        }
    }
}
