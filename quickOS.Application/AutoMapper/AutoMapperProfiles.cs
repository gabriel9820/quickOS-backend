using AutoMapper;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;

namespace quickOS.Application.AutoMapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CompanyInputModel, Company>();
        CreateMap<Company, CompanyOutputModel>();

        CreateMap<User, AuthenticatedUserOutputModel>();
    }
}
