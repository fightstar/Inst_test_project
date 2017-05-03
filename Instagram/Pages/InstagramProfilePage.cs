using Instagram.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Instagram.Pages
{
    public class InstagramProfilePage
    {
        #region 'Fields and controls'

        private IWebDriver Driver;

        private const string Following = "a[href*='following']";
        private const string Followers = "a[href*='followers']";

        [FindsBy(How = How.CssSelector, Using = Followers)]
        private IWebElement FollowersLink;

        [FindsBy(How = How.CssSelector, Using = Following)]
        private IWebElement FollowingLink;

        #endregion


        #region 'Constructor'

        public InstagramProfilePage()
        {
            Inj.Driver.WaitForElementVisible(By.CssSelector("button[class*='coreSpriteMobileNavSettings']"));
            this.Driver = Inj.Driver;
            PageFactory.InitElements(Driver, this);
        }

        #endregion

        #region 'Methods'


        #endregion
    }
}
