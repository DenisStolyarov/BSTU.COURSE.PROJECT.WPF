using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Commands;
using Microsoft.Win32;
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
    public class FacultyViewModel : BaseViewModel
    {
        private readonly IRepository<Faculty, string> repository;
        private readonly IFileRecordService<Faculty> service;

        public FacultyViewModel(IRepository<Faculty, string> repository, IFileRecordService<Faculty> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Faculty SelectedValue { get; set; }

        public ObservableCollection<Faculty> Faculties { get; set; }

        public ICommand Create => new BaseCommand(CreateFaculty);
        public ICommand Update => new BaseCommand(UpdateFaculty);
        public ICommand Delete => new BaseCommand(DeleteFaculty);
        public ICommand Export => new BaseCommand(ExportRecords);
        public ICommand Import => new BaseCommand(ImportRecords);

        private void CreateFaculty(object parameter)
        {
            if (this.SelectedValue is null) return;
            var value = new Faculty()
            {
               FacultyCode = SelectedValue.FacultyCode,
               FacultyName = SelectedValue.FacultyName,
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

        private void UpdateFaculty(object parameter)
        {
            if (this.SelectedValue is null) return;
            try
            {
                this.repository.Update(SelectedValue.FacultyCode, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteFaculty(object parameter)
        {
            if (this.SelectedValue is null) return;
            this.repository.Delete(SelectedValue.FacultyCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Faculties = new ObservableCollection<Faculty>(this.repository.GetAll());
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

        private int FillRecord(IEnumerable<Faculty> records)
        {
            var count = 0;
            foreach (var record in records)
            {
                try
                {
                    if (this.repository.Get(record.FacultyCode) is null)
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
