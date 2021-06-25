using System.ComponentModel.DataAnnotations;

namespace HelloTask.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int TabId { get; set; }
        public Tab Tab { get; set; }
    }
}
