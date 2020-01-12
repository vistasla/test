using System;
using System.Windows.Forms;
namespace webspider
{
    class ParseHtmlDocument
    {
        public ParseHtmlDocument(string strUrl, Boolean[] booleanArray)
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

            webBrowser.Navigate(strUrl);
            int intLoadTime = 0;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;

            void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                intLoadTime++;
                if (intLoadTime == 5)
                {

                    MessageBox.Show(null);

                    HtmlDocument hd = webBrowser.Document;
                    int intIndex = hd.Title.IndexOf(")") + 1;
                    string strTitle = hd.Title.Remove(intIndex);
                    HtmlElement he = hd.GetElementById("breadcrumb");
                    string strFirstDegree = he.GetElementsByTagName("a")[1].InnerText;
                    string strSecondDegree = he.GetElementsByTagName("a")[2].InnerText;
                    string strOriginalTitle = he.GetElementsByTagName("span")[3].InnerText;
                    HtmlElement he1 = hd.GetElementsByTagName("h2")[0];
                    string strTitleOriginal = he1.Children[0].InnerText;
                    //string strTitleOriginal = he1.GetElementsByTagName("span")[0].InnerText;
                    string strAuthor = hd.GetElementById("author").GetElementsByTagName("a")[0].InnerText;
                    HtmlElement he2 = hd.GetElementById("product_info");
                    HtmlElementCollection hec = he2.GetElementsByTagName("a");
                    string strPublishingHouse = hec[1].InnerText;
                    HtmlElement he3 = he2.GetElementsByTagName("span")[5];
                    int intIndex1 = he3.InnerText.IndexOf(":") + 1;
                    string strPublishingTime = he3.InnerText.Substring(intIndex1);
                    HtmlElementCollection hec1 = hd.GetElementById("main-img-slider").GetElementsByTagName("li");
                    int intImageCount = (hec1.Count / 3) - 1;
                    string[] strArrayImage = new string[intImageCount];
                    string[] strArraySmallImage = new string[intImageCount];
                    for (int i = 0; i < intImageCount; i++)
                    {
                        strArrayImage[i] = hec1[i].FirstChild.GetAttribute("data-imghref");
                        strArraySmallImage[i] = hec1[i].FirstChild.FirstChild.GetAttribute("src");
                    }
                    //HtmlElement he4 = hd.GetElementById("detail_describe").FirstChild;
                    HtmlElement he4 = hd.GetElementById("detail_describe").Children[0];

                    HtmlElement he5 = he4.GetElementsByTagName("li")[0];
                    int intIndex2 = he5.InnerText.IndexOf("：") + 1;
                    string strFormat = he5.InnerText.Substring(intIndex2);

                    HtmlElement he6 = he4.GetElementsByTagName("li")[1];
                    int intIndex3 = he6.InnerText.IndexOf("：") + 1;
                    string strPaper = he6.InnerText.Substring(intIndex3);

                    HtmlElement he7 = he4.GetElementsByTagName("li")[2];
                    int intIndex4 = he7.InnerText.IndexOf("：") + 1;
                    string strPackaging = he7.InnerText.Substring(intIndex4);

                    HtmlElement he8 = he4.GetElementsByTagName("li")[4];
                    int intIndex5 = he8.InnerText.IndexOf("：") + 1;
                    string strIsbn = he8.InnerText.Substring(intIndex5);

                    string strContent = hd.GetElementById("content").InnerHtml;
                    string strAuthorIntroduction = hd.GetElementById("authorIntroduction").InnerHtml;
                    //string strCatalog = hd.GetElementById("catalog").InnerHtml;
                    string strCatalog = hd.GetElementById("catalog-textarea").InnerHtml;

                    string strKeywords = strOriginalTitle + "," + strOriginalTitle + " " + strAuthor + "," + strOriginalTitle + " " + strFirstDegree + "," + strOriginalTitle + " " + strSecondDegree + "," + strOriginalTitle + " test," + strOriginalTitle + " pdf," + strOriginalTitle + " " + strAuthor + " pdf,<<" + strOriginalTitle + ">>,<<" + strOriginalTitle + ">> pdf";
                    
                    webBrowser.Dispose();
                    form.Dispose();
                    InsertHtmlDocumentInfo ihdi = new InsertHtmlDocumentInfo(strUrl, strTitle, strFirstDegree, strSecondDegree, strOriginalTitle, strArrayImage, strArraySmallImage, strTitleOriginal, strAuthor, strPublishingHouse, strPublishingTime, strFormat, strPaper, strPackaging, strIsbn, strContent, strAuthorIntroduction, strCatalog, strKeywords);
                    // UpdateHtmlDocument uhd = new UpdateHtmlDocument( strUrl,strTitle, strFirstDegree,strSecondDegree,strOriginalTitle,strArrayImage,strArraySmallImage,strTitleOriginal, strAuthor,strPublishingHouse,strPublishingTime,strFormat,strPaper,strPackaging,strIsbn,strContent,strAuthorIntroduction,strCatalog,strKeywords, booleanArray);

                }



            }
        }
    }
}
