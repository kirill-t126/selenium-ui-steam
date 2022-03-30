using FindGames.Framework.Base;
using OpenQA.Selenium;

namespace FindGames.Framework.Elements
{
    internal class Checkbox : BaseElement
    {
        public Checkbox(By locator, string name) : base (locator, name)
        { }
    }
}