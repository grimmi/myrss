using dotrss.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotrss.Interfaces
{
    /// <summary>
    /// Results of creating (reading) a new feed
    /// </summary>
    public interface IFeedCreateResult
    {
        Feed Feed { get; }
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
