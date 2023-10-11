using TechTalk.SpecFlow;
using BoDi;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using OpenQA.Selenium;
using System.Drawing.Text;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Xml.Linq;
using tflpro.Support;
using tflpro.Browser;

namespace tflpro.Hooks
{
    [Binding]
    public sealed class BeforeAndAfterHooks
    {

        [Binding]
        public  class WebBrowserHooks : Steps
        {

            private readonly IObjectContainer testStepClassObjects;
            private WebBrowser webBrowser = null;
            

            public WebBrowserHooks(IObjectContainer objectContainer)
            {
                testStepClassObjects = objectContainer;

            }
            [BeforeTestRun(Order = 0)]
            public static void BeforeTestRunLog()
            {
                AppSettings.Load();

            }
            public static IList<String> GetTestTags()
            {
                return TestContext.CurrentContext.Test.Properties["Category"].Cast<string>().ToList();
            }

            [BeforeScenario(Order = 1)]
            public void BeforeScenario(ScenarioContext scenarioContext)
            {

                IList<string> testTags = GetTestTags();
                bool isUsingWebBrowser = false;

                if
                    (testTags.Contains("tfl"))
                {
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("no-sandbox");
                    this.webBrowser = WebBrowser.CreateChromeWebBrowser(chromeOptions);
                    isUsingWebBrowser = true;
                }

                else if
                    (!testTags.Contains(""))
                {
                    this.webBrowser = WebBrowser.CreateChromeWebBrowser();
                    isUsingWebBrowser = true;
                }
                if
                    (isUsingWebBrowser)
                {
                    this.testStepClassObjects.RegisterInstanceAs<WebBrowser>(this.webBrowser);
                    this.ScenarioContext.Add("webBrowser", this.webBrowser);
                }
            }
            [AfterScenario(Order = int.MaxValue - 2)]
            public void AfterScenario()
            {

                this.webBrowser.WebDriver.Quit();
            }


        }
    }

}
