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
    public class TeacherViewModel : BaseViewModel
    {
        private readonly IRepository<Teacher, string> repository;

        public TeacherViewModel(IRepository<Teacher, string> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Teacher SelectedValue { get; set; }

        public ObservableCollection<Teacher> Teachers { get; set; }

        public ICommand Create => new BaseCommand(CreateTeacher);
        public ICommand Update => new BaseCommand(UpdateTeacher);
        public ICommand Delete => new BaseCommand(DeleteTeacher);

        private void CreateTeacher(object parameter)
        {
            var value = new Teacher()
            {
                TeacherCode = SelectedValue.TeacherCode,
                TeacherName = SelectedValue.TeacherName,
                PulpitCode = SelectedValue.PulpitCode,
                Foto = SelectedValue.Foto,
            };

            this.repository.Create(value);
            UpdateCollection();
        }

        private void UpdateTeacher(object parameter)
        {
            this.repository.Update(SelectedValue.TeacherCode, SelectedValue);
            UpdateCollection();
        }

        private void DeleteTeacher(object parameter)
        {
            this.repository.Delete(SelectedValue.TeacherCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Teachers = new ObservableCollection<Teacher>(this.repository.GetAll());
        }
    }
}
