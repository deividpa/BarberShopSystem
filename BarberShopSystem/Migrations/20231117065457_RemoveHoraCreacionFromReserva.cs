using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShopSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHoraCreacionFromReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraCreacion",
                table: "Reservas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HoraCreacion",
                table: "Reservas",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
