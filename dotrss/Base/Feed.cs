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
using System.Threading.Tasks;

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
                DbgHelper.CurrentNumberOfFeeds("Beginn von UpdateFeed");
                var feed = db.Feeds.Where(f => f.Id == this.Id).FirstOrDefault();
                if (feed != null)
                {
                    DbgHelper.CurrentNumberOfFeeds("Feed gefunden");
                    feed.LastUpdated = DateTime.Now;
                    db.SaveChanges();
                    DbgHelper.CurrentNumberOfFeeds("Nach db.SaveChanges");
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

        public static async Task<Feed> Init(string feedUri, string name, string type)
        {
            Feed initFeed = null;
            DbgHelper.CurrentNumberOfFeeds("Beginn von Init");
            using (var db = new FeedModelContainer())
            {
                var feedUris = db.Feeds.Select(f => f.Uri).ToList<string>();
                if (!feedUris.Contains(feedUri))
                {
                    DbgHelper.CurrentNumberOfFeeds("neue feedUri");
                    initFeed = new Feed() { Uri = feedUri, FeedType = type, Name = name, LastUpdated = DateTime.MinValue };
                }
                else
                {
                    DbgHelper.CurrentNumberOfFeeds("Keine neue feedUri");
                    initFeed = db.Feeds.Where(f => f.Uri.Equals(feedUri)).FirstOrDefault();
                }
            }
            DbgHelper.CurrentNumberOfFeeds("Vor ReadItems");
            await initFeed.ReadItems();
            return initFeed;
        }

        public async Task ReadItems()
        {
            DbgHelper.CurrentNumberOfFeeds("Beginn von ReadItems");
            IEnumerable<FeedItem> items = new List<FeedItem>();
            switch (FeedType)
            {
                case Param.FeedTypeFile: items = await FeedHelper.ReadItemsFromFile(Uri, this);
                    break;
                case Param.FeedTypeWeb: items = await FeedHelper.ReadItemsFromWeb(Uri, this);
                    break;
            }
            if (items.Count() > 0)
            {
                DbgHelper.CurrentNumberOfFeeds("items.Count > 0");
                SaveItemsToDatabase(items);
                DbgHelper.CurrentNumberOfFeeds("Nach SaveItemsToDatabase");
                UpdateFeed();
                DbgHelper.CurrentNumberOfFeeds("Nach UpdateFeed");
            }
        }

        public void SaveItemsToDatabase(IEnumerable<FeedItem> items)
        {
            using (var db = new FeedModelContainer())
            {
                DbgHelper.CurrentNumberOfFeeds("Beginn von SaveItemsToDatabase");
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
                DbgHelper.CurrentNumberOfFeeds("Vor db.SaveChanges");
                db.SaveChanges();
                DbgHelper.CurrentNumberOfFeeds("Nach db.SaveChanges");
            }
        }
    }
}
