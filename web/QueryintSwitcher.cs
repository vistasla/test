using MySql.Data.MySqlClient;
using System;

namespace webspider
{
    class QueryintSwitcher
    {
      public  string strUrl;

        public QueryintSwitcher()
        {
            string strConnection = "Server=localhost;User=pujing;Password=123456;Database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strConnection);
            string strMySql = "select strCategoryUrl from CategoryUrl  where (intSwitcher='0 ')and( intSwitcher1='0')";
            MySqlCommand mySqlCommand = new MySqlCommand(strMySql, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.Prepare();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                strUrl = mySqlDataReader.GetString("strCategoryUrl");
                Console.WriteLine("query sucecess:" + strUrl);               
            }
            else
            {
                strUrl = null;
                Console.WriteLine("query failed" + strUrl);
            }
            mySqlConnection.Close();
        }
    }
}
