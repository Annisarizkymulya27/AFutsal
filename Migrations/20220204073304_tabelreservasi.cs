using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AFutsal.Migrations
{
    public partial class tabelreservasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Reservasi",
                columns: table => new
                {
                    IdBooking = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: true),
                    NoHP = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Tanggal = table.Column<DateTime>(type: "datetime", nullable: false),
                    Jam = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Reservasi", x => x.IdBooking);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Reservasi");
        }
    }
}
