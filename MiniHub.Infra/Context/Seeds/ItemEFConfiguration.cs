using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniHub.Domain.Entities;

public class ItemEFConfiguration : IEntityTypeConfiguration<ItemModel>
{
    public void Configure(EntityTypeBuilder<ItemModel> builder)
    {
        builder.ToTable("Items");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Preco).HasPrecision(18, 2);

        builder.HasData(
            new ItemModel
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-a1b2-c3d4e5f67890"),
                Nome = "Notebook Dell Inspiron 15",
                Descricao = "Processador Intel i7, 16GB RAM, SSD 512GB, Windows 11",
                Categoria = "Informática",
                Preco = 4599.90m,
                Tag = "BlackFriday",
                Ativo = true,
                CriadoEm = new DateTime(2025, 10, 20, 14, 30, 0, DateTimeKind.Utc)
            },
            new ItemModel
            {
                Id = Guid.Parse("b2c3d4e5-f6a7-8901-b2c3-d4e5f6a78901"),
                Nome = "Smartphone Samsung Galaxy S24",
                Descricao = "Tela 6.2 AMOLED, 256GB, Câmera Tripla com IA",
                Categoria = "Smartphones",
                Preco = 5299.00m,
                Tag = "Lançamento",
                Ativo = true,
                CriadoEm = new DateTime(2026, 1, 10, 09, 00, 0, DateTimeKind.Utc)
            },
            new ItemModel
            {
                Id = Guid.Parse("c3d4e5f6-a7b8-9012-c3d4-e5f6a7b89012"),
                Nome = "Cadeira Ergonômica Office",
                Descricao = "Ajuste de lombar, braços 3D e encosto em mesh respirável",
                Categoria = "Móveis",
                Preco = 850.50m,
                Tag = "HomeOffice",
                Ativo = true,
                CriadoEm = new DateTime(2025, 11, 05, 11, 15, 0, DateTimeKind.Utc)
            },
            new ItemModel
            {
                Id = Guid.Parse("d4e5f6a7-b8c9-0123-d4e5-f6a7b8c90123"),
                Nome = "Monitor Ultrawide LG 29wl500",
                Descricao = "29 Polegadas, Full HD IPS, HDR10, HDMI",
                Categoria = "Periféricos",
                Preco = 1199.99m,
                Tag = "Produtividade",
                Ativo = false,
                CriadoEm = new DateTime(2024, 12, 01, 08, 00, 0, DateTimeKind.Utc)
            },
            new ItemModel
            {
                Id = Guid.Parse("e5f6a7b8-c9d0-1234-e5f6-a7b8c9d01234"),
                Nome = "Mouse Sem Fio Logitech MX Master 3S",
                Descricao = "Clique silencioso, sensor 8K DPI, recarregável via USB-C",
                Categoria = "Acessórios",
                Preco = 649.90m,
                Tag = "Premium",
                Ativo = true,
                CriadoEm = new DateTime(2026, 1, 15, 16, 45, 0, DateTimeKind.Utc)
            }
        );
    }
}