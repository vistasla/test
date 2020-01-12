test
using System;
using System.Windows.Forms;
namespace webspider
{
    class ComputeCategoryCount
    {
        Boolean[] booleanArray = new Boolean[5];
        Double[] doubleArray = new Double[4];
        string[] stringArray = new string[1];
        public ComputeCategoryCount(string strUrl)
        {
            booleanArray[0] = true;
            booleanArray[1] = true;
            booleanArray[2] = true;
            booleanArray[3] = true;
            booleanArray[4] = true;
            doubleArray[0] = 0.00;
            doubleArray[1] = 20.00;
            doubleArray[2] = 10.00;
            doubleArray[3] = -1.00;
            Double doubleLowprice = 0.00, doubleHighprice = 20.00, doubleWeight = 10.00, doubleReduceWeight = -1.00;
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
            //webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
            void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                intLoadTime++;
                if (intLoadTime == 2)
                {
                    HtmlDocument hd = webBrowser.Document;
                    HtmlElement he = hd.GetElementById("breadcrumb");
                    HtmlElementCollection hec = he.GetElementsByTagName("em");
                    HtmlElement he1 = hec[0];
                    string strCategoryCount = he1.InnerText;
                    int intCategoryCount = Convert.ToInt32(strCategoryCount);

                    ComputeCategoryCount1 ccc1 = new ComputeCategoryCount1(intCategoryCount, webBrowser, hd, doubleArray, booleanArray, stringArray);
                    intLoadTime = 0;

                    Console.WriteLine("ComputeCategoryCount:" + strCategoryCount);
                }
            }
        }
    }
}
