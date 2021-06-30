using System;
using System.Collections.Generic;

namespace HelloTask.Core.Models
{
    public class Board
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Tab> Tabs { get; protected set; }

        protected Board()
        {

        }

        public Board(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
