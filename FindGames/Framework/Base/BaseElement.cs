using FindGames.Framework.Driver;
using FindGames.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FindGames.Framework.Base
{
    internal abstract class BaseElement
    {
        protected readonly By locatorOfElement;
        public string nameOfElement;

        protected BaseElement(By locator, string name)
        {
            locatorOfElement = locator;
            nameOfElement = name;
        }

        public string GetAttributeElement(string attribute)
        {
            LoggerUtil.Info($"Get element '{this.nameOfElement}' attribute '{attribute}' ");
            return Singleton.GetInstance().FindElement(locatorOfElement).GetAttribute(attribute);
        }

        public bool ElementIsExist()
        {
            return Singleton.GetInstance().FindElements(locatorOfElement).Count > 0;
        }

        public bool ElementIsDisplayed()
        {
            WaiterUtil.UseExplicitWait(locatorOfElement);
            return Singleton.GetInstance().FindElement(locatorOfElement).Displayed;
        }

        public bool ElementIsEnabled()
        {
            WaiterUtil.UseExplicitWait(locatorOfElement);
            return Singleton.GetInstance().FindElement(locatorOfElement).Enabled;
        }

        public void ClickElement()
        {
            LoggerUtil.Info($"Click element '{this.nameOfElement}'");
            WaiterUtil.UseExplicitWait(locatorOfElement);
            Singleton.GetInstance().FindElement(locatorOfElement).Click();
        }

        public string GetTextFromElement()
        {
            LoggerUtil.Info($"Get element '{this.nameOfElement}' text");
            WaiterUtil.UseExplicitWait(locatorOfElement);
            return Singleton.GetInstance().FindElement(locatorOfElement).Text;
        }

        public void MoveToElement()
        {
            Actions actions = new Actions(Singleton.GetInstance());
            WaiterUtil.UseExplicitWait(locatorOfElement);
            actions.MoveToElement(Singleton.GetInstance().FindElement(locatorOfElement));
            actions.Perform();
        }
    }
}