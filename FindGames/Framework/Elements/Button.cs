using FindGames.Framework.Base;
using OpenQA.Selenium;

namespace FindGames.Framework.Elements
{
    internal class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name)
        { }
    }
}