using System.IO;
namespace webspider
{
    class CreateDirectory
    {
        public CreateDirectory(string strDirectoryPath)
        {

            Directory.CreateDirectory(strDirectoryPath);

        }
    }
}
