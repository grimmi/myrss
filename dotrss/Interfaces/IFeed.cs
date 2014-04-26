using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotrss.Interfaces
{
    public interface IFeed
    {
        string Name { get; }
        IEnumerable<IFeedItem> Items { get; }
        Uri FeedUri { get; }
        void Init(Uri feedUri, string name, XDocument feedXML);
    }
}
