using FindGames.Framework.Base;
using FindGames.Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FindGames.Framework.Elements
{
    internal class Slider : BaseElement
    {
        public Slider(By locator, string name) : base(locator, name)
        { }

        public void MoveSlider(int x, int y)
        {
            Actions action = new Actions(Singleton.GetInstance());
            action.DragAndDropToOffset(Singleton.GetInstance().FindElement(this.locatorOfElement), x, y).Build().Perform();
        }
    }
}