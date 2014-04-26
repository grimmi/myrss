using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Base
{
    public class FeedCreateResult : IFeedCreateResult
    {
        private readonly IFeed feed;
        private readonly FeedCreateResultEnum result;

        public FeedCreateResult()
        {

        }

        public FeedCreateResult(IFeed feed, FeedCreateResultEnum result)
        {
            this.feed = feed;
            this.result = result;
        }

        public IFeed Feed
        {
            get { return feed; }
        }

        public FeedCreateResultEnum Result
        {
            get { return result; }
        }
    }
}
