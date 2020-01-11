using MySql.Data.MySqlClient;
using System;
namespace webspider
{
    class QueryHtmlDocumentInfo
    {
        public Boolean boolean;
        public QueryHtmlDocumentInfo(string strUrl)
        {

            string strConnection = "Server=localhost;User=pujing;Password=123456;Database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strConnection);
            string strMySql = "select strUrl from HtmlDocumentInfo0_copy  where strUrl='" + strUrl + "';";
            MySqlCommand mySqlCommand = new MySqlCommand(strMySql, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.Prepare();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                boolean = true;
                Console.WriteLine("query sucecess");
            }
            else
            {
                boolean = false;
                Console.WriteLine("query failed");
            }
            mySqlConnection.Close();
        }
    }
}
