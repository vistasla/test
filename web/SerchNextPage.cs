using System;
using System.Windows.Forms;

namespace webspider
{
    class SerchNextPage
    {
        public Boolean boolean;
        public string strUrl;
        public SerchNextPage(HtmlDocument hd)
        {
            HtmlElementCollection hec = hd.GetElementsByTagName("ul");
            int inthecCount = hec.Count;
            for (int i = 0; i < inthecCount; i++)
            {
                string strUlName = hec[i].GetAttribute("name");
                Console.WriteLine(strUlName);
                if (strUlName.Equals("Fy"))
                {
                    HtmlElementCollection hec1 = hec[i].GetElementsByTagName("a");

                    int inthec1Count = hec1.Count;
                    string strUrl = hec1[inthec1Count - 1].GetAttribute("href");
                    /* if (strClassName.Equals("next"))
                     {
                         boolean = true;
                         strUrl= hec1[inthec1Count - 2].FirstChild.GetAttribute("href");                        
                     }
                     else
                     {                        

                     }*/
                    if (strUrl.Equals(""))
                    {
                        boolean = false;

                        Console.WriteLine("SerchNextPage:" + boolean);
                    }
                    else
                    {
                        boolean = true;

                        Console.WriteLine("SerchNextPage:" + boolean);
                    }
                    break;
                }

            }

        }

    }
}
