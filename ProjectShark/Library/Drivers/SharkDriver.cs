using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ProjectShark.Library.Extensions;
using ProjectShark.Library.Interfaces;

namespace ProjectShark.Library.Drivers{
    public abstract class SharkDriver : IDriver{
        protected IWebDriver Driver{ get; set; }
        
        protected IScrapper Scrapper{ get; set; }
        protected string Browser{ get; set; }
        protected string DriverPath{ get; set; }
        protected TimeSpan TimeOut{ get; set; }

        protected SharkDriver(string browser, string driverPath, TimeSpan timeSpan){
            TimeOut = timeSpan;
            Browser = browser;
            DriverPath = driverPath;
            InitDriver();
        }
        protected SharkDriver(string browser, string driverPath, TimeSpan timeSpan, IScrapper scrapper){
            TimeOut = timeSpan;
            Browser = browser;
            DriverPath = driverPath;
            InitDriver();
            Scrapper = scrapper;
        }

        protected void InitDriver(){
            Driver = InitWebDriver(DriverPath);
            WindowSize(Driver);
            SetFullScreen(Driver);
            SetTimeoutsForItemsVisibility(Driver, TimeOut);
        }

        protected abstract IWebDriver InitWebDriver(string driverPath);
        
        public DriverOptions GetOptions(List<string> options, string browser){
            DriverOptions driverOptions = null;

            if (options == null){
                options = new List<string>();
                options.SetDefaultOptions();
            }

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

        public void NavigateToWebPage(IWebDriver driver, string url){
            try{
                driver.NavigateToWebPage(url);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot start browser with URL: {url}");
            }
        }

        public void SetFullScreen(IWebDriver driver){
            try{
                driver.SetFullScreen();
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set browser to full screen");
            }
        }

        public void WindowSize(IWebDriver driver, int width = (int) Enumerations.WindowSize.Width,
            int height = (int) Enumerations.WindowSize.Height){
            try{
                driver.SetWindowSize(width, height);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set window size to size {width} x {height}");
            }
        }

        public void KillBrowserProcesses(string browserName){
            var processes = new List<Process>();

            switch (browserName){
                case "chrome":{
                    processes.AddRange(Process.GetProcessesByName("chromedriver"));
                    processes.AddRange(Process.GetProcessesByName(browserName));
                    break;
                }

                case "firefox":{
                    processes.AddRange(Process.GetProcessesByName("geckodriver"));
                    processes.AddRange(Process.GetProcessesByName(browserName));
                    break;
                }
            }

            processes.AddRange(Process.GetProcessesByName("Web Content"));

            foreach (var process in processes){
                try{
                    process.Kill();
                }
                catch (Exception e){
                    Console.WriteLine(e);
                    throw new Exception($"Cannot kill process with name: {process.ProcessName}");
                }
            }
        }

        public void SetTimeoutsForItemsVisibility(IWebDriver driver, TimeSpan timeSpan){
            try{
                driver.SetBrowserLoadingTimeout(timeSpan);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set timeout on timespan for total seconds of {timeSpan.TotalSeconds}");
            }
        }
    }
}