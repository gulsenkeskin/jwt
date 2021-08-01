using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proje.Core.Models;
using Proje.Core.Repositories;
using Proje.Core.Services;
using Proje.Core.UnitOfWorks;

namespace Proje.Service.Services
{
    public class KullaniciService:GuidService<Kullanici>,IKullaniciService
    {
        public KullaniciService(IUnitOfWork unitOfWork, IGuidRepository<Kullanici> repository):base(unitOfWork,repository){

        }


        //buraya kullanıcıya özel işlemleri yaz

    }
}