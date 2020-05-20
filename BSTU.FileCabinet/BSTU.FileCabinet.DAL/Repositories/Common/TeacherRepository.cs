using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class TeacherRepository : IRepository<Teacher, string>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public TeacherRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Teacher entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Teachers.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Teachers.FirstOrDefault(i => i.TeacherCode.Equals(id));
                if (item != null)
                {
                    context.Teachers.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Teacher Get(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Teachers.Include(i => i.Pulpit).Include(i => i.Pulpit.Faculty).FirstOrDefault(i => i.TeacherCode.Equals(id));
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Teachers.Include(i => i.Pulpit).ToArray();
            }
        }

        public bool Update(string id, Teacher entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Teachers.Include(i => i.Pulpit).FirstOrDefault(i => i.TeacherCode.Equals(id));
                if (item != null)
                {
                    item.PulpitCode = entity.PulpitCode ?? item.PulpitCode;
                    item.Foto = entity.Foto ?? item.Foto;
                    item.TeacherName = entity.TeacherName ?? item.TeacherName;
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
