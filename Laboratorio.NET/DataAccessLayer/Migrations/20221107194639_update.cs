using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Penca",
                newName: "PencaId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Penca",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Penca");

            migrationBuilder.RenameColumn(
                name: "PencaId",
                table: "Penca",
                newName: "Id");
        }
    }
}
