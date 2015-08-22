using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace MegaracSP_QuickConnect
{
    class MegaracKVM
    {
        public static void DownloadAndRunKVM(Server s)
        {
            // The gnarliest hack to avoid parsing JSON
            // You may ask me why I wanted to do this? 
            // Well load create.asp yourself. Look at the response.
            string regexToExtractSession = @"'SESSION_COOKIE' : '([^']*)'";

            // POST
            // WEBVAR_USERNAME
            // WEBVAR_PASSWORD

            // URL 1 Login: http://<>/rpc/WEBSES/create.asp

            string loginURL = String.Format("http://{0}/rpc/WEBSES/create.asp", s.host);
            string downloadURL = String.Format("http://{0}/Java/jviewer.jnlp?EXTRNIP={0}&JNLPSTR=JViewer", s.host);

            // http://stackoverflow.com/questions/581570/how-can-i-create-a-temp-file-with-a-specific-extension-with-net
            // We want jnlp extension so java opens itself :)
            string downloadPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".jnlp";

            using (CookieWebClient wc = new CookieWebClient())
            {
                // Login
                NameValueCollection parms = new NameValueCollection();
                parms.Add("WEBVAR_USERNAME", s.username);
                parms.Add("WEBVAR_PASSWORD", s.password);

                byte[] responsebytes = wc.UploadValues(loginURL, "POST", parms);
                string response = Encoding.UTF8.GetString(responsebytes);

                Match m = Regex.Match(response, regexToExtractSession);

                //Console.WriteLine(m.Groups[0].Value);
                //Console.WriteLine(m.Groups[1].Value);

                // Two new cookies needed
                // BMC_IP_ADDR
                // SessionCookie
                // test=1
                wc.augmentCookieContainer("SessionCookie", m.Groups[1].Value, "/", s.host);
                wc.augmentCookieContainer("BMC_IP_ADDR", s.host, "/", s.host);
                // TODO: Login confirmed check???

                // Download to TMP
                wc.DownloadFile(downloadURL, downloadPath);
                System.Diagnostics.Process.Start(downloadPath);

                // Console.WriteLine("Downloaded!");
            }


            // Download to TMP

            // Execute
        }

    }
}
