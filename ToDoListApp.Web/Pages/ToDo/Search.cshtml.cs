using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Web.Pages.ToDo
{
    public class SearchModel : PageModel
    {
        private readonly IToDoListRepository _repo;

        public SearchModel(IToDoListRepository toDoListRepository)
        {
            _repo = toDoListRepository;
        }
        [BindProperty]
        public string? TitleFilter { get; set; }

        [BindProperty]
        public List<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();
        public IActionResult OnGet()
        {

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<ToDoList> result = (List<ToDoList>)_repo.Find(TitleFilter);

            if (result.Count > 0)
            {
                ToDoLists = result;
            }



            return Page();
        }
    }
}