﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Interfaces
{
    public interface IFeedItem
    {
        string ItemTitle { get; set; }
        string ItemDescription { get; set; }
        string ItemBody { get; set; }
        DateTime? ItemDate { get; set; }
        string ToString();
    }
}
