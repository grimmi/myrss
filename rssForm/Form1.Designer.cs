namespace rssForm
{
    partial class rssForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadRSS = new System.Windows.Forms.Button();
            this.txtBoxRSSUrl = new System.Windows.Forms.TextBox();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.cmbBoxFeedItems = new System.Windows.Forms.ComboBox();
            this.listViewFeeds = new System.Windows.Forms.ListView();
            this.txtBoxFeedDetail = new System.Windows.Forms.TextBox();
            this.feedBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnReadRSS
            // 
            this.btnReadRSS.Location = new System.Drawing.Point(12, 39);
            this.btnReadRSS.Name = "btnReadRSS";
            this.btnReadRSS.Size = new System.Drawing.Size(75, 23);
            this.btnReadRSS.TabIndex = 0;
            this.btnReadRSS.Text = "read rss";
            this.btnReadRSS.UseVisualStyleBackColor = true;
            this.btnReadRSS.Click += new System.EventHandler(this.btnReadRSS_Click);
            // 
            // txtBoxRSSUrl
            // 
            this.txtBoxRSSUrl.Location = new System.Drawing.Point(13, 13);
            this.txtBoxRSSUrl.Name = "txtBoxRSSUrl";
            this.txtBoxRSSUrl.Size = new System.Drawing.Size(529, 20);
            this.txtBoxRSSUrl.TabIndex = 1;
            this.txtBoxRSSUrl.Text = "http://www.culinaricast.de/feed/";
            // 
            // btnBeenden
            // 
            this.btnBeenden.Location = new System.Drawing.Point(467, 39);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(75, 23);
            this.btnBeenden.TabIndex = 2;
            this.btnBeenden.Text = "beenden";
            this.btnBeenden.UseVisualStyleBackColor = true;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            // 
            // cmbBoxFeedItems
            // 
            this.cmbBoxFeedItems.FormattingEnabled = true;
            this.cmbBoxFeedItems.Location = new System.Drawing.Point(13, 69);
            this.cmbBoxFeedItems.Name = "cmbBoxFeedItems";
            this.cmbBoxFeedItems.Size = new System.Drawing.Size(529, 21);
            this.cmbBoxFeedItems.TabIndex = 3;
            this.cmbBoxFeedItems.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFeedItems_SelectedIndexChanged);
            // 
            // listViewFeeds
            // 
            this.listViewFeeds.FullRowSelect = true;
            this.listViewFeeds.Location = new System.Drawing.Point(560, 13);
            this.listViewFeeds.MultiSelect = false;
            this.listViewFeeds.Name = "listViewFeeds";
            this.listViewFeeds.Size = new System.Drawing.Size(136, 430);
            this.listViewFeeds.TabIndex = 5;
            this.listViewFeeds.UseCompatibleStateImageBehavior = false;
            this.listViewFeeds.SelectedIndexChanged += new System.EventHandler(this.listViewFeeds_SelectedIndexChanged);
            // 
            // txtBoxFeedDetail
            // 
            this.txtBoxFeedDetail.Location = new System.Drawing.Point(703, 13);
            this.txtBoxFeedDetail.Multiline = true;
            this.txtBoxFeedDetail.Name = "txtBoxFeedDetail";
            this.txtBoxFeedDetail.Size = new System.Drawing.Size(190, 231);
            this.txtBoxFeedDetail.TabIndex = 6;
            // 
            // feedBrowser
            // 
            this.feedBrowser.Location = new System.Drawing.Point(13, 97);
            this.feedBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.feedBrowser.Name = "feedBrowser";
            this.feedBrowser.Size = new System.Drawing.Size(529, 346);
            this.feedBrowser.TabIndex = 7;
            // 
            // rssForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 455);
            this.Controls.Add(this.feedBrowser);
            this.Controls.Add(this.txtBoxFeedDetail);
            this.Controls.Add(this.listViewFeeds);
            this.Controls.Add(this.cmbBoxFeedItems);
            this.Controls.Add(this.btnBeenden);
            this.Controls.Add(this.txtBoxRSSUrl);
            this.Controls.Add(this.btnReadRSS);
            this.Name = "rssForm";
            this.Text = "RSS Form";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rssForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadRSS;
        private System.Windows.Forms.TextBox txtBoxRSSUrl;
        private System.Windows.Forms.Button btnBeenden;
        private System.Windows.Forms.ComboBox cmbBoxFeedItems;
        private System.Windows.Forms.ListView listViewFeeds;
        private System.Windows.Forms.TextBox txtBoxFeedDetail;
        private System.Windows.Forms.WebBrowser feedBrowser;
    }
}

