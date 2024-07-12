using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final.Test
{
    using final.Core;
    using final.Helper;
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    [SetUpFixture]
    public class Hooks
    {
        public static IConfiguration Config;

        const string AppSettingPath = "Configurations\\appsettings.json";

        [OneTimeSetUp]
        public void MySetup()
        {
            TestContext.Progress.WriteLine("====> Global one time setup");

            // Read Configuration file
            Config = ConfigurationHelper.ReadConfiguration(AppSettingPath);
        }
    }

}





