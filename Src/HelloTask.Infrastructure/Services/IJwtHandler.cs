using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}
