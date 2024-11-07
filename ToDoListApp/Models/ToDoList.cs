using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoList
    {
        public int Id {  get; set; }

        [Required]
        public string Task { get; set; }

        public bool Completed { get; set; }
    }
}
