using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Base
{
    public class FeedItem : IFeedItem
    {
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public string ItemBody { get; set; }
        public DateTime? ItemDate { get; set; }

        public FeedItem(string title = "n/a", string description = "n/a", string body = "n/a", DateTime? date = null)
        {
            ItemTitle = title;
            ItemDescription = description;
            ItemBody = body;
            ItemDate = date;
        }

        /// <summary>
        /// Simple display
        /// </summary>
        /// <returns>[Title]: [Description] ([Date]) \r\n [Body]</returns>
        public override string ToString()
        {
            return String.Format("{0}: {1} ({2}) {3} {4}", ItemTitle, ItemDescription, ItemDate.HasValue ? ItemDate.Value.ToShortDateString() : "n/a", Environment.NewLine, ItemBody);
        }
    }
}
