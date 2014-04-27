
using dotrss.Base;
using dotrss.Database;
using dotrss.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
        public static IEnumerable<FeedItem> ParseItemsFromXML(XDocument feedXML, Feed fromFeed)
        {
            IList<FeedItem> items = new List<FeedItem>();
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
                var guidElement = item.Descendants(Param.XMLGuidTag).FirstOrDefault();
                var guid = (guidElement != null) ? guidElement.Value : Guid.NewGuid().ToString();
                FeedItem feedItem = new FeedItem(fromFeed, title, description, content, date, guid);
                items.Add(feedItem);
            }
            return items;
        }

        public static IEnumerable<FeedItem> ReadItemsFromFile(string feedFile, Feed fromFeed)
        {
            var fileString = File.ReadAllText(feedFile).Trim();
            XDocument feedXML = XDocument.Parse(fileString);
            return ParseItemsFromXML(feedXML, fromFeed);
        }

        public static IEnumerable<FeedItem> ReadItemsFromWeb(string feedUri, Feed fromFeed)
        {
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            var feedString = client.DownloadString(new Uri(feedUri));
            XDocument feedXML = XDocument.Parse(feedString.Trim());
            return ParseItemsFromXML(feedXML, fromFeed);
        }
    }
}
