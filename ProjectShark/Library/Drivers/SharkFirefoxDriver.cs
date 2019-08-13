using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ProjectShark.Library.Scrappers;

namespace ProjectShark.Library.Drivers{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SharkFirefoxDriver : SharkDriver{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="timeSpan"></param>
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan) : base("firefox", driverPath, timeSpan){
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="timeSpan"></param>
        /// <param name="scrapper"></param>
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, BaseScrapper scrapper) : base("firefox",
            driverPath, timeSpan, scrapper){
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="timeSpan"></param>
        /// <param name="scrapper"></param>
        /// <param name="url"></param>
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, BaseScrapper scrapper, string url) : base(
            "firefox",
            driverPath, timeSpan, scrapper, url){
            scrapper.NavigateToWebPage(Driver, url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <returns></returns>
        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as FirefoxOptions;
            var firefoxDriver = new FirefoxDriver(driverPath, options);
            return firefoxDriver;
        }
    }
}