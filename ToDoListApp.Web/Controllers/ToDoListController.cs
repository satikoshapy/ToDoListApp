using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;
using ToDoListApp.Web;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Controllers
{
    public class ToDoListController : Controller
    {

        private readonly IToDoListRepository _repository;

        public ToDoListController(IToDoListRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Detail(Guid id)
        {
            var result = _repository.GetById(id);

            if (result == null)
            {

            }

            var viewModel = new ToDoListDetailViewModel(result);

            return View(viewModel);
        }

        [HttpPost]
        public void Create(ToDoListDetailViewModel model)
        {
            
            _repository.AddItemToExistingList(model.ListId, model.NewItemDescription);
            
        }
    }
}
