using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    internal class ToDoItemRepositoryImpl : IToDoItemRepository
    {
        private readonly ToDoListContext _context;

        public ToDoItemRepositoryImpl(ToDoListContext context)
        {
            _context = context;
        }

        public int GetTotalOfItemsThatAreNotDone()
        {
            List<ToDoItem> items = _context.ToDoLists.SelectMany(list => list.Items).ToList();
            return items.Where(item => !item.IsDone).Count();
        }

        public ToDoItem Update(Guid id, bool isDone)
        {
            
            var item = _context.ToDoLists.SelectMany(list => list.Items).FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                
                item.IsDone = isDone;

                
                _context.SaveChanges();
            }

            return item;
        }
    }
}
