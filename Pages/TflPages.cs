using NUnit.Framework;
using TechTalk.SpecFlow;
using tflpro.Drivers;
using static tflpro.Support.AppSettings.Properties;
using WebBrowser = tflpro.Browser.WebBrowser;

namespace tflpro.Pages
{

    public class TflPages : Page
    {
        private readonly WebBrowser browser;

        public TflPages(WebBrowser webBrowser) : base(webBrowser)
        {
            this.browser = webBrowser;
        }

        public void TflHomepage()
        {
            //browser.Navigate().GoToUrl("https://tfl.gov.uk/");
            browser.WebDriver.Navigate().GoToUrl("https://tfl.gov.uk/");
           
        }
        public void PlanAJourney() 
        {
            browser.WebDriver.FindElement(PageObject.tflPages.PlanAJourney).Click();
            Thread.Sleep(2000);
            string Pageinfo = browser.WebDriver.FindElement(PageObject.tflPages.PageInformation).Text;
            if (Pageinfo  != "Plan a journey") 
            {
            Assert.Fail();
            }
        }

        public void JourneyFrom( string JF) 
        {
            browser.WebDriver.FindElement(PageObject.tflPages.JourneyFrom).SendKeys(JF);
        }
        public void JourneyTo(string JT)
        {
            browser.WebDriver.FindElement(PageObject.tflPages.JourneyTo).SendKeys(JT);
        }
        public void PlanMyJourney()
        {
            browser.WebDriver.FindElement(PageObject.tflPages.PlanMyJourney).Click();

        }

    }
}