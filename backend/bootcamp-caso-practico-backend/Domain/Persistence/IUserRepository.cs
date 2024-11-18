using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Domain.Entities;
using bootcamp_framework.Application;
using bootcamp_framework.Domain.Persistence;

namespace bootcamp_caso_practico_backend.Domain.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    }
}
