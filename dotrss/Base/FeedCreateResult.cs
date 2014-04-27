using dotrss.Interfaces;
using dotrss.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Base
{
    public class FeedCreateResult : IFeedCreateResult
    {
        private readonly Feed feed;
        private readonly FeedCreateResultEnum result;

        public FeedCreateResult()
        {

        }

        public FeedCreateResult(Feed feed, FeedCreateResultEnum result)
        {
            this.feed = feed;
            this.result = result;
        }

        public Feed Feed
        {
            get { return feed; }
        }

        public FeedCreateResultEnum Result
        {
            get { return result; }
        }
    }
}
