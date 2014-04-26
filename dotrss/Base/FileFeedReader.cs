using dotrss.Interfaces;
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
                Feed newFeed = new Feed();
                string fileString = File.ReadAllText(fileName).Trim();
                newFeed.Init(new Uri(fileName), feedName, XDocument.Parse(fileString));
                return new FeedCreateResult(newFeed as IFeed, FeedCreateResultEnum.Success);
            }
            catch (FileNotFoundException notFoundEx)
            {
                logger.ErrorException(">>>>>>>>", notFoundEx);
                return new FeedCreateResult(null, FeedCreateResultEnum.ErrorFileNotFound);
            }
            catch (NotSupportedException notSuppEx)
            {
                logger.ErrorException(">>>>>>>>", notSuppEx);
                return new FeedCreateResult(null, FeedCreateResultEnum.ErrorNotSupportedUriFormat);
            }
            catch (ArgumentException argEx)
            {
                logger.ErrorException(">>>>>>>>", argEx);
                return new FeedCreateResult(null, FeedCreateResultEnum.ErrorInvalidPath);
            }
        }
    }
}
