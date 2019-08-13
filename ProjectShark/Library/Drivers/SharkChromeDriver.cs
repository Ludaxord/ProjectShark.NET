using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectShark.Library.Interfaces;

namespace ProjectShark.Library.Drivers{
    public sealed class SharkChromeDriver : SharkDriver{
        public SharkChromeDriver(string driverPath, TimeSpan timeSpan) : base("chrome", driverPath, timeSpan){
            InitDriver();
        }

        public SharkChromeDriver(string driverPath, TimeSpan timeSpan, IScrapper scrapper) : base("firefox",
            driverPath, timeSpan, scrapper){
            InitDriver();
        }

        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as ChromeOptions;
            var chromeDriver = new ChromeDriver(driverPath, options);
            return chromeDriver;
        }
    }
}