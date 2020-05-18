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
    public class FacultyViewModel : BaseViewModel
    {
        private readonly IRepository<Faculty, string> repository;

        public FacultyViewModel(IRepository<Faculty, string> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Faculty SelectedValue { get; set; }

        public ObservableCollection<Faculty> Faculties { get; set; }

        public ICommand Create => new BaseCommand(CreateFaculty);
        public ICommand Update => new BaseCommand(UpdateFaculty);
        public ICommand Delete => new BaseCommand(DeleteFaculty);

        private void CreateFaculty(object parameter)
        {
            var value = new Faculty()
            {
               FacultyCode = SelectedValue.FacultyCode,
               FacultyName = SelectedValue.FacultyName,
            };

            this.repository.Create(value);
            UpdateCollection();
        }

        private void UpdateFaculty(object parameter)
        {
            this.repository.Update(SelectedValue.FacultyCode, SelectedValue);
            UpdateCollection();
        }

        private void DeleteFaculty(object parameter)
        {
            this.repository.Delete(SelectedValue.FacultyCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Faculties = new ObservableCollection<Faculty>(this.repository.GetAll());
        }
    }
}
