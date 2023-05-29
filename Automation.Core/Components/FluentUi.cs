using System;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public class FluentUi : IFluent
    {
      ////  private readonly IWebDriver driver;
        private readonly ILogger logger;

        protected FluentUi(IWebDriver driver) :
            this(driver, new TraceLogger())
        { }

        protected FluentUi(IWebDriver driver, ILogger logger)
        {
            Driver = driver;
            Logger = logger;
        }

        public IWebDriver Driver { get; }
        public ILogger Logger { get; }
        public T ChangeContext<T>()
        {
            // return (T)Activator.CreateInstance(typeof(T), new object[] { driver });
            var instance = Create<T>(null);
            logger.Debug($"instance of [{GetType().FullName}] created");
            return instance;
        }
        public T ChangeContext<T>(ILogger logger)
        {
            // return (T)Activator.CreateInstance(typeof(T), new object[] { driver, logger });
            return Create<T>(logger);
        }

        public T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return (T)Activator.CreateInstance(typeof(T), new object[] { Driver, logger });
        }

        public T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(logger);
        }

        private T Create<T>(ILogger logger)
        {
            return logger == null
            ? (T)Activator.CreateInstance(typeof(T), new object[] { Driver })
            : (T)Activator.CreateInstance(typeof(T), new object[] { Driver, logger });
        }
    }
}
