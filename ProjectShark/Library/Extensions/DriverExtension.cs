using System;
using System.Drawing;
using OpenQA.Selenium;

namespace ProjectShark.Library.Extensions{
    internal static class DriverExtension{
        internal static void NavigateToWebPage(this IWebDriver driver, string url){
            driver.Navigate().GoToUrl(url);
        }

        internal static void SetFullScreen(this IWebDriver driver){
            driver.Manage().Window.FullScreen();
        }

        internal static void SetWindowSize(this IWebDriver driver, int width, int height){
            driver.Manage().Window.Size = new Size(width, height);
        }

        internal static void SetBrowserLoadingTimeout(this IWebDriver driver, TimeSpan timeSpan){
            driver.Manage().Timeouts().ImplicitWait = timeSpan;
        }
    }
}