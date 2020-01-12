using System;
using System.Windows.Forms;
namespace webspider
{
    class GetCategoryUrl
    {
        public GetCategoryUrl(string strUrl)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(strUrl);
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                HtmlDocument hd = webBrowser.Document;
                HtmlElement he = hd.GetElementById("floor_1");
                HtmlElementCollection hec = he.Children;

                int inthecCount = hec.Count;

                for (int i = 0; i < inthecCount; i++)
                {
                    if (i > 0 && i < (inthecCount - 5))
                    {
                        HtmlElement he1 = hec[i].GetElementsByTagName("ul")[0];
                        HtmlElementCollection hec1 = he1.GetElementsByTagName("li");

                        int inthec1Count = hec1.Count;

                        for (int j = 0; j < inthec1Count - 1; j++)
                        {
                            string strUrl1 = hec1[j].FirstChild.GetAttribute("href");

                            InsertCategoryUrl icu = new InsertCategoryUrl(strUrl1);
                        }
                    }
                }
                Console.WriteLine("yunxingjieshu");
            }
        }
    }
}
