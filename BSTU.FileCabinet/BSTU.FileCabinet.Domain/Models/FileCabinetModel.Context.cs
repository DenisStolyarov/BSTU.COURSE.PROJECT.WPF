namespace BSTU.FileCabinet.Domain.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FileCabinetContext : DbContext
    {
        public FileCabinetContext()
            : base("name=FileCabinetContext")
        {
        }
    
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Pulpit> Pulpits { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
    
        public virtual ObjectResult<StudentsOfGroup> GetStudentsOfGroup(Nullable<int> groupId)
        {
            var groupIdParameter = groupId.HasValue ?
                new ObjectParameter("GroupId", groupId) :
                new ObjectParameter("GroupId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StudentsOfGroup>("GetStudentsOfGroup", groupIdParameter);
        }
    
        public virtual ObjectResult<SubjectsOfStudent> GetSubjectsOfStudent(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SubjectsOfStudent>("GetSubjectsOfStudent", studentIdParameter);
        }
    }
}
