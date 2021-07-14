using System;

namespace HelloTask.Core.Models
{
    public class Assignment
    {
        public Guid Id { get; }
        public User Owner { get; }
        public string Name { get; }
        public string Description { get; }

        public Guid TabId { get; }

        public Assignment(Guid id, User owner, string name, string description, Guid tabId)
        {
            Id = id;
            Owner = owner;
            Name = name;
            Description = description;
            TabId = tabId;
        }
    }
}
