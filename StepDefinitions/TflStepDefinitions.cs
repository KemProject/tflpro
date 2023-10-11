using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tflpro.Browser;
using tflpro.Pages;


namespace tflpro.StepDefinitions
{
    [Binding]
    public class TflStepDefinitions
    {
        private readonly WebBrowser browser;

        private readonly TflPages PagesOfTfl;
        public TflStepDefinitions(WebBrowser webBrowser)
        {
            this.browser = webBrowser;
            PagesOfTfl = new TflPages(this.browser);
        }
        
       // PagesOfTfl = new TflPages(webBrowser);

        [Given(@"I naviagte to tfl homepage")]
        public void GivenINaviagteToTflHomepage()
        {
            //TflPages PagesOfTfl = new TflPages(WebBrowser);
            PagesOfTfl.TflHomepage();
        }

        [Given(@"I clicked on the journey planner")]
        public void GivenIClickedOnTheJourneyPlanner()
        {
            PagesOfTfl.PlanAJourney();
        }

        [Given(@"I enter '([^']*)' as my from")]
        public void GivenIEnterAsMyFrom(string london)
        {
            PagesOfTfl.JourneyFrom(london);
        }

        [Given(@"I enter '([^']*)' as my to")]
        public void GivenIEnterAsMyTo(string kent)
        {
           PagesOfTfl.JourneyTo(kent);
        }

        [When(@"I click plan my journey")]
        public void WhenIClickPlanMyJourney()
        {
           PagesOfTfl.PlanMyJourney();
        }

        [Then(@"the result should display the planned journey")]
        public void ThenTheResultShouldDisplayThePlannedJourney()
        {
            PagesOfTfl.PlanMyJourney();
        }

        //[Given(@"I enter '([^']*)' as my from")]
        //public void GivenIEnterAsMyFrom(string p0)
        //{
        //    
        //}

        //[Given(@"I enter '([^']*)' as my to")]
        //public void GivenIEnterAsMyTo(string p0)
        //{
        //   
        //}

        [Then(@"the result should display the field is required")]
        public void ThenTheResultShouldDisplayTheFieldIsRequired()
        {
           
        }

        [Given(@"I click on arrival tab")]
        public void GivenIClickOnArrivalTab()
        {
           
        }

        [Then(@"the result should display the journey information based on arrival time")]
        public void ThenTheResultShouldDisplayTheJourneyInformationBasedOnArrivalTime()
        {
           
        }

        [Then(@"the result should display the journey information")]
        public void ThenTheResultShouldDisplayTheJourneyInformation()
        {
           
        }

        [Then(@"I click on edit journey hyperlink")]
        public void ThenIClickOnEditJourneyHyperlink()
        {
           
        }

        [Then(@"The original journey page is displayed")]
        public void ThenTheOriginalJourneyPageIsDisplayed()
        {
            
        }

        [Then(@"I change from location to  '([^']*)'")]
        public void ThenIChangeFromLocationTo(string p0)
        {
            
        }

        [Then(@"I click update journey")]
        public void ThenIClickUpdateJourney()
        {
            
        }

        [Then(@"the result should display the newly updated journey information")]
        public void ThenTheResultShouldDisplayTheNewlyUpdatedJourneyInformation()
        {
            
        }

        [Then(@"I navigate to tfl homepage")]
        public void ThenINavigateToTflHomepage()
        {
            
        }

        [Then(@"I click on the recent tab")]
        public void ThenIClickOnTheRecentTab()
        {
            
        }

        [Then(@"I enable the cookies if not enabled")]
        public void ThenIEnableTheCookiesIfNotEnabled()
        {
            
        }

        [Then(@"I can view the recent planned journey")]
        public void ThenICanViewTheRecentPlannedJourney()
        {
            
        }

    }
}
