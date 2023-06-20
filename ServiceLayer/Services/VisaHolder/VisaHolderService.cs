using AutoMapper;
using DataLayer;
using DataLayer.Repository;
using DomainLayer.Constants;
using DomainLayer.Entities.DOC;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public class VisaHolderService : IVisaHolderService
{
    private readonly IVisaHolderRepository visaHolderRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public VisaHolderService(IVisaHolderRepository visaHolderRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.visaHolderRepository = visaHolderRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<int> CreateAsync(CreateVizaDlDto dto)
    {
        if ((dto.documentId is not null && dto.informationLetterId is not null)
            || (dto.documentId is null && dto.informationLetterId is null))
        {
            throw new Exception("You can only create visa holders for one model !");
        }

        var newVisaHolder = this.mapper
            .Map<VisaHolders>(dto);

        newVisaHolder = await this.visaHolderRepository
            .InsertAsync(newVisaHolder);

        return newVisaHolder.Id;
    }
    public IQueryable<VizaHolderDto> SelectList()
    {
        var visaHolders = this.visaHolderRepository
            .SelectAll()
            .Include(v => v.Document)
            .Include(v => v.InformationLetter)
            .Include(v => v.Organization);

        return visaHolders
            .Select(vh => this.mapper.Map<VizaHolderDto>(vh));
    }
    public async ValueTask<VizaHolderDto> SelectByIdAsync(int id)
    {
        var storageVisa = await this.visaHolderRepository
            .SelectByIdWithDetailsAsync(
            expression: vs => vs.Id == id,
            includes: new string[]
            {
                nameof(VisaHolders.Document),
                nameof(VisaHolders.InformationLetter),
                nameof(VisaHolders.Organization)
            });

        ValidationStorageObj
            .GenericValidation<VisaHolders>(storageVisa, id);

        return this.mapper
            .Map<VizaHolderDto>(storageVisa);
    }
    public async ValueTask<VizaHolderDto> UpdateAsync(UpdateVizaDlDto dto, int? docId, int? infId)
    {
        var storageVisa = await this.visaHolderRepository
            .SelectByIdWithDetailsAsync(
            expression: vs => vs.Id == dto.Id
                                    && ((vs.DocumentId == docId && vs.Document.DocumentStatusId != StatusIds.DELETE)
                                    || vs.InformationLetterId == infId),
            includes: new string[] { nameof(VisaHolders.Document) });

        ValidationStorageObj
            .GenericValidation<VisaHolders>(storageVisa, dto.Id);

        var changedVisa = this.mapper
            .Map(dto, storageVisa);

        changedVisa = await this.visaHolderRepository
            .UpdateAsync(changedVisa);

        return this.mapper
            .Map<VizaHolderDto>(changedVisa);
    }
    public async ValueTask<VizaHolderDto> DeleteAsync(int id, int? docId, int? infId)
    {
        var storageVisa = await this.visaHolderRepository
            .SelectByIdWithDetailsAsync(
            expression: vs => vs.Id == id
                             && ((vs.DocumentId == docId && vs.Document.DocumentStatusId != StatusIds.DELETE) 
                             || vs.InformationLetterId == infId),
            includes: new string[] {nameof(Document.DocumentStatus)});

        ValidationStorageObj
            .GenericValidation<VisaHolders>(storageVisa, id);

        storageVisa = await this.visaHolderRepository
            .DeleteAsync(storageVisa);

        return this.mapper
            .Map<VizaHolderDto>(storageVisa);
    }
}