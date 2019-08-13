using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ProjectShark.Library.Interfaces{
    internal interface IScrapper{
        string Url{ get; set; }

        IJavaScriptExecutor CreateJavaScriptExecutor(IWebDriver driver);

        IWebElement GetElementByClassName(IWebDriver webDriver, string className);

        IWebElement GetElementByTagName(IWebDriver webDriver, string tagName);

        string GetFullPage(IWebDriver driver);

        IWebElement GetElementFromParentBySelector(IWebElement webDriver, By selector);

        ReadOnlyCollection<IWebElement> GetElementsByClassName(IWebDriver webDriver, string className);

        ReadOnlyCollection<IWebElement> GetElementsFromParentByClassName(IWebElement webElement, string className);

        ReadOnlyCollection<IWebElement> GetElementsFromParentBySelector(IWebElement webDriver, By selector);

        ReadOnlyCollection<IWebElement> GetElementsByTagName(IWebDriver webDriver, string tagName);

        IWebElement GetElementById(IWebDriver webDriver, string id);

        IWebElement GetElementByXPath(IWebDriver webDriver, string xPath);

        ReadOnlyCollection<IWebElement> GetElementsByXPath(IWebDriver webDriver, string xPath);

        bool ElementHasClass(IWebElement element, string active);

        IWebDriver ChangeDriverFocusToIFrame(IWebDriver driver, IWebElement element, By selector);

        Actions CreateActionsWithMovementToElementByOffset(IWebDriver driver, IWebElement element, int offsetX,
            int offsetY);

        Actions CreateActionsWithMovementByOffset(IWebDriver driver, int offsetX, int offsetY);

        Actions CreateActions(IWebDriver driver);

        Actions CreateActionsWithMovementToElement(IWebDriver driver, IWebElement element);

        IWebDriver BackToMainDriver(IWebDriver driver);

        bool CheckIfElementExists(IWebDriver driver, By selector);

        bool CheckIfElementHasChildren(IWebElement element, By selector);

        WebDriverWait GetDriverWait(IWebDriver webDriver, TimeSpan forTime);

        IWebElement GetElementClickableWait(WebDriverWait wait, IWebElement forElement);

        IWebElement GetElementWaitForVisibility(WebDriverWait wait, By selector);

        bool GetElementWaitForEnabled(WebDriverWait wait, IWebElement forElement);

        void WaitWithSendKeys(IWebDriver driver, TimeSpan forTime, By selector, string keys);

        void NavigateToWebPage(IWebDriver driver, string url);

        void RefreshPage(IWebDriver driver);
    }
}