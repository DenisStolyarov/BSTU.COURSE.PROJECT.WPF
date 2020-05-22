using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories.Common;
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
    class TeacherSubjectViewModel : BaseViewModel
    {
        private readonly TeacherSubjectRepository repository;

        public TeacherSubjectViewModel(TeacherSubjectRepository repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public TeacherSubject SelectedValue { get; set; }

        public ObservableCollection<TeacherSubject> TeacherSubjects { get; set; }

        public ICommand Create => new BaseCommand(CreateTeacherSubject);
        public ICommand Update => new BaseCommand(UpdateTeacherSubject);
        public ICommand Delete => new BaseCommand(DeleteTeacherSubject);

        private void CreateTeacherSubject(object parameter)
        {
            var value = new TeacherSubject()
            {
                TeacherCode = SelectedValue.TeacherCode,
                SubjectCode = SelectedValue.SubjectCode,
                Course = SelectedValue.Course,
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

        private void UpdateTeacherSubject(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.TeacherCode, SelectedValue.SubjectCode, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTeacherSubject(object parameter)
        {
            this.repository.Delete(SelectedValue.TeacherCode, SelectedValue.SubjectCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.TeacherSubjects = new ObservableCollection<TeacherSubject>(this.repository.GetAll());
        }
    }
}
