using quickOS.Core.Entities;

namespace quickOS.Core.Reports;

public interface IServiceOrderReport
{
    byte[] GenerateIndividual(ServiceOrder serviceOrder);
}
