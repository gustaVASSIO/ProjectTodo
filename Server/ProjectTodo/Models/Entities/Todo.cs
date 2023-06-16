using ProjectTodo.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectTodo.Models.Entities
{
    public class Todo
    {
        [Key]
        public string TodoId { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "The name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The date to conclusion is required")]
        public DateTime? DateConclusion { get; set; }

        public TodoState? State { get; set; } = 0;
       
        public Todo()
        {
            TodoId = Guid.NewGuid().ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Todo todo &&
                   Name == todo.Name &&
                   DateConclusion == todo.DateConclusion;
        }

    }
}
