﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Interfaces
{
    public interface IFeedCreateResult
    {
        IFeed Feed { get; }
        FeedCreateResultEnum Result { get; }
    }

    public enum FeedCreateResultEnum
    {
        Success,
        ErrorFileNotFound,
        ErrorCouldNotParseUri,
        ErrorNotSupportedUriFormat,
        ErrorInvalidPath
    }
}
