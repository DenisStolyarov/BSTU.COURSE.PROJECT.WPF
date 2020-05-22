using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BSTU.FileCabinet.WPF.Converters;
using System.Windows.Media.Imaging;

namespace BSTU.FileCabinet.WPF.ViewModels.User
{
    public class UserGroupViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        public Student SelectedStudent { get; set; }
        public BitmapImage SelectedImage
        {
            get
            {
                return ImageConverter.LoadImage(SelectedStudent?.Foto);
            }
        }
        public Group SelectedGroup { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public UserGroupViewModel(IUnitOfWork unitOfWork, int userId)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            var groupId = unitOfWork.Students.Get(userId).GroupId ?? throw new NullReferenceException();
            this.SelectedGroup = unitOfWork.Groups.Get(groupId);
            this.Students = new ObservableCollection<Student>(this.SelectedGroup.Students);
        }

    }
}
