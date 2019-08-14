using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ProjectShark.Library.Extensions;
using ProjectShark.Library.Interfaces;
using ProjectShark.Library.Scrappers;

namespace ProjectShark.Library.Drivers{
    /// <summary>
    /// Abstract class that can be inherit by new driver, defines methods for browser
    /// </summary>
    public abstract class SharkDriver : IDriver{
        /// <summary>
        /// Getter, Setter for passed driver
        /// </summary>
        protected IWebDriver Driver{ get; set; }

        /// <summary>
        /// Getter, Setter for passed options
        /// </summary>
        protected List<string> Options{ get; set; }

        /// <summary>
        /// Getter, Setter for passed scrapper
        /// </summary>
        protected SharkScrapper Scrapper{ get; set; }

        /// <summary>
        /// Getter, Setter for passed browser name
        /// </summary>
        protected string Browser{ get; set; }

        /// <summary>
        /// Getter, Setter for passed driver path
        /// </summary>
        protected string DriverPath{ get; set; }

        /// <summary>
        /// Getter, Setter for passed timeout
        /// </summary>
        protected TimeSpan TimeOut{ get; set; }

        /// <summary>
        /// Constructor that create driver with default parameters
        /// </summary>
        /// <param name="browser">passed browser name</param>
        /// <param name="driverPath">passed driver path</param>
        /// <param name="timeSpan">passed timeout that page will be wait until load</param>
        /// <param name="options">passed options of web browser if it is set to null it takes default options of web browser</param>
        protected SharkDriver(string browser, string driverPath, TimeSpan timeSpan, List<string> options = null){
            TimeOut = timeSpan;
            Browser = browser;
            DriverPath = driverPath;
            Options = options;
            InitDriver();
        }

        /// <summary>
        /// Constructor that create driver with default parameters and custom scrapper that contains scrapping web page methods
        /// </summary>
        /// <param name="browser">passed browser name</param>
        /// <param name="driverPath">passed driver path</param>
        /// <param name="timeSpan">passed timeout that page will be wait until load</param>
        /// <param name="scrapper">custom scrapper that implements BaseScrapper and can extends BaseScrapper abstract class</param>
        /// <param name="options">passed options of web browser if it is set to null it takes default options of web browser</param>
        protected SharkDriver(string browser, string driverPath, TimeSpan timeSpan,
            SharkScrapper scrapper, List<string> options = null){
            TimeOut = timeSpan;
            Browser = browser;
            DriverPath = driverPath;
            Options = options;
            InitDriver();
            Scrapper = scrapper;
        }


        /// <summary>
        /// Constructor that create driver with default parameters and custom scrapper that contains scrapping web page methods and sets base url of page 
        /// </summary>
        /// <param name="browser">passed browser name</param>
        /// <param name="driverPath">passed driver path</param>
        /// <param name="timeSpan">passed timeout that page will be wait until load</param>
        /// <param name="scrapper">custom scrapper that implements BaseScrapper and can extends BaseScrapper abstract class</param>
        /// <param name="url">passed url of page that driver should navigate browser</param>
        /// <param name="options">passed options of web browser if it is set to null it takes default options of web browser</param>
        protected SharkDriver(string browser, string driverPath, TimeSpan timeSpan,
            SharkScrapper scrapper,
            string url, List<string> options = null){
            TimeOut = timeSpan;
            Browser = browser;
            DriverPath = driverPath;
            Options = options;
            InitDriver();
            Scrapper = scrapper;
            Scrapper.Url = url;
        }

        /// <summary>
        /// Abstract method that need to be implemented in every SharkDriver class. It defines Driver that will be loaded to package
        /// </summary>
        /// <param name="driverPath">passed driver path</param>
        /// <returns>Driver that will be used in browser lifecycle</returns>
        protected abstract IWebDriver InitWebDriver(string driverPath);

        /// <summary>
        /// Initializer of default functions in WebDriver
        /// </summary>
        protected void InitDriver(){
            Driver = InitWebDriver(DriverPath);
            WindowSize(Driver);
            SetFullScreen(Driver);
            SetTimeoutsForItemsVisibility(Driver, TimeOut);
        }

        /// <summary>
        /// Method that returns options for web driver
        /// </summary>
        /// <param name="options">list of options passed to driver</param>
        /// <param name="browser">passed browser name available names: chrome, firefox</param>
        /// <returns>Browser options</returns>
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

        /// <summary>
        /// Method that set web browser to full screen
        /// </summary>
        /// <param name="driver">passed driver</param>
        /// <exception cref="Exception">Problem with driver</exception>
        public void SetFullScreen(IWebDriver driver){
            try{
                driver.SetFullScreen();
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set browser to full screen");
            }
        }

        /// <summary>
        /// Method that set window size of web browser
        /// </summary>
        /// <param name="driver">passed driver</param>
        /// <param name="width">width that window will have -> default 1920</param>
        /// <param name="height">width that window will have -> default 1080</param>
        /// <exception cref="Exception">Problem with setting window size</exception>
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

        /// <summary>
        /// Killing all driver and browser processes that runs in background
        /// </summary>
        /// <param name="browserName">browser name, available names: chrome, firefox</param>
        /// <exception cref="Exception">Problem with killing process</exception>
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

        /// <summary>
        /// Setting timeout for load page elements
        /// </summary>
        /// <param name="driver">passed driver</param>
        /// <param name="timeSpan">passed timespan </param>
        /// <exception cref="Exception">Problem with setting timeout</exception>
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