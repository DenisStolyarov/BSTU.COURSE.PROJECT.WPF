using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;

namespace BSTU.FileCabinet.DAL.Infrastructures
{
    public class FileCabinetDbContextFactory : IDbContextFactory<FileCabinetContext>
    {
        public FileCabinetContext CreateDbContext()
        {
            return new FileCabinetContext();
        }
    }
}
