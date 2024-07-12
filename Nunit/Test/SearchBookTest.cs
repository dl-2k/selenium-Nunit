using AngleSharp.Common;
using final.Constant;
using final.Core.Helper;
using final.Helper;
using final.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final.Test
{
    public class SearchBookTest : BaseTest
    {

        private SearchBookPage _searchBookPage;
        private string bookstore_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "bookstore_url");

        [SetUp]
        public void PageSetUp()
        {
            _searchBookPage = new SearchBookPage();

        }

        [Test, Description("SearchBook")]
        [TestCase("design")]
        [TestCase("Des")]
        public void SearchBook(string keyword)
        {
            ExtentReportHelper.LogTestStep("Go to SearckBook page");
            WebObject.NavigateTo(bookstore_url);

            List<string> expectedHeaders = new List<string> { "Image", "Title", "Author", "Publisher" };
            
            ExtentReportHelper.LogTestStep("Enter Search keyword");
            _searchBookPage.EnterSearchKeyword(keyword);

            ExtentReportHelper.LogTestStep("Verify Search result");
            _searchBookPage.AssertSearchResults(keyword, expectedHeaders);

        }
    }
}
