using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class SpecialtyRepository : IRepository<Specialty, string>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public SpecialtyRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Specialty entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Specialties.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Specialties.FirstOrDefault(i => i.SpecialtyCode.Equals(id));
                if (item != null)
                {
                    context.Specialties.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Specialty Get(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Specialties.FirstOrDefault(i => i.SpecialtyCode.Equals(id));
            }
        }

        public IEnumerable<Specialty> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Specialties.ToArray();
            }
        }

        public bool Update(string id, Specialty entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Specialties.FirstOrDefault(i => i.SpecialtyCode.Equals(id));
                if (item != null)
                {
                    item.PulpitCode = entity.PulpitCode ?? item.PulpitCode;
                    item.Pulpit = entity.Pulpit ?? item.Pulpit;
                    item.SpecialtyName = entity.SpecialtyName ?? item.SpecialtyName;
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
