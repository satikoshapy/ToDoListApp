using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Web.Models;

public class AddNewToDoListModel
{
    [Required]
    [MinLength(4, ErrorMessage ="Title must be at least 4 letters long")]
    public string Title { get; set; } = null!;
}