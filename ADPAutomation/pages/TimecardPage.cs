using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ADPAutomation.pages
{
    public class TimecardPage : BasePage
    {
        public TimecardPage(IWebDriver driver) : base(driver)
        {
            @Url =
                "https://workforcenow.adp.com/portal/theme#/Myself_ttd_Time%26Attendance_MyTimecard/MyselfTabTimecardsAttendanceSchCategoryTLMWebMyTimecard";
        }

        [FindsBy(How = How.Id, Using = "TcGrid")]
        public IWebElement TimeCardTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='TcGrid']/tbody//tr[@class ='dR' or  @class = 'dR AltDay']")]
        public IList<IWebElement> DayOfWeekRows { get; set; }

        public override void NavigateTo()
        {
            base.NavigateTo();
            WaitForLoad(By.Id("TcGrid"));
        }

        public void FillTimecardEntry(IWebElement row)
        {
            var tce = GetTimecardEntry(row);

            WriteTimecardEntry(row, tce);
        }

        private TimecardEntry GetTimecardEntry(IWebElement row)
        {
            IList<IWebElement> cells = row.FindElements(By.XPath("td"));
            
            var tce = new TimecardEntry
            {
                TimeCode = cells[3].Text,
                Hours = cells[4].Text,
                Task = cells[7].Text,
                Project = cells[8].Text,
                Initiative = cells[9].Text
            };

            return tce;
        }

        private void WriteTimecardEntry(IWebElement row, TimecardEntry timecardEntry)
        {
            IList<IWebElement> cells = row.FindElements(By.XPath("td"));
            var cellInput = Driver.FindElement(By.Id("TLMWidgets_TimeEntry_DurationTextBox_1"));
            cellInput.SendKeys("10.00");
        }

        public void FillEntries()
        {
            FillTimecardEntry(DayOfWeekRows[1]);
        }
    }

    public class TimecardEntry
    {
        public string TimeCode { get; set; }
        public string Hours { get; set; }
        public string Task { get; set; }
        public string Project { get; set; }
        public string Initiative { get; set; }

    }

}

