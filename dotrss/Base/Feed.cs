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

namespace dotrss.Database
{
    public partial class Feed
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private ICollection<FeedItem> itemCache;
        private DateTime lastRefresh = DateTime.MinValue;

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
                        return items.ToList<FeedItem>();
                    }
                }
                else
                {
                    return itemCache;
                }
            }
        }

        public static Feed Init(string feedUri, string name, string type)
        {
            Feed initFeed = null;
            using (var db = new FeedModelContainer())
            {
                var feedUris = db.Feeds.Select(f => f.Uri).ToList<string>();
                if (!feedUris.Contains(feedUri))
                {
                    initFeed = new Feed() { Uri = feedUri, FeedType = type, Name = name, LastUpdated = DateTime.MinValue };
                    //db.Feeds.Add(initFeed);
                    //db.SaveChanges();
                }
                else
                {
                    initFeed = db.Feeds.Where(f => f.Uri.Equals(feedUri)).FirstOrDefault();
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
