using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Web.Pages.ToDo;

public class SearchModel : PageModel
{
    private readonly IToDoListRepository _repository;

    [BindProperty(SupportsGet = true)]
    public string? TitleFilter { get; set; }

    public List<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();

    public SearchModel(IToDoListRepository repository)
    {
        _repository = repository;
    }

    public void OnGet()
    {
        // No search is performed on GET
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        // Perform search
        ToDoLists = _repository.Find(TitleFilter).ToList();
    }
}
