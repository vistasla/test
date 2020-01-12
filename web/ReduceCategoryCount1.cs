using System;
using System.Windows.Forms;
namespace webspider
{
    class ReduceCategoryCount1
    {
        public ReduceCategoryCount1(HtmlDocument hd, Double doubleLowprice, Double doubleHighprice)
        {
            doubleLowprice = doubleHighprice;
            HtmlElement he = hd.GetElementById("input_lowprice");
            HtmlElement he1 = hd.GetElementById("input_highprice");
            HtmlElement he2 = hd.GetElementById("price_btn_yes");

            string strLowprice = Convert.ToString(doubleLowprice);
            he.InnerText = strLowprice;
            he1.InnerText = null;

            he2.InvokeMember("click");
        }
    }
}
