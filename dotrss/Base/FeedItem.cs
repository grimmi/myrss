using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Database
{
    public partial class FeedItem
    {
        public FeedItem()
        {

        }

        public FeedItem(Feed fromFeed, string title = "n/a", string description = "n/a", string body = "n/a", DateTime date = default(DateTime), string itemId = "")
        {
            Title = title;
            Description = description;
            Body = body;
            PubDate = date;
            UId = String.IsNullOrWhiteSpace(itemId) ? Guid.NewGuid().ToString() : itemId;
            Uri = "";
            Feed = fromFeed;
        }

        /// <summary>
        /// Simple display
        /// </summary>
        /// <returns>[Title]: [Description] ([Date]) \r\n [Body]</returns>
        public override string ToString()
        {
            return String.Format("{0}: {1} ({2}) {3} {4}", Title, Description, PubDate.ToShortDateString(), Environment.NewLine, Body);
        }
    }
    //public class FeedItem : IFeedItem
    //{
    //    public string ItemTitle { get; private set; }
    //    public string ItemDescription { get; private set; }
    //    public string ItemBody { get; private set; }
    //    public DateTime? ItemDate { get; private set; }
    //    public string IFeedItemId { get; private set; }
    //    public string IFeedId { get; private set; }

    //    public FeedItem(string title = "n/a", string description = "n/a", string body = "n/a", DateTime? date = null, string itemId = "", string feedId = "")
    //    {
    //        ItemTitle = title;
    //        ItemDescription = description;
    //        ItemBody = body;
    //        ItemDate = date;
    //        IFeedItemId = String.IsNullOrWhiteSpace(itemId) ? Guid.NewGuid().ToString() : itemId;
    //        IFeedId = feedId;
    //    }

    //    /// <summary>
    //    /// Simple display
    //    /// </summary>
    //    /// <returns>[Title]: [Description] ([Date]) \r\n [Body]</returns>
    //    public override string ToString()
    //    {
    //        return String.Format("{0}: {1} ({2}) {3} {4}", ItemTitle, ItemDescription, ItemDate.HasValue ? ItemDate.Value.ToShortDateString() : "n/a", Environment.NewLine, ItemBody);
    //    }
    //}
}
