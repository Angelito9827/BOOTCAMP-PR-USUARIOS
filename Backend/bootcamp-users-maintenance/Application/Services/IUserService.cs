using bootcamp_framework.Application;
using bootcamp_framework.Application.Services;
using bootcamp_users_maintenance.Application.Dtos;

namespace bootcamp_users_maintenance.Application.Services
{
    public interface IUserService : IGenericService<UserDto>
    {
        PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    }
}
