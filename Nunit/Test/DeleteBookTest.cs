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
    public class DeleteBookTest : BaseTest
    {


        private LoginPage _loginPage;
        private DeleteBookPage _deleteBookPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _deleteBookPage = new DeleteBookPage();

        }

        [Test,Description("DeleteBook")]
        [TestCase("Git Pocket Guide")]
        public void DeleteBook(string bookTitle)
        {
            ExtentReportHelper.LogTestStep("Go to Login Page");
            WebObject.NavigateTo(login_url);
            
            ExtentReportHelper.LogTestStep("Enter valid username and password");
            _loginPage.Login(FileConstant.username, FileConstant.password);
            _loginPage.VerifyLoginSuccessfully();

            ExtentReportHelper.LogTestStep("Delete book search");
            _deleteBookPage.DeleteBook(bookTitle);
            bool isBookDeleted = _deleteBookPage.IsBookDeleted(bookTitle);
            Assert.IsTrue(isBookDeleted, $"The book titled '{bookTitle}' was not deleted successfully.");

        }
    }
}


