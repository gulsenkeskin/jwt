using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proje.Core.Models;
using Proje.Core.Repositories;

namespace Proje.Data.Repositories
{
    public class StokRepository : Repository<Stok>, IStokRepository
    {
        
        private AppDbContext _appDbContext {get=> _context as AppDbContext;}
        // STOK repository context üret
        public StokRepository(AppDbContext context) : base(context)
        {
        }

        

        
    }
}