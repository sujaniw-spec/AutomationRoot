using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using Automation.Extentions.Components;
using System.Threading;
using System;
using Automation.Extentions.Contracts;


namespace Automation.Testing
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class ParallelLocal
    {
        [Test]
        [Parallelizable]
        public void GoToRemoteUrlEdgeNode5567_1()
        {
            EdgeOptions options = new EdgeOptions();
             options.AddAdditionalOption("nodename:applicationName","app_1");

            var driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));

            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            System.Console.WriteLine($"title chrome {driver.Title}");
            System.Console.WriteLine($"machine# {options.ToCapabilities().GetCapability("nodename:applicationName")}");

            driver.Quit();
        }

        [Test]
        [Parallelizable]
        public void GoToRemoteUrlEdgeNode5567_2()
        {
            EdgeOptions options = new EdgeOptions();
           options.AddAdditionalOption("nodename: applicationName", "Node2-Sujani");

            var driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));

            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            System.Console.WriteLine($"titleEdge# {driver.Title}");
            System.Console.WriteLine($"machine# {options.ToCapabilities().GetCapability("nodename: applicationName")}");
            //  IWebDriver driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = "http://localhost:4444/wd/hub", Source = "remote" }).Get();
            //   var capabilities = ((RemoteWebDriver)driver).Capabilities;

            //   string nodeName = capabilities.GetCapability("nodeName").ToString();
            //  System.Console.WriteLine($"Running on node: {nodeName}");

            driver.Quit();
        }

        [Test]
        [Parallelizable]
        public void GoToRemoteUrlChromeNode5566_1()
        {
            ChromeOptions options = new ChromeOptions();
            //  options.AddArguments("browserName", "MicrosoftEdge");
            //  options.AddArguments("nodeName", "Node2");
            
            //http://100.124.17.23:5566/wd/hub

            var driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            System.Console.WriteLine($"titleEdge# {driver.Title}");
            System.Console.WriteLine($"machine# {options.ToCapabilities().GetCapability("nodeName")}");
            Thread.Sleep(4000);
            driver.Quit();
        }

        [Test]
        [Parallelizable]
        public void GoToRemoteUrlChromeNode5566_2()
        {
            //  var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = "http://localhost:4444/wd/hub", Source = "remote" }).Get();
            ChromeOptions options = new ChromeOptions();
            var driver = new RemoteWebDriver(
            new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
            driver.GoToUrl("https://www.google.com/?gws_rd=ssl");
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
