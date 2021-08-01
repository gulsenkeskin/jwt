using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proje.Core.Repositories;

namespace Proje.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
    //repositorylerimizi veriyoruz

        IKullaniciRepository Kullanicilar {get;}

        ICariRepository Cariler {get;}

        IStokRepository Stoklar {get;}



        //CommitAsync metodunu imlemente ettiğimizde ef tarafında savaChange metodunu çağırır
         Task CommitAsync();
         void Commit();
    }
}