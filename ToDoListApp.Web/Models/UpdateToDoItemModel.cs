using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Web.Models;

public class UpdateToDoItemModel
{
    [Required]
    public bool IsDone { get; set; }
}