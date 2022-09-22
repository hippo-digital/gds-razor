using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Hippo.GdsRazor.Test.Components.Internal;

public class SeleniumBase : IDisposable
{
    public readonly IWebDriver Driver;

    public SeleniumBase()
    {
        var options = new ChromeOptions();
        options.AddArguments("--headless", "--ignore-certificate-errors", "--disable-gpu");
        Driver = new ChromeDriver(options);
    }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}