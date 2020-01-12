using System.IO;
namespace webspider
{
    class CreateFile
    {
        public CreateFile(string strFilePath)
        {

            FileStream fs = File.Create(strFilePath);
            fs.Close();
        }
    }
}
