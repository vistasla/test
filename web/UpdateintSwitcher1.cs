using MySql.Data.MySqlClient;
using System;
namespace webspider
{
    class UpdateintSwitcher1
    {

        public UpdateintSwitcher1(string strUrl)
        {

            string strConnection = "Server=localhost;User=pujing;Password=123456;Database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strConnection);
            string strMySql = "UPDATE categoryurl SET intSwitcher='0', intSwitcher1='1' WHERE strCategoryUrl='" + strUrl + "'";
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
