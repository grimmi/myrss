
using dotrss.Base;
using dotrss.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotrss.Util
{
    /// <summary>
    /// Helps with parsing and other stuff
    /// </summary>
    class FeedHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Reads all items from a given XML file
        /// </summary>
        /// <param name="feedXML">The XML file from the feed</param>
        /// <returns>IEnumerable with all IFeedItems - some properties might be empty</returns>
        public static IEnumerable<IFeedItem> ParseItemsFromXML(XDocument feedXML)
        {
            IList<IFeedItem> items = new List<IFeedItem>();
            var itemElements = feedXML.Descendants(Param.XMLItemTag);
            foreach (var item in itemElements)
            {
                var titleElement = item.Descendants(Param.XMLTitleTag).FirstOrDefault();
                var title = (titleElement != null) ? titleElement.Value : Param.PlaceHolderString;
                var descriptionElement = item.Descendants(Param.XMLDescriptionTag).FirstOrDefault();
                var description = (descriptionElement != null) ? descriptionElement.Value : Param.PlaceHolderString;
                var contentElement = item.Descendants(Param.XMLContentTag).FirstOrDefault();
                var content = (contentElement != null) ? contentElement.Value : Param.PlaceHolderString;
                var dateElement = item.Descendants(Param.XMLPubDateTag).FirstOrDefault();
                var date = (dateElement != null) ? DateTime.Parse(dateElement.Value) : default(DateTime);
                IFeedItem feedItem = new FeedItem(title, description, content, date);
                items.Add(feedItem);
            }
            return items;
        }
    }
}
