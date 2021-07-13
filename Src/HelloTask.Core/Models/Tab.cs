using System;
using System.Collections.Generic;

namespace HelloTask.Core.Models
{
    public class Tab
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Assignment> Assignments { get; protected set; }

        public Guid BoardId { get; protected set; }

        protected Tab()
        {
                
        }

        public Tab(Guid id, string name, Guid boardId)
        {
            Id = id;
            Name = name;
            BoardId = boardId;
        }
    }
}
