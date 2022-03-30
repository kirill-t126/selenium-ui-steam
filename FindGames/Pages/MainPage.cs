using FindGames.Framework.Base;
using FindGames.Framework.Elements;
using OpenQA.Selenium;

namespace FindGames.Pages
{
    internal class MainPage : BaseForm
    {
        private readonly Button newAndNoteworthyButton = new Button(By.XPath("//div[@id='noteworthy_tab']"), "Note and Noteworthy button");
        private readonly Label newAndNoteworthyLabel = new Label(By.XPath("//div[@id='noteworthy_flyout']"), "Note and Noteworthy popup menu");
        private readonly Button topSellersButton = new Button(By.XPath("//div[@id='noteworthy_flyout']//a[contains(text(),'Top Sellers')]"), "Top Sellers");
        private readonly TextBox searchTextBox = new TextBox(By.XPath("//input[contains(@id,'search')]"), "Search textbox");
        private readonly Button searchButton = new Button(By.XPath("//a[contains(@id,'search')]//img"), "Search button");

        public MainPage() : base(By.XPath("//div[@class='gutter_header']/a/img"), "Main Page")
        { }

        public void MoveToNewAndNoteworthy() => newAndNoteworthyButton.MoveToElement();

        public void ClickTopSellersButton()
        {
            if (newAndNoteworthyLabel.ElementIsEnabled())
            {
                topSellersButton.ClickElement();
            }
        }

        public void InputTestText(string text) => searchTextBox.InputText(text);

        public void ClickSearchButton() => searchButton.ClickElement();
    }
}