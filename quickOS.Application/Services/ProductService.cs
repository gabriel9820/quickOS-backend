using System.Linq.Expressions;
using System.Net;
using LinqKit;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Application.Mappings;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfMeasurementRepository _unitOfMeasurementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfMeasurementRepository unitOfMeasurementRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfMeasurementRepository = unitOfMeasurementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<ProductOutputModel>> CreateAsync(ProductInputModel productInputModel)
    {
        var product = await productInputModel.ToEntity(_unitOfMeasurementRepository);

        await _productRepository.CreateAsync(product);
        await _unitOfWork.SaveChangesAsync();

        var createdProduct = product.ToOutputModel();

        return ApiResponse<ProductOutputModel>.Ok(createdProduct);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var product = await _productRepository.GetByExternalIdAsync(externalId);

        if (product == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Produto não encontrado");
        }

        _productRepository.Delete(product);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<PagedResult<ProductOutputModel>>> GetAllAsync(ProductQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var products = await _productRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);

        var result = new PagedResult<ProductOutputModel>(
            products.CurrentPage,
            products.TotalPages,
            products.PageSize,
            products.TotalCount,
            products.Data.ToOutputModel());

        return ApiResponse<PagedResult<ProductOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<ProductOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var product = await _productRepository.GetByExternalIdAsync(externalId);

        if (product == null)
        {
            return ApiResponse<ProductOutputModel>.Error(HttpStatusCode.NotFound, "Produto não encontrado");
        }

        var result = product.ToOutputModel();

        return ApiResponse<ProductOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<int>> GetNextCode()
    {
        var nextCode = await _productRepository.GetNextCode();

        return ApiResponse<int>.Ok(nextCode);
    }

    public async Task<ApiResponse<ProductOutputModel>> UpdateAsync(Guid externalId, ProductInputModel productInputModel)
    {
        var product = await _productRepository.GetByExternalIdAsync(externalId);

        if (product == null)
        {
            return ApiResponse<ProductOutputModel>.Error(HttpStatusCode.NotFound, "Produto não encontrado");
        }

        var unitOfMeasurement = await _unitOfMeasurementRepository.GetByExternalIdAsync(productInputModel.UnitOfMeasurementExternalId);

        product.UpdateCode(productInputModel.Code);
        product.UpdateName(productInputModel.Name);
        product.UpdateDescription(productInputModel.Description);
        product.UpdateCostPrice(productInputModel.CostPrice);
        product.UpdateProfitMargin(productInputModel.ProfitMargin);
        product.UpdateSellingPrice(productInputModel.SellingPrice);
        product.UpdateStock(productInputModel.Stock);
        product.UpdateIsActive(productInputModel.IsActive);
        product.UpdateUnitOfMeasurement(unitOfMeasurement);
        await _unitOfWork.SaveChangesAsync();

        var result = product.ToOutputModel();

        return ApiResponse<ProductOutputModel>.Ok(result);
    }

    private ExpressionStarter<Product>? GetFilters(ProductQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<Product>(true);

        if (queryParams.Code.HasValue)
        {
            predicate = predicate.And(x => x.Code == queryParams.Code);
        }
        if (!string.IsNullOrEmpty(queryParams.Name))
        {
            predicate = predicate.And(x => x.Name.Contains(queryParams.Name));
        }
        if (queryParams.SellingPrice.HasValue)
        {
            predicate = predicate.And(x => x.SellingPrice == queryParams.SellingPrice);
        }
        if (queryParams.Stock.HasValue)
        {
            predicate = predicate.And(x => x.Stock == queryParams.Stock);
        }
        if (queryParams.UnitsOfMeasurement?.Length > 0)
        {
            predicate = predicate.And(x => queryParams.UnitsOfMeasurement.Contains(x.UnitOfMeasurement.ExternalId));
        }
        if (queryParams.IsActive.HasValue)
        {
            predicate = predicate.And(x => x.IsActive == queryParams.IsActive);
        }

        return predicate;
    }

    private Expression<Func<Product, object>>? GetOrderByField(ProductQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            "code" => x => x.Code,
            "name" => x => x.Name,
            "sellingPrice" => x => x.SellingPrice,
            "stock" => x => x.Stock,
            "isActive" => x => x.IsActive,
            _ => null,
        };
    }
}
