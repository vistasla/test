using MySql.Data.MySqlClient;
using System;
namespace webspider
{
    class UpdateintSwitcher
    {
        public UpdateintSwitcher(int intSwitcher, string strUrl)
        {

            string strConnection = "Server=localhost;User=pujing;Password=123456;Database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strConnection);
            string strMySql = "update CategoryUrl set intSwitcher ='" + intSwitcher + "' where strCategoryUrl='" + strUrl + "';";
            MySqlCommand mySqlCommand = new MySqlCommand(strMySql, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.Prepare();
            int intResultSetRow = mySqlCommand.ExecuteNonQuery();
            if (intResultSetRow == 1)
            {
                Console.WriteLine("update sucecess");
            }
            else
            {
                Console.WriteLine("update failed");
            }
            mySqlConnection.Close();
        }
    }
}
