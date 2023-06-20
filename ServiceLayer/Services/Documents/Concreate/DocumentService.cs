using AutoMapper;
using DataLayer;
using DataLayer.Context;
using DataLayer.Repository;
using DomainLayer.Constants;
using DomainLayer.Entities;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;
using ServiceLayer.Services.Documents;
using ServiceLayer.Validations;

namespace ServiceLayer.Services;
public partial class DocumentService : IDocumentService
{
    private readonly IDocumentRepository documentRepository;
    private readonly IInformationLetterRepository informationLetterRepository;
    private readonly IVisaHolderRepository visaHolderRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IAuthServices authServices;
    public DocumentService(
        IDocumentRepository documentRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IInformationLetterRepository documentLetterRepository,
        IVisaHolderRepository visaHolderRepository,
        IAuthServices authServices)
    {
        this.documentRepository = documentRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.informationLetterRepository = documentLetterRepository;
        this.visaHolderRepository = visaHolderRepository;
        this.authServices = authServices;
    }

    public async ValueTask<int> CreateAsync(DocCreateDlDto cDto)
    {
        Document addedDocument;
        using var transaction = await this.unitOfWork.TransactionAsync();
        try
        {
            ValidateIfUserNotHavePermission(cDto);

            ValidateIfDocumentDesignedOrNot(cDto);

            var doc = this.mapper.Map<Document>(cDto);
            addedDocument = await this.documentRepository.InsertAsync(doc);

            foreach (var item in cDto.createVizaDlDto)
            {
                var newVisa = this.mapper
                    .Map<VisaHolders>(item);

                newVisa.DocumentId = addedDocument.Id;

                var addedVisa = await this.visaHolderRepository
                    .InsertAsync(newVisa);
            }

            ValidateIfDocumentMemorandum(cDto);

            var newInformationLetter = this.mapper
                .Map<InformationLetter>(cDto.createLetterDlDto);

            newInformationLetter.DocumentId = addedDocument.Id;

            newInformationLetter = await this.informationLetterRepository
                .InsertAsync(newInformationLetter);

            foreach (var item in cDto.createLetterDlDto!.createVizaDlDto)
            {
                var newVisa = this.mapper
                    .Map<VisaHolders>(item);

                newVisa.InformationLetterId = newInformationLetter.Id;

                var uploadedVisa = await this.visaHolderRepository
                    .InsertAsync(newVisa);
            }
        }
        catch(Exception)
        {
            await this.unitOfWork.Rolback();

            return -1;
        }
        await this.unitOfWork.Save();
        await this.unitOfWork.Commit();

        return addedDocument.Id;
    }
    public IQueryable<DocumentDto> SelectListAsync()
    {
        var documnets = this.documentRepository
            .SelectAll().Where(doc => doc.DocumentStatusId != StatusIds.DELETE);

        return documnets
            .Select(d => this.mapper.Map<DocumentDto>(d));
    }
    public async ValueTask<DocumentDto> SelectByIdAsync(int id)
    {
        var storageDocument = await this.documentRepository
        .SelectByIdWithDetailsAsync(
            expression: doc => doc.Id == id && doc.DocumentStatusId != StatusIds.DELETE,
            includes: new string[]
            {
                nameof(Document.InitiativeType),
                nameof(Document.File),
                $"{nameof(Document.NormativeDocument)}.{nameof(NormativeDocumentType.State)}",
                $"{nameof(Document.DocumentImportance)}.{nameof(DocumentImportance.State)}",
                $"{nameof(Document.StateProgram)}.{nameof(StateProgram.State)}",
                $"{nameof(Document.Sector)}.{nameof(Sector.State)}",
                $"{nameof(Document.Organization)}.{nameof(Organization.State)}",
                $"{nameof(Document.DocumentStatus)}.{nameof(DocumentStatus.Status)}",
                $"{nameof(Document.InformationLetters)}.{nameof(InformationLetter.StateProgram)}",
                $"{nameof(Document.InformationLetters)}.{nameof(InformationLetter.Employee)}",
                $"{nameof(Document.VisaHolders)}"
            });

        return this.mapper
            .Map<DocumentDto>(storageDocument);
    }
    public async ValueTask<DocumentDto> UpdateAsync(DocModDlDto docModDlDto)
    {
        var storageDocument = await this.documentRepository
        .SelectByIdWithDetailsAsync(
            expression: doc => doc.Id == docModDlDto.Id,
            includes: new string[]
            {
                $"{nameof(Document.DocumentImportance)}",
                $"{nameof(Document.StateProgram)}",
                $"{nameof(Document.Sector)}",
                $"{nameof(Document.OrginizationUser)}",
                $"{nameof(Document.InitiativeType)}",
                $"{nameof(Document.Organization)}",
                $"{nameof(Document.DocumentStatus)}",
                $"{nameof(Document.File)}",
                $"{nameof(Document.InformationLetters)}.{nameof(InformationLetter.Employee)}"
            });

        ValidationStorageObj
            .GenericValidation<Document>(storageDocument, docModDlDto.Id);

        var modifyDoc = await this.documentRepository
            .UpdateAsync(this.mapper.Map(docModDlDto, storageDocument));

        if (storageDocument.InformationLetters.Any())
        {
            var storageInfLetter = storageDocument.InformationLetters
                .FirstOrDefault(il => il.Id == docModDlDto.updateInfLetterDlDto.Id);

            ValidationStorageObj
                .GenericValidation<InformationLetter>(storageInfLetter, docModDlDto.updateInfLetterDlDto.Id);

            var modifyInfLetter = await this.informationLetterRepository
                .UpdateAsync(this.mapper.Map(docModDlDto.updateInfLetterDlDto, storageInfLetter));
        }

        return this.mapper
            .Map<DocumentDto>(modifyDoc);
    }
    public async ValueTask<int> DeleteAsync(int id)
    {
        var storageDocument = await this.documentRepository
            .SelectByIdAsync(id);

        ValidationStorageObj
            .GenericValidation<Document>(storageDocument, id);

        storageDocument.DocumentStatusId = StatusIds.DELETE;

        return id;
    }
    public async ValueTask<List<VizaHolderDto>> VisaViewersOfDocument(int documentId)
    {
        var storageDocument = await this.documentRepository
            .SelectByIdWithDetailsAsync(
            expression: doc => doc.Id == documentId && doc.DocumentStatusId != StatusIds.DELETE,
            includes: new string[] {nameof(Document.VisaHolders)});

        ValidationStorageObj
            .GenericValidation<Document>(storageDocument, documentId);

        var visas = storageDocument.VisaHolders;

        return visas
            .Select(vs => this.mapper.Map<VizaHolderDto>(vs))
            .ToList();
    }

    public IQueryable<function_model> SelectDocumentByOrganization(
        int organizationId,
        DateOnly from_date,
        DateOnly to_date)
    {
        return this.documentRepository
            .SelectDocumentByOrganization(organizationId, from_date, to_date);
    }
}
