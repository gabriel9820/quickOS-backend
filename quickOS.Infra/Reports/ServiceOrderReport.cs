using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using quickOS.Core.Entities;
using quickOS.Core.Enums;
using quickOS.Core.Reports;
using quickOS.Core.Utils;

namespace quickOS.Infra.Reports;

public class ServiceOrderReport : IServiceOrderReport
{
    public byte[] GenerateIndividual(ServiceOrder data)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header().Element(c => ComposeHeader(c, data));
                page.Content().Element(c => ComposeContent(c, data));
                page.Footer().Element(c => ComposeFooter(c));
            });
        });

        return document.GeneratePdf();
    }

    private void ComposeHeader(IContainer container, ServiceOrder data)
    {
        container.Column(column =>
        {
            column.Item().Row(row =>
            {
                row.RelativeItem().Text($"OS: {data.Number}").Bold().FontSize(16);
            });

            column.Item().Text(data.Tenant.Name).Bold().FontSize(20).AlignCenter();
        });
    }

    private void ComposeContent(IContainer container, ServiceOrder data)
    {
        container.PaddingVertical(20).Column(column =>
        {
            column.Item().Text($"Data: {DateTimeUtils.ConvertToBrasiliaTime(data.Date)}");
            column.Item().Text($"Técnico: {data.Technician.FullName}");
            column.Item().Text($"Status: {data.Status.GetLabel()}");

            column.Item().PaddingVertical(5);

            column.Item().Text($"Cliente: {data.Customer.FullName}").Bold();
            column.Item().Text($"Celular: {data.Customer.Cellphone}");

            if (data.Customer.Address != null)
            {
                var number = data.Customer.Address.Number != null ? $", {data.Customer.Address.Number}" : "";
                var details = data.Customer.Address.Details != null ? $" - {data.Customer.Address.Details}" : "";
                var state = data.Customer.Address.State != null ? $" - {data.Customer.Address.State}" : "";

                column.Item().Text($"CEP: {data.Customer.Address.ZipCode}");
                column.Item().Text($"Endereço: {data.Customer.Address.Street}{number}{details}");
                column.Item().Text($"Bairro: {data.Customer.Address.Neighborhood}");
                column.Item().Text($"Cidade: {data.Customer.Address.City}{state}");
            }

            column.Item().PaddingTop(10).Text("Descrição do Equipamento:").Bold().AlignLeft();
            column.Item().PaddingTop(5).Text(data.EquipmentDescription);
            column.Item().PaddingTop(5).LineHorizontal(0.7f);

            column.Item().PaddingTop(10).Text("Descrição do Problema:").Bold().AlignLeft();
            column.Item().PaddingTop(5).Text(data.ProblemDescription);
            column.Item().PaddingTop(5).LineHorizontal(0.7f);

            column.Item().PaddingTop(10).Text("Laudo Técnico:").Bold().AlignLeft();
            column.Item().PaddingTop(5).Text(data.TechnicalReport);
            column.Item().PaddingTop(5).LineHorizontal(0.7f);

            column.Item().PaddingTop(20).Element(c => ComposeServicesTable(c, data.Services));
            column.Item().PaddingTop(20).Element(c => ComposeProductsTable(c, data.Products));

            column.Item().PaddingTop(15).Text($"Total Geral: {FormatUtils.FormatDecimal(data.TotalPrice, 2)}").Bold().AlignRight();

            column.Item().ExtendVertical().AlignBottom().EnsureSpace(200).Column(x =>
            {
                x.Item().AlignCenter().Width(250).LineHorizontal(0.7f);
                x.Item().Text($"{data.Customer.FullName}").AlignCenter();
            });
        });
    }

    private void ComposeServicesTable(IContainer container, ICollection<ServiceOrderService> services)
    {
        if (services.Count == 0) return;

        container.Column(column =>
        {
            column.Item().Text("Serviços").FontSize(16).Bold().AlignCenter();

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(40);
                    columns.RelativeColumn();
                    columns.ConstantColumn(40);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().Element(TableHeaderStyle).Text("#");
                    header.Cell().Element(TableHeaderStyle).Text("Serviço");
                    header.Cell().Element(TableHeaderStyle).Text("Quant.").AlignRight();
                    header.Cell().Element(TableHeaderStyle).Text("Valor").AlignRight();
                    header.Cell().Element(TableHeaderStyle).Text("Total").AlignRight();
                });

                foreach (var service in services)
                {
                    table.Cell().Text(service.Item.ToString());
                    table.Cell().Text(service.Service.Name);
                    table.Cell().Text(FormatUtils.FormatDouble(service.Quantity, 2)).AlignRight();
                    table.Cell().Text(FormatUtils.FormatDecimal(service.Price, 2)).AlignRight();
                    table.Cell().Text(FormatUtils.FormatDecimal(service.TotalPrice, 2)).AlignRight();
                }
            });

            var total = services.Sum(x => x.TotalPrice);
            column.Item().PaddingTop(5).Text($"Total: {FormatUtils.FormatDecimal(total, 2)}").Bold().AlignRight();
        });
    }

    private void ComposeProductsTable(IContainer container, ICollection<ServiceOrderProduct> products)
    {
        if (products.Count == 0) return;

        container.Column(column =>
        {
            column.Item().Text("Produtos").FontSize(16).Bold().AlignCenter();

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(40);
                    columns.RelativeColumn();
                    columns.ConstantColumn(40);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().Element(TableHeaderStyle).Text("#");
                    header.Cell().Element(TableHeaderStyle).Text("Produto");
                    header.Cell().Element(TableHeaderStyle).Text("Quant.").AlignRight();
                    header.Cell().Element(TableHeaderStyle).Text("Valor").AlignRight();
                    header.Cell().Element(TableHeaderStyle).Text("Total").AlignRight();
                });

                foreach (var product in products)
                {
                    table.Cell().Text(product.Item.ToString());
                    table.Cell().Text(product.Product.Name);
                    table.Cell().Text(FormatUtils.FormatDouble(product.Quantity, 2)).AlignRight();
                    table.Cell().Text(FormatUtils.FormatDecimal(product.Price, 2)).AlignRight();
                    table.Cell().Text(FormatUtils.FormatDecimal(product.TotalPrice, 2)).AlignRight();
                }
            });

            var total = products.Sum(x => x.TotalPrice);
            column.Item().PaddingTop(5).Text($"Total: {FormatUtils.FormatDecimal(total, 2)}").Bold().AlignRight();
        });
    }

    private void ComposeFooter(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().AlignLeft().Text($"Data: {DateTimeUtils.GetBrasiliaTime()}").FontSize(8);

            row.RelativeItem().AlignRight().Text(text =>
            {
                text.DefaultTextStyle(x => x.FontSize(8));
                text.Span("Página ");
                text.CurrentPageNumber();
                text.Span(" de ");
                text.TotalPages();
            });
        });
    }

    private IContainer TableHeaderStyle(IContainer container)
    {
        return container.PaddingBottom(3).BorderBottom(0.7f);
    }
}
