using System.Collections.Generic;
using HelloTask.Core.Domain;

namespace HelloTask.Infrastructure.DTO
{
    public class BoardDetailsDto : BoardDto
    {
        public ICollection<Tab> Tabs { get; protected set; }
    }
}
