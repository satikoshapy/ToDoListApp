using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Components
{
    public class ToDoItemCount : ViewComponent
    {

        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemCount(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = _toDoItemRepository.GetTotalOfItemsThatAreNotDone();

            var todoViewModel = new ToDoCountViewModel { Count = count };
            return View(todoViewModel);
        }
    }
}
