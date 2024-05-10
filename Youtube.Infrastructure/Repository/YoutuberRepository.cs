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
    public class VillaRepository : Repository<Youtuber>, IYoutuberRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Youtuber entity)
        {
            _db.Update(entity);
        }
    }
}
