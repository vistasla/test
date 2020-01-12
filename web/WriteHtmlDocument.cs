using System;
using System.IO;
namespace webspider
{
    class WriteHtmlDocument
    {
        public WriteHtmlDocument(string strHtml, string strFirstDegree, string strSecondDegree, string strIsbn, Boolean[] booleanArray)
        {
            string strDirectoryPath = "C:\\Users\\pujing\\Documents\\C#\\pujing\\" + strFirstDegree + "\\" + strSecondDegree;
            string strFilePath = strDirectoryPath + "\\" + strIsbn + ".html";

            CreateDirectory cd = new CreateDirectory(strDirectoryPath);
            File.WriteAllText(strFilePath, strHtml);

            booleanArray[4] = true;
        }
    }
}
