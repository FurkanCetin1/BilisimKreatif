using Microsoft.EntityFrameworkCore.Migrations;

namespace BilisimKreatif.Data.Migrations
{
    public partial class proname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Proposals",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Proposals",
                newName: "Authorize");

            migrationBuilder.AddColumn<string>(
                name: "ProposalContext",
                table: "Proposals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposalContext",
                table: "Proposals");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Proposals",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Authorize",
                table: "Proposals",
                newName: "FirstName");
        }
    }
}
