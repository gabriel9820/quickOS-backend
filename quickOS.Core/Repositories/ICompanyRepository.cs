using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface ICompanyRepository
{
    Task<Company> GetByExternalIdAsync(Guid externalId);
}
