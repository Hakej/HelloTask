using System.Collections.Generic;
using HelloTask.Core.Models;

namespace HelloTask.Infrastructure.DTO
{
    public class TabDetailsDto : TabDto
    {
        public ICollection<Assignment> Assignments { get; protected set; }
    }
}
