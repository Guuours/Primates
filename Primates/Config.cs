using System;
using System.ComponentModel;
using System.Configuration;
using System.Text;

namespace Primates
{
    internal class Config
    {
        #region mandrill

        private static string mandrillKey;
        public static string MandrillKey
        {
            get
            {
                if (string.IsNullOrEmpty(mandrillKey))
                {
                    mandrillKey = ConfigurationManager.AppSettings["MandrillKey"];
                    if (string.IsNullOrEmpty(mandrillKey))
                    {
                        // no key
                        throw new Exception("An entry named \"MandrillKey\" with a valid api key should be placed in appsettings.");
                    }
                }

                return mandrillKey;
            }
        }

        #endregion

        #region mailchimp

        private static string mailChimpKey;
        public static string MailChimpKey
        {
            get
            {
                if (string.IsNullOrEmpty(mailChimpKey))
                {
                    mailChimpKey = ConfigurationManager.AppSettings["MailChimpKey"];
                    if (string.IsNullOrEmpty(mailChimpKey))
                    {
                        // no key
                        throw new Exception("An entry named \"MailChimpKey\" with a valid api key should be placed in appsettings.");
                    }
                }

                return mailChimpKey;
            }
        }

        private static string apiRoot;
        public static string APIRoot
        {
            get
            {
                if (string.IsNullOrEmpty(apiRoot))
                {
                    string dc = MailChimpKey.Split('-')[1];
                    apiRoot = $"https://{dc}.api.mailchimp.com/3.0/";
                }

                return apiRoot;
            }
        }

        private static string authorization;
        public static string Authorization
        {
            get
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    string raw = $"mailchimp:{MailChimpKey}";
                    authorization = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(raw));
                }

                return authorization;
            }
        }

        #endregion
    }
}
