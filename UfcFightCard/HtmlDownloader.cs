using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace UfcFightCard
{
    public static class HtmlDownloader
    {
        public static string DownloadHtml (string url)
        {
            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = client.GetAsync(url).Result;
            using HttpContent content = response.Content;
            return content.ReadAsStringAsync().Result;
        }
    }
}
