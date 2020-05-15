using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    public class TeacherSubjectRepository
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public TeacherSubjectRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(TeacherSubject entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.TeacherSubjects.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string teacherId, string subjectId)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.TeacherSubjects.FirstOrDefault(i => i.SubjectCode.Equals(teacherId) && i.TeacherCode.Equals(subjectId));
                if (item != null)
                {
                    context.TeacherSubjects.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public TeacherSubject Get(string teacherId, string subjectId)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.TeacherSubjects.FirstOrDefault(i => i.SubjectCode.Equals(teacherId) && i.TeacherCode.Equals(subjectId));
            }
        }

        public IEnumerable<TeacherSubject> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.TeacherSubjects.ToArray();
            }
        }

        public bool Update(string teacherId, string subjectId, TeacherSubject entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.TeacherSubjects.FirstOrDefault(i => i.SubjectCode.Equals(teacherId) && i.TeacherCode.Equals(subjectId));
                if (item != null)
                {
                    item.Course = entity.Course > 0 
                        ? entity.Course
                        :item.Course;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
