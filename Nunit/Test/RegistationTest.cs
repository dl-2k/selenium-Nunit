using final.Constant;
using final.Core.Helper;
using final.DataObject;
using final.Helper;
using final.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace final.Test
{
    public class RegistationTest : BaseTest
    {
        private RegistationPage _registationPage;
        private string form_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "form_url");


        [SetUp]
        public void PageSetUp()
        {
            _registationPage = new RegistationPage();

        }

        [Test]
        [TestCaseSource(nameof(RegisterAllFieldsData))]

        public void Registation(FormFieldData formData)
        {
            ExtentReportHelper.LogTestStep("Go to Registation page");
            WebObject.NavigateTo(form_url);
            
            ExtentReportHelper.LogTestStep("Fill data into all fields");
            _registationPage.FillRegistrationForm(formData);

            ExtentReportHelper.LogTestStep("Verify Thank You label");
            _registationPage.VerifyThankYouMessage();

            ExtentReportHelper.LogTestStep("Verify Resgistation form infomation");
            _registationPage.VerifyFormSubmission(formData);

        }


        [Test]
        [TestCaseSource(nameof(RegisterMandantoryFieldsData))]

        public void RegistationMandantory(FormFieldData formData)
        {
            ExtentReportHelper.LogTestStep("Go to Registation page");
            WebObject.NavigateTo(form_url);

            ExtentReportHelper.LogTestStep("Fill data into mandantory fields");
            _registationPage.FillRegistrationForm(formData);

            ExtentReportHelper.LogTestStep("Verify Thank You label");
            _registationPage.VerifyThankYouMessage();

            ExtentReportHelper.LogTestStep("Verify Resgistation form infomation");
            _registationPage.VerifyFormSubmission(formData);

        }

        public static IEnumerable<FormFieldData> RegisterAllFieldsData()
        {
            string relativePath = "DataObject\\Data\\Registration.json";
            var dataList = JsonUtils.LoadJsonData<FormFieldData>(relativePath);
            foreach (var data in dataList)
            {
                yield return data;
            }
        }



        public static IEnumerable<FormFieldData> RegisterMandantoryFieldsData()
        {
            string relativePath = "DataObject\\Data\\RegistrationMandantory.json";
            var dataList = JsonUtils.LoadJsonData<FormFieldData>(relativePath);
            foreach (var data in dataList)
            {
                yield return data;
            }
        }
    }
}
