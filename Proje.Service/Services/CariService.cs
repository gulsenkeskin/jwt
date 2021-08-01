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
    public class CariService:Service<Cari>, ICariService
    {
        public CariService(IUnitOfWork unitOfWork, IRepository<Cari> repository): base(unitOfWork,repository){

        }
        //cariye özel işlemleri yaz
    }
}