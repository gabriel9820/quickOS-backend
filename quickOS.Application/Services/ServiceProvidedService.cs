using System.Net;
using AutoMapper;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class ServiceProvidedService : IServiceProvidedService
{
    private readonly IServiceProvidedRepository _serviceProvidedRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceProvidedService(IServiceProvidedRepository serviceProvidedRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _serviceProvidedRepository = serviceProvidedRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ServiceProvidedOutputModel>> CreateAsync(ServiceProvidedInputModel serviceInputModel)
    {
        var service = _mapper.Map<ServiceProvided>(serviceInputModel);

        await _serviceProvidedRepository.CreateAsync(service);
        await _unitOfWork.SaveChangesAsync();

        var createdService = _mapper.Map<ServiceProvidedOutputModel>(service);

        return ApiResponse<ServiceProvidedOutputModel>.Ok(createdService);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var service = await _serviceProvidedRepository.GetByExternalIdAsync(externalId);

        if (service == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Serviço não encontrado");
        }

        _serviceProvidedRepository.Delete(service);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<IEnumerable<ServiceProvidedOutputModel>>> GetAllAsync()
    {
        var services = await _serviceProvidedRepository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<ServiceProvidedOutputModel>>(services);

        return ApiResponse<IEnumerable<ServiceProvidedOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<ServiceProvidedOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var service = await _serviceProvidedRepository.GetByExternalIdAsync(externalId);

        if (service == null)
        {
            return ApiResponse<ServiceProvidedOutputModel>.Error(HttpStatusCode.NotFound, "Serviço não encontrado");
        }

        var result = _mapper.Map<ServiceProvidedOutputModel>(service);

        return ApiResponse<ServiceProvidedOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<ServiceProvidedOutputModel>> UpdateAsync(Guid externalId, ServiceProvidedInputModel serviceInputModel)
    {
        var service = await _serviceProvidedRepository.GetByExternalIdAsync(externalId);

        if (service == null)
        {
            return ApiResponse<ServiceProvidedOutputModel>.Error(HttpStatusCode.NotFound, "Serviço não encontrado");
        }

        service.UpdateCode(serviceInputModel.Code);
        service.UpdateName(serviceInputModel.Name);
        service.UpdateDescription(serviceInputModel.Description);
        service.UpdatePrice(serviceInputModel.Price);
        service.UpdateIsActive(serviceInputModel.IsActive);
        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ServiceProvidedOutputModel>(service);

        return ApiResponse<ServiceProvidedOutputModel>.Ok(result);
    }
}
