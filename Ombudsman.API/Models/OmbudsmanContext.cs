using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ombudsman.API.Models
{
    public partial class OmbudsmanContext : DbContext
    {
        public OmbudsmanContext()
        {
        }

        public OmbudsmanContext(DbContextOptions<OmbudsmanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocDocument> DocDocuments { get; set; } = null!;
        public virtual DbSet<DocFileModel> DocFileModels { get; set; } = null!;
        public virtual DbSet<DocInformationLetter> DocInformationLetters { get; set; } = null!;
        public virtual DbSet<DocVisaHoldersForDoc> DocVisaHoldersForDocs { get; set; } = null!;
        public virtual DbSet<EnumDocumentStatus> EnumDocumentStatuses { get; set; } = null!;
        public virtual DbSet<EnumDocumentStatusTranslate> EnumDocumentStatusTranslates { get; set; } = null!;
        public virtual DbSet<EnumInitiativeType> EnumInitiativeTypes { get; set; } = null!;
        public virtual DbSet<EnumInitiativeTypeTranslate> EnumInitiativeTypeTranslates { get; set; } = null!;
        public virtual DbSet<EnumLanguage> EnumLanguages { get; set; } = null!;
        public virtual DbSet<EnumNormativeDocument> EnumNormativeDocuments { get; set; } = null!;
        public virtual DbSet<EnumNormativeDocumentTranslate> EnumNormativeDocumentTranslates { get; set; } = null!;
        public virtual DbSet<EnumPerformerType> EnumPerformerTypes { get; set; } = null!;
        public virtual DbSet<EnumPerformerTypeTranslate> EnumPerformerTypeTranslates { get; set; } = null!;
        public virtual DbSet<EnumStateOrganization> EnumStateOrganizations { get; set; } = null!;
        public virtual DbSet<EnumStateOrganizationTranslate> EnumStateOrganizationTranslates { get; set; } = null!;
        public virtual DbSet<EnumStatus> EnumStatuses { get; set; } = null!;
        public virtual DbSet<EnumStatusTranslate> EnumStatusTranslates { get; set; } = null!;
        public virtual DbSet<EnumUserRole> EnumUserRoles { get; set; } = null!;
        public virtual DbSet<HlUser> HlUsers { get; set; } = null!;
        public virtual DbSet<InfoDocumentImportance> InfoDocumentImportances { get; set; } = null!;
        public virtual DbSet<InfoOrganization> InfoOrganizations { get; set; } = null!;
        public virtual DbSet<InfoSector> InfoSectors { get; set; } = null!;
        public virtual DbSet<InfoStateProgram> InfoStatePrograms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=Ombudsman;Username=postgres;Password=0803");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocDocument>(entity =>
            {
                entity.ToTable("doc_documents");

                entity.HasIndex(e => e.DocumentImportanceId, "ix_doc_documents_document_importance_id");

                entity.HasIndex(e => e.DocumentStatusId, "ix_doc_documents_document_status_id");

                entity.HasIndex(e => e.FileId, "ix_doc_documents_file_id");

                entity.HasIndex(e => e.InformationLetterId, "ix_doc_documents_information_letter_id");

                entity.HasIndex(e => e.InitiativeTypeId, "ix_doc_documents_initiative_type_id");

                entity.HasIndex(e => e.NormativeDocumentId, "ix_doc_documents_normative_document_id");

                entity.HasIndex(e => e.OrganizationId, "ix_doc_documents_organization_id");

                entity.HasIndex(e => e.OrginizationUserId, "ix_doc_documents_orginization_user_id");

                entity.HasIndex(e => e.SectorId, "ix_doc_documents_sector_id");

                entity.HasIndex(e => e.StateProgramId, "ix_doc_documents_state_program_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.DocumentContent).HasColumnName("document_content");

                entity.Property(e => e.DocumentImportanceId).HasColumnName("document_importance_id");

                entity.Property(e => e.DocumentName).HasColumnName("document_name");

                entity.Property(e => e.DocumentStatusId).HasColumnName("document_status_id");

                entity.Property(e => e.EstimatedExecutionTime).HasColumnName("estimated_execution_time");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.InformationLetterId).HasColumnName("information_letter_id");

                entity.Property(e => e.InitiativeTypeId).HasColumnName("initiative_type_id");

                entity.Property(e => e.MainMinistry).HasColumnName("main_ministry");

                entity.Property(e => e.NormativeDocDate).HasColumnName("normative_doc_date");

                entity.Property(e => e.NormativeDocNumber).HasColumnName("normative_doc_number");

                entity.Property(e => e.NormativeDocumentId).HasColumnName("normative_document_id");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.OrginizationUserId).HasColumnName("orginization_user_id");

                entity.Property(e => e.Performers).HasColumnName("performers");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.SendDocumentData).HasColumnName("send_document_data");

                entity.Property(e => e.StateProgramId).HasColumnName("state_program_id");

                entity.Property(e => e.StateProgramIncluded).HasColumnName("state_program_included");

                entity.HasOne(d => d.DocumentImportance)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.DocumentImportanceId)
                    .HasConstraintName("fk_doc_documents_info_document_importance_document_importance_");

                entity.HasOne(d => d.DocumentStatus)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.DocumentStatusId)
                    .HasConstraintName("fk_doc_documents_enum_document_status_document_status_id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("fk_doc_documents_doc_file_model_file_id");

                entity.HasOne(d => d.InformationLetter)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.InformationLetterId)
                    .HasConstraintName("fk_doc_documents_doc_information_letter_information_letter_id");

                entity.HasOne(d => d.InitiativeType)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.InitiativeTypeId)
                    .HasConstraintName("fk_doc_documents_enum_initiative_type_initiative_type_id");

                entity.HasOne(d => d.NormativeDocument)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.NormativeDocumentId)
                    .HasConstraintName("fk_doc_documents_enum_normative_document_normative_document_id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("fk_doc_documents_info_organization_organization_id");

                entity.HasOne(d => d.OrginizationUser)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.OrginizationUserId)
                    .HasConstraintName("fk_doc_documents_hl_user_orginization_user_id");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("fk_doc_documents_info_sectors_sector_id");

                entity.HasOne(d => d.StateProgram)
                    .WithMany(p => p.DocDocuments)
                    .HasForeignKey(d => d.StateProgramId)
                    .HasConstraintName("fk_doc_documents_info_state_program_state_program_id");
            });

            modelBuilder.Entity<DocFileModel>(entity =>
            {
                entity.ToTable("doc_file_model");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName).HasColumnName("file_name");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<DocInformationLetter>(entity =>
            {
                entity.ToTable("doc_information_letter");

                entity.HasIndex(e => e.EmployeeId, "ix_doc_information_letter_employee_id");

                entity.HasIndex(e => e.StateProgramId, "ix_doc_information_letter_state_program_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InformationLetterDate).HasColumnName("information_letter_date");

                entity.Property(e => e.InformationLetterNumber).HasColumnName("information_letter_number");

                entity.Property(e => e.InformationLetterText).HasColumnName("information_letter_text");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.ResponsibleEmployee).HasColumnName("responsible_employee");

                entity.Property(e => e.StateProgramId).HasColumnName("state_program_id");

                entity.Property(e => e.VisaHolder).HasColumnName("visa_holder");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DocInformationLetters)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_doc_information_letter_hl_user_employee_id");

                entity.HasOne(d => d.StateProgram)
                    .WithMany(p => p.DocInformationLetters)
                    .HasForeignKey(d => d.StateProgramId)
                    .HasConstraintName("fk_doc_information_letter_info_state_program_state_program_id");
            });

            modelBuilder.Entity<DocVisaHoldersForDoc>(entity =>
            {
                entity.ToTable("doc_visa_holders_for_doc");

                entity.HasIndex(e => e.DocumentId, "ix_doc_visa_holders_for_doc_document_id");

                entity.HasIndex(e => e.InformationLetterId, "ix_doc_visa_holders_for_doc_information_letter_id");

                entity.HasIndex(e => e.OrganizationId, "ix_doc_visa_holders_for_doc_organization_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.DateVisaAddition).HasColumnName("date_visa_addition");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.Fio).HasColumnName("fio");

                entity.Property(e => e.InformationLetterId).HasColumnName("information_letter_id");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.ResponsibleEmployee).HasColumnName("responsible_employee");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocVisaHoldersForDocs)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("fk_doc_visa_holders_for_doc_doc_documents_document_id");

                entity.HasOne(d => d.InformationLetter)
                    .WithMany(p => p.DocVisaHoldersForDocs)
                    .HasForeignKey(d => d.InformationLetterId)
                    .HasConstraintName("fk_doc_visa_holders_for_doc_doc_information_letter_information");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.DocVisaHoldersForDocs)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("fk_doc_visa_holders_for_doc_info_organization_organization_id");
            });

            modelBuilder.Entity<EnumDocumentStatus>(entity =>
            {
                entity.ToTable("enum_document_status");

                entity.HasIndex(e => e.StatusId, "ix_enum_document_status_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.EnumDocumentStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_enum_document_status_enum_status_status_id");
            });

            modelBuilder.Entity<EnumDocumentStatusTranslate>(entity =>
            {
                entity.ToTable("enum_document_status_translate");

                entity.HasIndex(e => e.DocumentStatusId, "ix_enum_document_status_translate_document_status_id");

                entity.HasIndex(e => e.LanguageId, "ix_enum_document_status_translate_language_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.DocumentStatusId).HasColumnName("document_status_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.TranslateText).HasColumnName("translate_text");

                entity.HasOne(d => d.DocumentStatus)
                    .WithMany(p => p.EnumDocumentStatusTranslates)
                    .HasForeignKey(d => d.DocumentStatusId)
                    .HasConstraintName("fk_enum_document_status_translate_enum_document_status_documen");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumDocumentStatusTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_enum_document_status_translate_enum_language_language_id");
            });

            modelBuilder.Entity<EnumInitiativeType>(entity =>
            {
                entity.ToTable("enum_initiative_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Names).HasColumnName("names");
            });

            modelBuilder.Entity<EnumInitiativeTypeTranslate>(entity =>
            {
                entity.ToTable("enum_initiative_type_translate");

                entity.HasIndex(e => e.InitiativeTypeId, "ix_enum_initiative_type_translate_initiative_type_id");

                entity.HasIndex(e => e.LanguageId, "ix_enum_initiative_type_translate_language_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.InitiativeTypeId).HasColumnName("initiative_type_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.TranslateText).HasColumnName("translate_text");

                entity.HasOne(d => d.InitiativeType)
                    .WithMany(p => p.EnumInitiativeTypeTranslates)
                    .HasForeignKey(d => d.InitiativeTypeId)
                    .HasConstraintName("fk_enum_initiative_type_translate_enum_initiative_type_initiat");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumInitiativeTypeTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_enum_initiative_type_translate_enum_language_language_id");
            });

            modelBuilder.Entity<EnumLanguage>(entity =>
            {
                entity.ToTable("enum_language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.ShortName).HasColumnName("short_name");
            });

            modelBuilder.Entity<EnumNormativeDocument>(entity =>
            {
                entity.ToTable("enum_normative_document");

                entity.HasIndex(e => e.StatusId, "ix_enum_normative_document_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ShortCharacter).HasColumnName("short_character");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.EnumNormativeDocuments)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_enum_normative_document_enum_status_status_id");
            });

            modelBuilder.Entity<EnumNormativeDocumentTranslate>(entity =>
            {
                entity.ToTable("enum_normative_document_translate");

                entity.HasIndex(e => e.LanguageId, "ix_enum_normative_document_translate_language_id");

                entity.HasIndex(e => e.NormativeDocumentTypeId, "ix_enum_normative_document_translate_normative_document_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.NormativeDocumentTypeId).HasColumnName("normative_document_type_id");

                entity.Property(e => e.TranslateText).HasColumnName("translate_text");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumNormativeDocumentTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_enum_normative_document_translate_enum_language_language_id");

                entity.HasOne(d => d.NormativeDocumentType)
                    .WithMany(p => p.EnumNormativeDocumentTranslates)
                    .HasForeignKey(d => d.NormativeDocumentTypeId)
                    .HasConstraintName("fk_enum_normative_document_translate_enum_normative_document_n");
            });

            modelBuilder.Entity<EnumPerformerType>(entity =>
            {
                entity.ToTable("enum_performer_type");

                entity.HasIndex(e => e.StatusId, "ix_enum_performer_type_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.EnumPerformerTypes)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_enum_performer_type_enum_status_status_id");
            });

            modelBuilder.Entity<EnumPerformerTypeTranslate>(entity =>
            {
                entity.ToTable("enum_performer_type_translate");

                entity.HasIndex(e => e.LanguageId, "ix_enum_performer_type_translate_language_id");

                entity.HasIndex(e => e.PerformerTypeId, "ix_enum_performer_type_translate_performer_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.PerformerTypeId).HasColumnName("performer_type_id");

                entity.Property(e => e.TranslateText).HasColumnName("translate_text");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumPerformerTypeTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_enum_performer_type_translate_enum_language_language_id");

                entity.HasOne(d => d.PerformerType)
                    .WithMany(p => p.EnumPerformerTypeTranslates)
                    .HasForeignKey(d => d.PerformerTypeId)
                    .HasConstraintName("fk_enum_performer_type_translate_enum_performer_type_performer");
            });

            modelBuilder.Entity<EnumStateOrganization>(entity =>
            {
                entity.ToTable("enum_state_organization");

                entity.HasIndex(e => e.StatusId, "ix_enum_state_organization_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.EnumStateOrganizations)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_enum_state_organization_enum_status_status_id");
            });

            modelBuilder.Entity<EnumStateOrganizationTranslate>(entity =>
            {
                entity.ToTable("enum_state_organization_translate");

                entity.HasIndex(e => e.LanguageId, "ix_enum_state_organization_translate_language_id");

                entity.HasIndex(e => e.StateOrganizationId, "ix_enum_state_organization_translate_state_organization_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.StateOrganizationId).HasColumnName("state_organization_id");

                entity.Property(e => e.TranslateText).HasColumnName("translate_text");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumStateOrganizationTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_enum_state_organization_translate_enum_language_language_id");

                entity.HasOne(d => d.StateOrganization)
                    .WithMany(p => p.EnumStateOrganizationTranslates)
                    .HasForeignKey(d => d.StateOrganizationId)
                    .HasConstraintName("fk_enum_state_organization_translate_enum_state_organization_s");
            });

            modelBuilder.Entity<EnumStatus>(entity =>
            {
                entity.ToTable("enum_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<EnumStatusTranslate>(entity =>
            {
                entity.ToTable("enum_status_translate");

                entity.HasIndex(e => e.LanguageId, "ix_enum_status_translate_language_id");

                entity.HasIndex(e => e.StatusId, "ix_enum_status_translate_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TranslateText).HasColumnName("translate_text");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumStatusTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_enum_status_translate_enum_language_language_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.EnumStatusTranslates)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_enum_status_translate_enum_status_status_id");
            });

            modelBuilder.Entity<EnumUserRole>(entity =>
            {
                entity.ToTable("enum_user_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<HlUser>(entity =>
            {
                entity.ToTable("hl_user");

                entity.HasIndex(e => e.LanguageId, "ix_hl_user_language_id");

                entity.HasIndex(e => e.OrganizationId, "ix_hl_user_organization_id");

                entity.HasIndex(e => e.RoleId, "ix_hl_user_role_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Fio).HasColumnName("fio");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.RefreshToken).HasColumnName("refresh_token");

                entity.Property(e => e.RefreshTokenExpiredDate).HasColumnName("refresh_token_expired_date");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Salt).HasColumnName("salt");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.HlUsers)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_hl_user_enum_language_language_id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.HlUsers)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("fk_hl_user_info_organization_organization_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.HlUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_hl_user_enum_user_role_role_id");
            });

            modelBuilder.Entity<InfoDocumentImportance>(entity =>
            {
                entity.ToTable("info_document_importance");

                entity.HasIndex(e => e.StatusId, "ix_info_document_importance_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.InfoDocumentImportances)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_info_document_importance_enum_status_status_id");
            });

            modelBuilder.Entity<InfoOrganization>(entity =>
            {
                entity.ToTable("info_organization");

                entity.HasIndex(e => e.OrganizationId, "ix_info_organization_organization_id");

                entity.HasIndex(e => e.StateOrganizationId, "ix_info_organization_state_organization_id");

                entity.HasIndex(e => e.StatusId, "ix_info_organization_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.IsGrouper).HasColumnName("is_grouper");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StateOrganizationId).HasColumnName("state_organization_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.InverseOrganization)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("fk_info_organization_info_organization_organization_id");

                entity.HasOne(d => d.StateOrganization)
                    .WithMany(p => p.InfoOrganizations)
                    .HasForeignKey(d => d.StateOrganizationId)
                    .HasConstraintName("fk_info_organization_enum_state_organization_state_organizatio");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.InfoOrganizations)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_info_organization_enum_status_status_id");
            });

            modelBuilder.Entity<InfoSector>(entity =>
            {
                entity.ToTable("info_sectors");

                entity.HasIndex(e => e.StatusId, "ix_info_sectors_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.SectorNumber).HasColumnName("sector_number");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.InfoSectors)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_info_sectors_enum_status_status_id");
            });

            modelBuilder.Entity<InfoStateProgram>(entity =>
            {
                entity.ToTable("info_state_program");

                entity.HasIndex(e => e.StatusId, "ix_info_state_program_status_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ShortName).HasColumnName("short_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.InfoStatePrograms)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_info_state_program_enum_status_status_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
