﻿using System.Net;
using AutoMapper;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IRequestProvider _requestProvider;
    private readonly IMapper _mapper;

    public TenantService(ITenantRepository tenantRepository, IRequestProvider requestProvider, IMapper mapper)
    {
        _tenantRepository = tenantRepository;
        _requestProvider = requestProvider;
        _mapper = mapper;
    }

    public async Task<ApiResponse<TenantOutputModel>> GetCurrentAsync()
    {
        var tenant = await _tenantRepository.GetByIdAsync(_requestProvider.TenantId);

        if (tenant == null)
        {
            return ApiResponse<TenantOutputModel>.Error(HttpStatusCode.NotFound, "Estabelecimento não encontrado");
        }

        var result = _mapper.Map<TenantOutputModel>(tenant);

        return ApiResponse<TenantOutputModel>.Ok(result);
    }
}
