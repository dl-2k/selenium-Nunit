using AngleSharp.Dom;
using final.Core;
using final.Core.Helper;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace final.Page
{
    public class DeleteBookPage
    {
        private WebObject _searchBar = new WebObject(By.Id("searchBox"));
        private WebObject _btnOK = new WebObject(By.XPath("//button[text()='OK']"));
        private WebObject lblBookTitle(string bookTitle)
        {
            return new WebObject(By.XPath($"//a[text()='{bookTitle}']"));
        }
        public WebObject btnDelete(string bookTitle)
        {
            return new WebObject(By.XPath($"//a[text()='{bookTitle}']/ancestor::div[@role='gridcell']/following-sibling::div//span[@id='delete-record-undefined']"));
        }

        public void EnterSearchKeyword(string keyword)
        {
            var _keyword = keyword.ToLower();
            _searchBar.EnterText(_keyword);
        }


        public void closeAlert()
        {
            DriverManager.wait.Until(ExpectedConditions.AlertIsPresent());
            DriverManager.driver.SwitchTo().Alert().Accept();
        }

        public void DeleteBook(string Book)
        {
            EnterSearchKeyword(Book);
            btnDelete(Book).ClickOnElement();
            _btnOK.ClickOnElement();
            closeAlert();
        }

        public bool IsBookDeleted(string bookTitle)
        {
            // Wait for some time to ensure the page is updated after deletion
            WebDriverWait wait = new WebDriverWait(DriverManager.driver, TimeSpan.FromSeconds(10));
            wait.Until(d => !lblBookTitle(bookTitle).IsElementDisplayed());
            return !lblBookTitle(bookTitle).IsElementDisplayed();
        }
     

    }
}