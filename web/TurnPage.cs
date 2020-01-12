using System.Windows.Forms;
namespace webspider
{
    class TurnPage
    {

        public TurnPage(string strUrl, WebBrowser webBrowser)
        {
            webBrowser.Navigate(strUrl);
        }


    }
}
