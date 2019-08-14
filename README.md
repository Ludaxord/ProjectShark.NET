
# ProjectShark.NET

ProjectShark is additional package for web scrapping with C#/.NET.

- **Source code:** https://github.com/Ludaxord/ProjectShark.NET
- **Bug reports:** https://github.com/Ludaxord/ProjectShark.NET/issues

Description
----------------------

ProjectShark provides:

- Implementation of Selenium methods that in easy way gives ability to find, move, click and search elements in page. It is also possible to get all source code of scrapping web page.
- Classes that in easy way create driver and run browser with selenium.
- Abstract classes that can be inherit with all methods provided by scrapping engine and driver engine.

Requirements
----------------------

- Driver of choice. It can be geckoDriver, chromeDriver or any other driver that selenium support. For more info about drivers check [Selenium Drivers Docs](https://www.seleniumhq.org/projects/webdriver/)
- Web browser of choice. It can be Firefox, Chrome or any other that selenium package support.

Installation
----------------------

You can either download the source and compile or use nuget at http://nuget.org. To install with nuget:
Install-Package ProjectShark


Getting Started
----------------------

example of usage with SharkDriver:

```c#
    class Program{
        static void Main(string[] args){
            var sharkRun = new SharkRun();
            sharkRun.RunDriver();
        }

        private class SharkExampleScrapper : SharkScrapper{
        }

        private class SharkRun{
            public void RunDriver(){
                var options = new List<string>();
                var firefoxDriver = new SharkFirefoxDriver(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    TimeSpan.FromMinutes(1),
                    new SharkExampleScrapper(),
                    "https://www.example.com/",
                    options
                );
                
            }
        }
    }
```

example of usage with SharkRequest:

- T.B.A



Documentation
----------------------

### To run package simply run one of SharkDriver class.

### ``SharkChromeDriver()``

* SharkChromeDriver
    * Chrome driver (chromeDriver) implementation of SharkDriver abstract class.
   
* SharkChromeDriver
    * Constructor that create driver with default parameters, Inherits base constructor of SharkDriver with chrome as browser

```c#
     SharkChromeDriver(string driverPath, TimeSpan timeSpan)
```

* SharkChromeDriver
    * Constructor that create chrome driver with default parameters, Inherits base constructor of SharkDriver with chrome as browser
         
```c#
      SharkChromeDriver(string driverPath, TimeSpan timeSpan, SharkScrapper scrapper)
```

* SharkChromeDriver
    * Constructor that create chrome driver with default parameters, Inherits base constructor of SharkDriver with chrome as browser.
      Constructor also calls method NavigateToWebPage from scrapper that navigate browser to passed url   
         
```c#
     SharkChromeDriver(string driverPath, TimeSpan timeSpan, SharkScrapper scrapper, string url)
```

* SharkChromeDriver
    * Implementation of abstract method InitWebDriver from SharkDriver abstract class.
      Method return ChromeWebDriver specified by browser
```c#
    IWebDriver InitWebDriver(string driverPath)
``` 

### ``SharkFirefoxDriver()``

* SharkFirefoxDriver
    * Firefox driver (geckoDriver) implementation of SharkDriver abstract class.
    
* SharkChromeDriver
    * Constructor that create driver with default parameters, Inherits base constructor of SharkDriver with Firefox as browser

```c#
     SharkFirefoxDriver(string driverPath, TimeSpan timeSpan)
```

* SharkFirefoxDriver
    * Constructor that create Firefox driver with default parameters, Inherits base constructor of SharkDriver with Firefox as browser
         
```c#
      SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, SharkScrapper scrapper)
```

* SharkFirefoxDriver
    * Constructor that create Firefox driver with default parameters, Inherits base constructor of SharkDriver with Firefox as browser.
      Constructor also calls method NavigateToWebPage from scrapper that navigate browser to passed url   
         
```c#
     SharkFirefoxDriver(string driverPath, TimeSpan timeSpan, SharkScrapper scrapper, string url)
```

* SharkFirefoxDriver
    * Implementation of abstract method InitWebDriver from SharkDriver abstract class.
      Method return FirefoxWebDriver specified by browser
```c#
    IWebDriver InitWebDriver(string driverPath)
``` 

### if you want to create own driver just inherit ``SharkDriver()`` abstract class

* SharkDriver
    * Abstract class that can be inherit by new driver, defines methods for browser
    
* SharkDriver
    * Constructor that create driver with default parameters
```c#
    SharkDriver(string browser, string driverPath, TimeSpan timeSpan)
``` 

* SharkDriver
    * Constructor that create driver with default parameters and custom scrapper that contains scrapping web page methods
```c#
    SharkDriver(string browser, string driverPath, TimeSpan timeSpan, SharkScrapper scrapper)
``` 

* SharkDriver
    * Constructor that create driver with default parameters and custom scrapper that contains scrapping web page methods and sets base url of page 
```c#
    SharkDriver(string browser, string driverPath, TimeSpan timeSpan, SharkScrapper scrapper)
``` 

* SharkDriver
    * Abstract method that need to be implemented in every SharkDriver class. It defines Driver that will be loaded to package
```c#
    abstract IWebDriver InitWebDriver(string driverPath)
``` 

* SharkDriver
    * Method that returns options for web driver
```c#
    DriverOptions GetOptions(List<string> options, string browser)
``` 

* SharkDriver
    * Method that set web browser to full screen
```c#
    void SetFullScreen(IWebDriver driver)
``` 

* SharkDriver
    * Method that set window size of web browser
```c#
    void WindowSize(IWebDriver driver, int width = (int) Enumerations.WindowSize.Width,
                int height = (int) Enumerations.WindowSize.Height)
``` 

* SharkDriver
    * Killing all driver and browser processes that runs in background
```c#
    void KillBrowserProcesses(string browserName)
``` 

* SharkDriver
    * Setting timeout for load page elements
```c#
    void SetTimeoutsForItemsVisibility(IWebDriver driver, TimeSpan timeSpan)
``` 

### If you want to set default window size there is enum ``WindowSize`` for default browser window size

* WindowSize
    * Defines default WindowSize if it won't be override in WindowSize method in SharkScrapper

* WindowSize
    * Default Width of window
```c#
      Width
```    
* WindowSize
    * Default Height of window
```c#
      Height
```

### To make action on scrapping web page you need to create your own scrapper class and extends ``SharkScrapper`` abstract class

* SharkScrapper
    * Abstract class that can be inherit by web page scrapper, defines methods for scrapping web page. It allows to make actions with scrapping web page by using selenium features, packed in methods of class.

* SharkScrapper
    *  Getter setter to set actual web page
    
       TODO: listener of url change in automation process
```c#
      string Url{ get; set; }
```

* SharkScrapper
    * Cast driver to JavaScriptExecutor Interface
```c#
      IJavaScriptExecutor CreateJavaScriptExecutor(IWebDriver driver)
```

* SharkScrapper
    * Find element in scrapped web page by class name. Note that if there is more than one element with passed className it will return only first one. To return collection of element check GetElementsByClassName method
```c#
      IWebElement GetElementByClassName(IWebDriver webDriver, string className)
```

* SharkScrapper
    * Find element in scrapped web page by tag name
```c#
      IWebElement GetElementByTagName(IWebDriver webDriver, string tagName)
```

* SharkScrapper
    * Return full page source code (html, css, javascript, etc.)
```c#
      string GetFullPage(IWebDriver driver)
```

* SharkScrapper
    * Find element inside parent web element
```c#
      IWebElement GetElementFromParentBySelector(IWebElement webDriver, By selector)
```

* SharkScrapper
    * Find collection of elements in scrapped web page by class name.
```c#
      ReadOnlyCollection<IWebElement> GetElementsByClassName(IWebDriver webDriver, string className)
```

* SharkScrapper
    * Find collection of elements in parent web element by class name.
```c#
      ReadOnlyCollection<IWebElement>
            GetElementsFromParentByClassName(IWebElement webElement, string className)
```

* SharkScrapper
    * Find collection of elements in parent web element by selenium selector.
```c#
      ReadOnlyCollection<IWebElement> GetElementsFromParentBySelector(IWebElement webDriver, By selector)
```

* SharkScrapper
    * Find collection of elements on web page by tag name.
```c#
      ReadOnlyCollection<IWebElement> GetElementsByTagName(IWebDriver webDriver, string tagName)
```

* SharkScrapper
    * Find element on web page by id.
```c#
      IWebElement GetElementById(IWebDriver webDriver, string id)
```

* SharkScrapper
    * Find element on web page by xPath.
```c#
      IWebElement GetElementByXPath(IWebDriver webDriver, string xPath)
```

* SharkScrapper
    * Find collection of elements on web page by xPath.
```c#
      ReadOnlyCollection<IWebElement> GetElementsByXPath(IWebDriver webDriver, string xPath)
```

* SharkScrapper
    * Check if element has desired class name
```c#
      bool ElementHasClass(IWebElement element, string active)
```

* SharkScrapper
    * Change focus of main driver to iFrame
```c#
      IWebDriver ChangeDriverFocusToIFrame(IWebDriver driver, IWebElement element, By selector)
```

* SharkScrapper
    * Moving to element by specific offset
```c#
      Actions CreateActionsWithMovementToElementByOffset(IWebDriver driver, IWebElement element, int offsetX,
                  int offsetY)
```

* SharkScrapper
    * Moving by specific offset
```c#
      Actions CreateActionsWithMovementByOffset(IWebDriver driver, int offsetX, int offsetY)
```

* SharkScrapper
    * Create new action that can be made on web driver
```c#
      Actions CreateActions(IWebDriver driver)
```

* SharkScrapper
    * Moving to element
```c#
      Actions CreateActionsWithMovementToElement(IWebDriver driver, IWebElement element)
```

* SharkScrapper
    * Back to default driver if driver was set to iFrame
```c#
      IWebDriver BackToMainDriver(IWebDriver driver)
```

* SharkScrapper
    * Check if element exists on web page by selenium based selector
```c#
      bool CheckIfElementExists(IWebDriver driver, By selector)
```

* SharkScrapper
    * Check if element exists has children elements by selenium based selector
```c#
      bool CheckIfElementHasChildren(IWebElement element, By selector)
```

* SharkScrapper
    * Create Web Driver wait object
```c#
      WebDriverWait GetDriverWait(IWebDriver webDriver, TimeSpan forTime)
```

* SharkScrapper
    * set timeout until element will be clickable
```c#
      IWebElement GetElementClickableWait(WebDriverWait wait, IWebElement forElement)
```

* SharkScrapper
    * set timeout until element will be visible
```c#
      IWebElement GetElementWaitForVisibility(WebDriverWait wait, By selector)
```

* SharkScrapper
    * set timeout until element will be enable
```c#
      bool GetElementWaitForEnabled(WebDriverWait wait, IWebElement forElement)
```

* SharkScrapper
    * sending keys to e.g. Input that need some kind of value
```c#
      void WaitWithSendKeys(IWebDriver driver, TimeSpan forTime, By selector, string keys)
```

* SharkScrapper
    * Navigate browser to web page with passed URL
```c#
      void NavigateToWebPage(IWebDriver driver, string url)
```

* SharkScrapper
    * Refresh actual web page
```c#
      void RefreshPage(IWebDriver driver)
```

### if you want to make web scrapping without run selenium and it's drivers call class ``SharkRequest()``

* SharkRequest
    * sealed class defines static download of page and make request without call selenium.

* SharkRequest
    * Getter, Setter for passed url
```c#
      string Url{ get; set; }
```

* SharkRequest
    * Getter, Setter for passed html
```c#
      string Html{ get; set; }
```

* SharkRequest
    * Getter, Setter for passed htmlDocument
```c#
      HtmlDocument HtmlDocument{ get; set; }
```

* SharkRequest
    * Getter, Setter for passed scrapper
```c#
      SharkStaticScrapper Scrapper{ get; set; }
```

* SharkRequest
    * Constructor that create request with default parameters
```c#
      SharkRequest(string url, SharkStaticScrapper scrapper)
```

* SharkRequest
    * Initializer of request
```c#
      void InitRequest()
```

* SharkRequest
    * Get html from url. Make HTTP Request to page
```c#
      string GetHtml(string url)
```

* SharkRequest
    * Change html to HTMLDocument object
```c#
      HtmlDocument GetDocument(string html)
```

### To make action on scrapping web page without run selenium you need to create your own scrapper class and extends ``SharkStaticScrapper`` abstract class

* SharkStaticScrapper
    * Abstract class that can be inherit by web page scrapper, defines methods for scrapping web page. It allows to make actions with scrapping web page without selenium features, packed in methods of class.

* SharkStaticScrapper
    * Getter, Setter for passed url
```c#
      string Url{ get; set; }
```

* SharkStaticScrapper
    * Getter, Setter for passed html
```c#
      string Html{ get; set; }
```

* SharkStaticScrapper
    * Find elements by class name in html
```c#
      IEnumerable<HtmlNode> GetElementsByClassName(HtmlDocument htmlDocument, string className)
```

* SharkStaticScrapper
    * Find elements by tag name in html
```c#
      IEnumerable<HtmlNode> GetElementsByTagName(HtmlDocument htmlDocument, string tagName)
```

* SharkStaticScrapper
    * Find element by tag name in html
```c#
      HtmlNode GetElementByTagName(HtmlDocument htmlDocument, string tagName)
```

* SharkStaticScrapper
    * Get all elements from parent node
```c#
      IEnumerable<HtmlNode> GetElementsFromParent(HtmlNode htmlNode)
```

* SharkStaticScrapper
    * Finding elements by xPath
```c#
      IEnumerable<HtmlNode> GetElementsByXPath(HtmlDocument htmlDocument, string xPath)
```

* SharkStaticScrapper
    * Finding element by xPath
```c#
      HtmlNode GetElementByXPath(HtmlDocument htmlDocument, string xPath)
```

* SharkStaticScrapper
    * Find element with passed class name
```c#
      HtmlNode GetElementByClassName(HtmlDocument htmlDocument, string className)
```

* SharkStaticScrapper
    * Find element by id
```c#
      HtmlNode GetElementById(HtmlDocument htmlDocument, string id)
```

* SharkStaticScrapper
    * Finding Attribute of element
```c#
      HtmlAttribute GetElementAttributeFromNode(HtmlNode htmlNode, string attribute)
```

* SharkStaticScrapper
    * Finding value of attribute
```c#
      string GetElementAttributeValue(HtmlNode htmlNode, string attribute)
```

* SharkStaticScrapper
    * Return full page html
```c#
      string GetFullPage(HtmlDocument htmlDocument)
```

License
----------------------

Licensed under MIT.

For full License and included software licenses please see LICENSE.txt