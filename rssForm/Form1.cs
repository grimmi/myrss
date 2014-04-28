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
            //IFeedReader feedReader = new FileFeedReader();
            //IFeedCreateResult feedResult = feedReader.CreateFeed(@"D:\fefe_feed.xml", "fefe");
            IFeedReader feedReader = new FeedReader();
            IFeedCreateResult feedResult = feedReader.CreateFeed(txtBoxRSSUrl.Text, "CulinariCast");
            Feed rssFeed = feedResult.Feed;
            Feed feed = (Feed)rssFeed;
            if (rssFeed != null)
            {
                foreach (FeedItem feedItem in rssFeed.Items.OrderBy(f => f.PubDate))
                {
                    cmbBoxFeedItems.Items.Add(feedItem);
                    cmbBoxFeedItems.DisplayMember = "ItemTitle";
                }
                if (rssFeed.Items.Count() > 0)
                {
                    cmbBoxFeedItems.SelectedIndex = 0;
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
