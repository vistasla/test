using System;
using System.Windows.Forms;
namespace webspider
{
    class UpdateHtmlDocument
    {
        public UpdateHtmlDocument(string strUrl, string strTitle, string strFirstDegree, string strSecondDegree, string strOriginalTitle, string[] strArrayImage, string[] strArraySmallImage, string strTitleOriginal, string strAuthor, string strPublishingHouse, string strPublishingTime, string strFormat, string strPaper, string strPackaging, string strIsbn, string strContent, string strAuthorIntroduction, string strCatalog, string strKeywords, Boolean[] booleanArray)
        {

            Form form = new Form();
            form.SetBounds((Screen.PrimaryScreen.Bounds.Width - 800) / 2, (Screen.PrimaryScreen.Bounds.Height - 450) / 2, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            form.StartPosition = FormStartPosition.CenterScreen;

            WebBrowser webBrowser = new WebBrowser();
            webBrowser.SetBounds(0, 0, form.Width, form.Height);
            webBrowser.Dock = DockStyle.Fill;

            webBrowser.ScriptErrorsSuppressed = true;

            form.Controls.Add(webBrowser);

            form.Visible = true;

            string strPath = "C:\\Users\\pujing\\Documents\\C#\\pujing\\DetailPageTemplate1.html";

            webBrowser.Navigate(strPath);

            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;

            void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                HtmlDocument hd = webBrowser.Document;
                hd.Title = strTitle;
                hd.GetElementById("breadcrumb").FirstChild.InnerText = strFirstDegree;
                // hd.GetElementById("breadcrumb").GetElementsByTagName("a")[1].InnerText = strSecondDegree;
                hd.GetElementById("breadcrumb").Children[2].InnerText = strSecondDegree;
                // hd.GetElementById("breadcrumb").GetElementsByTagName("span")[2].InnerText = strOriginalTitle;
                hd.GetElementById("breadcrumb").Children[4].InnerText = strOriginalTitle;

                hd.GetElementById("image").SetAttribute("src", strArrayImage[0]);
                int intImageCount = strArrayImage.Length;
                for (int i = 0; i < intImageCount; i++)
                {
                    HtmlElement he = hd.CreateElement("img");
                    he.SetAttribute("src", strArraySmallImage[i]);
                    hd.GetElementById("smallimage").AppendChild(he);
                }

                hd.GetElementsByTagName("h1")[0].FirstChild.InnerText = strOriginalTitle;
                hd.GetElementsByTagName("h2")[0].FirstChild.InnerText = strTitleOriginal;
                HtmlElementCollection hec = hd.GetElementById("publishing_info").GetElementsByTagName("span");
                hec[0].InnerText = hec[0].InnerText + strAuthor;
                hec[1].InnerText = hec[1].InnerText + strPublishingHouse;
                hec[2].InnerText = hec[2].InnerText + strPublishingTime;
                HtmlElement he1 = hd.CreateElement("button");
                HtmlElement he2 = hd.CreateElement("a");
                he2.SetAttribute("href", strUrl);
                he2.SetAttribute("target", "_blank");
                he2.InnerText = "test";
                he1.AppendChild(he2);
                hd.GetElementById("buy_btn").AppendChild(he1);
                HtmlElementCollection hec1 = hd.GetElementsByTagName("li");
                hec1[0].InnerText = hec1[0].InnerText + strFormat;
                hec1[1].InnerText = hec1[1].InnerText + strPaper;
                hec1[2].InnerText = hec1[2].InnerText + strPackaging;
                hec1[3].InnerText = hec1[3].InnerText + strIsbn;
                hd.GetElementById("content").InnerHtml = strContent;
                hd.GetElementById("authorIntroduction").InnerHtml = strAuthorIntroduction;
                hd.GetElementById("catalog").InnerHtml = strCatalog;
                int intIndex = webBrowser.DocumentText.IndexOf(">") + 1;
                string strDocType = webBrowser.DocumentText.Remove(intIndex);
                string strBodyHtml = hd.GetElementsByTagName("html")[0].OuterHtml;
                string strHtml = strDocType + strBodyHtml;
                Console.WriteLine(strHtml);
                webBrowser.Dispose();
                form.Dispose();
                WriteHtmlDocument whd = new WriteHtmlDocument(strHtml, strFirstDegree, strSecondDegree, strIsbn, booleanArray);
            }
        }
    }
}
