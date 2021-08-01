using Proje.Core.Models;
using Proje.Core.Services;
using Proje.Data;
using System.Collections.Generic;

namespace Proje.API
{
    public class YetkiKontrol
    {
        // private AppDbContext _context;
        // private readonly IService<Yetki> _service;

        // public YetkiKontrol(AppDbContext context, IService<Yetki> service)
        // {
        //     _context = context;
        //     _service = service;
        // }



        // public bool YetkiliMi(string ControllerAdi, string CanGet, string CanPost, string CanPut , string CanDelete){
        //     var context = new AppDbContext();
        //     var query =from y in context.Yetki where ( y.
        //     controller_name==ControllerAdi AND y.can_get==CanGet AND y.can_post== CanPost AND y.can_put==CanPut AND Y.can_delete==CanDelete; 
            
        //     var yetki = query.FirstOrDefault<Yetki>();

        // }



        // public bool YetkiliMi(string ControllerAdi, string IstekTipi)
        // {


        //     var yetki = _service
        //         .Where(x => x.controller_name == ControllerAdi
        //             && ((IstekTipi != "get") || ((IstekTipi == "get") && x.can_get == true))
        //             && ((IstekTipi != "post") || ((IstekTipi == "post") && x.can_post == true))
        //             && ((IstekTipi != "put") || ((IstekTipi == "put") && x.can_put == true))
        //             && ((IstekTipi != "delete") || ((IstekTipi == "delete") && x.can_delete == true))
        //         );

        //   return yetki;
        // }
    }
}