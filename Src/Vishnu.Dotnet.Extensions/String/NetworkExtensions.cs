using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace Vishnu.Extensions.StringType
{
    /// <summary>
    /// String network extension
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="messageBody">mail body</param>
        /// <param name="subject">mail subject</param>
        /// <param name="sender">sender address</param>
        /// <param name="receiver">receiver address</param>
        /// <param name="server">mail server</param>
        /// <returns></returns>
        public static bool SendMail(this string messageBody, string subject, string sender, string receiver, string server)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(receiver);
                MailAddress fromAddress = new MailAddress(sender);
                mail.From = fromAddress;
                mail.Subject = subject;
                mail.Body = messageBody;
                SmtpClient cient = new SmtpClient(server);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                cient.Credentials = credentials;
                cient.Send(mail);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check URL validity
        /// </summary>
        /// <param name="text">Url</param>
        /// <returns>true or false</returns>
        public static bool IsValidUrl(this string text)
        {
            Regex regex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return regex.IsMatch(text);
        }

        /// <summary>
        /// Check for IP address validity
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>true or false</returns>
        public static bool IsValidIPAdress(this string ipAddress)
        {
            return Regex.IsMatch(ipAddress,
                    @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }

        /// <summary>
        /// Get system response statys
        /// </summary>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="timeout">timeout</param>
        /// <param name="retry">retry count</param>
        /// <returns>true or false</returns>
        public static bool Ping(this string ipAddress, int timeout = 1000, int retry = 3)
        {
            bool result = false;
            try
            {
                Ping ping = new Ping();
                for (int ii = 0; ii < retry; ii++)
                {
                    PingReply reply = ping.Send(ipAddress, timeout);
                    if (reply != null)
                    {
                        if (reply.Status == IPStatus.Success)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }

            return result;
        }
    }
}
