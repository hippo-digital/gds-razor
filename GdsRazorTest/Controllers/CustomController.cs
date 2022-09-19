using Microsoft.AspNetCore.Mvc;

namespace GdsRazorTest.Controllers;

public class CustomController : Controller
{
    private readonly IModelProvider _modelProvider;

    public CustomController(IModelProvider modelProvider)
    {
        _modelProvider = modelProvider;
    }

    public IActionResult Index()
    {
        var (viewName, model) = _modelProvider.GetModel();
        return PartialView(viewName, model);
    }
}
