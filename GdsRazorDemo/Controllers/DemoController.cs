using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace GdsRazor.Controllers;

public class DemoController : Controller
{
    [HttpGet]
    public IActionResult Index(string demo)
    {
        var types = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(RazorPage).IsAssignableFrom(type) && type.Name?.StartsWith("Views_Demo") == true)
            .Select(type => type.Name.Replace("Views_Demo_", ""));

        ViewBag.types = types;

        if (!types.Contains(demo))
        {
            return NotFound();
        }

        return View(demo);
    }
}