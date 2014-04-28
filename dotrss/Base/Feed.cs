using System.Collections.Generic;
using NLog;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;
using System;
using dotrss.Interfaces;
using dotrss.Util;
using dotrss.Database;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace dotrss.Database
{
    public partial class Feed
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ICollection<FeedItem> itemCache;
        private DateTime lastRefresh = DateTime.MinValue;

        /// <summary>
        /// Setzt das letzte Update des Feeds auf den aktuellen Zeitpunkt (sollte in Event geändert werden)
        /// </summary>
        public void UpdateFeed()
        {
            using (var db = new FeedModelContainer())
            {
                var feed = db.Feeds.Where(f => f.Id == this.Id).FirstOrDefault();
                if (feed != null)
                {
                    feed.LastUpdated = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public ICollection<FeedItem> Items
        {
            get
            {
                TimeSpan span = DateTime.Now - lastRefresh;
                if (itemCache == null || itemCache.Count == 0 || span > TimeSpan.FromMinutes(5))
                {
                    using (var db = new FeedModelContainer())
                    {
                        var items = db.FeedItems.Where(f => f.Feed.Id == this.Id);
                        itemCache = items.ToList<FeedItem>();
                    }
                }
                return itemCache;
            }
        }

        public static Feed Init(string feedUri, string name, string type)
        {
            Feed initFeed = null;
            using (var db = new FeedModelContainer())
            {
                logger.Debug("Anzahl Feeds Beginn Init: " + db.Feeds.Count());
                var feedUris = db.Feeds.Select(f => f.Uri).ToList<string>();
                if (!feedUris.Contains(feedUri))
                {
                    initFeed = new Feed() { Uri = feedUri, FeedType = type, Name = name, LastUpdated = DateTime.MinValue };
                    logger.Debug("Anzahl Feeds nach new Feed(): " + db.Feeds.Count());
                }
                else
                {
                    initFeed = db.Feeds.Where(f => f.Uri.Equals(feedUri)).FirstOrDefault();
                    logger.Debug("Anzahl Feeds nach Query: " + db.Feeds.Count());
                }
            }
            initFeed.ReadItems();
            return initFeed;
        }

        public void ReadItems()
        {
            IEnumerable<FeedItem> items = new List<FeedItem>();
            switch (FeedType)
            {
                case Param.FeedTypeFile: items = FeedHelper.ReadItemsFromFile(Uri, this);
                    break;
                case Param.FeedTypeWeb: items = FeedHelper.ReadItemsFromWeb(Uri, this);
                    break;
            }
            if (items.Count() > 0)
            {
                SaveItemsToDatabase(items);
                UpdateFeed();
            }
        }

        public void SaveItemsToDatabase(IEnumerable<FeedItem> items)
        {
            using (var db = new FeedModelContainer())
            {
                var itemUIds = db.FeedItems.Where(i => i.Feed.Id == this.Id).Select(i => i.UId).ToList<string>();
                foreach (var item in items)
                {
                    try
                    {
                        if (!itemUIds.Contains(item.UId))
                        {
                            db.FeedItems.Add(item);
                        }
                    }
                    catch (DbEntityValidationException dbValEx)
                    {
                        logger.ErrorException(">>>>>>>>>>>", dbValEx);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
