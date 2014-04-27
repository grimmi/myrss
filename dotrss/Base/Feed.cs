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
        public ICollection<FeedItem> Items
        {
            get
            {
                return this.FeedItem;
            }
        }
        public void Init(string feedUri, string name, string type)
        {
            Uri = feedUri;
            Name = name;
            FeedType = type;
            LastUpdated = DateTime.MinValue;
            using (var db = new FeedModelContainer())
            {
                db.Feeds.Add(this);
                db.SaveChanges();
            }
            ReadItems();
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
                foreach (var item in items)
                {
                    try
                    {
                        int nextId = db.FeedItems.Select(i => i.Id).OrderByDescending(i => i).FirstOrDefault();
                        nextId++;
                        item.Id = nextId;
                        db.FeedItems.Add(item);
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
