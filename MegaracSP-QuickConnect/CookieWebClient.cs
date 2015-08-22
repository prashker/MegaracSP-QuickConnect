using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MegaracSP_QuickConnect
{
    // With love from http://stackoverflow.com/questions/1777221/using-cookiecontainer-with-webclient-class
    class CookieWebClient : WebClient
    {
        private CookieContainer m_container = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            Console.WriteLine(address) ;
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest webRequest = request as HttpWebRequest;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2489.0 Safari/537.36";
            if (webRequest != null)
            {
                webRequest.CookieContainer = m_container;
            }
            return request;
        }

        public void augmentCookieContainer(string key, string val, string path, string domain)
        {
            Cookie c = new Cookie(key, val, path, domain);
            m_container.Add(c);
        }

    }
}
