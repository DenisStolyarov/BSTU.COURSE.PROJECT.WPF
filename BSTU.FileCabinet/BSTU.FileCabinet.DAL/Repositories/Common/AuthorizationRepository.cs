using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    public class AuthorizationRepository : IRepository<Authorization, string>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public AuthorizationRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Authorization entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Authorizations.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Authorizations.FirstOrDefault(i => i.Login.Equals(id));
                if (item != null)
                {
                    context.Authorizations.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Authorization Get(string id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Authorizations.Include(i => i.Student).FirstOrDefault(i => i.Login.Equals(id));
            }
        }

        public IEnumerable<Authorization> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Authorizations.Include(i => i.Student).ToArray();
            }
        }

        public bool Update(string id, Authorization entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Authorizations.Include(i => i.Student).FirstOrDefault(i => i.Login.Equals(id));
                if (item != null)
                {
                    item.Role = entity.Role;
                    item.UserId = entity.UserId ?? item.UserId;
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
