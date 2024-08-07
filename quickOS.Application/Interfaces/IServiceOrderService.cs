﻿using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IServiceOrderService
{
    Task<ApiResponse<ServiceOrderOutputModel>> CreateAsync(ServiceOrderInputModel serviceOrderInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<PagedResult<ServiceOrderOutputModel>>> GetAllAsync(ServiceOrderQueryParams queryParams);
    Task<ApiResponse<ServiceOrderOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<int>> GetNextNumber();
    Task<ApiResponse<byte[]>> IndividualReportAsync(Guid externalId);
    Task<ApiResponse> InvoiceAsync(Guid externalId, ServiceOrderInvoiceInputModel inputModel);
    Task<ApiResponse> SendPDFByEmailAsync(Guid externalId);
    Task<ApiResponse<ServiceOrderOutputModel>> UpdateAsync(Guid externalId, ServiceOrderInputModel serviceOrderInputModel);
}
