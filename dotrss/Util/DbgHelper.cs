using dotrss.Database;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Util
{
    public static class DbgHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void CurrentNumberOfFeeds(string msg = "")
        {
            using (var db = new FeedModelContainer())
            {
                logger.Debug(msg + "Aktuelle Zahl von Feeds: " + db.Feeds.Count());
            }
        }

        public static void CurrentNumberOfItemsInFeed(int feedId, string msg = "")
        {
            using (var db = new FeedModelContainer())
            {
                var itemCount = db.Feeds.Where(f => f.Id == feedId).FirstOrDefault().Items.Count;
                logger.Debug(msg + "Aktuelle Zahl von Items in Feed " + feedId + ": " + itemCount);
            }
        }
    }
}
