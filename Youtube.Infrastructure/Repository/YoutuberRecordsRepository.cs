using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Application.Common.Interfaces;
using Youtube.Domain.Entities;
using Youtube.Infrastructure.Data;

namespace Youtube.Infrastructure.Repository
{
    public class VillaNumberRepository : Repository<YoutuberRecords>, IYoutuberRecordsRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(YoutuberRecords entity)
        {
            _db.Update(entity);
        }
    }
}
