using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Proje.Core.Models
{
    public class Stok
    {
      
        public int Id { get; set; }
        public DateTime kayit_tarihi { get { return DateTime.Now; } }

        public string stok_kod { get; set; }
        public string stok_adi { get; set; }
        public string kategori { get; set; }
    }
}