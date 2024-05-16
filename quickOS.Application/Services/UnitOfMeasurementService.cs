using AutoMapper;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class UnitOfMeasurementService : IUnitOfMeasurementService
{
    private readonly IUnitOfMeasurementRepository _unitOfMeasurementRepository;
    private readonly IMapper _mapper;

    public UnitOfMeasurementService(IUnitOfMeasurementRepository unitOfMeasurementRepository, IMapper mapper)
    {
        _unitOfMeasurementRepository = unitOfMeasurementRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<UnitOfMeasurementOutputModel>>> FillAutocompleteAsync()
    {
        var unitsOfMeasurement = await _unitOfMeasurementRepository.FillAutocompleteAsync();
        var unitsOfMeasurementDTO = _mapper.Map<IEnumerable<UnitOfMeasurementOutputModel>>(unitsOfMeasurement);

        return ApiResponse<IEnumerable<UnitOfMeasurementOutputModel>>.Ok(unitsOfMeasurementDTO);
    }
}
