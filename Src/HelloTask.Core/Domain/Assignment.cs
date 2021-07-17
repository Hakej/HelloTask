using System;

namespace HelloTask.Core.Domain
{
    public class Assignment
    {
        public Guid Id { get; }
        public User Owner { get; }
        public string Name { get; }
        public string Description { get; }

        public Tab Tab { get; }

        public Assignment(Guid id, User owner, string name, string description, Tab tab)
        {
            Id = id;
            Owner = owner;
            Name = name;
            Description = description;
            Tab = tab;
        }
    }
}
