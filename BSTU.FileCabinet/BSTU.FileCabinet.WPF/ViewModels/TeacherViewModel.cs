using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Commands;
using BSTU.FileCabinet.WPF.Converters;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
        public BitmapImage SelectedImage
        {
            get
            {
                return ImageConverter.LoadImage(SelectedValue?.Foto);
            }
        }

        public ObservableCollection<Teacher> Teachers { get; set; }

        public ICommand Create => new BaseCommand(CreateTeacher);
        public ICommand Update => new BaseCommand(UpdateTeacher);
        public ICommand Delete => new BaseCommand(DeleteTeacher);
        public ICommand Browse => new BaseCommand(SelectImage);

        private void CreateTeacher(object parameter)
        {
            var value = new Teacher()
            {
                TeacherCode = SelectedValue.TeacherCode,
                TeacherName = SelectedValue.TeacherName,
                PulpitCode = SelectedValue.PulpitCode,
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

        private void UpdateTeacher(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.TeacherCode, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void SelectImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                var array = ImageConverter.ImageToByteArrayFromFilePath(path);
                this.SelectedValue.Foto = new byte[array.Length];
                Array.Copy(array, SelectedValue.Foto, array.Length);
                this.repository.Update(this.SelectedValue.TeacherCode, this.SelectedValue);
            }
            UpdateCollection();
        }
    }
}
