using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_framework.Application;
using bootcamp_framework.Application.Services;

namespace bootcamp_caso_practico_backend.Application.Services
{
    public interface IUserService : IGenericService<UserDto>
    {
        PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    }
}
