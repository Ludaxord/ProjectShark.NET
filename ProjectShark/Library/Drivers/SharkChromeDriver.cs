using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjectShark.Library.Drivers{
    public sealed class SharkChromeDriver : SharkDriver{
        
        public SharkChromeDriver(string driverPath, TimeSpan timeSpan) : base("chrome", driverPath, timeSpan){
            
        }
        
        protected override IWebDriver InitWebDriver(string driverPath){
            var options = GetOptions(null, Browser) as ChromeOptions;
            var chromeDriver = new ChromeDriver(driverPath, options);
            return chromeDriver;
        }
    }
}