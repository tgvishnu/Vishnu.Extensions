using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace Vishnu.Extensions.CollectionType
{
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// Get query string from namevalue collection
        /// </summary>
        /// <param name="nvc"><see cref="NameValueCollection"/></param>
        /// <returns>query string</returns>
        public static string ToQueryString(this NameValueCollection nvc)
        {
            return string.Join("&", nvc.AllKeys.Select(key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
        }
    }
}
