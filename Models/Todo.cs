using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApik8.Models
{
    public class Todo
    {
        [Required]
        public string Id { get; set; }     
        [Required]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}