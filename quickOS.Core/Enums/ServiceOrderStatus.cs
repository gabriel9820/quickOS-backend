namespace quickOS.Core.Enums;

public enum ServiceOrderStatus
{
    Open = 1,
    InProgress = 2,
    Quotation = 3,
    Approved = 4,
    Rejected = 5,
    Completed = 6,
    Invoiced = 7
}

public static class ServiceOrderStatusExtensions
{
    private static readonly Dictionary<ServiceOrderStatus, string> Labels = new()
    {
        { ServiceOrderStatus.Open, "Aberto" },
        { ServiceOrderStatus.InProgress, "Em Andamento" },
        { ServiceOrderStatus.Quotation, "Orçamento" },
        { ServiceOrderStatus.Approved, "Orçamento Aprovado" },
        { ServiceOrderStatus.Rejected, "Orçamento Rejeitado" },
        { ServiceOrderStatus.Completed, "Finalizado" },
        { ServiceOrderStatus.Invoiced, "Faturado" }
    };

    public static string GetLabel(this ServiceOrderStatus status)
    {
        if (Labels.TryGetValue(status, out var label))
        {
            return label;
        }

        return Enum.GetName(typeof(ServiceOrderStatus), status)!;
    }
}