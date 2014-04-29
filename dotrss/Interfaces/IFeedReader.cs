using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Interfaces
{
    /// <summary>
    /// Responsible for creating and initializing feeds
    /// </summary>
    public interface IFeedReader
    {
        Task<IFeedCreateResult> CreateFeed(string feedUri, string feedName);
    }
}
