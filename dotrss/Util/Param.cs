using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Util
{
    /// <summary>
    /// Global Parameters
    /// </summary>
    public static class Param
    {
        // ******************************
        // * Parameters for parsing XML *
        // ******************************
        public static string XMLItemTag = "item";
        public static string XMLPubDateTag = "pubDate";
        public static string XMLTitleTag = "title";
        public static string XMLDescriptionTag = "description";
        public static string XMLContentTag = "content";

        // **************
        // * Feed-Types *
        // **************
        public const string FeedTypeFile = "file";
        public const string FeedTypeWeb = "web";

        // **************************
        // * Placeholder Parameters *
        // **************************
        public static string PlaceHolderString = "n/a";
    }

    public enum FeedType
    {
        File,
        Web
    }
}
