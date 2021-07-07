using System;

namespace HelloTask.Core.Models
{
    public class Assignment
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public Guid TabId { get; protected set; }

        protected Assignment()
        {
        }
        
        public Assignment(Guid id, string name, string description, Guid tabId)
        {
            Id = id;
            Name = name;
            Description = description;
            TabId = tabId;
        }
    }
}
