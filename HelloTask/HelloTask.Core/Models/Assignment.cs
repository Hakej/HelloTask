using System;

namespace HelloTask.Core.Models
{
    public class Assignment
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected Assignment()
        {
        }

        public Assignment(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}
