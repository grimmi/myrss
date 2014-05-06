using dotrss.Database;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRss.Controllers
{
    public class ReadingListController : Controller
    {
        //
        // GET: /ReadingList/
        public ActionResult Index()
        {
            //IEnumerable<Feed> feeds = new FeedModelContainer().Feeds.Include(f => f.FeedItem);
            IEnumerable<FeedItem> feedItems = new FeedModelContainer().FeedItems.Include(i => i.Feed);
            return View(feedItems.OrderBy(i => i.PubDate));
        }
    }
}