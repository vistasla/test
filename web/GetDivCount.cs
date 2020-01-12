using System.Windows.Forms;
namespace webspider
{
    class GetDivCount
    {
        public int intDivCount;
        public GetDivCount(HtmlDocument hd)
        {
            HtmlElement he = hd.GetElementById("breadcrumb");
            HtmlElementCollection hec = he.FirstChild.GetElementsByTagName("div");

            intDivCount = hec.Count;

        }
    }
}
