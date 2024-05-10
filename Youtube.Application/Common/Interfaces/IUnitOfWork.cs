using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IYoutuberRepository Youtuber { get; }
        IYoutuberRecordsRepository YoutuberRecords { get; }

        void Save();
    }
}
