using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_document_status_translates_enum_document_status_document_st",
                table: "document_status_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_document_status_translates_enum_language_language_id",
                table: "document_status_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_country_organization_enum_status_status_id",
                table: "enum_country_organization");

            migrationBuilder.DropForeignKey(
                name: "fk_info_organization_enum_country_organization_state_organizat",
                table: "info_organization");

            migrationBuilder.DropForeignKey(
                name: "fk_initiative_type_translates_enum_initiative_type_initiative_",
                table: "initiative_type_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_initiative_type_translates_enum_language_language_id",
                table: "initiative_type_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_normative_document_type_translates_enum_language_language_id",
                table: "normative_document_type_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_normative_document_type_translates_enum_normative_document_",
                table: "normative_document_type_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_performer_type_translates_enum_language_language_id",
                table: "performer_type_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_performer_type_translates_enum_performer_type_performer_typ",
                table: "performer_type_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_state_organization_translates_enum_country_organization_sta",
                table: "state_organization_translates");

            migrationBuilder.DropForeignKey(
                name: "fk_state_organization_translates_enum_language_language_id",
                table: "state_organization_translates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_state_organization_translates",
                table: "state_organization_translates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_performer_type_translates",
                table: "performer_type_translates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_normative_document_type_translates",
                table: "normative_document_type_translates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_initiative_type_translates",
                table: "initiative_type_translates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_country_organization",
                table: "enum_country_organization");

            migrationBuilder.DropPrimaryKey(
                name: "pk_document_status_translates",
                table: "document_status_translates");

            migrationBuilder.RenameTable(
                name: "state_organization_translates",
                newName: "enum_state_organization_translate");

            migrationBuilder.RenameTable(
                name: "performer_type_translates",
                newName: "enum_performer_type_translate");

            migrationBuilder.RenameTable(
                name: "normative_document_type_translates",
                newName: "enum_normative_document_translate");

            migrationBuilder.RenameTable(
                name: "initiative_type_translates",
                newName: "enum_initiative_type_translate");

            migrationBuilder.RenameTable(
                name: "enum_country_organization",
                newName: "enum_state_organization");

            migrationBuilder.RenameTable(
                name: "document_status_translates",
                newName: "enum_document_status_translate");

            migrationBuilder.RenameIndex(
                name: "ix_state_organization_translates_state_organization_id",
                table: "enum_state_organization_translate",
                newName: "ix_enum_state_organization_translate_state_organization_id");

            migrationBuilder.RenameIndex(
                name: "ix_state_organization_translates_language_id",
                table: "enum_state_organization_translate",
                newName: "ix_enum_state_organization_translate_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_performer_type_translates_performer_type_id",
                table: "enum_performer_type_translate",
                newName: "ix_enum_performer_type_translate_performer_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_performer_type_translates_language_id",
                table: "enum_performer_type_translate",
                newName: "ix_enum_performer_type_translate_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_normative_document_type_translates_normative_document_type_",
                table: "enum_normative_document_translate",
                newName: "ix_enum_normative_document_translate_normative_document_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_normative_document_type_translates_language_id",
                table: "enum_normative_document_translate",
                newName: "ix_enum_normative_document_translate_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_initiative_type_translates_language_id",
                table: "enum_initiative_type_translate",
                newName: "ix_enum_initiative_type_translate_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_initiative_type_translates_initiative_type_id",
                table: "enum_initiative_type_translate",
                newName: "ix_enum_initiative_type_translate_initiative_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_country_organization_status_id",
                table: "enum_state_organization",
                newName: "ix_enum_state_organization_status_id");

            migrationBuilder.RenameIndex(
                name: "ix_document_status_translates_language_id",
                table: "enum_document_status_translate",
                newName: "ix_enum_document_status_translate_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_document_status_translates_document_status_id",
                table: "enum_document_status_translate",
                newName: "ix_enum_document_status_translate_document_status_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_state_organization_translate",
                table: "enum_state_organization_translate",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_performer_type_translate",
                table: "enum_performer_type_translate",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_normative_document_translate",
                table: "enum_normative_document_translate",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_initiative_type_translate",
                table: "enum_initiative_type_translate",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_state_organization",
                table: "enum_state_organization",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_document_status_translate",
                table: "enum_document_status_translate",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_enum_document_status_translate_enum_document_status_documen",
                table: "enum_document_status_translate",
                column: "document_status_id",
                principalTable: "enum_document_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_document_status_translate_enum_language_language_id",
                table: "enum_document_status_translate",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_initiative_type_translate_enum_initiative_type_initiat",
                table: "enum_initiative_type_translate",
                column: "initiative_type_id",
                principalTable: "enum_initiative_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_initiative_type_translate_enum_language_language_id",
                table: "enum_initiative_type_translate",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_normative_document_translate_enum_language_language_id",
                table: "enum_normative_document_translate",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_normative_document_translate_enum_normative_document_n",
                table: "enum_normative_document_translate",
                column: "normative_document_type_id",
                principalTable: "enum_normative_document",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_performer_type_translate_enum_language_language_id",
                table: "enum_performer_type_translate",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_performer_type_translate_enum_performer_type_performer",
                table: "enum_performer_type_translate",
                column: "performer_type_id",
                principalTable: "enum_performer_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_state_organization_enum_status_status_id",
                table: "enum_state_organization",
                column: "status_id",
                principalTable: "enum_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_state_organization_translate_enum_language_language_id",
                table: "enum_state_organization_translate",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_state_organization_translate_enum_state_organization_s",
                table: "enum_state_organization_translate",
                column: "state_organization_id",
                principalTable: "enum_state_organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_info_organization_enum_state_organization_state_organizatio",
                table: "info_organization",
                column: "state_organization_id",
                principalTable: "enum_state_organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_enum_document_status_translate_enum_document_status_documen",
                table: "enum_document_status_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_document_status_translate_enum_language_language_id",
                table: "enum_document_status_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_initiative_type_translate_enum_initiative_type_initiat",
                table: "enum_initiative_type_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_initiative_type_translate_enum_language_language_id",
                table: "enum_initiative_type_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_normative_document_translate_enum_language_language_id",
                table: "enum_normative_document_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_normative_document_translate_enum_normative_document_n",
                table: "enum_normative_document_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_performer_type_translate_enum_language_language_id",
                table: "enum_performer_type_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_performer_type_translate_enum_performer_type_performer",
                table: "enum_performer_type_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_state_organization_enum_status_status_id",
                table: "enum_state_organization");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_state_organization_translate_enum_language_language_id",
                table: "enum_state_organization_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_enum_state_organization_translate_enum_state_organization_s",
                table: "enum_state_organization_translate");

            migrationBuilder.DropForeignKey(
                name: "fk_info_organization_enum_state_organization_state_organizatio",
                table: "info_organization");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_state_organization_translate",
                table: "enum_state_organization_translate");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_state_organization",
                table: "enum_state_organization");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_performer_type_translate",
                table: "enum_performer_type_translate");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_normative_document_translate",
                table: "enum_normative_document_translate");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_initiative_type_translate",
                table: "enum_initiative_type_translate");

            migrationBuilder.DropPrimaryKey(
                name: "pk_enum_document_status_translate",
                table: "enum_document_status_translate");

            migrationBuilder.RenameTable(
                name: "enum_state_organization_translate",
                newName: "state_organization_translates");

            migrationBuilder.RenameTable(
                name: "enum_state_organization",
                newName: "enum_country_organization");

            migrationBuilder.RenameTable(
                name: "enum_performer_type_translate",
                newName: "performer_type_translates");

            migrationBuilder.RenameTable(
                name: "enum_normative_document_translate",
                newName: "normative_document_type_translates");

            migrationBuilder.RenameTable(
                name: "enum_initiative_type_translate",
                newName: "initiative_type_translates");

            migrationBuilder.RenameTable(
                name: "enum_document_status_translate",
                newName: "document_status_translates");

            migrationBuilder.RenameIndex(
                name: "ix_enum_state_organization_translate_state_organization_id",
                table: "state_organization_translates",
                newName: "ix_state_organization_translates_state_organization_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_state_organization_translate_language_id",
                table: "state_organization_translates",
                newName: "ix_state_organization_translates_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_state_organization_status_id",
                table: "enum_country_organization",
                newName: "ix_enum_country_organization_status_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_performer_type_translate_performer_type_id",
                table: "performer_type_translates",
                newName: "ix_performer_type_translates_performer_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_performer_type_translate_language_id",
                table: "performer_type_translates",
                newName: "ix_performer_type_translates_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_normative_document_translate_normative_document_type_id",
                table: "normative_document_type_translates",
                newName: "ix_normative_document_type_translates_normative_document_type_");

            migrationBuilder.RenameIndex(
                name: "ix_enum_normative_document_translate_language_id",
                table: "normative_document_type_translates",
                newName: "ix_normative_document_type_translates_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_initiative_type_translate_language_id",
                table: "initiative_type_translates",
                newName: "ix_initiative_type_translates_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_initiative_type_translate_initiative_type_id",
                table: "initiative_type_translates",
                newName: "ix_initiative_type_translates_initiative_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_document_status_translate_language_id",
                table: "document_status_translates",
                newName: "ix_document_status_translates_language_id");

            migrationBuilder.RenameIndex(
                name: "ix_enum_document_status_translate_document_status_id",
                table: "document_status_translates",
                newName: "ix_document_status_translates_document_status_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_state_organization_translates",
                table: "state_organization_translates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_enum_country_organization",
                table: "enum_country_organization",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_performer_type_translates",
                table: "performer_type_translates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_normative_document_type_translates",
                table: "normative_document_type_translates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_initiative_type_translates",
                table: "initiative_type_translates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_document_status_translates",
                table: "document_status_translates",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_document_status_translates_enum_document_status_document_st",
                table: "document_status_translates",
                column: "document_status_id",
                principalTable: "enum_document_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_document_status_translates_enum_language_language_id",
                table: "document_status_translates",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_enum_country_organization_enum_status_status_id",
                table: "enum_country_organization",
                column: "status_id",
                principalTable: "enum_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_info_organization_enum_country_organization_state_organizat",
                table: "info_organization",
                column: "state_organization_id",
                principalTable: "enum_country_organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_initiative_type_translates_enum_initiative_type_initiative_",
                table: "initiative_type_translates",
                column: "initiative_type_id",
                principalTable: "enum_initiative_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_initiative_type_translates_enum_language_language_id",
                table: "initiative_type_translates",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_normative_document_type_translates_enum_language_language_id",
                table: "normative_document_type_translates",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_normative_document_type_translates_enum_normative_document_",
                table: "normative_document_type_translates",
                column: "normative_document_type_id",
                principalTable: "enum_normative_document",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_performer_type_translates_enum_language_language_id",
                table: "performer_type_translates",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_performer_type_translates_enum_performer_type_performer_typ",
                table: "performer_type_translates",
                column: "performer_type_id",
                principalTable: "enum_performer_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_state_organization_translates_enum_country_organization_sta",
                table: "state_organization_translates",
                column: "state_organization_id",
                principalTable: "enum_country_organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_state_organization_translates_enum_language_language_id",
                table: "state_organization_translates",
                column: "language_id",
                principalTable: "enum_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
