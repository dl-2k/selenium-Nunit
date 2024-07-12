using AngleSharp.Dom;
using final.Constant;
using final.Core.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final.Page
{
    public class LoginPage
    {
        private WebObject _txtUserName = new WebObject(By.Id("userName"));
        private WebObject _txtPassword = new WebObject(By.Id("password"));
        private WebObject _btnLogin = new WebObject(By.Id("login"));
        private WebObject _lblUserName = new WebObject(By.Id("userName-value"));

        public void Login(string username, string password)
        {
            _txtUserName.EnterText(username);
            _txtPassword.EnterText(password);
            _btnLogin.ClickOnElement();

        }

        public string VerifyUserName()
        {
            return _lblUserName.GetTextFromElement();
        }


        public void VerifyLoginSuccessfully()
        {
            Assert.That(VerifyUserName(), Is.EqualTo(FileConstant.username));
        }


    }
}
