using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banca.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrimerApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SegundoApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rfc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CalleYNumero = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colonia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Municipio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstaActivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ahorro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstaActivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ahorro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ahorro_Cliente",
                        column: x => x.Id,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    AhorroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaccion_Ahorro",
                        column: x => x.AhorroId,
                        principalTable: "Ahorro",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_AhorroId",
                table: "Transaccion",
                column: "AhorroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Ahorro");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
