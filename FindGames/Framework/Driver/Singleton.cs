using OpenQA.Selenium;

namespace FindGames.Framework.Driver
{
    internal sealed class Singleton
    {
        private Singleton() { }

        private static WebDriver webDriver;

        public static WebDriver GetInstance()
        {
            if (webDriver == null)
            {
                webDriver = BrowserFactory.GetBrowser();
            }
            return webDriver;
        }

        public static void CloseDriver()
        {
            webDriver = null;
        }
    }
}