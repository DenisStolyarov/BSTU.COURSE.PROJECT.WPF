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
    class PulpitViewModel : BaseViewModel
    {
        private readonly IRepository<Pulpit, string> repository;
        private readonly IFileRecordService<Pulpit> service;

        public PulpitViewModel(IRepository<Pulpit, string> repository, IFileRecordService<Pulpit> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Pulpit SelectedValue { get; set; }

        public ObservableCollection<Pulpit> Pulpits { get; set; }

        public ICommand Create => new BaseCommand(CreatePulpit);
        public ICommand Update => new BaseCommand(UpdatePulpit);
        public ICommand Delete => new BaseCommand(DeletePulpit);
        public ICommand Export => new BaseCommand(ExportRecords);
        public ICommand Import => new BaseCommand(ImportRecords);

        private void CreatePulpit(object parameter)
        {
            if (this.SelectedValue is null) return;
            var value = new Pulpit()
            {
                PulpitCode = SelectedValue.PulpitCode,
                PulpitName = SelectedValue.PulpitName,
                FacultyCode = SelectedValue.FacultyCode,
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

        private void UpdatePulpit(object parameter)
        {
            if (this.SelectedValue is null) return;
            try
            {
                this.repository.Update(SelectedValue.PulpitCode, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePulpit(object parameter)
        {
            if (this.SelectedValue is null) return;
            this.repository.Delete(SelectedValue.PulpitCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Pulpits = new ObservableCollection<Pulpit>(this.repository.GetAll());
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

        private int FillRecord(IEnumerable<Pulpit> records)
        {
            var count = 0;
            foreach (var record in records)
            {
                try
                {
                    if (this.repository.Get(record.PulpitCode) is null)
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
