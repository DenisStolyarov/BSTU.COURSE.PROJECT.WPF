using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.DAL.Interfaces
{
    public interface IDbContextFactory<T>
    {
        T CreateDbContext(string[] args);
    }
}
