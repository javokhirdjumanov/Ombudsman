using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class updatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "main_performer",
                table: "doc_documents");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "info_state_program",
                newName: "info_state_program",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "info_document_importance",
                newName: "info_document_importance",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "performers",
                table: "doc_information_letter",
                newName: "visa_holder");

            migrationBuilder.AddColumn<int>(
                name: "employee_id",
                table: "doc_information_letter",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orginization_user_id",
                table: "doc_documents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                    refresh_token_expired_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "ix_doc_information_letter_employee_id",
                table: "doc_information_letter",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_orginization_user_id",
                table: "doc_documents",
                column: "orginization_user_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_doc_documents_hl_user_orginization_user_id",
                table: "doc_documents",
                column: "orginization_user_id",
                principalSchema: "public",
                principalTable: "hl_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_doc_information_letter_hl_user_employee_id",
                table: "doc_information_letter",
                column: "employee_id",
                principalSchema: "public",
                principalTable: "hl_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doc_documents_hl_user_orginization_user_id",
                table: "doc_documents");

            migrationBuilder.DropForeignKey(
                name: "fk_doc_information_letter_hl_user_employee_id",
                table: "doc_information_letter");

            migrationBuilder.DropTable(
                name: "hl_user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "enum_user_role",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_doc_information_letter_employee_id",
                table: "doc_information_letter");

            migrationBuilder.DropIndex(
                name: "ix_doc_documents_orginization_user_id",
                table: "doc_documents");

            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "doc_information_letter");

            migrationBuilder.DropColumn(
                name: "orginization_user_id",
                table: "doc_documents");

            migrationBuilder.RenameTable(
                name: "info_state_program",
                schema: "public",
                newName: "info_state_program");

            migrationBuilder.RenameTable(
                name: "info_document_importance",
                schema: "public",
                newName: "info_document_importance");

            migrationBuilder.RenameColumn(
                name: "visa_holder",
                table: "doc_information_letter",
                newName: "performers");

            migrationBuilder.AddColumn<string>(
                name: "main_performer",
                table: "doc_documents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
