using final.Core.Helper;
using final.DataObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace final.Page
{
    public class BasePage
    {
        private WebObject _btnFormLabel  = new WebObject(By.XPath("//span[text()='Practice Form']"));

        //Page Method
        public void GoToFormPage()
        {
            _btnFormLabel.ClickOnElement();
        }
    }

}

