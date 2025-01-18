using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    internal class ToDoListRepositoryImpl : IToDoListRepository
    {

        private readonly ToDoListContext _context;

        public ToDoListRepositoryImpl(ToDoListContext context)
        {
            _context = context;
        }
        public void AddItemToExistingList(Guid listId, string itemDescription)
        {
            var list = _context.ToDoLists
                .Include(t => t.Items) // Ensure navigation property is loaded
                .FirstOrDefault(list => list.Id == listId);
            if (list != null)
            {
                var item = ToDoItem.CreateNew(itemDescription);
                _context.Attach(item);
                list.Items.Add(item);
                _context.ToDoLists.Update(list);
                _context.ChangeTracker.DetectChanges();
                _context.SaveChanges();
            }
            
        }

        public ToDoList AddNew(string title)
        {
            var todoList = ToDoList.CreateNew(title);
            _context.ToDoLists.Add(todoList);
            _context.SaveChanges();
            return todoList;
        }

        public IList<ToDoList> Find(string? titleFilter)
        {
            if (string.IsNullOrWhiteSpace(titleFilter))
            {
                return _context.ToDoLists.Include(t => t.Items).ToList();
            }

            return _context.ToDoLists
                .Where(list => list.Title.Contains(titleFilter))
                .Include(t => t.Items)
                .ToList();
        }

        public ToDoList? GetById(Guid id)
        {
            return _context.ToDoLists.Include(t => t.Items).FirstOrDefault(list => list.Id == id);
        }

        public List<ToDoList> GetAll()
        {
            return _context.ToDoLists.Include(t => t.Items).ToList();
        }

        public IEnumerable<ToDoList> SearchLists(string search)
        {
            return _context.ToDoLists.Where(list => list.Title.Contains(search));
        }
    }
}
