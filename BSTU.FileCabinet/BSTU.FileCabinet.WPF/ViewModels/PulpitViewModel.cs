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

        private void CreatePulpit(object parameter)
        {
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
            this.repository.Delete(SelectedValue.PulpitCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Pulpits = new ObservableCollection<Pulpit>(this.repository.GetAll());
        }
    }
}
