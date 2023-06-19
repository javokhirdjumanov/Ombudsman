using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.HL;
using DomainLayer.Entities.INFO;
using ServiceLayer.Services.Documents;

namespace ServiceLayer.Services;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region document mapping

        CreateMap<DocCreateDlDto, Document>();
        CreateMap<CreateInfLetterDlDto, InformationLetter>();
        CreateMap<CreateVizaDlDto, VisaHolders>();

        CreateMap<DocModDlDto, Document>();
        CreateMap<UpdateInfLetterDlDto, InformationLetter>();
        CreateMap<UpdateVizaDlDto, VisaHolders>();

        CreateMap<Document, DocumentDto>();
        CreateMap<InformationLetter, InformationLetterDto>();
        CreateMap<VisaHolders, VizaHolderDto>();
        #endregion
        
        #region user mapping

        CreateMap<User, UserDto>()
            .ForMember(u => u.organization, cfg => cfg.MapFrom(u => u.Organization.FullName));

        CreateMap<UserCreateDlDto, User>();

        CreateMap<UserModifyDlDto, User>();

        #endregion

        #region employee mapping
        CreateMap<EmpCreateDlDto, Employee>();
        CreateMap<Employee, EmpDto>();
        CreateMap<EmpUpdateDlDto, Employee>();
        CreateMap<Employee, EmpUpdateDlDto>();
        #endregion

        #region manual mapping
        CreateMap<DocumentStatus, DocStatusDto>();
        CreateMap<NormativeDocumentType, NormativeDocTypeDto>();
        CreateMap<InitiativeType, InitiativeTypeDto>();
        CreateMap<PerformerType, PerformerTypeDto>();
        CreateMap<StateOrganization, StateOrganizationDto>();
        CreateMap<DocumentImportance, DocumentImportanceDto>();
        CreateMap<UserRole, UserRoleDto>();
        CreateMap<Language, LanguageDto>();
        #endregion

        #region organization mapping
        CreateMap<OrgDlDto, Organization>();
        CreateMap<OrgDlDtoForModify, Organization>();
        CreateMap<Organization, OrgDto>();
        #endregion

        #region state programm mapping
        CreateMap<SPDlDto, StateProgram>();
        CreateMap<StateProgram, SPDto>();
        #endregion

        #region sectors mapping
        CreateMap<SectorDlDto, Sector>();
        CreateMap<SectorUpdateDlDto, Sector>();
        CreateMap<Sector, SectorDto>();
        #endregion

        #region status mapping
        CreateMap<State, StateDto>();
        #endregion
    }
}
