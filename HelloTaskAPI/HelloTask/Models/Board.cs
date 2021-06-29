using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelloTask.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Tab> Tabs { get; set; }
    }
}
