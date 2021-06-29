using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloTask.Models
{
    public class Tab
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
