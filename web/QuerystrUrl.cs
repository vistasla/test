using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace webspider
{
    class QuerystrUrl
    {
        public int intIndex;
        public QuerystrUrl(string strUrl)
        {

            string strconnetStr = "server=localhost;user=pujing;password=123456;database=webspider;Charset=utf8";
            MySqlConnection mySqlConnection = new MySqlConnection(strconnetStr);
            string strSql = "select strUrl from webinfo  where strUrl='strUrl1'";
            MySqlCommand mySqlCommand = new MySqlCommand(strSql, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) {

            intIndex=  mySqlDataReader.GetInt32("intIndex");
              


            }
            
           /* if (intRow == 1)
            {

                Console.WriteLine("insert sucecess");

            }
            else
            {

                Console.WriteLine("insert failed");
            }
            */


        }

    }
}
