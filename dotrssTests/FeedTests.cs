using dotrss.Base;
using dotrss.Database;
using dotrss.Interfaces;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace dotrss.Testing
{
    [TestFixture]
    class FeedTests
    {
        private static string resourcePfad = Path.GetFullPath(@"./Testing Resources/");
        private static string tagesschauXMLFile = "tagesschau_feed.xml";
        private static string tagesschauPfad = Path.Combine(new[] { resourcePfad, tagesschauXMLFile });
        private static string nsfwXMLFile = "nsfw_feed.xml";
        private static string nsfwPfad = Path.Combine(new[] { resourcePfad, nsfwXMLFile });
        private static string fefeXMLFile = "fefe_feed.xml";
        private static string fefePfad = Path.Combine(new[] { resourcePfad, fefeXMLFile });
        private static string nichtvorhanden = "blubb";
        private static string nichtVorhandenPfad = Path.Combine(new[] { resourcePfad, nichtvorhanden });
        private static string ungueltigeUri = "";
        private static string nichtUnterstuetzt = "hxxp://blubb";

        [Test]
        public async void ParseTagesschauItem()
        {
            IFeedReader feedReader = new FileFeedReader();
            string f = Path.GetFullPath(tagesschauPfad);
            Feed newFeed = (await feedReader.CreateFeed(f, "Tagesschau Test-Feed")).Feed;
            var items = newFeed.Items;
            //var fItems = newFeed.FeedItem.ToList<FeedItem>();
            Assert.AreEqual(40, items.Count());
            Assert.AreEqual("Niederlande feiern Willem-Alexander am \"Königstag\"", items.ElementAt(3).Title);
        }

        [Test]
        public async void ParseNSFWItem()
        {
            IFeedReader feedReader = new FileFeedReader();
            string f = Path.GetFullPath(nsfwPfad);
            Feed newFeed = (await feedReader.CreateFeed(f, "NSFW Test-Feed")).Feed;
            var items = newFeed.Items;
            Assert.AreEqual(10, items.Count());
            Assert.AreEqual("NSFW082 Erfahrungskohorte NSFW", items.ElementAt(2).Title);
        }

        [Test]
        public async void ParseFefeItem()
        {
            IFeedReader feedReader = new FileFeedReader();
            string f = Path.GetFullPath(fefePfad);
            Feed newFeed = (await feedReader.CreateFeed(f, "Fefe Test-Feed")).Feed;
            var items = newFeed.Items;
            Assert.AreEqual(20, items.Count());
            Assert.AreEqual(
                "Aus der beliebten Reihe \"bei UNS ist Kernkraft SICHER\": Rauchwolken über dem AKW Fessenheim.Ursache sei kein Feuer gewesen, sondern ein Problem mit einem Sicherungsschalter in einem Nebengebäude des Maschinenraums von Block ein.Ich bin mir sicher, dass keine Gefahr für Anwohner und Mitarbeiter besteht.",
                items.ElementAt(5).Title);
        }

        [Test]
        public async void CorrectFeedName()
        {
            IFeedReader feedReader = new FileFeedReader();
            string f = Path.GetFullPath(tagesschauPfad);
            Feed newFeed = (await feedReader.CreateFeed(f, "Tagesschau Test-Feed")).Feed;
            Assert.AreEqual("Tagesschau Test-Feed", newFeed.Name);
        }

        [Test]
        public async void FileNotFound()
        {
            IFeedReader feedReader = new FileFeedReader();
            Feed newFeed = (await feedReader.CreateFeed(nichtVorhandenPfad, "NotFound-Feed")).Feed;
            Assert.IsNull(newFeed);
        }

        [Test]
        public async void CorrectResultFileNotFound()
        {
            IFeedReader feedReader = new FileFeedReader();
            IFeedCreateResult feedResult = await feedReader.CreateFeed(nichtVorhandenPfad, "NotFound-Feed");
            Assert.AreEqual(FeedCreateResultEnum.ErrorFileNotFound, feedResult.Result);
        }

        [Test]
        public async void CorrectResultEmptyUri()
        {
            IFeedReader feedReader = new FileFeedReader();
            IFeedCreateResult feedResult = await feedReader.CreateFeed(ungueltigeUri, "Ungültiger Feed");
            Assert.AreEqual(FeedCreateResultEnum.ErrorCouldNotParseUri, feedResult.Result);
        }
    }
}
