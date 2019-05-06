using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Vishnu.Extensions.StringType
{
    /// <summary>
    /// String Criptography extensions
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Get MD5 has of the content
        /// </summary>
        /// <param name="content">string value</param>
        /// <returns>MD5 Hash</returns>
        public static string GetMd5Hash(this string content)
        {
            var provider = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(content);
            bytes = provider.ComputeHash(bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
