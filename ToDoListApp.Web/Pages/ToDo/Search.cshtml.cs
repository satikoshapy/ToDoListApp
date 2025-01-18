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
        public void OnGet()
        {

            //return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("OnPost invoked");
            if (!ModelState.IsValid)
            {
                // Log the errors for debugging
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"{error.Key}: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }

                return Page();
            }

            ToDoLists = string.IsNullOrWhiteSpace(TitleFilter)
                ? _repo.GetAll().ToList()
                : _repo.Find(TitleFilter).ToList();

            return Page();
        }

    }
}