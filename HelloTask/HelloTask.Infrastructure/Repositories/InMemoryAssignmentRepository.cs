using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;

namespace HelloTask.Infrastructure.Repositories
{
    public class InMemoryAssignmentRepository : IAssignmentRepository
    {
        private static ISet<Assignment> _assignments = new HashSet<Assignment>()
        {
            new Assignment("First assignment", "Very easy one"),
            new Assignment("Second assignment", "Difficulty is medium here"),
            new Assignment("Third assignment", "This is the most challenging one yet")
        };

        public Assignment Get(Guid id)
            => _assignments.Single(x => x.Id == id);

        public IEnumerable<Assignment> GetAll()
            => _assignments;

        public void Add(Assignment assignment)
        {
            _assignments.Add(assignment);
        }

        public void Remove(Guid id)
        {
            var assignment = Get(id);

            if (assignment == null)
            {
                throw new Exception("Assignment to delete not found.");
            }

            _assignments.Remove(assignment);
        }

        public void Update(Assignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}
