using System.Net;
using AutoMapper;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IRequestProvider _requestProvider;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository, IRequestProvider requestProvider, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _requestProvider = requestProvider;
        _mapper = mapper;
    }

    public async Task<ApiResponse<CompanyOutputModel>> GetCurrentAsync()
    {
        var company = await _companyRepository.GetByIdAsync(_requestProvider.CompanyId);

        if (company == null)
        {
            return ApiResponse<CompanyOutputModel>.Error(HttpStatusCode.NotFound, "Estabelecimento não encontrado");
        }

        var result = _mapper.Map<CompanyOutputModel>(company);

        return ApiResponse<CompanyOutputModel>.Ok(result);
    }
}
