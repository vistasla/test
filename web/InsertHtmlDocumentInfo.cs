using MySql.Data.MySqlClient;
using System;
namespace webspider
{
    class InsertHtmlDocumentInfo
    {
        Boolean boolean;
        public InsertHtmlDocumentInfo(string strUrl, string strTitle, string strFirstDegree, string strSecondDegree, string strOriginalTitle, string[] strArrayImage, string[] strArraySmallImage, string strTitleOriginal, string strAuthor, string strPublishingHouse, string strPublishingTime, string strFormat, string strPaper, string strPackaging, string strIsbn, string strContent, string strAuthorIntroduction, string strCatalog, string strKeywords)
        {
            int intstrArrayImageCount = strArrayImage.Length;
            string strImage = null;
            string strSmallImage = null;
            for (int i = 0; i < intstrArrayImageCount; i++)
            {
                strImage = strImage + strArrayImage[i];
                strSmallImage = strSmallImage + strArraySmallImage[i];
            }
            
            string strConnection = "Server=localhost;User=pujing;Password=123456;Database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strConnection);
            //string strMySql = "INSERT INTO htmldocumentinfo0_copy (`strUrl`, `strtitle`) VALUES ('"+strUrl+"', '"+strTitle+"')";
            string strMySql = "INSERT INTO htmldocumentinfo (strUrl, strTitle,strFirstDegree, strSecondDegree, strOriginalTitle, strArrayImage,strArraySmallImage, strTitleOriginal, strAuthor,  strPublishingHouse, strPublishingTime,  strFormat,strPaper, strPackaging, strIsbn,  strContent,  strAuthorIntroduction, strCatalog, strKeywords) VALUES ('" + strUrl + "', '" + strTitle + "','" + strFirstDegree + "', '" + strSecondDegree + "', '" + strOriginalTitle + "', '" + strImage + "','" + strSmallImage + "', '" + strTitleOriginal + "', '" + strAuthor + "', '" + strPublishingHouse + "', '" + strPublishingTime + "',  '" + strFormat + "','" + strPaper + "', '" + strPackaging + "', '" + strIsbn + "',  '" + strContent + "',  '" + strAuthorIntroduction + "', '" + strCatalog + "', '" + strKeywords + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(strMySql, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.Prepare();
            int intResultSetRow = mySqlCommand.ExecuteNonQuery();
            if (intResultSetRow == 1)
            {
                boolean = true;
                Console.WriteLine("insert sucecess");
            }
            else
            {
                boolean = false;
                Console.WriteLine("insert failed");
            }
            mySqlConnection.Close();
        }
    }
}
