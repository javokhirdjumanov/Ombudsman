using AutoMapper;
using DataLayer;
using DataLayer.Repository;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class StateProgramService : IStateProgramService
{
    private readonly IStateProgramRepository stateProgramRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public StateProgramService(
        IStateProgramRepository stateProgramRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.stateProgramRepository = stateProgramRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<SPDto> CreateStateProgramAsync(SPDlDto spDlDto)
    {
        var newStateProgram = this.mapper
            .Map<StateProgram>(spDlDto);

        var addedStatusProgram = await this.stateProgramRepository
            .InsertAsync(newStateProgram);

        return this.mapper
            .Map<SPDto>(addedStatusProgram);
    }
    public IQueryable<SPDto> StateProgramSelectListAsync()
    {
        var statePrograms = this.stateProgramRepository
            .SelectAll()
            .Include(sp => sp.State);

        return statePrograms
            .Select(x => this.mapper.Map<SPDto>(x));
    }
    public async ValueTask<SPDto> DeleteStateProgramAsync(int id)
    {
        var storageStateProgram = await this.stateProgramRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
           .GenericValidation<StateProgram>(storageStateProgram, id);

        var removeSP = await this.stateProgramRepository
            .DeleteAsync(storageStateProgram);

        return this.mapper
            .Map<SPDto>(removeSP);
    }
}
