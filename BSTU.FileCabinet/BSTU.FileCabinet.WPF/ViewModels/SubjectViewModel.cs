using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BSTU.FileCabinet.WPF.ViewModels
{
    public class SubjectViewModel : BaseViewModel
    {
        private readonly IRepository<Subject, string> repository;
        private readonly IFileRecordService<Subject> service;

        public SubjectViewModel(IRepository<Subject, string> repository, IFileRecordService<Subject> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
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

        private void UpdateSubject(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.SubjectCode, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
