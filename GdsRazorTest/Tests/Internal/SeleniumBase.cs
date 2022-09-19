using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GdsRazorTest.Tests.Internal;

public class SeleniumBase : IDisposable
{
    public readonly IWebDriver Driver;

    public SeleniumBase()
    {
        var options = new ChromeOptions();
        options.AddArgument("headless");
        Driver = new ChromeDriver(options);
    }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}