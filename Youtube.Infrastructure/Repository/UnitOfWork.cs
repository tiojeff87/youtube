using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Application.Common.Interfaces;
using Youtube.Infrastructure.Data;

namespace Youtube.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IYoutuberRepository Youtuber { get; private set; }
        public IYoutuberRecordsRepository YoutuberRecords { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Youtuber = new VillaRepository(db);
            YoutuberRecords = new VillaNumberRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
