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
    public class StokService: Service<Stok>, IStokService
    {
        public StokService(IUnitOfWork unitOfWork, IRepository<Stok> repository):base(unitOfWork,repository){

        }
        //buraya stok service e özel kodları yaz
    }
}