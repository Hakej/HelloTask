using System;
using System.Collections.Generic;

namespace HelloTask.Core.Models
{
    public class Tab
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        public Tab()
        {
                
        }

        public Tab(Guid id, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
