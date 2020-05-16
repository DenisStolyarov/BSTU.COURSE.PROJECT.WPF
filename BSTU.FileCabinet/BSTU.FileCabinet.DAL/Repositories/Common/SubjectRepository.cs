using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class SubjectRepository : IRepository<Subject, string>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public SubjectRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Subject entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Subjects.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Subjects.FirstOrDefault(i => i.SubjectCode.Equals(id));
                if (item != null)
                {
                    context.Subjects.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Subject Get(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Subjects.Include(i => i.Pulpit).FirstOrDefault(i => i.SubjectCode.Equals(id));
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Subjects.Include(i => i.Pulpit).ToArray();
            }
        }

        public bool Update(string id, Subject entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Subjects.Include(i => i.Pulpit).FirstOrDefault(i => i.SubjectCode.Equals(id));
                if (item != null)
                {
                    item.PulpitCode = entity.PulpitCode ?? item.PulpitCode;
                    item.SubjectName = entity.SubjectName ?? item.SubjectName;
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
