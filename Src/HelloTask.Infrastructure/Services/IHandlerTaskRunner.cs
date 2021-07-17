using System;
using System.Threading.Tasks;

namespace HelloTask.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask Run(Func<Task> run);
    }
}