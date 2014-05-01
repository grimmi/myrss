using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace dotrss.Database
{
    public partial class FeedItem
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public FeedItem()
        {

        }

        public FeedItem(Feed fromFeed, string title = "n/a", string description = "n/a", string body = "n/a", DateTime date = default(DateTime), string itemId = "", string link = "")
        {
            Title = title;
            Description = description;
            Body = body;
            PubDate = date;
            UId = String.IsNullOrWhiteSpace(itemId) ? Guid.NewGuid().ToString() : itemId;
            Feed = fromFeed;
            Link = link;
        }

        public FeedItem(SyndicationItem item)
        {
            logger.Debug("item: " + item.ToString());
            logger.Debug("Autoren: " + String.Join(",", item.Authors.Select(a => a.Name)));
            logger.Debug("Titel: " + item.Title.Text);
            logger.Debug("Zusammenfassung: " + item.Summary.Text);
            if (item.Content != null)
            {
                var content = item.Content;
                logger.Debug(content.Type);
                logger.Debug("Text: " + (item.Content as TextSyndicationContent).Text);
            }
            else
            {
                logger.Debug("item.Content == null");
            }
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
}
