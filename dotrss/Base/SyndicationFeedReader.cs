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
            try
            {
                XmlReader reader = XmlReader.Create(feedUri);
                SyndicationFeed synFeed = SyndicationFeed.Load(reader);
                foreach (var synItem in synFeed.Items.Take(5))
                {
                    FeedItem theItem = new FeedItem(synItem);
                }
                Feed newFeed = await Feed.Init(feedUri, feedName, Param.FeedTypeWeb);
            }
            catch (XmlException xmlEx)
            {
                logger.DebugException("xmlEx: ", xmlEx);
            }
            return null;
        }

        private void DebugSyndicationFeed(SyndicationFeed synFeed)
        {
            logger.Debug(synFeed.Title.Text);
            logger.Debug(synFeed.LastUpdatedTime);
        }
    }
}
