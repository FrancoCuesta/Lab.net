using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class CPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "montoGanado",
                table: "Resultado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "Puesto",
                table: "Resultado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<double>(
                name: "Puntos",
                table: "Prediccion",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "GolesEquipo2",
                table: "Prediccion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "GolesEquipo1",
                table: "Prediccion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "PartidoId",
                table: "Prediccion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.CampeonatoId);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    PartidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GolesEquipo1 = table.Column<int>(type: "int", nullable: false),
                    GolesEquipo2 = table.Column<int>(type: "int", nullable: false),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.PartidoId);
                    table.ForeignKey(
                        name: "FK_Partido_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "CampeonatoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penca_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "CampeonatoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prediccion_PartidoId",
                table: "Prediccion",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_CampeonatoId",
                table: "Partido",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Penca_CampeonatoId",
                table: "Penca",
                column: "CampeonatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prediccion_Partido_PartidoId",
                table: "Prediccion",
                column: "PartidoId",
                principalTable: "Partido",
                principalColumn: "PartidoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prediccion_Partido_PartidoId",
                table: "Prediccion");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Penca");

            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Prediccion_PartidoId",
                table: "Prediccion");

            migrationBuilder.DropColumn(
                name: "PartidoId",
                table: "Prediccion");

            migrationBuilder.AlterColumn<string>(
                name: "montoGanado",
                table: "Resultado",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Puesto",
                table: "Resultado",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Puntos",
                table: "Prediccion",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "GolesEquipo2",
                table: "Prediccion",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GolesEquipo1",
                table: "Prediccion",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
