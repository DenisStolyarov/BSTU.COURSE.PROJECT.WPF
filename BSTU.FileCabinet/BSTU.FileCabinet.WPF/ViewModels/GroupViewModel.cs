﻿using BSTU.FileCabinet.BLL.Interfaces;
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
    class GroupViewModel : BaseViewModel
    {
        private readonly IRepository<Group, int> repository;
        private readonly IFileRecordService<Group> service;

        public GroupViewModel(IRepository<Group, int> repository, IFileRecordService<Group> service)
        {
            this.repository = repository ?? throw new NullReferenceException();
            this.service = service ?? throw new NullReferenceException();
            UpdateCollection();
        }

        public Group SelectedValue { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public ICommand Create => new BaseCommand(CreateGroup);
        public ICommand Update => new BaseCommand(UpdateGroup);
        public ICommand Delete => new BaseCommand(DeleteGroup);

        private void CreateGroup(object parameter)
        {
            var value = new Group()
            {
                Course = SelectedValue.Course,
                FacultyCode = SelectedValue.FacultyCode,
                GroupNumber = SelectedValue.GroupNumber,
                SpecialtyCode = SelectedValue.SpecialtyCode,
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

        private void UpdateGroup(object parameter)
        {
            try
            {
                this.repository.Update(SelectedValue.GroupId, SelectedValue);
                UpdateCollection();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong instance key parameter!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteGroup(object parameter)
        {
            this.repository.Delete(SelectedValue.GroupId);
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            this.Groups = new ObservableCollection<Group>(this.repository.GetAll());
        }
    }
}
