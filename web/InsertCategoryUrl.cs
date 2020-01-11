using MySql.Data.MySqlClient;
using System;
namespace webspider
{
    class InsertCategoryUrl
    {
        public InsertCategoryUrl(string strUrl)
        {
            string strConnection = "Server=localhost;User=pujing;Password=123456;Database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strConnection);
            string strMySql = "insert into CategoryUrl (strCategoryUrl,intSwitcher,intSwitcher1) VALUES ('" + strUrl + "','0','0');";
            MySqlCommand mySqlCommand = new MySqlCommand(strMySql, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.Prepare();
            int intResultSetRow = mySqlCommand.ExecuteNonQuery();
            if (intResultSetRow == 1)
            {
                Console.WriteLine("insert sucecess");
            }
            else
            {
                Console.WriteLine("insert failed");
            }
            mySqlConnection.Close();
        }


    }
}
