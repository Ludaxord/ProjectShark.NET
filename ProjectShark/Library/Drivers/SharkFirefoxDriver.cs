using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ProjectShark.Library.Interfaces;

namespace ProjectShark.Library.Drivers{
    public sealed class SharkFirefoxDriver : SharkDriver{
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan) : base("firefox", driverPath, timeSpan){
            InitDriver();
        }

        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, IScrapper scrapper) : base("firefox",
            driverPath, timeSpan, scrapper){
            InitDriver();
        }

        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as FirefoxOptions;
            var firefoxDriver = new FirefoxDriver(driverPath, options);
            return firefoxDriver;
        }
    }
}