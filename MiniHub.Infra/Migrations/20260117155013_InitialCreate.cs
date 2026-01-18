using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniHub.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Ativo", "Categoria", "CriadoEm", "Descricao", "Nome", "Preco", "Tag" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-a1b2-c3d4e5f67890"), true, "Informática", new DateTime(2025, 10, 20, 14, 30, 0, 0, DateTimeKind.Utc), "Processador Intel i7, 16GB RAM, SSD 512GB, Windows 11", "Notebook Dell Inspiron 15", 4599.90m, "BlackFriday" },
                    { new Guid("b2c3d4e5-f6a7-8901-b2c3-d4e5f6a78901"), true, "Smartphones", new DateTime(2026, 1, 10, 9, 0, 0, 0, DateTimeKind.Utc), "Tela 6.2 AMOLED, 256GB, Câmera Tripla com IA", "Smartphone Samsung Galaxy S24", 5299.00m, "Lançamento" },
                    { new Guid("c3d4e5f6-a7b8-9012-c3d4-e5f6a7b89012"), true, "Móveis", new DateTime(2025, 11, 5, 11, 15, 0, 0, DateTimeKind.Utc), "Ajuste de lombar, braços 3D e encosto em mesh respirável", "Cadeira Ergonômica Office", 850.50m, "HomeOffice" },
                    { new Guid("d4e5f6a7-b8c9-0123-d4e5-f6a7b8c90123"), false, "Periféricos", new DateTime(2024, 12, 1, 8, 0, 0, 0, DateTimeKind.Utc), "29 Polegadas, Full HD IPS, HDR10, HDMI", "Monitor Ultrawide LG 29wl500", 1199.99m, "Produtividade" },
                    { new Guid("e5f6a7b8-c9d0-1234-e5f6-a7b8c9d01234"), true, "Acessórios", new DateTime(2026, 1, 15, 16, 45, 0, 0, DateTimeKind.Utc), "Clique silencioso, sensor 8K DPI, recarregável via USB-C", "Mouse Sem Fio Logitech MX Master 3S", 649.90m, "Premium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
