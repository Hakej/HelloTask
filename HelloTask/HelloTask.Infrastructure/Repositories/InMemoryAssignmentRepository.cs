﻿using System;
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

        public async Task<Assignment> GetAsync(Guid id)
            => await Task.FromResult(_assignments.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Assignment>> GetAllAsync()
            => await Task.FromResult(_assignments);

        public async Task AddAsync(Assignment assignment)
        {
            _assignments.Add(assignment);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var assignment = await GetAsync(id);

            if (assignment == null)
            {
                throw new Exception("Assignment to delete not found.");
            }

            _assignments.Remove(assignment);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            throw new NotImplementedException();

            await Task.CompletedTask;
        }
    }
}