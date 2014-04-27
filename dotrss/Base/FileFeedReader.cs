using dotrss.Database;
using dotrss.Interfaces;
using dotrss.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotrss.Base
{
    /// <summary>
    /// Handles feed-creation from (local) files
    /// </summary>
    public class FileFeedReader : IFeedReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IFeedCreateResult CreateFeed(string fileName, string feedName)
        {
            try
            {
                Feed newFeed = null;
                Uri fileUri = new Uri(fileName);
                if (File.Exists(fileName))
                {
                    newFeed = Feed.Init(fileName, feedName, Param.FeedTypeFile);
                    return new FeedCreateResult(newFeed, FeedCreateResultEnum.Success);
                }
                else
                {
                    return new FeedCreateResult(null, FeedCreateResultEnum.ErrorFileNotFound);
                }
            }
            catch (UriFormatException uriFormatEx)
            {
                logger.ErrorException(">>>>>>>>>", uriFormatEx);
                return new FeedCreateResult(null, FeedCreateResultEnum.ErrorCouldNotParseUri);
            }
            catch (ArgumentException argEx)
            {
                logger.ErrorException(">>>>>>>>", argEx);
                return new FeedCreateResult(null, FeedCreateResultEnum.ErrorInvalidPath);
            }
        }
    }
}
