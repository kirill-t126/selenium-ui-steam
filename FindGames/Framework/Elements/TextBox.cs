using FindGames.Framework.Base;
using FindGames.Framework.Driver;
using OpenQA.Selenium;

namespace FindGames.Framework.Elements
{
    internal class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, name)
        { }

        public void InputText(string text)
        {
            base.ElementIsDisplayed();
            Singleton.GetInstance().FindElement(this.locatorOfElement).SendKeys(text);
        }
    }
}