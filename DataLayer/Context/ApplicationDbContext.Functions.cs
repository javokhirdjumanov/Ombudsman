using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Context;
public partial class ApplicationDbContext
{
    [DbFunction("get_documents_by_organization", Schema = "public")]
    public IQueryable<function_model> SelectDocumentByOrganization(
        int organizationId, DateOnly from_date, DateOnly to_date)
        => FromExpression(() => SelectDocumentByOrganization(organizationId, from_date, to_date));
}
[Keyless]
public class function_model
{
    [Column("id")]
    public int Id { get; set; }

    [Column("order_number")]
    public int OrderNumber { get; set; }

    [Column("normative_full_name")]
    public string NormativeFullName { get; set; }

    [Column("document_importance_full_name")]
    public string DocumentImportanceFullName { get; set; }

    [Column("state_program_included")]
    public bool StateProgramIncluded { get; set; }

    [Column("state_program_full_name")]
    public string StateProgramFullName { get; set; }

    [Column("document_name")]
    public string DocumentName { get; set; }

    [Column("document_content")]
    public string DocumentContent { get; set; }

    [Column("create_at")]
    public DateTime CreatedAt { get; set; }

    [Column("send_document_data")]
    public DateTime SendDocumentData { get; set; }

    [Column("estimated_execution_time")]
    public DateTime EstimatedExecutionTime { get; set; }

    [Column("sector_full_name")]
    public string SectorFullName { get; set; }

    [Column("main_ministry")]
    public string MainMinistry { get; set; }

    [Column("orginization_user_full_name")]
    public string UserFullName { get; set; }

    [Column("initiative_type_name")]
    public string InitiativeTypeName { get; set; }

    [Column("performers")]
    public string Performs { get; set; }

    [Column("organization_name")]
    public string OrganizationName { get; set; }

    [Column("document_status_name")]
    public string DocumentStatusName { get; set; }

    [Column("normative_doc_number")]
    public int NormativeDocumentNumber { get; set; }

    [Column("normative_doc_date")]
    public DateTime NormativeDocumentDate { get; set; }

    [Column("file_name")]
    public string FileName { get; set; }
}
