using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;

public class BaseController : Controller
{
    private readonly IToDoItemRepository _repository;

    public BaseController(IToDoItemRepository repository)
    {
        _repository = repository;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        // Fetch the data to display in the layout
        int pendingCount = _repository.GetTotalOfItemsThatAreNotDone();

        // Pass the data to ViewData (or ViewBag)
        ViewData["PendingCount"] = pendingCount;
    }
}
