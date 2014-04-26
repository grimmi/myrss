using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Interfaces
{
    public interface IFeedReader
    {
        IFeedCreateResult CreateFeed(string feedUri, string feedName);
    }
}
