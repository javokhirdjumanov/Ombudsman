using DataLayer;
using DataLayer.Repository;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Extantions;
using ServiceLayer.Validations;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace ServiceLayer.Services;
public class StateProgramService : IStateProgramService
{
    private readonly IStateProgramRepository stateProgramRepository;
    private readonly IUnitOfWork unitOfWork;
    public StateProgramService(
        IStateProgramRepository stateProgramRepository,
        IUnitOfWork unitOfWork)
    {
        this.stateProgramRepository = stateProgramRepository;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<SPDto> CreateStateProgramAsync(SPDlDto spDlDto)
    {
        spDlDto.status_id.IsDefault();

        var storageStatus = await this.unitOfWork.context.Statuses
            .FirstOrDefaultAsync(x => x.Id == spDlDto.status_id);

        ValidationStorageObj
            .GenericValidation<Status>(storageStatus, spDlDto.status_id);

        var newStateProgram = new StateProgram
        {
            OrderNumber = spDlDto.order_number,
            ShortName = spDlDto.short_name,
            FullName = spDlDto.full_name,
            Status = storageStatus
        };

        var addedStatusProgram = await this.stateProgramRepository
            .InsertAsync(newStateProgram);

        return new SPDto(
            addedStatusProgram.Id,
            addedStatusProgram.OrderNumber,
            addedStatusProgram.ShortName,
            addedStatusProgram.FullName,
            new SDto(spDlDto.status_id, addedStatusProgram.Status.Name));
    }
    public IQueryable<SPDto> GetListStateProgramAsync()
    {
        var statePrograms = this.stateProgramRepository
            .SelectAll()
            .Include(sp => sp.Status)
            .Where(sp => sp.StatusId != 3);

        return statePrograms
            .Select(sp =>
            new SPDto(sp.Id, sp.OrderNumber, sp.ShortName, sp.FullName, new SDto(sp.Status.Id, sp.Status.Name)));
    }
    public async ValueTask<SPDto> DeleteStateProgramAsync(int id)
    {
        id.IsDefault();

        var storageStateProgram = await this.stateProgramRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
           .GenericValidation<StateProgram>(storageStateProgram, id);

        var deleteStatusObj = this.unitOfWork.context.Statuses.FirstOrDefault(x => x.Id == 3);

        storageStateProgram.Status = deleteStatusObj;

        var updateStateProgram = await this.stateProgramRepository
            .UpdateAsync(storageStateProgram);

        return new SPDto(
           updateStateProgram.Id,
           updateStateProgram.OrderNumber,
           updateStateProgram.ShortName,
           updateStateProgram.FullName,
           new SDto(deleteStatusObj.Id, deleteStatusObj.Name));
    }
}
