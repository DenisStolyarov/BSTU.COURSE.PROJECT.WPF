using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories.Common;
using BSTU.FileCabinet.Domain.Models;
using System;

namespace BSTU.FileCabinet.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public UnitOfWork(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        private IRepository<Authorization, string> authorizationRepository;
        private IRepository<Faculty, string> facultyRepository;
        private IRepository<Group, int> groupRepository;
        private IRepository<Pulpit, string> pulpitRepository;
        private IRepository<Specialty, string> specialtyRepository;
        private IRepository<Student, int> studentRepository;
        private IRepository<Subject, string> subjectRepository;
        private IRepository<Teacher, string> teacherRepository;
        private TeacherSubjectRepository teacherSubjectRepository;

        public IRepository<Authorization, string> Authorizations
        {
            get
            {
                if (authorizationRepository is null)
                    authorizationRepository = new AuthorizationRepository(contextFactory);
                return authorizationRepository;
            }
        }

        public IRepository<Faculty, string> Faculties
        {
            get
            {
                if (facultyRepository is null)
                    facultyRepository = new FacultyRepository(contextFactory);
                return facultyRepository;
            }
        }

        public IRepository<Group, int> Groups
            {
            get
            {
                if (groupRepository is null)
                    groupRepository = new GroupRepository(contextFactory);
                return groupRepository;
            }
        }

        public IRepository<Pulpit, string> Pulpits
            {
            get
            {
                if (pulpitRepository is null)
                    pulpitRepository = new PulpitRepository(contextFactory);
                return pulpitRepository;
            }
        }

        public IRepository<Specialty, string> Specialties
            {
            get
            {
                if (specialtyRepository is null)
                    specialtyRepository = new SpecialtyRepository(contextFactory);
                return specialtyRepository;
            }
        }

        public IRepository<Student, int> Students
            {
            get
            {
                if (studentRepository is null)
                    studentRepository = new StudentRepository(contextFactory);
                return studentRepository;
            }
        }

        public IRepository<Subject, string> Subjects
            {
            get
            {
                if (subjectRepository is null)
                    subjectRepository = new SubjectRepository(contextFactory);
                return subjectRepository;
            }
        }

        public IRepository<Teacher, string> Teachers
            {
            get
            {
                if (teacherRepository is null)
                    teacherRepository = new TeacherRepository(contextFactory);
                return teacherRepository;
            }
        }

        public TeacherSubjectRepository TeacherSubjects
            {
            get
            {
                if (teacherSubjectRepository is null)
                    teacherSubjectRepository = new TeacherSubjectRepository(contextFactory);
                return teacherSubjectRepository;
            }
        }
    }
}
