using bootcamp_framework.Application;
using bootcamp_framework.Domain.Persistence;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Domain.Entities;

namespace bootcamp_users_maintenance.Domain.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    }
}
