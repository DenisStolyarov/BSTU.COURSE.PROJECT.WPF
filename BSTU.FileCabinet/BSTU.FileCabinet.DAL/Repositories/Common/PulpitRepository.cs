using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class PulpitRepository : IRepository<Pulpit, string>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public PulpitRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Pulpit entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Pulpits.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Pulpits.FirstOrDefault(i => i.PulpitCode.Equals(id));
                if (item != null)
                {
                    context.Pulpits.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Pulpit Get(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Pulpits.Include(i => i.Faculty).FirstOrDefault(i => i.PulpitCode.Equals(id));
            }
        }

        public IEnumerable<Pulpit> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Pulpits.Include(i => i.Faculty).ToArray();
            }
        }

        public bool Update(string id, Pulpit entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Pulpits.Include(i => i.Faculty).FirstOrDefault(i => i.PulpitCode.Equals(id));
                if (item != null)
                {
                    item.PulpitName = entity.PulpitName ?? item.PulpitName;
                    item.FacultyCode = entity.FacultyCode ?? item.FacultyCode;
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
