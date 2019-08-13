using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ProjectShark.Library.Drivers{
    public sealed class SharkFirefoxDriver : SharkDriver{
        
        public SharkFirefoxDriver(string driverPath, TimeSpan timeSpan) : base("firefox", driverPath, timeSpan){
            
        }

        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as FirefoxOptions;
            var firefoxDriver = new FirefoxDriver(driverPath, options);
            return firefoxDriver;
        }
    }
}