using dotrss;
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
            IFeed rssFeed = feedResult.Feed;
            if (rssFeed != null)
            {
                foreach (IFeedItem feedItem in rssFeed.Items.OrderBy(f => f.ItemDate))
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
            IFeedItem selectedItem = feedBox.SelectedItem as IFeedItem;
            txtBoxItemText.Text = selectedItem.ItemDescription;
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
    }
}
