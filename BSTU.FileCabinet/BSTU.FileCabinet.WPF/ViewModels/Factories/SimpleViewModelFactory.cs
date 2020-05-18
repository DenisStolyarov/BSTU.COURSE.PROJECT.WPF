using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels.Factories
{
    public class SimpleViewModelFactory : ISimpleViewModelFactory
    {
        private readonly IUnitOfWork unitOfWork;

        public SimpleViewModelFactory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BaseViewModel CreateViewModel(ViewType view)
        {
            switch (view)
            {
                case ViewType.Authorization:
                    return new AuthorizationViewModel(unitOfWork.Authorizations);
                case ViewType.Faculty:
                    return new FacultyViewModel(unitOfWork.Faculties);
                case ViewType.Group:
                    return new GroupViewModel(unitOfWork.Groups);
                case ViewType.Pulpit:
                    return new PulpitViewModel(unitOfWork.Pulpits);
                case ViewType.Speciality:
                    return new SpecialtyViewModel(unitOfWork.Specialties);
                case ViewType.Student:
                    return new StudentViewModel(unitOfWork.Students);
                case ViewType.Subject:
                    return new SubjectViewModel(unitOfWork.Subjects);
                case ViewType.TeacherSubject:
                    return new TeacherSubjectViewModel(unitOfWork.TeacherSubjects);
                case ViewType.Teacher:
                    return new TeacherViewModel(unitOfWork.Teachers);
                default:
                    throw new Exception();
            }
        }
    }
}
