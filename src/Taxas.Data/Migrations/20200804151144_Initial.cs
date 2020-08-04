using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxasDeJuros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxasDeJuros", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxasDeJuros",
                columns: new[] { "Id", "Excluido", "Percentual" },
                values: new object[] { new Guid("7772b216-a9e0-47d8-88da-529ecfbf9023"), false, 0.01m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxasDeJuros");
        }
    }
}
