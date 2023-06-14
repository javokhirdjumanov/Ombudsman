using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doc_file_model",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doc_file_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enum_initiative_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    names = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_initiative_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enum_language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    short_name = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enum_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "initiative_type_translates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    initiative_type_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_initiative_type_translates", x => x.id);
                    table.ForeignKey(
                        name: "fk_initiative_type_translates_enum_initiative_type_initiative_",
                        column: x => x.initiative_type_id,
                        principalTable: "enum_initiative_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_initiative_type_translates_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_country_organization",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_country_organization", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_country_organization_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_document_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_document_status", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_document_status_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_normative_document",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    short_character = table.Column<string>(type: "text", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_normative_document", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_normative_document_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_performer_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_performer_type", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_performer_type_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_status_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_status_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_status_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_status_translate_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_document_importance",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_document_importance", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_document_importance_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_sectors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sector_number = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_sectors", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_sectors_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_state_program",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_state_program", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_state_program_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_organization",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    state_organization_id = table.Column<int>(type: "integer", nullable: false),
                    is_grouper = table.Column<bool>(type: "boolean", nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_organization", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_organization_enum_country_organization_state_organizat",
                        column: x => x.state_organization_id,
                        principalTable: "enum_country_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_info_organization_enum_status_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_info_organization_info_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "info_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "state_organization_translates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    state_organization_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_state_organization_translates", x => x.id);
                    table.ForeignKey(
                        name: "fk_state_organization_translates_enum_country_organization_sta",
                        column: x => x.state_organization_id,
                        principalTable: "enum_country_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_state_organization_translates_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document_status_translates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_status_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_status_translates", x => x.id);
                    table.ForeignKey(
                        name: "fk_document_status_translates_enum_document_status_document_st",
                        column: x => x.document_status_id,
                        principalTable: "enum_document_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_document_status_translates_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "normative_document_type_translates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    normative_document_type_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_normative_document_type_translates", x => x.id);
                    table.ForeignKey(
                        name: "fk_normative_document_type_translates_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_normative_document_type_translates_enum_normative_document_",
                        column: x => x.normative_document_type_id,
                        principalTable: "enum_normative_document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "performer_type_translates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    performer_type_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_performer_type_translates", x => x.id);
                    table.ForeignKey(
                        name: "fk_performer_type_translates_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_performer_type_translates_enum_performer_type_performer_typ",
                        column: x => x.performer_type_id,
                        principalTable: "enum_performer_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doc_information_letter",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    information_letter_number = table.Column<int>(type: "integer", nullable: false),
                    information_letter_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    information_letter_text = table.Column<string>(type: "text", nullable: false),
                    state_program_id = table.Column<int>(type: "integer", nullable: false),
                    performers = table.Column<string>(type: "text", nullable: false),
                    responsible_employee = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doc_information_letter", x => x.id);
                    table.ForeignKey(
                        name: "fk_doc_information_letter_info_state_program_state_program_id",
                        column: x => x.state_program_id,
                        principalTable: "info_state_program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doc_documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    normative_document_id = table.Column<int>(type: "integer", nullable: false),
                    document_importance_id = table.Column<int>(type: "integer", nullable: false),
                    state_program_included = table.Column<bool>(type: "boolean", nullable: false),
                    state_program_id = table.Column<int>(type: "integer", nullable: true),
                    document_name = table.Column<string>(type: "text", nullable: true),
                    document_content = table.Column<string>(type: "text", nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    send_document_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    estimated_execution_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sector_id = table.Column<int>(type: "integer", nullable: true),
                    main_ministry = table.Column<string>(type: "text", nullable: true),
                    main_performer = table.Column<string>(type: "text", nullable: false),
                    initiative_type_id = table.Column<int>(type: "integer", nullable: false),
                    performers = table.Column<string>(type: "text", nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    document_status_id = table.Column<int>(type: "integer", nullable: false),
                    normative_doc_number = table.Column<int>(type: "integer", nullable: true),
                    normative_doc_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    information_letter_id = table.Column<int>(type: "integer", nullable: true),
                    file_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doc_documents", x => x.id);
                    table.ForeignKey(
                        name: "fk_doc_documents_doc_file_model_file_id",
                        column: x => x.file_id,
                        principalTable: "doc_file_model",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_doc_documents_doc_information_letter_information_letter_id",
                        column: x => x.information_letter_id,
                        principalTable: "doc_information_letter",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_doc_documents_enum_document_status_document_status_id",
                        column: x => x.document_status_id,
                        principalTable: "enum_document_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_documents_enum_initiative_type_initiative_type_id",
                        column: x => x.initiative_type_id,
                        principalTable: "enum_initiative_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_documents_enum_normative_document_normative_document_id",
                        column: x => x.normative_document_id,
                        principalTable: "enum_normative_document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_documents_info_document_importance_document_importance_",
                        column: x => x.document_importance_id,
                        principalTable: "info_document_importance",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_documents_info_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "info_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_documents_info_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "info_sectors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_doc_documents_info_state_program_state_program_id",
                        column: x => x.state_program_id,
                        principalTable: "info_state_program",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "doc_visa_holders_for_doc",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    information_letter_id = table.Column<int>(type: "integer", nullable: true),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    fio = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    responsible_employee = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_visa_addition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doc_visa_holders_for_doc", x => x.id);
                    table.ForeignKey(
                        name: "fk_doc_visa_holders_for_doc_doc_documents_document_id",
                        column: x => x.document_id,
                        principalTable: "doc_documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_visa_holders_for_doc_doc_information_letter_information",
                        column: x => x.information_letter_id,
                        principalTable: "doc_information_letter",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_doc_visa_holders_for_doc_info_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "info_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_document_importance_id",
                table: "doc_documents",
                column: "document_importance_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_document_status_id",
                table: "doc_documents",
                column: "document_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_file_id",
                table: "doc_documents",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_information_letter_id",
                table: "doc_documents",
                column: "information_letter_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_initiative_type_id",
                table: "doc_documents",
                column: "initiative_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_normative_document_id",
                table: "doc_documents",
                column: "normative_document_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_organization_id",
                table: "doc_documents",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_sector_id",
                table: "doc_documents",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_state_program_id",
                table: "doc_documents",
                column: "state_program_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_information_letter_state_program_id",
                table: "doc_information_letter",
                column: "state_program_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_visa_holders_for_doc_document_id",
                table: "doc_visa_holders_for_doc",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_visa_holders_for_doc_information_letter_id",
                table: "doc_visa_holders_for_doc",
                column: "information_letter_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_visa_holders_for_doc_organization_id",
                table: "doc_visa_holders_for_doc",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_status_translates_document_status_id",
                table: "document_status_translates",
                column: "document_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_status_translates_language_id",
                table: "document_status_translates",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_country_organization_status_id",
                table: "enum_country_organization",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_document_status_status_id",
                table: "enum_document_status",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_normative_document_status_id",
                table: "enum_normative_document",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_performer_type_status_id",
                table: "enum_performer_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_status_translate_language_id",
                table: "enum_status_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_status_translate_status_id",
                table: "enum_status_translate",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_document_importance_status_id",
                table: "info_document_importance",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_organization_organization_id",
                table: "info_organization",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_organization_state_organization_id",
                table: "info_organization",
                column: "state_organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_organization_status_id",
                table: "info_organization",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_sectors_status_id",
                table: "info_sectors",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_state_program_status_id",
                table: "info_state_program",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_initiative_type_translates_initiative_type_id",
                table: "initiative_type_translates",
                column: "initiative_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_initiative_type_translates_language_id",
                table: "initiative_type_translates",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_normative_document_type_translates_language_id",
                table: "normative_document_type_translates",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_normative_document_type_translates_normative_document_type_",
                table: "normative_document_type_translates",
                column: "normative_document_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_performer_type_translates_language_id",
                table: "performer_type_translates",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_performer_type_translates_performer_type_id",
                table: "performer_type_translates",
                column: "performer_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_state_organization_translates_language_id",
                table: "state_organization_translates",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_state_organization_translates_state_organization_id",
                table: "state_organization_translates",
                column: "state_organization_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doc_visa_holders_for_doc");

            migrationBuilder.DropTable(
                name: "document_status_translates");

            migrationBuilder.DropTable(
                name: "enum_status_translate");

            migrationBuilder.DropTable(
                name: "initiative_type_translates");

            migrationBuilder.DropTable(
                name: "normative_document_type_translates");

            migrationBuilder.DropTable(
                name: "performer_type_translates");

            migrationBuilder.DropTable(
                name: "state_organization_translates");

            migrationBuilder.DropTable(
                name: "doc_documents");

            migrationBuilder.DropTable(
                name: "enum_performer_type");

            migrationBuilder.DropTable(
                name: "enum_language");

            migrationBuilder.DropTable(
                name: "doc_file_model");

            migrationBuilder.DropTable(
                name: "doc_information_letter");

            migrationBuilder.DropTable(
                name: "enum_document_status");

            migrationBuilder.DropTable(
                name: "enum_initiative_type");

            migrationBuilder.DropTable(
                name: "enum_normative_document");

            migrationBuilder.DropTable(
                name: "info_document_importance");

            migrationBuilder.DropTable(
                name: "info_organization");

            migrationBuilder.DropTable(
                name: "info_sectors");

            migrationBuilder.DropTable(
                name: "info_state_program");

            migrationBuilder.DropTable(
                name: "enum_country_organization");

            migrationBuilder.DropTable(
                name: "enum_status");
        }
    }
}
