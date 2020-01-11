using System;
using System.Windows.Forms;
namespace webspider
{
    class ReduceCategoryCount
    {
        public ReduceCategoryCount(HtmlDocument hd, Double doubleLowprice, Double doubleHighprice)
        {

            HtmlElement he = hd.GetElementById("input_lowprice");
            HtmlElement he1 = hd.GetElementById("input_highprice");
            HtmlElement he2 = hd.GetElementById("price_btn_yes");

            string strLowprice = Convert.ToString(doubleLowprice);
            string strHighprice = Convert.ToString(doubleHighprice);
            he.InnerText = strLowprice;
            he1.InnerText = strHighprice;

            he2.InvokeMember("click");
        }
    }
}
