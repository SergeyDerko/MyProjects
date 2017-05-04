using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AngleSharp.Parser.Html;
using AngleSharp.Dom.Html;

namespace Apartments
{
    class DownloadPage
    {
        public List<IHtmlDocument> Bucha { get; set; }

        public DownloadPage()
        {
            Bucha = DownloadDom(SitePages.SitePagesBucha());
        }
        

       List<IHtmlDocument> DownloadDom(IEnumerable<string> page)
        {
            List<IHtmlDocument> documentList = new List<IHtmlDocument>();
            foreach (var item in page)
            {
                var htmlParser = new HtmlParser();
                var siteList = new List<string>();
                using (var webClient = new WebClient { Encoding = Encoding.UTF8 })
                {
                    // combine https + site name
                    var downloadResult = webClient.DownloadString(item);
                    var document = htmlParser.Parse(downloadResult);
                    var resultFindList = document.QuerySelectorAll("a.no-decor");
                    siteList.AddRange(resultFindList.Select(x => $"https://novostroyki.lun.ua{x.GetAttribute("href")}"));
                    // download site DOM
                    foreach (var siteaddress in siteList)
                    {
                        var downloadResult2 = webClient.DownloadString(siteaddress);
                        documentList.Add(htmlParser.Parse(downloadResult2));
                    }
                }
            }

            return documentList;
        }

    }
}
