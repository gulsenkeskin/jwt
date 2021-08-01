using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Core.Models;

namespace Proje.Data.Configurations
{
    public class CariConfiguration : IEntityTypeConfiguration<Cari>
    {
        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.cari_kod).IsRequired().HasMaxLength(25);
            builder.Property(x => x.cari_adi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ozel_kod1).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ozel_kod2).IsRequired().HasMaxLength(15);
            builder.Property(x => x.ozel_kod3).IsRequired().HasMaxLength(20);

            builder.ToTable("Cariler");
        }
    }
}