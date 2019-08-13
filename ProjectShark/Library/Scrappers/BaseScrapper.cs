using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectShark.Library.Extensions;
using ProjectShark.Library.Interfaces;
using SeleniumExtras.WaitHelpers;

namespace ProjectShark.Library.Scrappers{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseScrapper : IScrapper{
        /// <summary>
        /// 
        /// </summary>
        public string Url{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="forTime"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="forElement"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IWebElement GetElementWaitForVisibility(WebDriverWait wait, By selector){
            try{
                var w = wait.Until(ExpectedConditions.ElementIsVisible(selector));
                return w;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot set element {selector} vilibility");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="forElement"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="forTime"></param>
        /// <param name="selector"></param>
        /// <param name="keys"></param>
        /// <exception cref="Exception"></exception>
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
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        /// <exception cref="Exception"></exception>
        public void NavigateToWebPage(IWebDriver driver, string url){
            try{
                Url = url;
                driver.NavigateToWebPage(url);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot start browser with URL {url}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <exception cref="Exception"></exception>
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