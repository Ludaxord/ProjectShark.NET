using System.Collections.Generic;
using OpenQA.Selenium;

namespace ProjectShark.Library.Interfaces{
    public interface IDriver{
        DriverOptions GetOptions(List<string> options, string browser);
    }
}