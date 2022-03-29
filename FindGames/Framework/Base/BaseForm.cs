using FindGames.Framework.Driver;
using OpenQA.Selenium;

namespace FindGames.Framework.Base
{
    internal abstract class BaseForm
    {
        protected By locator;
        public string PageName;

        protected BaseForm(By locator, string pageName)
        {
            this.PageName = pageName;
            this.locator = locator;
        }

        public bool PageIsDisplayed()
        {
            return Singleton.GetInstance().FindElements(locator).Count > 0;
        }
    }
}