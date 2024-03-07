namespace quickOS.Core.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
