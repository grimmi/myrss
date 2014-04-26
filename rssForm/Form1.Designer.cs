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
            this.txtBoxItemText = new System.Windows.Forms.RichTextBox();
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
            // txtBoxItemText
            // 
            this.txtBoxItemText.Enabled = false;
            this.txtBoxItemText.Location = new System.Drawing.Point(13, 97);
            this.txtBoxItemText.Name = "txtBoxItemText";
            this.txtBoxItemText.Size = new System.Drawing.Size(529, 346);
            this.txtBoxItemText.TabIndex = 4;
            this.txtBoxItemText.Text = "";
            this.txtBoxItemText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxItemText_KeyDown);
            // 
            // rssForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 455);
            this.Controls.Add(this.txtBoxItemText);
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
        private System.Windows.Forms.RichTextBox txtBoxItemText;
    }
}

