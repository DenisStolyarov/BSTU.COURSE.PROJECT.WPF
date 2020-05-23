using BSTU.FileCabinet.BLL.Interfaces;
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
    public class StudentViewModel : BaseViewModel
    {
        private readonly IRepository<Student, int> repository;
        private readonly IFileRecordService<Student> service;

        public StudentViewModel(IRepository<Student, int> repository, IFileRecordService<Student> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Student SelectedValue { get; set; }
        public BitmapImage SelectedImage 
        { 
            get 
            {
                return ImageConverter.LoadImage(SelectedValue?.Foto);
            } 
        }

        public ObservableCollection<Student> Students { get; set; }

        public ICommand Create => new BaseCommand(CreateStudent);
        public ICommand Update => new BaseCommand(UpdateStudent);
        public ICommand Delete => new BaseCommand(DeleteStudent);
        public ICommand Browse => new BaseCommand(SelectImage);
        public ICommand Export => new BaseCommand(ExportRecords);
        public ICommand Import => new BaseCommand(ImportRecords);

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

        private void SelectImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                var array = ImageConverter.ImageToByteArrayFromFilePath(path);
                this.SelectedValue.Foto = new byte[array.Length];
                Array.Copy(array, SelectedValue.Foto, array.Length);
                this.repository.Update(this.SelectedValue.StudentId, this.SelectedValue);
            }
            UpdateCollection();
        }

        private void ExportRecords(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var path = openFileDialog.FileName;
                    this.service.ExportRecords(this.repository.GetAll(), path);
                    MessageBox.Show($"Record(s) were exported to {path}.", "File", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong file format!", "File", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ImportRecords(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var path = openFileDialog.FileName;
                    var records = this.service.ImportRecords(path);
                    var count = FillRecord(records);
                    MessageBox.Show($"{count} record(s) were imported.", "File", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong file format!", "File", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            UpdateCollection();
        }

        private int FillRecord(IEnumerable<Student> records)
        {
            var count = 0;
            foreach (var record in records)
            {
                try
                {
                    if (this.repository.Get(record.StudentId) is null)
                    {
                        this.repository.Create(record);
                        count++;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return count;
        }
    }
}
