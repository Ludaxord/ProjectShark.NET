using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ProjectShark.Library.Interfaces{
    internal interface IDriver{
        DriverOptions GetOptions(List<string> options, string browser);
        void SetFullScreen(IWebDriver driver);

        void WindowSize(IWebDriver driver, int width = (int) Enumerations.WindowSize.Width,
            int height = (int) Enumerations.WindowSize.Height);

        void KillBrowserProcesses(string browser);

        void SetTimeoutsForItemsVisibility(IWebDriver driver, TimeSpan timeSpan);
    }
}