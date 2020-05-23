using BSTU.FileCabinet.BLL.Services;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using BSTU.FileCabinet.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels.Factories
{
    public class AdminSimpleViewModelFactory : ISimpleViewModelFactory
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminSimpleViewModelFactory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BaseViewModel CreateViewModel(ViewType view)
        {
            switch (view)
            {
                case ViewType.Authorization:
                    return new AuthorizationViewModel(unitOfWork.Authorizations, new CommonFileRecordService<Authorization>());
                case ViewType.Faculty:
                    return new FacultyViewModel(unitOfWork.Faculties, new CommonFileRecordService<Faculty>());
                case ViewType.Group:
                    return new GroupViewModel(unitOfWork.Groups, new CommonFileRecordService<Group>());
                case ViewType.Pulpit:
                    return new PulpitViewModel(unitOfWork.Pulpits, new CommonFileRecordService<Pulpit>());
                case ViewType.Speciality:
                    return new SpecialtyViewModel(unitOfWork.Specialties, new CommonFileRecordService<Specialty>());
                case ViewType.Student:
                    return new StudentViewModel(unitOfWork.Students, new CommonFileRecordService<Student>());
                case ViewType.Subject:
                    return new SubjectViewModel(unitOfWork.Subjects, new CommonFileRecordService<Subject>());
                case ViewType.TeacherSubject:
                    return new TeacherSubjectViewModel(unitOfWork.TeacherSubjects, new CommonFileRecordService<TeacherSubject>());
                case ViewType.Teacher:
                    return new TeacherViewModel(unitOfWork.Teachers, new CommonFileRecordService<Teacher>());
                default:
                    throw new Exception();
            }
        }
    }
}
