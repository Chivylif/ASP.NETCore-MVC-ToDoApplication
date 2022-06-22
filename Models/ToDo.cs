using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [DisplayName("Due Date")]
        public DateTime Date { get; set; }
    }
}
