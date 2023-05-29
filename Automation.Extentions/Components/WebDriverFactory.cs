using Automation.Extentions.Contracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Extentions.Components
{
    public class WebDriverFactory
    {
        private readonly DriverParams driverParams;
        public WebDriverFactory(string driverParamJson) : this(LoadParams(driverParamJson))
        {

        }

        public WebDriverFactory(DriverParams driverParams)
        {
            //driverParams = LoadParams(driverParams);
            this.driverParams = driverParams;
            if (string.IsNullOrEmpty(driverParams.Binaries) || driverParams.Binaries == ".")
            {
                driverParams.Binaries = Environment.CurrentDirectory;
            }
        }

        /// <summary>
        /// generate web-driver based on input params
        /// </summary>
        /// <returns>web-driver instance</returns>
        public IWebDriver Get()
        {
            if (!string.Equals(driverParams.Source,"REMOTE", StringComparison.OrdinalIgnoreCase))
            {
                return GetDriver();
            }
            return GetRemoteDriver();
        }

        //local web-drivers
        private IWebDriver GetChrome() => new ChromeDriver(driverParams.Binaries);
        private IWebDriver GetFirefox() => new FirefoxDriver(driverParams.Binaries);
        private IWebDriver GetEdge() => new EdgeDriver(driverParams.Binaries);

        //remote web-drivers
        private IWebDriver GetRemoteChrome() => new RemoteWebDriver(new Uri(driverParams.Binaries), new ChromeOptions());
        private IWebDriver GetRemoteFirefox() => new RemoteWebDriver(new Uri(driverParams.Binaries), new FirefoxOptions());
        private IWebDriver GetRemoteEdge() => new EdgeDriver(driverParams.Binaries);

        private IWebDriver GetDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "FIREFOX": return GetFirefox();
                case "EDGE": return GetEdge();
                case "CHROME": 
                default: return GetChrome();
            }
        }

        private IWebDriver GetRemoteDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "FIREFOX": return GetRemoteFirefox();
                case "EDGE": return GetRemoteEdge();
                case "CHROME":
                default: return GetRemoteChrome();
            }
        }

        //load json into driver-params object

        private static DriverParams LoadParams(string driverParamsJson)
        {
            if (string.IsNullOrEmpty(driverParamsJson))
            {
                return new DriverParams { Source = "Local", Driver = "Chrome", Binaries = "." };
            }

            return JsonConvert.DeserializeObject<DriverParams>(driverParamsJson);
        }
    }
}
