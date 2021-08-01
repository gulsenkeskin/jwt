using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.API.DTOs
{
    public class KullaniciDto
    {
        [Key]
        public Guid Id { get; set; }
        public string eposta { get; set; }
        public string sifre { get; set; }
        public string cinsiyet { get; set; }
    }
}