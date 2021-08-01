using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Core.Models;

namespace Proje.Data.Configurations
{
    public class KullaniciConfiguration:IEntityTypeConfiguration<Kullanici>
    {
        
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
        //     builder.HasKey(x => x.Id);
        //     builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.eposta).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.sifre).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.cinsiyet).HasMaxLength(15);
            builder.ToTable("Kullanıcılar");
        }
    }
}