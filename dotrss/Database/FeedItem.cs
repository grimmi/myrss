//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dotrss.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeedItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string UId { get; set; }
        public System.DateTime PubDate { get; set; }
        public string Link { get; set; }
    
        public virtual Feed Feed { get; set; }
    }
}
