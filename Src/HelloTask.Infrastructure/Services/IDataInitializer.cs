using System.Threading.Tasks;

namespace HelloTask.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
