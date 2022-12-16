using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace UfcFightCard
{
    public static class HtmlDownloader
    {
        public static async Task<string> DownloadHtml (string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            return html;
        }
    }
}
