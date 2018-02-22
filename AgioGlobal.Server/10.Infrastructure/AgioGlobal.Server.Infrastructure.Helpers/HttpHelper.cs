using System.Net;
using System.Net.Http;

namespace AgioGlobal.Server.Infrastructure.Helpers
{
    public class HttpHelper
    {
        public static HttpResponseMessage GetHttpResponseErrorMessage(string message)
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(message)
            };
        }

        /// <summary>
        /// Checks if url is valid to connect to web api
        /// </summary>
        /// <param name="origen"></param>
        /// <returns></returns>
        public static bool IsUrlValid(string origen)
        {
            foreach (string url in ConfigurationHelper.UrlsWebApp)
            {
                if (origen.StartsWith(url))
                    return true;
            }

            return false;
        }
    }

}
