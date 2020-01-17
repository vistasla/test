using System;
using System.Windows.Forms;
namespace webspider
{
    class ComputeCategoryCount1
    {
        public ComputeCategoryCount1(int intCategoryCount, WebBrowser webBrowser, HtmlDocument hd, Double[] doubleArray, Boolean[] booleanArray, string[] stringArray)
        {

            if (intCategoryCount > 0 && intCategoryCount <= 6000)
            {

                if (booleanArray[0])
                {
                    stringArray[0] = webBrowser.Url.ToString();
                }

                if (!booleanArray[1])
                {
                    booleanArray[1] = true;
                }
                HtmlElement he = hd.GetElementById("search_nature_rg").FirstChild;
                HtmlElementCollection hec = he.GetElementsByTagName("li");
                int intCurrentPageCount = hec.Count;
                int i = 0;
                while (booleanArray[3])
                {
                    while (booleanArray[4])
                    {
                        booleanArray[4] = false;
                        if (i < intCurrentPageCount)
                        {
                            string strUrl = hec[i].FirstChild.GetAttribute("href");

                            QueryHtmlDocumentInfo qhdi = new QueryHtmlDocumentInfo(strUrl);

                            if (qhdi.boolean)
                            {
                                i++;
                                break;
                            }
                            else
                            {
                                ParseHtmlDocument phd = new ParseHtmlDocument(strUrl, booleanArray);
                                i++;
                            }

                        }
                        else
                        {
                            booleanArray[3] = false;
                            break;
                        }
                    }
                }
                booleanArray[3] = true;

                SerchNextPage snp = new SerchNextPage(hd);

                if (snp.boolean)
                {
                    string strUrl = snp.strUrl;
                    TurnPage tp = new TurnPage(strUrl, webBrowser);
                }
                else
                {
                    if (!booleanArray[0])
                    {
                        if (!booleanArray[2])
                        {
                            UpdateintSwitcher1 us1 = new UpdateintSwitcher1(stringArray[0]);
                            QueryintSwitcher qs = new QueryintSwitcher();
                            webBrowser.Navigate(qs.strUrl);
                            stringArray[0] = qs.strUrl;
                            UpdateintSwitcher us = new UpdateintSwitcher(1, qs.strUrl);

                            Console.WriteLine("yunxingjieshu1");
                        }
                        else
                        {
                            booleanArray[2] = false;
                            ReduceCategoryCount1 rcc1 = new ReduceCategoryCount1(hd, doubleArray[0], doubleArray[1]);
                        }

                    }
                    else
                    {
                        UpdateintSwitcher1 us1 = new UpdateintSwitcher1(stringArray[0]);
                        QueryintSwitcher qs = new QueryintSwitcher();
                        webBrowser.Navigate(qs.strUrl);
                        stringArray[0] = qs.strUrl;
                        UpdateintSwitcher us = new UpdateintSwitcher(1, qs.strUrl);

                        Console.WriteLine("yunxingjieshu0");
                    }

                }

            }
            else if (intCategoryCount > 6000)
            {

                if (booleanArray[0])
                {
                    stringArray[0] = webBrowser.Url.ToString();
                    booleanArray[0] = false;
                    booleanArray[1] = false;
                    ReduceCategoryCount rcc = new ReduceCategoryCount(hd, doubleArray[0], doubleArray[1]);
                }
                else
                {
                    if (!booleanArray[1])
                    {
                        doubleArray[1] = doubleArray[1] + doubleArray[3];

                        ReduceCategoryCount rcc = new ReduceCategoryCount(hd, doubleArray[0], doubleArray[1]);
                    }


                    else if (!booleanArray[2])
                    {
                        booleanArray[2] = true;
                        booleanArray[1] = false;
                        doubleArray[0] = doubleArray[1];
                        doubleArray[1] = doubleArray[1] + doubleArray[2];
                        ReduceCategoryCount rcc = new ReduceCategoryCount(hd, doubleArray[0], doubleArray[1]);
                    }

                }

            }
            else
            {

                if (!booleanArray[2])
                {
                    UpdateintSwitcher1 us1 = new UpdateintSwitcher1(stringArray[0]);
                    QueryintSwitcher qs = new QueryintSwitcher();
                    webBrowser.Navigate(qs.strUrl);
                    stringArray[0] = qs.strUrl;
                    UpdateintSwitcher us = new UpdateintSwitcher(1, qs.strUrl);

                    Console.WriteLine("yunxingjieshu2");
                }
                else
                {

                }
            }
        }
    }
}
