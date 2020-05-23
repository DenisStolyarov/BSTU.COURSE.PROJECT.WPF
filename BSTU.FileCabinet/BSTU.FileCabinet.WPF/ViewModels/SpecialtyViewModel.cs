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
    public class SpecialtyViewModel : BaseViewModel
    {
        private readonly IRepository<Specialty, string> repository;
        private readonly IFileRecordService<Specialty> service;

        public SpecialtyViewModel(IRepository<Specialty, string> repository, IFileRecordService<Specialty> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Specialty SelectedValue { get; set; }

        public ObservableCollection<Specialty> Specialties { get; set; }

        public ICommand Create => new BaseCommand(CreateSpecialty);
        public ICommand Update => new BaseCommand(UpdateSpecialty);
        public ICommand Delete => new BaseCommand(DeleteSpecialty);

        private void CreateSpecialty(object parameter)
        {
            var value = new Specialty()
            {
                SpecialtyCode = SelectedValue.SpecialtyCode,
                SpecialtyName = SelectedValue.SpecialtyName,
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

        private void UpdateSpecialty(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.SpecialtyCode, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteSpecialty(object parameter)
        {
            this.repository.Delete(SelectedValue.SpecialtyCode);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Specialties = new ObservableCollection<Specialty>(this.repository.GetAll());
        }
    }
}
