using AutoMapper;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;

namespace quickOS.Application.AutoMapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProductInputModel, Product>();
        CreateMap<Product, ProductOutputModel>();

        CreateMap<ServiceProvidedInputModel, ServiceProvided>();
        CreateMap<ServiceProvided, ServiceProvidedOutputModel>();

        CreateMap<TenantInputModel, Tenant>();
        CreateMap<Tenant, TenantOutputModel>();

        CreateMap<UnitOfMeasurement, UnitOfMeasurementOutputModel>();

        CreateMap<User, UserOutputModel>();
    }
}
