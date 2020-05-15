using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return context.Groups.FirstOrDefault(i => i.GroupId.Equals(id));
            }
        }

        public IEnumerable<Group> GetAll()
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                return context.Groups.ToArray();
            }
        }

        public bool Update(int id, Group entity)
        {
            using (var context = this.contextFactory.CreateDbContext())
            {
                var item = context.Groups.FirstOrDefault(i => i.GroupId.Equals(id));
                if (item != null)
                {
                    item.Course = entity.Course ?? item.Course;
                    item.Faculty = entity.Faculty ?? item.Faculty;
                    item.FacultyCode = entity.FacultyCode ?? item.FacultyCode;
                    item.GroupNumber = entity.GroupNumber ?? item.GroupNumber;
                    item.Specialty = entity.Specialty ?? item.Specialty;
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
