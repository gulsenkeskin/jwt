using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Core.Models;

namespace Proje.Data.Seeds
{
    public class CariSeed : IEntityTypeConfiguration<Cari>
    {
        // private readonly int[] _ids;

        // public CariSeed(int[] ids)
        // {
        //     _ids = ids;
        // }

        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            // builder.HasData(
            //     new Cari { id = _ids[0],  cari_kod = "1", cari_adi = "cari1", ozel_kod1 = "ozel1", ozel_kod2 = "ozel2", ozel_kod3 = "ozel3" },
            //     new Cari { id = _ids[1], cari_kod = "2", cari_adi = "cari2", ozel_kod1 = "ozel11", ozel_kod2 = "ozel22", ozel_kod3 = "ozel33" }

            //     );
        }
    }
}