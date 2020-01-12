using System;
using System.Windows.Forms;

namespace webspider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Boolean[] booleanArray = new Boolean[5];
            string strUrl = textBox1.Text;
            ComputeCategoryCount ccc = new ComputeCategoryCount(strUrl);
            //ParseHtmlDocument phd = new ParseHtmlDocument(strUrl, booleanArray);
            //GetCategoryUrl gcu = new GetCategoryUrl(strUrl);
        }
    }
}
