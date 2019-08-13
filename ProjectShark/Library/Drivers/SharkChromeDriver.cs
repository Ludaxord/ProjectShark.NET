using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectShark.Library.Scrappers;

namespace ProjectShark.Library.Drivers{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SharkChromeDriver : SharkDriver{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="timeSpan"></param>
        public SharkChromeDriver(string driverPath, TimeSpan timeSpan) : base("chrome", driverPath, timeSpan){
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="timeSpan"></param>
        /// <param name="scrapper"></param>
        public SharkChromeDriver(string driverPath, TimeSpan timeSpan, BaseScrapper scrapper) : base("chrome",
            driverPath, timeSpan, scrapper){
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <param name="timeSpan"></param>
        /// <param name="scrapper"></param>
        /// <param name="url"></param>
        public SharkChromeDriver(string driverPath, TimeSpan timeSpan, BaseScrapper scrapper, string url) : base(
            "chrome",
            driverPath, timeSpan, scrapper, url){
            scrapper.NavigateToWebPage(Driver, url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverPath"></param>
        /// <returns></returns>
        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as ChromeOptions;
            var chromeDriver = new ChromeDriver(driverPath, options);
            return chromeDriver;
        }
    }
}