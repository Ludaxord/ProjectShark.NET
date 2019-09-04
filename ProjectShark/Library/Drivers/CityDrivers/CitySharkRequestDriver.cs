using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using ProjectShark.Library.Scrappers.CityScrappers;

namespace ProjectShark.Library.Drivers.CityDrivers{
    /// <summary>
    /// City Shark Request Driver (geckoDriver) implementation of CitySharkDriver abstract class. 
    /// </summary>
    public class CitySharkRequestDriver : CitySharkDriver{
        public CitySharkRequestDriver(string url, CitySharkScrapper scrapper, bool withCookies = false) : base(url,
            scrapper, withCookies){
        }

        private CitySharkRequestDriver(string browser, string driverPath, TimeSpan timeSpan,
            List<string> options = null)
            : base(browser, driverPath, timeSpan, options){
        }

        private CitySharkRequestDriver(string browser, string driverPath, TimeSpan timeSpan, CitySharkScrapper scrapper,
            List<string> options = null) : base(browser, driverPath, timeSpan, scrapper, options){
        }

        private CitySharkRequestDriver(string browser, string driverPath, TimeSpan timeSpan, CitySharkScrapper scrapper,
            string url, List<string> options = null) : base(browser, driverPath, timeSpan, scrapper, url, options){
        }


        /// <summary>
        /// Implementation of abstract method InitWebDriver from CitySharkDriver abstract class.
        /// Method return FirefoxWebDriver specified by browser
        /// </summary>
        /// <param name="driverPath">passed driver path</param>
        /// <returns>null</returns>
        protected override IWebDriver InitWebDriver(string driverPath){
            return null;
        }

        /// <summary>
        /// Initializer of web request
        /// </summary>
        protected override void InitWebRequest(bool withCookies){
            Html = withCookies ? GetHtmlWithCookies(Url) : GetHtml(Url);
            Scrapper.Html = Html;
            HtmlDocument = GetDocument(Html);
        }
    }
}