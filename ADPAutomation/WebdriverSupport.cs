using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace ADPAutomation
{
    [Binding]
    public class WebdriverSupport
    {
        private readonly IObjectContainer _objectContainer;

        public WebdriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var driver = new FirefoxDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

    }
}
