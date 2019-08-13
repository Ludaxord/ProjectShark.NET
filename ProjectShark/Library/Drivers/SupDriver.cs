using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ProjectShark.Library.Interfaces;

namespace ProjectShark.Library.Drivers{
    public abstract class SupDriver : IDriver{
        public DriverOptions GetOptions(List<string> options, string browser){
            DriverOptions driverOptions = null;

            switch (browser){
                case "chrome":
                    driverOptions = new ChromeOptions();
                    ((ChromeOptions) driverOptions).AddArguments(options.ToArray());
                    break;
                case "firefox":
                    driverOptions = new FirefoxOptions();
                    ((FirefoxOptions) driverOptions).AddArguments(options.ToArray());
                    break;
            }

            return driverOptions;
        }
    }
}