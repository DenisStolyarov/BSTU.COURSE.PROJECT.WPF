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
    public class SubjectViewModel : BaseViewModel
    {
        private readonly IRepository<Subject, string> repository;

        public SubjectViewModel(IRepository<Subject, string> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Subject SelectedValue { get; set; }

        public ObservableCollection<Subject> Subjects { get; set; }

        public ICommand Create => new BaseCommand(CreateSubject);
        public ICommand Update => new BaseCommand(UpdateSubject);
        public ICommand Delete => new BaseCommand(DeleteSubject);

        private void CreateSubject(object parameter)
        {
            var value = new Subject()
            {
                SubjectCode = SelectedValue.SubjectCode,
                SubjectName = SelectedValue.SubjectName,
                PulpitCode = SelectedValue.PulpitCode,
            };

            this.repository.Create(value);
            UpdateCollection();
        }

        private void UpdateSubject(object parameter)
        {
            this.repository.Update(SelectedValue.SubjectCode, SelectedValue);
            UpdateCollection();
        }

        private void DeleteSubject(object parameter)
        {
            this.repository.Delete(SelectedValue.SubjectCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Subjects = new ObservableCollection<Subject>(this.repository.GetAll());
        }
    }
}
