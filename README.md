
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

Installation
----------------------

- To run ProjectShark 



Getting Started
----------------------

### To run package simply run one of SharkDriver class.

### ``SharkChromeDriver()``

* SharkChromeDriver
    * Chrome driver (chromeDriver) implementation of SharkDriver abstract class.
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

* InitWebDriver
    * Implementation of abstract method InitWebDriver from SharkDriver abstract class.
      Method return ChromeWebDriver specified by browser
```c#
    IWebDriver InitWebDriver(string driverPath)
``` 

### ``SharkFirefoxDriver()``

* SharkFirefoxDriver
    * Firefox driver (geckoDriver) implementation of SharkDriver abstract class.
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

* InitWebDriver
    * Implementation of abstract method InitWebDriver from SharkDriver abstract class.
      Method return FirefoxWebDriver specified by browser
```c#
    IWebDriver InitWebDriver(string driverPath)
``` 

### if you want to create own driver just inherit ``SharkDriver()`` abstract class

* SharkDriver
    * Abstract class that can be inherit by new driver, defines methods for browser
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

TO DO
----------------------

