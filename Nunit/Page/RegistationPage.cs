using AngleSharp.Dom;
using final.Core.Helper;
using final.DataObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V123.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace final.Page
{
    public class RegistationPage
    {
        private WebObject _txtFirstName = new WebObject(By.Id("firstName"));
        private WebObject _txtLastNames = new WebObject(By.Id("lastName"));
        private WebObject _txtEmail = new WebObject(By.XPath("//input[@placeholder='name@example.com']"));
        private WebObject _dtpDateofBirth = new WebObject(By.Id("dateOfBirthInput"));
        private WebObject _txtMobilePhone = new WebObject(By.XPath("//input[@placeholder='Mobile Number']"));
        private WebObject _txtSubject = new WebObject(By.Id("subjectsInput"));
        private WebObject _btnPicture = new WebObject(By.Id("uploadPicture"));
        private WebObject _txtaCurrentAddress = new WebObject(By.Id("currentAddress"));
        private WebObject _ddlState = new WebObject(By.XPath("//div[@id='state']//input"));
        private WebObject _ddlCity = new WebObject(By.XPath("//div[@id='city']//input"));
        private WebObject _btnSubmit = new WebObject(By.XPath("//button[@type='submit']"));
        public WebObject _msgThankYouMessage = new WebObject(By.XPath("//div[contains(@class,'modal-title')]"));
        private WebObject genderLocator(string gender)
        {
            return new WebObject(By.XPath($"//div[@id='genterWrapper']//label[text()='{gender}']"));
        }

        public WebObject hobbiesLocator(string hobbie)
        {
            return new WebObject(By.XPath($"//div[@id='hobbiesWrapper']//label[text()='{hobbie}']"));
        }

        public WebObject SelectOption(string value)
        {
            return new WebObject(By.XPath($"//div[contains(@class,'option') and text()='{value}']"));
        }

        public WebObject SelectSubmitLabel(string label)
        {
            return new WebObject(By.XPath($"//td[contains(text(),'{label}')]/following-sibling::td"));
        }

        public void FillRegistrationForm(FormFieldData formData)
        {
            _txtFirstName.EnterText(formData.FirstName);
            _txtLastNames.EnterText(formData.LastName);
            if (!string.IsNullOrEmpty(formData.Email))
            {
                _txtEmail.EnterText(formData.Email);
            }
            if (!string.IsNullOrEmpty(formData.Gender))
            {
                genderLocator(formData.Gender).ClickOnElement();
            }

            if (!string.IsNullOrEmpty(formData.MobilePhone))
            {
                _txtMobilePhone.EnterText(formData.MobilePhone);
            }

            if (!string.IsNullOrEmpty(formData.DateOfBirth))
            {
                _dtpDateofBirth.SelectDateFromDatePicker(formData.DateOfBirth);
                _dtpDateofBirth.ClickOnElement();
            }

            if (!string.IsNullOrEmpty(formData.Subject))
            {
                EnterSubject(formData.Subject);
            }

            if (!string.IsNullOrEmpty(formData.Hobbies))
            {
                hobbiesLocator(formData.Hobbies).ClickOnElement();
            }

            if (!string.IsNullOrEmpty(formData.Picture))
            {
                _btnPicture.EnterText(formData.Picture);  
            };


            if (!string.IsNullOrEmpty(formData.CurrentAddress))
            {
                _txtaCurrentAddress.EnterText(formData.CurrentAddress);
            }

            if (!string.IsNullOrEmpty(formData.State))
            {
                SelectState(formData.State);
            };


            if (!string.IsNullOrEmpty(formData.City))
            {
                SelectCity(formData.City);
            };

            _btnSubmit.ClickOnElement();
        }

     


        public void EnterSubject(string subject)
        {
            _txtSubject.EnterText(subject);
            SelectOption(subject).ClickOnElement();
        }

        public void SelectState(string state)
        {
            _ddlState.EnterText(state);
            SelectOption(state).ClickOnElement();
        }

        public void SelectCity(string city)
        {
            _ddlCity.EnterText(city);
            SelectOption(city).ClickOnElement();
        }

        public string getThankYouMessage()
        {
            return _msgThankYouMessage.GetTextFromElement();
        }

        public void VerifyThankYouMessage()
        {
            Assert.That(getThankYouMessage, Is.EqualTo("Thanks for submitting the form"));
        }
        public Dictionary<string, string> GetFormResult()
        {
            var result = new Dictionary<string, string>
            {
                { "Student Name", SelectSubmitLabel("Student Name").GetTextFromElement() },
                { "Student Email", SelectSubmitLabel("Student Email").GetTextFromElement() },
                { "Gender", SelectSubmitLabel("Gender").GetTextFromElement() },
                { "Mobile", SelectSubmitLabel("Mobile").GetTextFromElement() },
                { "Date of Birth", SelectSubmitLabel("Date of Birth").GetTextFromElement() },
                { "Subjects", SelectSubmitLabel("Subjects").GetTextFromElement() },
                { "Hobbies", SelectSubmitLabel("Hobbies").GetTextFromElement() },
                { "Picture", SelectSubmitLabel("Picture").GetTextFromElement() },
                { "Address", SelectSubmitLabel("Address").GetTextFromElement() },
                { "State and City", SelectSubmitLabel("State and City").GetTextFromElement() }
            };

            return result;
        }

        public void VerifyFormSubmission(FormFieldData formData)
        {
            var formResult = GetFormResult();

            Assert.That(formResult["Student Name"], Is.EqualTo($"{formData.FirstName} {formData.LastName}"));

            if (!string.IsNullOrEmpty(formData.Email))
            {
                Assert.That(formResult["Student Email"], Is.EqualTo(formData.Email));
            }

            if (!string.IsNullOrEmpty(formData.Gender))
            {
                Assert.That(formResult["Gender"], Is.EqualTo(formData.Gender));
            }

            if (!string.IsNullOrEmpty(formData.MobilePhone))
            {
                Assert.That(formResult["Mobile"], Is.EqualTo(formData.MobilePhone));
            }

            if (!string.IsNullOrEmpty(formData.DateOfBirth))
            {
                Assert.That(formResult["Date of Birth"], Is.EqualTo(DateTime.Parse(formData.DateOfBirth).ToString("dd MMMM,yyyy")));
            }

            if (!string.IsNullOrEmpty(formData.Subject))
            {
                Assert.That(formResult["Subjects"], Is.EqualTo(formData.Subject));
            }

            if (!string.IsNullOrEmpty(formData.Hobbies))
            {
                Assert.That(formResult["Hobbies"], Is.EqualTo(string.Join(", ", formData.Hobbies)));
            }

            if (!string.IsNullOrEmpty(formData.Picture))
            {
                Assert.That(formResult["Picture"], Is.EqualTo(System.IO.Path.GetFileName(formData.Picture)));
            }

            if (!string.IsNullOrEmpty(formData.CurrentAddress))
            {
                Assert.That(formResult["Address"], Is.EqualTo(formData.CurrentAddress));
            }

            if (!string.IsNullOrEmpty(formData.State) && !string.IsNullOrEmpty(formData.City))
            {
                Assert.That(formResult["State and City"], Is.EqualTo($"{formData.State} {formData.City}"));
            }

            }

    }
}
