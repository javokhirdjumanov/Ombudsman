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

    public async ValueTask<SPDto> CreateAsync(SPDlDto dto)
    {
        var newStateProgram = this.mapper
            .Map<StateProgram>(dto);

        var addedStatusProgram = await this.stateProgramRepository
            .InsertAsync(newStateProgram);

        return this.mapper
            .Map<SPDto>(addedStatusProgram);
    }
    public IQueryable<SPDto> SelectList()
    {
        var statePrograms = this.stateProgramRepository
            .SelectAll()
            .Include(sp => sp.State);

        return statePrograms
            .Select(x => this.mapper.Map<SPDto>(x));
    }
    public async ValueTask<SPDto> SelectByIdAsync(int id)
    {
        var stateProgram = await this.stateProgramRepository
            .SelectByIdWithDetailsAsync(
            expression: st => st.Id == id,
            includes: new string[] {nameof(StateProgram.State) });

        return
            this.mapper.Map<SPDto>(stateProgram);
    }
    public async ValueTask<SPDto> UpdateAsync(SPModifyDlDto dto)
    {
        var storageSP = await this.stateProgramRepository.SelectByIdWithDetailsAsync(
            expression: s => s.Id == dto.Id,
            includes: new string[] { nameof(StateProgram.State) });

        ValidationStorageObj
            .GenericValidation<StateProgram>(storageSP, dto.Id);

        storageSP = this.mapper
            .Map<StateProgram>(storageSP);

        storageSP = await this.stateProgramRepository
            .UpdateAsync(storageSP);

        return this.mapper
            .Map<SPDto>(storageSP);

    }
    public async ValueTask<SPDto> DeleteAsync(int id)
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
