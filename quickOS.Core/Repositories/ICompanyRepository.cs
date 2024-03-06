using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface ICompanyRepository
{
    Task CreateAsync(Company company);
    Task<Company?> GetByIdAsync(int id);
}
