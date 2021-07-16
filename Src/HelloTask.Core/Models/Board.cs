using System;
using System.Collections.Generic;

namespace HelloTask.Core.Models
{
    public class Board
    {
        public Guid Id { get; }
        public User Owner { get; }
        public string Name { get; }

        public ICollection<Tab> Tabs { get; }

        public Board(Guid id, User owner, string name)
        {
            Id = id;
            Owner = owner;
            Name = name;
        }
    }
}