using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BSTU.FileCabinet.WPF.ViewModels.User
{
    public class UserSubjectViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        public Teacher SelectedTeacher 
        {
            get
            {
                return unitOfWork?.Teachers.Get(this.SelectedSubjectsOfStudent?.TeacherCode);
            }
        }

        public Subject SelectedSubject 
        {
            get
            {
                return unitOfWork?.Subjects.Get(this.SelectedSubjectsOfStudent?.SubjectCode);
            }
        }

        public BitmapImage SelectedImage
        {
            get
            {
                return ImageConverter.LoadImage(SelectedTeacher?.Foto);
            }
        }

        public GetSubjectsOfStudent_Result SelectedSubjectsOfStudent { get; set; }

        public ObservableCollection<GetSubjectsOfStudent_Result> Subjects { get; set; }

        public UserSubjectViewModel(IUnitOfWork unitOfWork, int userId)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            this.Subjects = new ObservableCollection<GetSubjectsOfStudent_Result>(unitOfWork.TeacherSubjects.GetSubjectsOfStudent(userId));
        }
    }
}
