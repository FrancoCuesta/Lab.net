using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class equipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partido_Campeonato_CampeonatoId",
                table: "Partido");

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Partido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.EquipoId);
                    table.ForeignKey(
                        name: "FK_Equipo_Partido_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partido",
                        principalColumn: "PartidoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_PartidoId",
                table: "Equipo",
                column: "PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partido_Campeonato_CampeonatoId",
                table: "Partido",
                column: "CampeonatoId",
                principalTable: "Campeonato",
                principalColumn: "CampeonatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partido_Campeonato_CampeonatoId",
                table: "Partido");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Partido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Partido_Campeonato_CampeonatoId",
                table: "Partido",
                column: "CampeonatoId",
                principalTable: "Campeonato",
                principalColumn: "CampeonatoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
