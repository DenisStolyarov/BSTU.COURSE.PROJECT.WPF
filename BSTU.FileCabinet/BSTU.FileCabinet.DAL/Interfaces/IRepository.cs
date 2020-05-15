using System.Collections.Generic;

namespace BSTU.FileCabinet.DAL.Interfaces
{
    public interface IRepository<Entity, Id>
    {
        IEnumerable<Entity> GetAll();

        Entity Get(Id id);

        bool Create(Entity entity);

        bool Update(Id id, Entity entity);

        bool Delete(Id id);
    }
}
