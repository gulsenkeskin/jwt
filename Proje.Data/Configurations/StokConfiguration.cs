using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Core.Models;
namespace Proje.Data.Configurations
{
    public class StokConfiguration:IEntityTypeConfiguration<Stok>
    {
        public void Configure(EntityTypeBuilder<Stok> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.stok_kod).IsRequired().HasMaxLength(25);
            builder.Property(x=>x.stok_adi).IsRequired().HasMaxLength(65);
            builder.Property(x=>x.kategori).HasMaxLength(15);
            builder.ToTable("Stoklar");
        }
    }
}