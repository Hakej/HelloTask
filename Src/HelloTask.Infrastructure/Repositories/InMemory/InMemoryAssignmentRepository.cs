using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Domain;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.Exceptions;

namespace HelloTask.Infrastructure.Repositories.InMemory
{
    public class InMemoryAssignmentRepository : IAssignmentRepository
    {
        private static readonly ISet<Assignment> Assignments = new HashSet<Assignment>();

        public async Task<Assignment> GetAsync(Guid id)
            => await Task.FromResult(Assignments.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Assignment>> GetAllAsync()
            => await Task.FromResult(Assignments);

        public async Task AddAsync(Assignment assignment)
        {
            Assignments.Add(assignment);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var assignment = await GetAsync(id);

            if (assignment == null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.AssignmentNotFound, "Assignment to delete not found.");
            }

            Assignments.Remove(assignment);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
