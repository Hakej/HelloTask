using System;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
