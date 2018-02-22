using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgioGlobal.Server.Infrastructure.Helpers
{
    /// <summary>
    /// This class contais the properties to get the web.config custom parameters
    /// </summary>
    public class ConfigurationHelper
    {
        #region AppSetting
        /*
        /// <summary>
        /// Gets the name or IP address of the host used for SMTP transactions.
        /// </summary>
        public static string UrlsWebApp { get { return ConfigurationManager.AppSettings["UrlsWebApp"]; } }
        */
        /// <summary>
        /// Gest urls that connect to web api
        /// </summary>
        public static string[] UrlsWebApp
        {
            get
            {
                var urls = ConfigurationManager.AppSettings["UrlsWebApp"];
                if (!string.IsNullOrEmpty(urls))
                    return urls.Split('#');

                return new string[] { };
            }
        }

        #endregion
    }

}
