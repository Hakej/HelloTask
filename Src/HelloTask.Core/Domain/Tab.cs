using System;
using System.Collections.Generic;

namespace HelloTask.Core.Domain
{
    public class Tab
    {
        public Guid Id { get; }
        public User Owner { get; }
        public string Name { get; }
        public ICollection<Assignment> Assignments { get; }

        public Board Board { get; }

        public Tab(Guid id, User owner, string name, Board board)
        {
            Id = id;
            Owner = owner;
            Name = name;
            Board = board;
        }
    }
}