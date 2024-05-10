using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Common.Interfaces
{
    public interface IYoutuberRecordsRepository : IRepository<YoutuberRecords>
    {
        void Update(YoutuberRecords entity);
    }
}
