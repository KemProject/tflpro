using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tflpro.PageObject
{
    public interface tflPages
    {
        public static By PlanAJourney = By.XPath("(//a[normalize-space()='Plan a journey'])[1]");

        public static By JourneyFrom = By.Id("InputFrom");

        public static By JourneyTo = By.Id("InputTo");

        public static By PlanMyJourney = By.Id("plan-journey-button");

        public static By PageInformation = By.ClassName("hero-headline");
    }
}
