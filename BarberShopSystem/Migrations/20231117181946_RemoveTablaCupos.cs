using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShopSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTablaCupos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Cupos_CupoId",
                table: "Reservas");

            migrationBuilder.DropTable(
                name: "Cupos");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_CupoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "CupoId",
                table: "Reservas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CupoId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfesionalId = table.Column<int>(type: "int", nullable: false),
                    EstadoCupo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ServiciosDisponibles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cupos_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CupoId",
                table: "Reservas",
                column: "CupoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cupos_ProfesionalId",
                table: "Cupos",
                column: "ProfesionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Cupos_CupoId",
                table: "Reservas",
                column: "CupoId",
                principalTable: "Cupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
