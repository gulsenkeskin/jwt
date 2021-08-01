using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Core.Models;

namespace Proje.Data.Seeds
{
    public class StokSeed:IEntityTypeConfiguration<Stok>
    {
        // private readonly int[] _ids;

        // public StokSeed(int[] ids)
        // {
        //     _ids = ids;
        // }

        public void Configure(EntityTypeBuilder<Stok> builder)
         {
        //     builder.HasData(
        //         new Stok { id = _ids[0],  stok_kod="1", stok_adi="stok1",kategori="kategori1" },
        //         new Stok  { id = _ids[1], stok_kod="2", stok_adi="stok2",kategori="kategori2" }

        //         );
        }
    }
}