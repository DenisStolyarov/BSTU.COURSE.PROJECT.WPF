﻿using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BSTU.FileCabinet.WPF.ViewModels.User
{
    public class UserGroupViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly int groupId = 1;
        public Student SelectedStudent { get; set; }
        public Group SelectedGroup { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public UserGroupViewModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            this.SelectedGroup = unitOfWork.Groups.Get(groupId);
            this.Students = new ObservableCollection<Student>(this.SelectedGroup.Students);
        }

    }
}
