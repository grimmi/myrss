﻿using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotrss.Base
{
    public class FeedReader : IFeedReader
    {

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
        public IFeedCreateResult CreateFeed(string feedUri, string feedName)
        {
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            var feedString = client.DownloadString(new Uri(feedUri));
            XDocument feedXML = XDocument.Parse(feedString.Trim());
            IFeed newFeed = new Feed();
            newFeed.Init(new Uri(feedUri), feedName, feedXML);
            return new FeedCreateResult(newFeed, FeedCreateResultEnum.Success);
        }
    }
}