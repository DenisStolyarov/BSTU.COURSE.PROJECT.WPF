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
    public class StudentViewModel : BaseViewModel
    {
        private readonly IRepository<Student, int> repository;

        public StudentViewModel(IRepository<Student, int> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Student SelectedValue { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public ICommand Create => new BaseCommand(CreateStudent);
        public ICommand Update => new BaseCommand(UpdateStudent);
        public ICommand Delete => new BaseCommand(DeleteStudent);

        private void CreateStudent(object parameter)
        {
            var value = new Student()
            {
                GroupId = SelectedValue.GroupId,
                FirstName = SelectedValue.FirstName,
                LastName = SelectedValue.LastName,
                Patronymic = SelectedValue.Patronymic,
                PhoneNumber = SelectedValue.PhoneNumber,
                Birthday = SelectedValue.Birthday,
                Foto = SelectedValue.Foto,
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

        private void UpdateStudent(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.StudentId, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteStudent(object parameter)
        {
            this.repository.Delete(SelectedValue.StudentId);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Students = new ObservableCollection<Student>(this.repository.GetAll());
        }
    }
}
