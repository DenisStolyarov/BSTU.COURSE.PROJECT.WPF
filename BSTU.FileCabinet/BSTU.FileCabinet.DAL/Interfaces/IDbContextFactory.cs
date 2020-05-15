namespace BSTU.FileCabinet.DAL.Interfaces
{
    public interface IDbContextFactory<T>
    {
        T CreateDbContext();
    }
}
