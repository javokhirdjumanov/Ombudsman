using DomainLayer.Entities;
using DomainLayer.Entities.DOC;
using DomainLayer.Entities.DOC.Files;
using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.HL;
using DomainLayer.Entities.INFO;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    /// <summary>
    /// DOCUMENT FILES
    /// </summary>
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<InformationLetter> InformationLetters { get; set; }
    public virtual DbSet<VisaHolders> VisaHoldersForDocs { get; set; }
    public virtual DbSet<FileModel> FileModels { get; set; }
    /// <summary>
    /// ENUM FILES
    /// </summary>
    public virtual DbSet<DocumentStatus> DocumentStatuses { get; set; }
    public virtual DbSet<InitiativeType> InitiativeTypes { get; set; }
    public virtual DbSet<NormativeDocumentType> NormativeDocumentTypes { get; set; }
    public virtual DbSet<PerformerType> PerformerTypes { get; set; }
    public virtual DbSet<StateOrganization> StateOrganizations { get; set; }
    public virtual DbSet<State> Statuses { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    /// <summary>
    /// ENUM TRANSLATE FILES
    /// </summary>
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<StateTranslate> StatusTranslates { get; set; }
    public virtual DbSet<DocumentStatusTranslate> DocumentStatusTranslates { get; set; }
    public virtual DbSet<InitiativeTypeTranslate> InitiativeTypeTranslates { get; set; }
    public virtual DbSet<NormativeDocumentTypeTranslate> NormativeDocumentTypeTranslates { get; set; }
    public virtual DbSet<PerformerTypeTranslate> PerformerTypeTranslates { get; set; }
    public virtual DbSet<StateOrganizationTranslate> StateOrganizationTranslates { get; set; }

    /// <summary>
    /// INFO FILES
    /// </summary>
    public virtual DbSet<DocumentImportance> DocumentImportances { get; set; }
    public virtual DbSet<Organization> Organizations { get; set; }
    public virtual DbSet<Sectors> Sectors { get; set; }
    public virtual DbSet<StateProgram> StatePrograms { get; set; }

    /// <summary>
    /// HL FILES
    /// </summary>
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
}
