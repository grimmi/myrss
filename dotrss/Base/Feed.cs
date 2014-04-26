using System.Collections.Generic;
using NLog;
using System.Linq;
using System.Xml.Linq;
using System;
using dotrss.Interfaces;
using dotrss.Util;

namespace dotrss.Base
{
    public class Feed : IFeed
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IEnumerable<IFeedItem> items;
        public string Name { get; set; }
        public Uri FeedUri { get; private set; }
        private XDocument feedXML;
        public IEnumerable<IFeedItem> Items
        {
            get
            {
                if (items == null || items.Count() < 1)
                {
                    items = FeedHelper.ParseItemsFromXML(feedXML);
                }
                return items;
            }
        }

        public Feed()
        {
        }

        public void Init(Uri feedUri, string name, XDocument feedXML)
        {
            FeedUri = feedUri;
            Name = name;
            this.feedXML = feedXML;
        }

    }
}
