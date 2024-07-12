using final.Core;
using final.Core.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace final.Page
{
    public class SearchBookPage : BasePage
    {
        private WebObject _txtsearchBar = new WebObject(By.Id("searchBox"));
        private WebObject _columnHeaders = new WebObject(By.CssSelector("div[role='columnheader']"));
        private WebObject _rowElements = new WebObject(By.CssSelector("[role='rowgroup'] tr"));


        public void EnterSearchKeyword(string keyword)
        {
            var _keyword = keyword.ToLower();
            _txtsearchBar.EnterText(_keyword);
        }


        public List<string> GetHeaders()
        {
            return _columnHeaders.FindElements()
                                 .Select(element => element.Text)
                                 .ToList();
        }

        public List<List<string>> GetRows()
        {
            var rows = new List<List<string>>();
            var rowElements = _rowElements.FindElements();

            foreach (var rowElement in rowElements)
            {
                var cellTexts = rowElement.FindElements(By.CssSelector("td"))
                                          .Select(cell => cell.Text)
                                          .ToList();
                rows.Add(cellTexts);
            }

            return rows;
        }


        public void AssertSearchResults(string keyword, List<string> expectedHeaders)
        {
            // Verify headers
            List<string> actualHeaders = GetHeaders();
            Assert.That(actualHeaders, Is.EquivalentTo(expectedHeaders), "Headers do not match.");

            // Verify search results
            List<List<string>> rows = GetRows();
            foreach (var row in rows)
            {
                Assert.IsTrue(row[1].Contains(keyword), $"Search result row does not contain the keyword '{keyword}'.");
            }
        }


    }
}

///
// private WebObject nextButton = new WebObject(By.XPath("//button[text()= 'Next']"));
//private WebObject noRowsFoundMessage = new WebObject(By.XPath("//div[text()='No rows found']"));
//private WebObject numberOfRow = new WebObject(By.CssSelector("select[aria-label='rows per page']"));
//private WebObject rows = new WebObject(By.CssSelector("div[role='columnheader']"));
///