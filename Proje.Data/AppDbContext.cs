using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje.Core.Auth;
using Proje.Core.Models;
using Proje.Data.Configurations;
using Proje.Data.Seeds;
namespace Proje.Data
{
    public class AppDbContext : IdentityDbContext< Kullanici, Role, Guid>
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Cari> Cariler { get; set; }

        public DbSet<Stok> Stoklar { get; set; }

        public DbSet<Yetki> Yetkiler { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

     

        //veri tabanında tablolar oluşmadan çalışacak olan metod- modeldeki tabloların veri tabanındaki tablolara dönüşürken nasıl dönüşeceğini belirler
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new KullaniciConfiguration());
            
            modelBuilder.ApplyConfiguration(new CariConfiguration());
            modelBuilder.ApplyConfiguration(new StokConfiguration());
            modelBuilder.ApplyConfiguration(new YetkiConfiguration());


            // modelBuilder.ApplyConfiguration(new KullaniciSeed(new int[] { 1, 2 }));

            // modelBuilder.ApplyConfiguration(new CariSeed(new int[] { 1, 2 }));

            // modelBuilder.ApplyConfiguration(new StokSeed(new int[] { 1, 2 }));


        }
    }
}