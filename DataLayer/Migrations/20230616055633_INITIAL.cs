using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class INITIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

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
                    id = table.Column<int>(type: "integer", nullable: false),
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
                name: "enum_state",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enum_user_role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_user_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enum_initiative_type_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_initiative_type_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_initiative_type_translate_enum_initiative_type_owner_id",
                        column: x => x.owner_id,
                        principalTable: "enum_initiative_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_initiative_type_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_document_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_document_status", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_document_status_enum_state_status_id",
                        column: x => x.status_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_normative_document",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    short_character = table.Column<string>(type: "text", nullable: false),
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_normative_document", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_normative_document_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_performer_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_performer_type", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_performer_type_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_state_organization",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_state_organization", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_state_organization_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_state_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_state_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_state_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_state_translate_enum_state_owner_id",
                        column: x => x.owner_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_document_importance",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_document_importance", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_document_importance_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
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
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_sectors", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_sectors_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_state_program",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_state_program", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_state_program_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_document_status_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_document_status_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_document_status_translate_enum_document_status_owner_id",
                        column: x => x.owner_id,
                        principalTable: "enum_document_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_document_status_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_normative_document_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_normative_document_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_normative_document_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_normative_document_translate_enum_normative_document_o",
                        column: x => x.owner_id,
                        principalTable: "enum_normative_document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_performer_type_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_performer_type_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_performer_type_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_performer_type_translate_enum_performer_type_owner_id",
                        column: x => x.owner_id,
                        principalTable: "enum_performer_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enum_state_organization_translate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    column_name = table.Column<string>(type: "text", nullable: false),
                    translate_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enum_state_organization_translate", x => x.id);
                    table.ForeignKey(
                        name: "fk_enum_state_organization_translate_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enum_state_organization_translate_enum_state_organization_o",
                        column: x => x.owner_id,
                        principalTable: "enum_state_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_organization",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    state_organization_ids = table.Column<int>(type: "integer", nullable: false),
                    is_grouper = table.Column<bool>(type: "boolean", nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: true),
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_info_organization", x => x.id);
                    table.ForeignKey(
                        name: "fk_info_organization_enum_state_organization_state_organizatio",
                        column: x => x.state_organization_ids,
                        principalTable: "enum_state_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_info_organization_enum_state_state_id",
                        column: x => x.state_id,
                        principalTable: "enum_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_info_organization_info_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "info_organization",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hl_employee",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fio = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    salary = table.Column<double>(type: "double precision", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hl_employee", x => x.id);
                    table.ForeignKey(
                        name: "fk_hl_employee_info_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "info_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hl_user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fio = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    salt = table.Column<string>(type: "text", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    refresh_token_expired_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hl_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_hl_user_enum_language_language_id",
                        column: x => x.language_id,
                        principalTable: "enum_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_hl_user_enum_user_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "enum_user_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_hl_user_info_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "info_organization",
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
                    visa_holder = table.Column<string>(type: "text", nullable: false),
                    information_letter_text = table.Column<string>(type: "text", nullable: false),
                    state_program_id = table.Column<int>(type: "integer", nullable: false),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    responsible_employee = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doc_information_letter", x => x.id);
                    table.ForeignKey(
                        name: "fk_doc_information_letter_hl_user_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "public",
                        principalTable: "hl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_information_letter_info_state_program_state_program_id",
                        column: x => x.state_program_id,
                        principalSchema: "public",
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
                    orginization_user_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "fk_doc_documents_hl_user_orginization_user_id",
                        column: x => x.orginization_user_id,
                        principalSchema: "public",
                        principalTable: "hl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doc_documents_info_document_importance_document_importance_",
                        column: x => x.document_importance_id,
                        principalSchema: "public",
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
                        principalSchema: "public",
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
                name: "ix_doc_documents_orginization_user_id",
                table: "doc_documents",
                column: "orginization_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_sector_id",
                table: "doc_documents",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_state_program_id",
                table: "doc_documents",
                column: "state_program_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_information_letter_employee_id",
                table: "doc_information_letter",
                column: "employee_id");

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
                name: "ix_enum_document_status_status_id",
                table: "enum_document_status",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_document_status_translate_language_id",
                table: "enum_document_status_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_document_status_translate_owner_id",
                table: "enum_document_status_translate",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_initiative_type_translate_language_id",
                table: "enum_initiative_type_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_initiative_type_translate_owner_id",
                table: "enum_initiative_type_translate",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_normative_document_state_id",
                table: "enum_normative_document",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_normative_document_translate_language_id",
                table: "enum_normative_document_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_normative_document_translate_owner_id",
                table: "enum_normative_document_translate",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_performer_type_state_id",
                table: "enum_performer_type",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_performer_type_translate_language_id",
                table: "enum_performer_type_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_performer_type_translate_owner_id",
                table: "enum_performer_type_translate",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_state_organization_state_id",
                table: "enum_state_organization",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_state_organization_translate_language_id",
                table: "enum_state_organization_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_state_organization_translate_owner_id",
                table: "enum_state_organization_translate",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_state_translate_language_id",
                table: "enum_state_translate",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_enum_state_translate_owner_id",
                table: "enum_state_translate",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_hl_employee_organization_id",
                schema: "public",
                table: "hl_employee",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_hl_user_language_id",
                schema: "public",
                table: "hl_user",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_hl_user_organization_id",
                schema: "public",
                table: "hl_user",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_hl_user_role_id",
                schema: "public",
                table: "hl_user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_document_importance_state_id",
                schema: "public",
                table: "info_document_importance",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_organization_organization_id",
                table: "info_organization",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_organization_state_id",
                table: "info_organization",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_organization_state_organization_ids",
                table: "info_organization",
                column: "state_organization_ids");

            migrationBuilder.CreateIndex(
                name: "ix_info_sectors_state_id",
                table: "info_sectors",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "ix_info_state_program_state_id",
                schema: "public",
                table: "info_state_program",
                column: "state_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doc_visa_holders_for_doc");

            migrationBuilder.DropTable(
                name: "enum_document_status_translate");

            migrationBuilder.DropTable(
                name: "enum_initiative_type_translate");

            migrationBuilder.DropTable(
                name: "enum_normative_document_translate");

            migrationBuilder.DropTable(
                name: "enum_performer_type_translate");

            migrationBuilder.DropTable(
                name: "enum_state_organization_translate");

            migrationBuilder.DropTable(
                name: "enum_state_translate");

            migrationBuilder.DropTable(
                name: "hl_employee",
                schema: "public");

            migrationBuilder.DropTable(
                name: "doc_documents");

            migrationBuilder.DropTable(
                name: "enum_performer_type");

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
                name: "info_document_importance",
                schema: "public");

            migrationBuilder.DropTable(
                name: "info_sectors");

            migrationBuilder.DropTable(
                name: "hl_user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "info_state_program",
                schema: "public");

            migrationBuilder.DropTable(
                name: "enum_language");

            migrationBuilder.DropTable(
                name: "enum_user_role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "info_organization");

            migrationBuilder.DropTable(
                name: "enum_state_organization");

            migrationBuilder.DropTable(
                name: "enum_state");
        }
    }
}
