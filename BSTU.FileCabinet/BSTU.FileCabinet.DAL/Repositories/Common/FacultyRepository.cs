using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class FacultyRepository : IRepository<Faculty, string>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public FacultyRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Faculty entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Faculties.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Faculties.FirstOrDefault(i => i.FacultyCode.Equals(id));
                if (item != null)
                {
                    context.Faculties.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Faculty Get(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Faculties.FirstOrDefault(i => i.FacultyCode.Equals(id));
            }
        }

        public IEnumerable<Faculty> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Faculties.ToArray();
            }
        }

        public bool Update(string id, Faculty entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Faculties.FirstOrDefault(i => i.FacultyCode.Equals(id));
                if (item != null)
                {
                    item.FacultyName = entity.FacultyName ?? item.FacultyName;
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
