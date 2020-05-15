using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.DAL.Interfaces
{
    public interface IRepository<Entity, Id>
    {
        Task<IEnumerable<Entity>> GetAll();

        Task<Entity> Get(Id id);

        Task<bool> Create(Entity entity);

        Task<bool> Update(Id id, Entity entity);

        Task<bool> Delete(Id id);
    }
}
