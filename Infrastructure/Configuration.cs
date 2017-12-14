using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using Infrastructure;

namespace FB_PlayerTransactions.Infrastructure
{
    public static class ConfigReader
    {
        public static string OutputDirectory
        {
            get
            {
                NameValueCollection appSettings;
                appSettings = ConfigurationManager.AppSettings;

                if (appSettings["OutputDirectory"].HasValue())
                {
                    return appSettings["OutputDirectory"];
                }
                else
                    throw new Exception("Unknown 'OutputDirectory'. This data should be at the App.config file");
            }
        }
        public static string YahooNonParameterTransactionUrl
        {
            get
            {
                NameValueCollection appSettings;
                appSettings = ConfigurationManager.AppSettings;

                if (appSettings["YahooNonParameterTransactionUrl"].HasValue())
                {
                    return appSettings["YahooNonParameterTransactionUrl"];
                }
                else
                    throw new Exception("Unknown 'YahooNonParameterTransactionUrl'. This data should be at the App.config file");
            }
        }
    }
}
