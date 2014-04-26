
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
    class FeedHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //public static IList<IFeedItem> ParseStringToItemList(string itemString)
        //{
        //    IList<IFeedItem> items = new List<IFeedItem>();
        //    XDocument itemXML = XDocument.Parse(itemString.Trim());
        //    var itemElements = itemXML.Descendants("item");
        //    foreach (var item in itemElements)
        //    {
        //        IFeedItem feedItem = ParseItemXMLToFeedItem(item);
        //        items.Add(feedItem);
        //    }
        //    return items;
        //}

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

        //private static IFeedItem ParseItemXMLToFeedItem(XElement itemElement)
        //{
        //    XElement titleElement = itemElement.Descendants("title").First();
        //    XElement descElement = itemElement.Descendants("description").First();
        //    XElement dateElement = itemElement.Descendants("pubDate").First();
        //    IFeedItem feedItem = new FeedItem(titleElement.Value, descElement.Value, "Hier kommt später der Content hin!", DateTime.Parse(dateElement.Value));
        //    return feedItem;
        //}
    }
}
