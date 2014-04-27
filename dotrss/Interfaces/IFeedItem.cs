using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Interfaces
{
    /// <summary>
    /// Single entry in a feed
    /// </summary>
    public interface IFeedItem
    {
        string IFeedItemId { get; }
        string IFeedId { get; }
        string ItemTitle { get; }
        string ItemDescription { get; }
        string ItemBody { get; }
        DateTime? ItemDate { get; }
        string ToString();
    }
}
