using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium.WebDriver.Extensions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tflpro.Support;
using System.Fabric.Description;
using System.Security.Policy;

namespace tflpro.Browser
{

    public class WebBrowser
    {
        private static readonly ReaderWriterLockSlim WriteLock = new ReaderWriterLockSlim();
        public IWebDriver WebDriver
        {
            get; private set;
        }
        public WebDriverWait WebDriverWait { get; set; }

        public WebBrowser(IWebDriver webDriver, bool addDefaultIgnoreExceptionTypes = true)
        {
            WebDriver = webDriver;
            int num = AppSettings.GetConfigurationProperty<int>(AppSettings.Properties.WebBrowser.PollingInterval);
            int num2 = AppSettings.GetConfigurationProperty<int>(AppSettings.Properties.WebBrowser.Timeout);
            if
                (num < 0)
            {
                num = 0;
            }
            if
                (num2 < 0)

            {
                num2 = 0;
            }
            WebDriverWait = new WebDriverWait(new SystemClock(), WebDriver, TimeSpan.FromMilliseconds(num2), TimeSpan.FromSeconds(num));
            if
                (addDefaultIgnoreExceptionTypes)
            {
                WebDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException), typeof(ElementNotVisibleException));
            }
        }
        
        public static WebBrowser CreateChromeWebBrowser(ChromeOptions options = null, bool isRemoteWebDriver = false)
        {
            if (options == null)
            {
                options = new ChromeOptions
                {
                    AcceptInsecureCertificates = true
                };
            }
            try
            {
                string configurationProperty = AppSettings.GetConfigurationProperty<string>(AppSettings.Properties.WebBrowser.Arguments);
                if
                    (!string.IsNullOrWhiteSpace(configurationProperty))
                {
                    options.AddArgument(configurationProperty);
                }
            }
            catch (ConfigurationErrorsException)
            {
            }
            try
            {
                if (isRemoteWebDriver)
                {
                    return new WebBrowser(CreateRemoteWebDiver(options));
                }
                string configurationProperty2 = AppSettings.GetConfigurationProperty<string>(AppSettings.Properties.WebBrowser.DefaultDriverDirectory);
                options.AddArgument("no-sandbox");
                return new WebBrowser(new ChromeDriver(configurationProperty2, options));
            }
            catch (DriverServiceNotFoundException exception)
            {

                throw;
            }
            catch (Exception exception2)
            {
                throw;
            }
        }
        public static RemoteWebDriver CreateRemoteWebDiver(DriverOptions driverOption)
        {
            string configurationProperty = AppSettings.GetConfigurationProperty<string>(AppSettings.Properties.WebBrowser.RemoteUri);
            return new RemoteWebDriver(new Uri(configurationProperty), driverOption);
        }




    }

    
}
