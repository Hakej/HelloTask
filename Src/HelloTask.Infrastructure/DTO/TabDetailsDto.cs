using System.Collections.Generic;
using HelloTask.Core.Domain;

namespace HelloTask.Infrastructure.DTO
{
    public class TabDetailsDto : TabDto
    {
        public ICollection<Assignment> Assignments { get; protected set; }
    }
}
