using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Automation.Extentions.Components;
using Automation.Extentions.Contracts;
using System.Drawing;
using OpenQA.Selenium.Remote;

namespace Automation.Testing
{
    [TestClass]
    public class SeleniumSamples
    {
        [TestMethod]
        public void WebDrvierSamples()
        {
            System.Console.WriteLine("Test");
            // TODO: add test logic here
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            //driver = new FirefoxDriver();
            //Thread.Sleep(1000);
            //driver.Dispose();

            driver = new EdgeDriver();
            Thread.Sleep(1000);
            driver.Dispose();

        }

        [TestMethod]
        public void WebElementSamples()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SelectElementSamples()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            var element = driver.FindElement(By.Id("SelectedDepartment"));
            var SelectElement = new SelectElement(element);
            SelectElement.SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void WebDriverFacotorySample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "edge", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GoToUrlSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.GetElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void AsSelecttSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");

            driver.GetElement(By.Id("SelectedDepartment")).AsSelect().SelectByValue("4");
           // var SelectElement = new SelectElement(element);
           // SelectElement.SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            var elements = driver.GetElements(By.XPath("//ul/li"));
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisisbleElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            var elements = driver.GetVisibleElements(By.XPath("//ul/li"));
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetEnabledElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetEnabledElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetEnabledElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            var elements = driver.GetEnabledElements(By.XPath("//ul/li"));
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void VerticalWindowScrollSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.Manage().Window.Size = new Size(100, 350);
            driver.VerticalWindowScroll(1000);
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ActionsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).Actions().Click().Build().Perform();
            Thread.Sleep(2000);
            driver.Dispose();
        }


        [TestMethod]
        public void GetForceClickSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.GetElement(By.XPath("//a[.='Students']")).ForceClick();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SendKeysIntervalSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("hello", 1000);
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ForceClearSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            var element =  driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("hello",0);
            element.SendKeys(Keys.Home);
            element.ForceClear();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SubmitForceSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\MyNotes\Mylearning\GridLearning\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("Alexender");
            driver.SubmitForm(0);
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GoToRemoteUrlSampleChrome()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = "http://localhost:4444/wd/hub", Source="remote" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            Thread.Sleep(2000);
            driver.Dispose();
        }

       
        [TestMethod]
        [Parallelizable]
        public void GoToRemoteUrlSampleEdge()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "edge", Binaries = "http://localhost:4444/wd/hub", Source = "remote" }).Get();
            driver.GoToUrl("http://dev1-mxapp-vm.awsdev.local:8081/Metrix/auth/login/");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        [Parallelizable]
        public void GoToRemoteUrlSampleChromeCapability()
        {
            ChromeOptions Options = new ChromeOptions();
          //  Options.
      //     var  driver = new RemoteWebDriver(
    //   new Uri("http://localhost:4444/wd/hub"), Options.ToCapabilities(), TimeSpan.FromSeconds(600));// NOTE: connection timeout of 600 seconds or more required for time to launch grid nodes if non are available.

            var driver = new WebDriverFactory(new DriverParams { Driver = "edge", Binaries = "http://localhost:4444/wd/hub", Source = "remote" }).Get();
            driver.GoToUrl("http://dev1-mxapp-vm.awsdev.local:8081/Metrix/auth/login/");
            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
    
}
