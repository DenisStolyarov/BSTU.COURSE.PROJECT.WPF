using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BSTU.FileCabinet.WPF.ViewModels.User
{
    public class UserHomeViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        public Student CurrentStudent { get; set; }
        public BitmapImage SelectedImage
        {
            get
            {
                return ImageConverter.LoadImage(CurrentStudent?.Foto);
            }
        }

        public UserHomeViewModel(IUnitOfWork unitOfWork, int userId)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            this.CurrentStudent = unitOfWork.Students.Get(userId);
        }
    }
}
