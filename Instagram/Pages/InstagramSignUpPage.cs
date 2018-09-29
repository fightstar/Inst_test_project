using System;
using Instagram.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Instagram.Pages
{
    public class InstagramSignUpPage
    {
        #region 'Properties and controls'

        private IWebDriver Driver;

        [FindsBy(How = How.CssSelector, Using = "a[href*=\"login\"]")]
        private IWebElement LoginLink;

        #endregion 'Properties and controls'

        #region 'Constructor'

        public InstagramSignUpPage()
        {
            this.Driver = Inj.Driver;
            PageFactory.InitElements(Driver, this);
        }

        #endregion 'Constructor'

        #region 'Methods'

        public void Open(Uri pageUri)
        {
            Driver.NavigateGoToUrl(pageUri);
        }

        public InstagramLoginPage OpenLogin()
        {
            this.LoginLink.Click();
            return new InstagramLoginPage();
        }

        #endregion 'Methods'
    }
}