using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using NLog;
using dotrss.Database;
using dotrss.Util;

namespace dotrss.Base
{
    public class SyndicationFeedReader : IFeedReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public async Task<IFeedCreateResult> CreateFeed(string feedUri, string feedName)
        {
            XmlReader reader = XmlReader.Create(feedUri);
            SyndicationFeed synFeed = SyndicationFeed.Load(reader);
            Feed newFeed = await Feed.Init(feedUri, feedName, Param.FeedTypeWeb);
            return null;
        }

        private void DebugSyndicationFeed(SyndicationFeed synFeed)
        {
            logger.Debug(synFeed.Title.Text);
            logger.Debug(synFeed.LastUpdatedTime);
        }
    }
}
