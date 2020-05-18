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
    public class SpecialtyViewModel : BaseViewModel
    {
        private readonly IRepository<Specialty, string> repository;

        public SpecialtyViewModel(IRepository<Specialty, string> repository)
        {
            this.repository = repository ?? throw new NullReferenceException();
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

            this.repository.Create(value);
            UpdateCollection();
        }

        private void UpdateSpecialty(object parameter)
        {
            this.repository.Update(SelectedValue.SpecialtyCode, SelectedValue);
            UpdateCollection();
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
