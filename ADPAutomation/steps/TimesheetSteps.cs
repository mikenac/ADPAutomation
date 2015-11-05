using System.Drawing.Drawing2D;
using ADPAutomation.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace ADPAutomation.steps
{
    [Binding]
    public class TimesheetSteps
    {
        private readonly IWebDriver _driver;
        private TimecardPage _page;
        public TimesheetSteps(IWebDriver driver)
        {
            _driver = driver;
        }


        [Given(@"I am logged in to ADP with user ""(.*)"" and password ""(.*)""")]
        public void GivenIAmLoggedInToADPWithUserAndPassword(string userName, string password)
        {
            var pg = PageFactory.InitElements<LoginPage>(_driver);
            pg.NavigateTo();
            pg.Login(userName, password);
        }

        [Given(@"I navigate to my timecard page")]
        public void GivenINavigateToMyTimecardPage()
        {
            _page = PageFactory.InitElements<TimecardPage>(_driver);
           _page.NavigateTo();
            Assert.IsTrue(_page.TimeCardTable.Displayed);
            Assert.AreEqual(14, _page.DayOfWeekRows.Count);
        }

        [Given(@"I enter time for the week")]
        public void GivenIEnterTimeForTheWeek()
        {
            _page.FillEntries();
        }

        [When(@"I submit my timecard")]
        public void WhenISubmitMyTimecard()
        {
            
        }

        [Then(@"I should get a success message")]
        public void ThenIShouldGetASuccessMessage()
        {
            
        }

    }
}
