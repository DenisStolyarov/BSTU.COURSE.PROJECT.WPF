using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Authorization, string> Authorizations { get; }
        IRepository<Faculty, string> Faculties { get; }
        IRepository<Group, int> Groups { get; }
        IRepository<Pulpit, string> Pulpits { get; }
        IRepository<Specialty, string> Specialties { get; }
        IRepository<Student, int> Students { get; }
        IRepository<Subject, string> Subjects { get; }
        IRepository<Teacher, string> Teachers { get; }
        IRepository<TeacherSubject, string> TeacherSubjects { get; }

    }
}
