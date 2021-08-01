using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Proje.Core.Models
{
    public class Kullanici :IdentityUser<Guid> 
    {
       
    //    [Key]
    //     public Guid Id { get; set; }
        public DateTime kayit_tarihi { get { return DateTime.Now; } }
        public string eposta { get; set; }
        public string sifre { get; set; }
        public string cinsiyet { get; set; }
    }
}