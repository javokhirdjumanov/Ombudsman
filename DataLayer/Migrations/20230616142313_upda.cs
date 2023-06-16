using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class upda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doc_documents_doc_information_letter_information_letter_id",
                table: "doc_documents");

            migrationBuilder.DropForeignKey(
                name: "fk_doc_information_letter_hl_user_employee_id",
                table: "doc_information_letter");

            migrationBuilder.DropForeignKey(
                name: "fk_hl_user_info_organization_organization_id",
                schema: "public",
                table: "hl_user");

            migrationBuilder.DropIndex(
                name: "ix_doc_documents_information_letter_id",
                table: "doc_documents");

            migrationBuilder.DropColumn(
                name: "information_letter_id",
                table: "doc_documents");

            migrationBuilder.AlterColumn<int>(
                name: "organization_id",
                schema: "public",
                table: "hl_user",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_visa_addition",
                table: "doc_visa_holders_for_doc",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "doc_visa_holders_for_doc",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "information_letter_date",
                table: "doc_information_letter",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "document_id",
                table: "doc_information_letter",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "send_document_data",
                table: "doc_documents",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "normative_doc_date",
                table: "doc_documents",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "estimated_execution_time",
                table: "doc_documents",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "doc_documents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "ix_doc_information_letter_document_id",
                table: "doc_information_letter",
                column: "document_id");

            migrationBuilder.AddForeignKey(
                name: "fk_doc_information_letter_doc_documents_document_id",
                table: "doc_information_letter",
                column: "document_id",
                principalTable: "doc_documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_doc_information_letter_hl_employee_employee_id",
                table: "doc_information_letter",
                column: "employee_id",
                principalSchema: "public",
                principalTable: "hl_employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_hl_user_info_organization_organization_id",
                schema: "public",
                table: "hl_user",
                column: "organization_id",
                principalTable: "info_organization",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doc_information_letter_doc_documents_document_id",
                table: "doc_information_letter");

            migrationBuilder.DropForeignKey(
                name: "fk_doc_information_letter_hl_employee_employee_id",
                table: "doc_information_letter");

            migrationBuilder.DropForeignKey(
                name: "fk_hl_user_info_organization_organization_id",
                schema: "public",
                table: "hl_user");

            migrationBuilder.DropIndex(
                name: "ix_doc_information_letter_document_id",
                table: "doc_information_letter");

            migrationBuilder.DropColumn(
                name: "document_id",
                table: "doc_information_letter");

            migrationBuilder.AlterColumn<int>(
                name: "organization_id",
                schema: "public",
                table: "hl_user",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_visa_addition",
                table: "doc_visa_holders_for_doc",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "doc_visa_holders_for_doc",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "information_letter_date",
                table: "doc_information_letter",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "send_document_data",
                table: "doc_documents",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "normative_doc_date",
                table: "doc_documents",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "estimated_execution_time",
                table: "doc_documents",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "doc_documents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "information_letter_id",
                table: "doc_documents",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_doc_documents_information_letter_id",
                table: "doc_documents",
                column: "information_letter_id");

            migrationBuilder.AddForeignKey(
                name: "fk_doc_documents_doc_information_letter_information_letter_id",
                table: "doc_documents",
                column: "information_letter_id",
                principalTable: "doc_information_letter",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_doc_information_letter_hl_user_employee_id",
                table: "doc_information_letter",
                column: "employee_id",
                principalSchema: "public",
                principalTable: "hl_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_hl_user_info_organization_organization_id",
                schema: "public",
                table: "hl_user",
                column: "organization_id",
                principalTable: "info_organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
