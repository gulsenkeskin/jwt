using System.Threading.Tasks;
using Proje.Core.Repositories;
using Proje.Core.UnitOfWorks;
using Proje.Data.Repositories;

namespace Proje.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        private KullaniciRepository _kullaniciRepository;
        private StokRepository _stokRepository;

        private CariRepository _cariRepository;
        //iki soru işareti null durumunu kontrol eder

        //kullanıcı repositoy var ise al yoksa kullanıcı repository oluştur
        public IKullaniciRepository Kullanicilar => _kullaniciRepository = _kullaniciRepository ?? new KullaniciRepository(_context);

        //stok repository varsa al yoksa yeni bir tane oluştur
        public IStokRepository Stoklar => _stokRepository = _stokRepository ?? new StokRepository(_context);
        //cari repository varsa al yoksa yeni bir tane oluştur
        public ICariRepository Cariler => _cariRepository = _cariRepository ?? new CariRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}