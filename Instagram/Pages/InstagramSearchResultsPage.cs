using Instagram.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Instagram.Pages
{
    public class InstagramSearchResultsPage : InstagramMainFeedPage
    {
        #region 'Fields and controls'

        private IWebDriver Driver;

        private IWebElement LoadMoreButton
        {
            get
            {
                return Driver.WaitForElementExists(By.XPath("//a[contains(@class,'_8imhp')]"));
            }
        }

        [FindsBy(How = How.XPath, Using = @"//div[@class='EZdmt']")]
        private IList<IWebElement> LoadedRowsWithPanes;

        #endregion 'Fields and controls'

        #region 'Constructor'

        public InstagramSearchResultsPage()
        {
            Driver = Inj.Driver;
            System.Threading.Thread.Sleep(2000);
            PageFactory.InitElements(Driver, this);
        }

        #endregion 'Constructor'

        #region 'Methods'

        public InstagramSearchResultsPage LoadMoreResults()
        {
            this.LoadMoreButton.ScrollIntoView();
            this.LoadMoreButton.Click();
            return this;
        }

        public IWebElement GetFirstPane()
        {
            return this.LoadedRowsWithPanes.First().FindElements(By.TagName("a")).First();
        }

        public PostDetails OpenFirstPostDetails()
        {
            GetFirstPane().ClickJs();
            return new PostDetails();
        }

        #endregion 'Methods'
    }
}