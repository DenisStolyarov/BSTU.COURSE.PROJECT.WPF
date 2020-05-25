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
        public ICommand Export => new BaseCommand(ExportRecords);
        public ICommand Import => new BaseCommand(ImportRecords);

        private void CreateSubject(object parameter)
        {
            if (this.SelectedValue is null) return;
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
            if (this.SelectedValue is null) return;
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
            if (this.SelectedValue is null) return;
            this.repository.Delete(SelectedValue.SubjectCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Subjects = new ObservableCollection<Subject>(this.repository.GetAll());
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

        private int FillRecord(IEnumerable<Subject> records)
        {
            var count = 0;
            foreach (var record in records)
            {
                try
                {
                    if (this.repository.Get(record.SubjectCode) is null)
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
