using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Core.Models;

namespace Proje.Data.Seeds
{
    public class KullaniciSeed:IEntityTypeConfiguration<Kullanici>
    {
        //  private readonly int[] _ids;

        // public KullaniciSeed(int[] ids)
        // {
        //     _ids = ids;
        // }

        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            // builder.HasData(
            //     new Kullanici { id = _ids[0], eposta="nihal@gmail.com",sifre="123" ,cinsiyet="kadın"},
            //     new Kullanici { id = _ids[1], eposta="gulsen@gmail.com",sifre="123",cinsiyet="kadın" }
            //     );
        }
    }
}