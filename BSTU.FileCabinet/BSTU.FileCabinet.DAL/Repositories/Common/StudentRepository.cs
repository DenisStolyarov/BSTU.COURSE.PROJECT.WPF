using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class StudentRepository : IRepository<Student, int>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public StudentRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Student entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Students.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Students.FirstOrDefault(i => i.StudentId.Equals(id));
                if (item != null)
                {
                    context.Students.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Student Get(int id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Students.Include(i => i.Group).FirstOrDefault(i => i.StudentId.Equals(id));
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Students.Include(i => i.Group).ToArray();
            }
        }

        public bool Update(int id, Student entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Students.Include(i => i.Group).FirstOrDefault(i => i.StudentId.Equals(id));
                if (item != null)
                {
                    item.Birthday = entity.Birthday ?? item.Birthday;
                    item.FirstName = entity.FirstName ?? item.FirstName;
                    item.Foto = entity.Foto ?? item.Foto;
                    item.GroupId = entity.GroupId ?? item.GroupId;
                    item.LastName = entity.LastName ?? item.LastName;
                    item.Patronymic = entity.Patronymic ?? item.Patronymic;
                    item.PhoneNumber = entity.PhoneNumber ?? item.PhoneNumber;
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
