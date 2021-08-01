using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Proje.Core.Models
{
    public class Cari
    {
        public int Id { get; set; }
        public DateTime kayit_tarihi { get { return DateTime.Now; } }

        public string cari_kod { get; set; }
        public string cari_adi { get; set; }
        public string ozel_kod1 { get; set; }
        public string ozel_kod2 { get; set; }
        public string ozel_kod3 { get; set; }
    }
}