using dotrss.Base;
using dotrss.Interfaces;
using NUnit.Framework;
using System;

namespace dotrssTests
{
    [TestFixture]
    public class FeedItemTests
    {
        [Test]
        public void FeedItemToStringDateNow()
        {
            DateTime testDateTime = DateTime.Now;
            IFeedItem feedItem = new FeedItem("Titel", "Beschreibung", "Body", testDateTime);
            var itemString = feedItem.ToString();
            var timeString = testDateTime.ToShortDateString();
            var expectedString = "Titel: Beschreibung (" + timeString + ") " + Environment.NewLine + " Body";
            Assert.AreEqual(itemString, expectedString);
        }
        [Test]
        public void FeedItemToStringDateNull()
        {
            DateTime? testDateTime = null;
            IFeedItem feedItem = new FeedItem("Titel", "Beschreibung", "Body", testDateTime);
            var itemString = feedItem.ToString();
            var timeString = "n/a";
            var expectedString = "Titel: Beschreibung (" + timeString + ") " + Environment.NewLine + " Body";
            Assert.AreEqual(itemString, expectedString);
        }
    }
}
