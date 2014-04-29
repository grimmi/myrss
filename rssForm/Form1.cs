using dotrss;
using dotrss.Database;
using dotrss.Base;
using dotrss.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssForm
{
    public partial class rssForm : Form
    {
        public rssForm()
        {
            InitializeComponent();
            List<Feed> feeds = new List<Feed>();
            using (var db = new dotrss.Database.FeedModelContainer())
            {
                feeds = db.Feeds.Include("FeedItem").ToList<Feed>();
            }
            foreach (var feed in feeds)
            {
                var listItem = new ListViewItem();
                listItem.Tag = feed;
                listItem.Text = feed.Name;
                listViewFeeds.Items.Add(listItem);
            }
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReadRSS_Click(object sender, EventArgs e)
        {
            TaskFactory fact = new TaskFactory();
            Task a = fact.StartNew(() => CreateFeedAndWriteFeedItemsToTextbox(@"D:\nsfw_feed.xml", "NSFW"));
            Task b = fact.StartNew(() => CreateFeedAndWriteFeedItemsToTextbox(@"D:\tagesschau_feed.xml", "Tagesschau"));
            Task c = fact.StartNew(() => CreateFeedAndWriteFeedItemsToTextbox(@"D:\fefe_feed.xml", "Fefe"));
            //cmbBoxFeedItems.DisplayMember = "ItemTitle";
            //BackgroundWorker bgWorker = new BackgroundWorker();
            //bgWorker.DoWork += HandleRssButtonClick;
            //string[] workerParams = new string[] { txtBoxRSSUrl.Text, "CulinariCast" };
            //bgWorker.RunWorkerAsync(workerParams);
        }

        private void AddTextToMultiFeed(string newText)
        {
            SuspendLayout();
            txtBoxMultiFeedBox.Text += newText + Environment.NewLine;
            ResumeLayout();
        }

        private async Task CreateFeedAndWriteFeedItemsToTextbox(string fileName, string feedName)
        {
            Debug.WriteLine(fileName + " : " + feedName);
            IFeedReader feedReader = new FileFeedReader();
            IFeedCreateResult result = await feedReader.CreateFeed(fileName, feedName);
            Feed resultFeed = result.Feed;
            foreach (var item in resultFeed.Items)
            {
                var text = item.Title.Substring(0, Math.Min(item.Title.Length, 10));
                MethodInvoker addText = () => AddTextToMultiFeed(resultFeed.Name + ": " + text);
                txtBoxMultiFeedBox.Invoke(addText);
            }
        }

        private async void HandleRssButtonClick(object sender, DoWorkEventArgs e)
        {
            string[] feedParams = e.Argument as string[];
            HandleRSSRead(feedParams[0], feedParams[1]);
        }

        private void AddFeedItem(FeedItem feedItem)
        {
            cmbBoxFeedItems.Items.Add(feedItem);
        }

        private void SetIndex(int index)
        {
            cmbBoxFeedItems.SelectedIndex = index;
        }

        private async Task HandleRSSRead(string url, string name)
        {
            try
            {
                IFeedReader feedReader = new FeedReader();
                IFeedCreateResult feedResult = await feedReader.CreateFeed(txtBoxRSSUrl.Text, "CulinariCast");
                Feed rssFeed = feedResult.Feed;
                Feed feed = (Feed)rssFeed;
                if (rssFeed != null)
                {
                    foreach (FeedItem feedItem in rssFeed.Items.OrderBy(f => f.PubDate))
                    {
                        MethodInvoker addItem = () => AddFeedItem(feedItem);
                        cmbBoxFeedItems.Invoke(addItem);
                    }
                    if (cmbBoxFeedItems.Items.Count > 0)
                    {
                        try
                        {
                            MethodInvoker setIndex = () => SetIndex(0);
                            cmbBoxFeedItems.Invoke(setIndex);
                        }
                        catch (System.Reflection.TargetParameterCountException argCountEx)
                        {
                            Debug.WriteLine(argCountEx);
                        }
                    }
                }
                else
                {
                    switch (feedResult.Result)
                    {
                        case FeedCreateResultEnum.ErrorCouldNotParseUri: MessageBox.Show("Uri hatte ungültiges Format!");
                            break;
                        case FeedCreateResultEnum.ErrorFileNotFound: MessageBox.Show("Datei konnte nicht gefunden werden!");
                            break;
                        case FeedCreateResultEnum.ErrorNotSupportedUriFormat: MessageBox.Show("Dieses Uri-Format wird nicht unterstützt!");
                            break;
                        default: MessageBox.Show("Unbekannter Fehler beim Erstellen des Feeds!");
                            break;
                    }
                }
            }
            catch (InvalidOperationException invOpEx)
            {
                Debug.WriteLine("InvOpException: " + invOpEx);
            }
        }

        private void cmbBoxFeedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox feedBox = sender as ComboBox;
            FeedItem selectedItem = feedBox.SelectedItem as FeedItem;
            feedBrowser.DocumentText = selectedItem.Body;
        }

        private void rssForm_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.Print("KeyCode: {0}, KeyValue: {1}", e.KeyCode, e.KeyValue);
            if (e.KeyCode.Equals(Keys.Right))
            {
                int curIndex = cmbBoxFeedItems.SelectedIndex;
                if (curIndex < cmbBoxFeedItems.Items.Count - 1)
                {
                    cmbBoxFeedItems.SelectedIndex = (curIndex + 1);
                }
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                int curIndex = cmbBoxFeedItems.SelectedIndex;
                if (curIndex > 0)
                {
                    cmbBoxFeedItems.SelectedIndex = (curIndex - 1);
                }
            }
        }

        private void txtBoxItemText_KeyDown(object sender, KeyEventArgs e)
        {
            rssForm_KeyDown(sender, e);
        }

        private void listViewFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                var item = listView.SelectedItems[0];
                if (item != null)
                {
                    Feed itemFeed = item.Tag as Feed;
                    txtBoxFeedDetail.Text = "";
                    txtBoxFeedDetail.Text += itemFeed.Name + Environment.NewLine;
                    txtBoxFeedDetail.Text += "Letztes Update: " + itemFeed.LastUpdated.ToShortDateString() + Environment.NewLine;
                    txtBoxFeedDetail.Text += "Anzahl Einträge: " + itemFeed.Items.Count;
                }
            }
        }
    }
}
