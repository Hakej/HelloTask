using System;

namespace HelloTask.Infrastructure.DTO
{
    public class AssignmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TabId { get; set; }
    }
}
