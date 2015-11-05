using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ADPAutomation.pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected string Url { get; set; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public virtual void NavigateTo()
        {
            Driver.Url = Url;
        }


        public void WaitForLoad(By byType)
        {
            var myDynamicElement = (new WebDriverWait(Driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(byType));
        }
    }
}
