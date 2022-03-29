using FindGames.Framework.Base;
using OpenQA.Selenium;

namespace FindGames.Framework.Elements
{
    internal class Label : BaseElement
    {
        public Label(By locator, string name) : base(locator, name)
        { }
    }
}