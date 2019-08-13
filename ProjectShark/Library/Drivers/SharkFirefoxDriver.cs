using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ProjectShark.Library.Scrappers;

namespace ProjectShark.Library.Drivers{
    /// <summary>
    /// Firefox driver (geckoDriver) implementation of SharkDriver abstract class. 
    /// </summary>
    public sealed class SharkFirefoxDriver : SharkDriver{
        /// <summary>
        /// Constructor that create driver with default parameters, Inherits base constructor of SharkDriver with firefox as browser
        /// </summary>
        /// <param name="driverPath">passed driver path</param>
        /// <param name="timeSpan">passed timeout that page will be wait until load</param>
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan) : base("firefox", driverPath, timeSpan){
        }

        /// <summary>
        /// Constructor that create firefox driver with default parameters, Inherits base constructor of SharkDriver with firefox as browser
        /// </summary>
        /// <param name="driverPath">passed driver path</param>
        /// <param name="timeSpan">passed timeout that page will be wait until load</param>
        /// <param name="scrapper">custom scrapper that implements BaseScrapper Interface and can extends BaseScrapper abstract class</param>
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, SharkScrapper scrapper) : base("firefox",
            driverPath, timeSpan, scrapper){
        }

        /// <summary>
        /// Constructor that create firefox driver with default parameters, Inherits base constructor of SharkDriver with firefox as browser.
        /// Constructor also calls method NavigateToWebPage from scrapper that navigate browser to passed url
        /// </summary>
        /// <param name="driverPath">passed driver path</param>
        /// <param name="timeSpan">passed timeout that page will be wait until load</param>
        /// <param name="scrapper">custom scrapper that implements BaseScrapper Interface and can extends BaseScrapper abstract class</param>
        /// <param name="url">passed url of page that driver should navigate browser</param>
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, SharkScrapper scrapper, string url) : base(
            "firefox",
            driverPath, timeSpan, scrapper, url){
            scrapper.NavigateToWebPage(Driver, url);
        }

        /// <summary>
        /// Implementation of abstract method InitWebDriver from SharkDriver abstract class.
        /// Method return FirefoxWebDriver specified by browser
        /// </summary>
        /// <param name="driverPath">passed driver path</param>
        /// <returns>FirefoxWebDriver</returns>
        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as FirefoxOptions;
            var firefoxDriver = new FirefoxDriver(driverPath, options);
            return firefoxDriver;
        }
    }
}