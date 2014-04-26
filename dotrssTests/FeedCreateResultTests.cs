using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using dotrss.Base;
using dotrss.Interfaces;

namespace dotrssTests
{
    [TestFixture]
    class FeedCreateResultTests
    {
        [Test]
        public void FeedCreateResultConstructor()
        {
            IFeedCreateResult feedResult = new FeedCreateResult();
            FeedCreateResultEnum result = default(FeedCreateResultEnum);
            Assert.IsNull(feedResult.Feed);
            Assert.AreEqual(result, feedResult.Result);
        }
    }
}
