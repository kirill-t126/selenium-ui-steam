using FindGames.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace FindGames.Framework.Driver
{
    internal static class BrowserFactory
    {
        public static WebDriver GetBrowser()
        {
            string browserName = ConfigUtil.GetValueByName("BrowserName");
            return browserName switch
            {
                "Chrome" => GetChromeInstance(),
                "Firefox" => GetFirefoxInstance(),
                _ => throw new NotImplementedException("Invalid browser name. Valid names: Firefox, Chrome"),
            };
        }

        private static FirefoxDriver GetFirefoxInstance()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            var webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Size = new System.Drawing.Size(Int32.Parse(ConfigUtil.GetValueByName("BrowserResolutionLength")), Int32.Parse(ConfigUtil.GetValueByName("BrowserResolutionWidth")));
            return webDriver;
        }

        private static ChromeDriver GetChromeInstance()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            var webDriver = new ChromeDriver();
            webDriver.Manage().Window.Size = new System.Drawing.Size(Int32.Parse(ConfigUtil.GetValueByName("BrowserResolutionLength")), Int32.Parse(ConfigUtil.GetValueByName("BrowserResolutionWidth")));
            return webDriver;
        }
    }
}