using FindGames.Framework.Base;
using FindGames.Framework.Driver;
using FindGames.Framework.Elements;
using FindGames.Models;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace FindGames.Pages
{
    internal class SearchPage : BaseForm
    {
        private ReadOnlyCollection<IWebElement> GameInSearchResults(string gameName) => Singleton.GetInstance().FindElements(By.XPath($"//div[@id='search_result_container']//span[@class='title' and text()='{gameName}']"));
        private readonly Label topSellersLabel = new Label(By.XPath("//div[@class='page_content']//h2[contains(text(),'Top Sellers')]"), "Top Sellers label");
        private Checkbox SearchFilterCheckbox(string checkboxName) => new Checkbox(By.XPath($"//div[@id='additional_search_options']//div[@data-loc='{checkboxName}']//span[contains(@class,'checkbox')]"), "Checkbox");
        private Label MinimizedSearchFilterMenu(string filterName) => new Label(By.XPath($"//div[@id='additional_search_options']/div[contains(@class,'collapsed')]//div[contains(text(),'{filterName}')]"), "Search filter menu");
        private readonly Slider slider = new Slider(By.XPath("//input[@id='price_range']"), "Price slider");
        private readonly Label priceFilter = new Label(By.XPath("//input[@id='maxprice_input']"), "Price filter");
        private Label SearchResult(int numberOfTheSearchResult) => new Label(By.XPath($"//div[@id='search_resultsRows']/a[{numberOfTheSearchResult}]"), "Search result");
        private Checkbox SelectedCheckbox(string checkboxName) => new Checkbox(By.XPath($"//div[@id='additional_search_options']//div[@data-loc='{checkboxName}']//span[contains(@class,'checked')]"), "Selected checkbox");
        private Label ProductTitle(int numberOfTheSearchResult) => new Label(By.XPath($"//div[@id='search_resultsRows']/a[{numberOfTheSearchResult}]//span[@class='title']"), "Title");
        private Label ProductReleaseDate(int numberOfTheSearchResult) => new Label(By.XPath($"//div[@id='search_resultsRows']/a[{numberOfTheSearchResult}]//div[contains(@class,'released')]"), "Release Date");
        private Label ProductPrice(int numberOfTheSearchResult) => new Label(By.XPath($"//div[@id='search_resultsRows']//a[{(numberOfTheSearchResult)}]//div[@data-price-final]"), "Price");
        private Label searchingLabel = new Label(By.XPath("//div[@id='search_result_container' and contains(@style,'opacity')]"), "Searching label");

        public SearchPage() : base(By.XPath("//div[@id='search_results']"), "Search Page")
        { }

        public bool IsGameInSearchResults(string gameName)
        {
            return GameInSearchResults(gameName).Count == 1;
        }

        public bool IsTopSellersOnThePage()
        {
            return topSellersLabel.ElementIsDisplayed();
        }

        public void ClickCheckBox(string filterName, string checkbox)
        {
            
            if (MinimizedSearchFilterMenu(filterName).ElementIsExist())
            {
                MinimizedSearchFilterMenu(filterName).ClickElement();
            }
            SearchFilterCheckbox(checkbox).MoveToElement();
            SearchFilterCheckbox(checkbox).ClickElement();
        }

        public void SetUpPrice(int price)
        {
            if (MinimizedSearchFilterMenu("Narrow by Price").ElementIsExist())
            {
                MinimizedSearchFilterMenu("Narrow by Price").ClickElement();
            }
            var filterPrice = 0;

            while (filterPrice != price)
            {
                slider.MoveSlider(-5, 0);
                filterPrice = Int32.Parse(priceFilter.GetAttributeElement("value"));
            }            
        }

        public bool IsCheckboxSelected(string checkboxName)
        {
            return SelectedCheckbox(checkboxName).ElementIsExist();
        }

        public SteamGame GetGameModelFromSearchResult(int number)
        {
            while (IsSearchFinished()) { }
            var game = new SteamGame();
            game.Price = ProductPrice(number).GetAttributeElement("data-price-final");
            game.ReleaseDate = ProductReleaseDate(number).GetTextFromElement();
            game.Title = ProductTitle(number).GetTextFromElement();
            return game;
        }

        public bool IsSearchFinished()
        {
            return searchingLabel.ElementIsExist();
        }

        public void ClickConreteSearchResult(int number)
        {
            while (IsSearchFinished()) { }
            SearchResult(number).MoveToElement();
            SearchResult(number).ClickElement();
        }
    }
}