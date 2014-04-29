using dotrss.Interfaces;
using dotrss.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dotrss.Util;
using System.Diagnostics;
using NLog;

namespace dotrss.Base
{
    public class FeedReader : IFeedReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public FeedReader()
        {
            // placeholder for handling ssl
            ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
        }

        /// <summary>
        /// Simple Method without error handling. It just downloads the feed as string and parses it to XDocument
        /// </summary>
        /// <param name="feedUri">Uri of the feed</param>
        /// <param name="feedName">Name of the feed</param>
        /// <returns></returns>
        public async Task<IFeedCreateResult> CreateFeed(string feedUri, string feedName)
        {
            Feed newFeed = await Feed.Init(feedUri, feedName, Param.FeedTypeWeb);
            return new FeedCreateResult(newFeed, FeedCreateResultEnum.Success);
        }
    }
}
