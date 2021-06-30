using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloTask.Core.Models;

namespace HelloTask.Core.Repositories
{
    public interface IAssignmentRepository
    {
        Assignment Get(Guid id);
        IEnumerable<Assignment> GetAll();
        void Add(Assignment assignment);
        void Remove(Guid id);
        void Update(Assignment assignment);
    }
}
