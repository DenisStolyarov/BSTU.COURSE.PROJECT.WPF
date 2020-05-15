using BSTU.FileCabinet.DAL.Repositories.Common;
using BSTU.FileCabinet.Domain.Models;

namespace BSTU.FileCabinet.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Authorization, string> Authorizations { get; }
        IRepository<Faculty, string> Faculties { get; }
        IRepository<Group, int> Groups { get; }
        IRepository<Pulpit, string> Pulpits { get; }
        IRepository<Specialty, string> Specialties { get; }
        IRepository<Student, int> Students { get; }
        IRepository<Subject, string> Subjects { get; }
        IRepository<Teacher, string> Teachers { get; }
        TeacherSubjectRepository TeacherSubjects { get; }
    }
}
