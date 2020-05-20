using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BSTU.FileCabinet.DAL.Repositories.Common
{
    class GroupRepository : IRepository<Group, int>
    {
        private readonly IDbContextFactory<FileCabinetContext> contextFactory;

        public GroupRepository(IDbContextFactory<FileCabinetContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new NullReferenceException(nameof(contextFactory));
        }

        public bool Create(Group entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                context.Groups.Add(entity);
                var createdResult = context.SaveChanges();
                return createdResult > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Groups.FirstOrDefault(i => i.GroupId.Equals(id));
                if (item != null)
                {
                    context.Groups.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Group Get(int id)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Groups
                    .Include(i => i.Faculty)
                    .Include(i => i.Specialty)
                    .Include(i => i.Students)
                    .FirstOrDefault(i => i.GroupId.Equals(id));
            }
        }

        public IEnumerable<Group> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Groups
                    .Include(i => i.Faculty)
                    .Include(i => i.Specialty)
                    .ToArray();
            }
        }

        public bool Update(int id, Group entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Groups
                    .Include(i => i.Faculty)
                    .Include(i => i.Specialty)
                    .FirstOrDefault(i => i.GroupId.Equals(id));
                if (item != null)
                {
                    item.Course = entity.Course ?? item.Course;
                    item.FacultyCode = entity.FacultyCode ?? item.FacultyCode;
                    item.GroupNumber = entity.GroupNumber ?? item.GroupNumber;
                    item.SpecialtyCode = entity.SpecialtyCode ?? item.SpecialtyCode;
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
