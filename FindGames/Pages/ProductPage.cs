using FindGames.Framework.Base;
using FindGames.Framework.Elements;
using FindGames.Models;
using OpenQA.Selenium;

namespace FindGames.Pages
{
    internal class ProductPage : BaseForm
    {
        private readonly Label productTitle = new Label(By.XPath("//div[@id='appHubAppName']"), "Product title");
        private readonly Label productReleaseDate = new Label(By.XPath("//div[@class='release_date']/div[@class='date']"), "Product release date");
        private readonly Label productPrice = new Label(By.XPath("//div[@class='game_purchase_action']//div[@data-price-final]"), "Product price");

        public ProductPage() : base(By.XPath("//div[@id='gameHeaderImageCtn']"), "Product page")
        { }

        public SteamGame GetGameModel()
        {
            var game = new SteamGame();
            game.Title = productTitle.GetTextFromElement();
            game.ReleaseDate = productReleaseDate.GetTextFromElement();
            game.Price = productPrice.GetAttributeElement("data-price-final");
            return game;
        }
    }
}