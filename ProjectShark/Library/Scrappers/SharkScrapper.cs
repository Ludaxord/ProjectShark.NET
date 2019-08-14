using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectShark.Library.Extensions;
using ProjectShark.Library.Interfaces;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ProjectShark.Library.Scrappers{
    /// <summary>
    /// Abstract class that can be inherit by web page scrapper, defines methods for scrapping web page. It allows to make actions with scrapping web page by using selenium features, packed in methods of class.
    /// </summary>
    public abstract class SharkScrapper : IScrapper{
        /// <summary>
        /// Getter setter to set actual web page
        /// TODO: listener of url change in automation process
        /// </summary>
        public string Url{ get; set; }

        /// <summary>
        /// Cast driver to JavaScriptExecutor Interface
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <returns>returns web driver casted as JavaScriptExecutor</returns>
        /// <exception cref="Exception">Problem with casting</exception>
        public IJavaScriptExecutor CreateJavaScriptExecutor(IWebDriver driver){
            try{
                return (IJavaScriptExecutor) driver;
            }

            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot cast IWebDriver to IJavaScriptExecutor");
            }
        }

        /// <summary>
        /// Find element in scrapped web page by class name. Note that if there is more than one element with passed className it will return only first one. To return collection of element check GetElementsByClassName method
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="className">passed class name of desired element</param>
        /// <returns>Web element if exists</returns>
        /// <exception cref="Exception">Problem with finding element with passed class name</exception>
        public IWebElement GetElementByClassName(IWebDriver webDriver, string className){
            try{
                var element = webDriver.FindElement(By.ClassName(className));
                return element;
            }

            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by className of {className}");
            }
        }

        /// <summary>
        /// Find element in scrapped web page by tag name
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="tagName">passed tag name of desired element</param>
        /// <returns>Web element if exists</returns>
        /// <exception cref="Exception">Problem with finding element with passed class name</exception>
        public IWebElement GetElementByTagName(IWebDriver webDriver, string tagName){
            try{
                IWebElement element = webDriver.FindElement(By.TagName(tagName));
                return element;
            }

            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by tagName of {tagName}");
            }
        }

        /// <summary>
        /// Return full page source code (html, css, javascript, etc.)
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <returns>page source as string</returns>
        /// <exception cref="Exception">Problem with returning source</exception>
        public string GetFullPage(IWebDriver driver){
            try{
                return driver.PageSource;
            }

            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot get page source");
            }
        }

        /// <summary>
        /// Find element inside parent web element
        /// </summary>
        /// <param name="webDriver">parent web element</param>
        /// <param name="selector">selector of child element it can be selenium based e.g. By.ClassName("className")</param>
        /// <returns>child web element if exists</returns>
        /// <exception cref="Exception">Problem with finding elements in parent element</exception>
        public IWebElement GetElementFromParentBySelector(IWebElement webDriver, By selector){
            try{
                IWebElement element = webDriver.FindElement(selector);
                return element;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by selector of {selector}");
            }
        }

        /// <summary>
        /// Find collection of elements in scrapped web page by class name.
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="className">passed class name of desired element</param>
        /// <returns>Collection of web elements if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by class name</exception>
        public ReadOnlyCollection<IWebElement> GetElementsByClassName(IWebDriver webDriver, string className){
            try{
                var elements = webDriver.FindElements(By.ClassName(className));
                return elements;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by className of {className}");
            }
        }

        /// <summary>
        /// Find collection of elements in parent web element by class name.
        /// </summary>
        /// <param name="webElement">passed web element</param>
        /// <param name="className">passed class name of desired element</param>
        /// <returns>Collection of web elements if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by class name</exception>
        public ReadOnlyCollection<IWebElement>
            GetElementsFromParentByClassName(IWebElement webElement, string className){
            try{
                var elements = webElement.FindElements(By.ClassName(className));
                return elements;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by className of {className}");
            }
        }

        /// <summary>
        /// Find collection of elements in parent web element by selenium selector.
        /// </summary>
        /// <param name="webDriver">passed web element</param>
        /// <param name="selector">selector of child element it can be selenium based e.g. By.ClassName("className")</param>
        /// <returns>Collection of web elements if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by selector</exception>
        public ReadOnlyCollection<IWebElement> GetElementsFromParentBySelector(IWebElement webDriver, By selector){
            try{
                var elements = webDriver.FindElements(selector);
                return elements;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by selector of {selector}");
            }
        }

        /// <summary>
        /// Find collection of elements on web page by tag name.
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="tagName">passed tag name of desired element</param>
        /// <returns>Collection of web elements if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by tag name</exception>
        public ReadOnlyCollection<IWebElement> GetElementsByTagName(IWebDriver webDriver, string tagName){
            try{
                var elements = webDriver.FindElements(By.TagName(tagName));
                return elements;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by tagName of {tagName}");
            }
        }

        /// <summary>
        /// Find element on web page by id.
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="id">passed id of desired element</param>
        /// <returns>Web element if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by id</exception>
        public IWebElement GetElementById(IWebDriver webDriver, string id){
            try{
                IWebElement element = webDriver.FindElement(By.Id(id));
                return element;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by id of {id}");
            }
        }

        /// <summary>
        /// Find element on web page by xPath.
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="xPath">passed xPath of desired element  e.g. //span[@class='className']</param>
        /// <returns>Web element if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by xPath</exception>
        public IWebElement GetElementByXPath(IWebDriver webDriver, string xPath){
            try{
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                return element;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by xPath of {xPath}");
            }
        }

        /// <summary>
        /// Find collection of elements on web page by xPath.
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="xPath">passed xPath of desired element</param>
        /// <returns>Collection of web elements if exists</returns>
        /// <exception cref="Exception">Problem with finding elements by xPath</exception>
        public ReadOnlyCollection<IWebElement> GetElementsByXPath(IWebDriver webDriver, string xPath){
            try{
                var elements = webDriver.FindElements(By.XPath(xPath));
                return elements;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by xPath of {xPath}");
            }
        }

        /// <summary>
        /// Check if element has desired class name
        /// </summary>
        /// <param name="element">element to check</param>
        /// <param name="active">passed class name</param>
        /// <returns>bool if class exists</returns>
        /// <exception cref="Exception">Problem with finding class</exception>
        public bool ElementHasClass(IWebElement element, string active){
            try{
                return element.GetAttribute("class").Contains(active);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements with class {active}");
            }
        }

        /// <summary>
        /// Change focus of main driver to iFrame
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="element">passed element that will be focus switched to</param>
        /// <param name="selector">selector of element with iframe that will be focus switched to</param>
        /// <returns>New web driver focused to iFrame</returns>
        /// <exception cref="Exception">problem with setting iFrame to specific element or finding element by selenium selector</exception>
        public IWebDriver ChangeDriverFocusToIFrame(IWebDriver driver, IWebElement element, By selector){
            IWebDriver iFrameDriver = null;

            if (selector != null){
                try{
                    iFrameDriver = driver.SwitchTo().Frame(driver.FindElement(selector));
                }
                catch (Exception e){
                    Console.WriteLine(e);
                    throw new Exception($"Cannot set focus to IFrame by selector {selector}");
                }
            }
            else if (element != null){
                try{
                    iFrameDriver = driver.SwitchTo().Frame(element);
                }
                catch (Exception e){
                    Console.WriteLine(e);
                    throw new Exception(
                        $"Cannot set focus to IFrame by element {element.GetAttribute("InnerHTML")}");
                }
            }

            return iFrameDriver;
        }

        /// <summary>
        /// Moving to element by specific offset
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="element">passed web element that will be moved to</param>
        /// <param name="offsetX">offset X</param>
        /// <param name="offsetY">offset Y</param>
        /// <returns>Action that can be made to element</returns>
        /// <exception cref="Exception">Problem with moving to element</exception>
        public Actions CreateActionsWithMovementToElementByOffset(IWebDriver driver, IWebElement element, int offsetX,
            int offsetY){
            try{
                return new Actions(driver).MoveToElement(element).MoveByOffset(offsetX, offsetY);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception(
                    $"Cannot move to element {element.GetAttribute("InnerHTML")} by offset {offsetX} x {offsetY}");
            }
        }

        /// <summary>
        /// Moving by specific offset
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="offsetX">offset X</param>
        /// <param name="offsetY">offset Y</param>
        /// <returns>Action that can be made to element</returns>
        /// <exception cref="Exception">Problem with moving by offset</exception>
        public Actions CreateActionsWithMovementByOffset(IWebDriver driver, int offsetX, int offsetY){
            try{
                return new Actions(driver).MoveByOffset(offsetX, offsetY);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot move by offset {offsetX} x {offsetY}");
            }
        }

        /// <summary>
        /// Create new action that can be made on web driver
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <returns>Action that can be made to web driver</returns>
        /// <exception cref="Exception">Problem with creating action</exception>
        public Actions CreateActions(IWebDriver driver){
            try{
                var action = new Actions(driver);
                return action;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot create action");
            }
        }

        /// <summary>
        /// Moving to element
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="element">passed web element that will be moved to</param>
        /// <returns>Action that can be made to element</returns>
        /// <exception cref="Exception">Problem with moving to element</exception>
        public Actions CreateActionsWithMovementToElement(IWebDriver driver, IWebElement element){
            try{
                return new Actions(driver).MoveToElement(element);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot move to element {element.GetAttribute("InnerHTML")}");
            }
        }

        /// <summary>
        /// Back to default driver if driver was set to iFrame
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <returns>default web driver</returns>
        /// <exception cref="Exception">problem with setting web driver</exception>
        public IWebDriver BackToMainDriver(IWebDriver driver){
            try{
                var mainDriver = driver.SwitchTo().DefaultContent();
                return mainDriver;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot back to main driver");
            }
        }

        /// <summary>
        /// Check if element exists on web page by selenium based selector
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="selector">selenium based selector e.g. By.ClassName("className")</param>
        /// <returns>bool that tells if element exists or not</returns>
        public bool CheckIfElementExists(IWebDriver driver, By selector){
            try{
                driver.FindElement(selector);
                return true;
            }
            catch (Exception){
                return false;
            }
        }

        /// <summary>
        /// Check if element exists has children elements by selenium based selector
        /// </summary>
        /// <param name="element">passed web element</param>
        /// <param name="selector">selenium based selector e.g. By.ClassName("className")</param>
        /// <returns>bool that tells if element exists has children elements</returns>
        public bool CheckIfElementHasChildren(IWebElement element, By selector){
            try{
                element.FindElement(selector);
                return true;
            }
            catch (Exception){
                return false;
            }
        }

        /// <summary>
        /// Create Web Driver wait object
        /// </summary>
        /// <param name="webDriver">passed web driver</param>
        /// <param name="forTime">timespan of web driver wait</param>
        /// <returns>Web Driver Wait object</returns>
        /// <exception cref="Exception">Problem with creating object</exception>
        public WebDriverWait GetDriverWait(IWebDriver webDriver, TimeSpan forTime){
            try{
                var wait = new WebDriverWait(webDriver, forTime);
                return wait;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set wait");
            }
        }

        /// <summary>
        /// set timeout until element will be clickable
        /// </summary>
        /// <param name="wait">passed Web Driver Wait object</param>
        /// <param name="forElement">passed element for timeout</param>
        /// <returns>Same element but clickable</returns>
        /// <exception cref="Exception">Problem with returning clickable element</exception>
        public IWebElement GetElementClickableWait(WebDriverWait wait, IWebElement forElement){
            try{
                return wait.Until(ExpectedConditions.ElementToBeClickable(forElement));
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set element {forElement.GetAttribute("InnerHTML")} clickable");
            }
        }

        /// <summary>
        /// set timeout until element will be visible
        /// </summary>
        /// <param name="wait">passed Web Driver Wait object</param>
        /// <param name="selector">passed selenium based selector for timeout</param>
        /// <returns>Same element but visible</returns>
        /// <exception cref="Exception">Problem with returning visible element</exception>
        public IWebElement GetElementWaitForVisibility(WebDriverWait wait, By selector){
            try{
                var w = wait.Until(ExpectedConditions.ElementIsVisible(selector));
                return w;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set element {selector} visibility");
            }
        }

        /// <summary>
        /// set timeout until element will be enable
        /// </summary>
        /// <param name="wait">passed Web Driver Wait object</param>
        /// <param name="forElement">passed element for timeout</param>
        /// <returns>Same element but enabled</returns>
        /// <exception cref="Exception">Problem with returning enabled element</exception>
        public bool GetElementWaitForEnabled(WebDriverWait wait, IWebElement forElement){
            try{
                return wait.Until(d => forElement.Enabled);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set element {forElement.GetAttribute("InnerHTML")} enabled");
            }
        }

        /// <summary>
        /// sending keys to e.g. Input that need some kind of value
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="forTime">time that need to web driver wait until it pass keys</param>
        /// <param name="selector">selector that will be sent keys to</param>
        /// <param name="keys">key that need to be sent to element</param>
        /// <exception cref="Exception">Problem with sending keys to element</exception>
        public void WaitWithSendKeys(IWebDriver driver, TimeSpan forTime, By selector, string keys){
            try{
                GetDriverWait(driver, forTime)
                    .Until(ExpectedConditions.ElementToBeClickable(selector))
                    .SendKeys(keys);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot send keys {keys} to selector of {selector}");
            }
        }

        /// <summary>
        /// Navigate browser to web page with passed URL
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <param name="url">url of desired web page that need to be run</param>
        /// <exception cref="Exception">Problem with starting browser</exception>
        public void NavigateToWebPage(IWebDriver driver, string url){
            try{
                url = url.UrlGenerator();
                Url = url;
                driver.NavigateToWebPage(url);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot start browser with URL {url}");
            }
        }

        /// <summary>
        /// Refresh actual web page
        /// </summary>
        /// <param name="driver">passed web driver</param>
        /// <exception cref="Exception">Problem with refreshing web page</exception>
        public void RefreshPage(IWebDriver driver){
            try{
                Url = driver.Url;
                driver.Navigate().GoToUrl(driver.Url);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot refresh page of url {driver.Url}");
            }
        }
    }
}