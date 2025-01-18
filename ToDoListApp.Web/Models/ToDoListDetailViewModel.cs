using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ToDoListApp.Domain;

namespace ToDoListApp.Web.Models
{
    public class ToDoListDetailViewModel
    {
        public ToDoList? List { get; }

        [BindProperty]
        public Guid ListId { get; set; }

        [Required(ErrorMessage ="The new item field is required")]
        [MinLength(4, ErrorMessage = "The field new item description must be a string with á minimum length '4' characters")]
        public string NewItemDescription { get; set; }

        public ToDoListDetailViewModel()
        {
            NewItemDescription = string.Empty;
        }

        public ToDoListDetailViewModel(ToDoList? list)
        {
            List = list;
            ListId = list?.Id ?? Guid.Empty;
            NewItemDescription = string.Empty;
        }
    }
}
