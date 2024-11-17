using AutoMapper;
using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Application.Services;
using bootcamp_caso_practico_backend.Domain.Entities;
using bootcamp_caso_practico_backend.Domain.Persistence;
using bootcamp_framework.Application;
using bootcamp_framework.Application.Services;

namespace bootcamp_users_maintenance.Application.Services
{
    public class UserServices : GenericService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var users = _userRepository.GetUsersByCriteriaPaged(filter, paginationParameters);
            return users;
        }
    }
}
