using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {

        private readonly IToDoListRepository _listRepository;
        private readonly IToDoItemRepository _itemRepository;

        public TodoListsController(IToDoListRepository listRepository, IToDoItemRepository itemRepository)
        {
            _listRepository = listRepository;
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public IActionResult CreateList([FromBody] AddNewToDoListModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ToDoList toDoList = _listRepository.AddNew(model.Title);

            return CreatedAtAction(nameof(toDoList), new { id = toDoList.Id }, toDoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetList(Guid id) 
        {
            var foundList = _listRepository.GetById(id);
            if (foundList == null) 
            { 
                return NotFound();
            }
            return Ok(foundList);
        }

        [HttpPut("{listId:guid}/items/{itemId:guid}")]
        public IActionResult UpdateItem(Guid listId, Guid itemId, [FromBody] UpdateToDoItemModel model)
        {
            var item = _itemRepository.Update(itemId, model.IsDone);
            model = new UpdateToDoItemModel();

            return Ok(item);
        }
    }
}
