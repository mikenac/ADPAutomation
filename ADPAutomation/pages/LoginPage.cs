using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ADPAutomation.pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            Url = @"https://workforcenow.adp.com/public/index.htm";
        }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement UserTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "PASSWORD")]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "portal.login.logIn")]
        public IWebElement SubmitButton { get; set; }

        public void Login(string userName, string password)
        {
            UserTextBox.Clear();
            UserTextBox.SendKeys(userName);
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            SubmitButton.Click();
        }
    }
}