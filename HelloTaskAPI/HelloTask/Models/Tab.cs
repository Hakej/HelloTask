using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloTask.Models
{
    public class Tab
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
