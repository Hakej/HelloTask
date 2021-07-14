using System;
using System.Collections.Generic;

namespace HelloTask.Core.Models
{
    public class Tab
    {
        public Guid Id { get; }
        public User Owner { get; }
        public string Name { get; }
        public ICollection<Assignment> Assignments { get; }

        public Guid BoardId { get; }

        public Tab(Guid id, string name, Guid boardId)
        {
            Id = id;
            Name = name;
            BoardId = boardId;
        }
    }
}
