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
            this.txtBoxMultiFeedBox = new System.Windows.Forms.TextBox();
            this.treeViewFeedList = new System.Windows.Forms.TreeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtBoxFeedName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.txtBoxRSSUrl.Size = new System.Drawing.Size(367, 20);
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
            this.listViewFeeds.Size = new System.Drawing.Size(136, 111);
            this.listViewFeeds.TabIndex = 5;
            this.listViewFeeds.UseCompatibleStateImageBehavior = false;
            this.listViewFeeds.SelectedIndexChanged += new System.EventHandler(this.listViewFeeds_SelectedIndexChanged);
            // 
            // txtBoxFeedDetail
            // 
            this.txtBoxFeedDetail.Location = new System.Drawing.Point(703, 13);
            this.txtBoxFeedDetail.Multiline = true;
            this.txtBoxFeedDetail.Name = "txtBoxFeedDetail";
            this.txtBoxFeedDetail.Size = new System.Drawing.Size(190, 29);
            this.txtBoxFeedDetail.TabIndex = 6;
            // 
            // feedBrowser
            // 
            this.feedBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feedBrowser.Location = new System.Drawing.Point(3, 3);
            this.feedBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.feedBrowser.Name = "feedBrowser";
            this.feedBrowser.Size = new System.Drawing.Size(577, 310);
            this.feedBrowser.TabIndex = 7;
            // 
            // txtBoxMultiFeedBox
            // 
            this.txtBoxMultiFeedBox.Location = new System.Drawing.Point(703, 48);
            this.txtBoxMultiFeedBox.Multiline = true;
            this.txtBoxMultiFeedBox.Name = "txtBoxMultiFeedBox";
            this.txtBoxMultiFeedBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxMultiFeedBox.Size = new System.Drawing.Size(190, 76);
            this.txtBoxMultiFeedBox.TabIndex = 8;
            // 
            // treeViewFeedList
            // 
            this.treeViewFeedList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewFeedList.Location = new System.Drawing.Point(3, 3);
            this.treeViewFeedList.Name = "treeViewFeedList";
            this.treeViewFeedList.Size = new System.Drawing.Size(287, 310);
            this.treeViewFeedList.TabIndex = 9;
            this.treeViewFeedList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFeedList_AfterSelect);
            this.treeViewFeedList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFeedList_NodeMouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(230, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "refresh feeds";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtBoxFeedName
            // 
            this.txtBoxFeedName.Location = new System.Drawing.Point(386, 13);
            this.txtBoxFeedName.Name = "txtBoxFeedName";
            this.txtBoxFeedName.Size = new System.Drawing.Size(156, 20);
            this.txtBoxFeedName.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 127);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewFeedList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.feedBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(880, 316);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 12;
            // 
            // rssForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 455);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtBoxFeedName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtBoxMultiFeedBox);
            this.Controls.Add(this.txtBoxFeedDetail);
            this.Controls.Add(this.listViewFeeds);
            this.Controls.Add(this.cmbBoxFeedItems);
            this.Controls.Add(this.btnBeenden);
            this.Controls.Add(this.txtBoxRSSUrl);
            this.Controls.Add(this.btnReadRSS);
            this.Name = "rssForm";
            this.Text = "RSS Form";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rssForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtBoxMultiFeedBox;
        private System.Windows.Forms.TreeView treeViewFeedList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtBoxFeedName;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

